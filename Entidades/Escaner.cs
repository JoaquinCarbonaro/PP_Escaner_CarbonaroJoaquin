using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public class Escaner
    {
        //CAMPOS (ATRIBUTOS)
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;


        //PROPIEDADES
        public List<Documento> ListaDocumentos { get { return listaDocumentos; } }
        public Departamento Locacion { get { return locacion; } }
        public string Marca { get { return marca; } }
        public TipoDoc Tipo { get { return tipo; } }


        //CONSTRUCTOR

        /// <summary>
        /// Inicializa una nueva instancia de la clase Escaner.
        /// </summary>
        /// <param name="marca">Marca del escáner.</param>
        /// <param name="tipo">Tipo de documentos que escanea.</param>
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();

            switch (tipo)
            {
                case TipoDoc.mapa:
                    this.locacion = Departamento.mapoteca;
                    break;
                case TipoDoc.libro:
                    this.locacion = Departamento.procesosTecnicos;
                    break;
                default:
                    this.locacion = Departamento.nulo;
                    break;
            }
        }

        //SOBRECARGAS

        /// <summary>
        /// Sobrecarga del operador != para comparar un escáner y un documento.
        /// </summary>
        /// <param name="e">El escáner a comparar.</param>
        /// <param name="d">El documento a comparar.</param>
        /// <returns>True si el documento no está en la lista del escáner, false en caso contrario.</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar un documento al escáner.
        /// </summary>
        /// <param name="e">El escáner al que se agregará el documento.</param>
        /// <param name="d">El documento a agregar.</param>
        /// <returns>True si el documento se agregó exitosamente, false en caso contrario.</returns>
        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;

            if ((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa))
            {
                if (e != d && d.Estado == Documento.Paso.Inicio)
                {
                    d.AvanzarEstado();
                    e.ListaDocumentos.Add(d);
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador == para comparar un escáner y un documento.
        /// </summary>
        /// <param name="e">El escáner a comparar.</param>
        /// <param name="d">El documento a comparar.</param>
        /// <returns>True si el documento está en la lista del escáner, false en caso contrario.</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;

            if ((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa))
            {
                foreach (Documento doc in e.listaDocumentos) //recorro objetos de la lista
                {
                    if(d is Libro && doc is Libro && ((Libro)d == (Libro)doc)) // documento (pasado) es de tipo libro y libro (pasado) es igual libro (exitente)
                    {
                        retorno = true;
                    }
                    else if (d is Mapa && doc is Mapa && ((Mapa)d == (Mapa)doc))
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }


        //METODOS

        /// <summary>
        /// Cambia el estado de un documento si se encuentra en la lista de documentos.
        /// </summary>
        /// <param name="d">Documento cuyo estado se desea cambiar.</param>
        /// <returns>True si el estado se pudo cambiar, false si no se pudo cambiar o si el documento no está en la lista.</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {
            bool retorno = false;

            if ((this.tipo == TipoDoc.libro && d is Libro) || (this.tipo == TipoDoc.mapa && d is Mapa)) // comparo escaner con documento pasado
            {
                foreach (Documento doc in this.listaDocumentos) //recorro lista de documento (dentro del escaner)
                {
                    if (this.locacion == Departamento.procesosTecnicos) //libro
                    {
                        if ((Libro)d == (Libro)doc) //parseo
                        {
                            retorno = doc.AvanzarEstado(); //cambio doc dentro del escaner
                            break;
                        }
                    }
                    else if (this.locacion == Departamento.mapoteca) //mapa
                    {
                        if ((Mapa)d == (Mapa)doc) //parseo
                        {
                            retorno = doc.AvanzarEstado(); //cambio doc dentro del escaner
                            break;
                        }
                    }
                }
            }
            return retorno;
        }


        //TIPOS ANIDADOS (ENUM)
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro,
            mapa
        }


    }

}
