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
        /// Crea una instancia de la clase Escaner con los datos proporcionados.
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
        /// Sobrecarga del operador != compara un escáner y un documento.
        /// </summary>
        /// <param name="e">El escáner a comparar.</param>
        /// <param name="d">El documento a comparar.</param>
        /// <returns>True si el documento no está en la lista del escáner, false en caso contrario.</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar un documento a la lista del escáner.
        /// </summary>
        /// <param name="e">El escáner al que se agregará el documento.</param>
        /// <param name="d">El documento a agregar.</param>
        /// <returns>True si el documento se agregó exitosamente, false en caso contrario.</returns>
        public static bool operator +(Escaner e, Documento d)
        {
            bool respuesta = false;

            // Verificar si el tipo del escáner y el tipo del documento son compatibles
            if ((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa))
            {
                // Verificar que el documento no esté ya en el escáner y que esté en el estado inicial
                if (e != d && d.Estado == Documento.Paso.Inicio)
                {
                    d.AvanzarEstado();
                    e.ListaDocumentos.Add(d);
                    respuesta = true;
                }
            }

            return respuesta;
        }

        /// <summary>
        /// Sobrecarga del operador == compara un escáner y un documento.
        /// </summary>
        /// <param name="e">El escáner a comparar.</param>
        /// <param name="d">El documento a comparar.</param>
        /// <returns>True si el documento está en la lista del escáner, false en caso contrario.</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            bool respuesta = false;

            // Verificar si el tipo del escáner y el tipo del documento son compatibles
            if ((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa))
            {
                // Recorrer la lista (de objetos) de documentos del escáner
                foreach (Documento doc in e.listaDocumentos) 
                {
                    // Si el documento(parametro) y el documento(lista) son de la misma clase y (casteando) los documentos entre si coinciden (segun sobrecarga ==)
                    if ((d is Libro && doc is Libro && ((Libro)d == (Libro)doc)) || (d is Mapa && doc is Mapa && ((Mapa)d == (Mapa)doc)))
                    {
                        respuesta = true;
                        break;
                    }
                }
            }
            return respuesta;
        }


        //METODOS

        /// <summary>
        /// Cambia el estado de un documento dentro de la lista de documentos.
        /// </summary>
        /// <param name="d">Documento cuyo estado se desea cambiar.</param>
        /// <returns>True si el estado se pudo cambiar, false si no se pudo cambiar o si el documento no está en la lista.</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {
            bool respuesta = false;

            // Verificar si el tipo del escáner(actual) y el tipo del documento(parametro) son compatibles
            if ((this.tipo == TipoDoc.libro && d is Libro) || (this.tipo == TipoDoc.mapa && d is Mapa))
            {
                // Recorrer la lista de documentos del escáner(actual)
                foreach (Documento doc in this.listaDocumentos)
                {
                    // Si la ubicación del escáner es "procesosTecnicos", se trata de un libro y (casteando) Compara (segun sobrecarga ==) el documento (parámetro) con el documento (actual)
                    if ((this.locacion == Departamento.procesosTecnicos) && ((Libro)d == (Libro)doc))
                    {
                        // Cambiar el estado del documento (dentro del escáner)
                            respuesta = doc.AvanzarEstado();
                            break;
                    }
                    // Si la ubicación del escáner es "mapoteca", se trata de un mapa y Comparar el documento pasado como parámetro con el documento actual
                    else if ((this.locacion == Departamento.mapoteca) && ((Mapa)d == (Mapa)doc))
                    {
                            respuesta = doc.AvanzarEstado();
                            break;
                    }
                }
            }
            return respuesta;
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
