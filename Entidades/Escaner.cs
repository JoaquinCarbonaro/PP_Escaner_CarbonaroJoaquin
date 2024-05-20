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

        //METODOS

        //CONSTRUCTOR
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            listaDocumentos = new List<Documento>();
            locacion = tipo == TipoDoc.libro ? Departamento.procesosTecnicos : Departamento.mapoteca;
        }

        public static bool operator !=(Escaner e, Documento d)
        {
        return !(e == d);
        }

        public static bool operator +(Escaner e, Documento d)
        {
            if (e.ListaDocumentos.Contains(d) || d.Estado != Paso.Inicio)
                return false;

            d.AvanzarEstado();
            e.ListaDocumentos.Add(d);
            return true;
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            return e.listaDocumentos.Contains(d);
        }

        //public static bool operator ==(Escaner e, Documento d)
        //{
        //    bool isEqual = false;

        //    // Verifica si el documento es del tipo adecuado para el escáner
        //    if ((e.Tipo == TipoDoc.Libro && d is Libro) || (e.Tipo == TipoDoc.Mapa && d is Mapa))
        //    {
        //        isEqual = e.ListaDocumentos.Contains(d);
        //    }

        //    return isEqual;
        //}

        public bool CambiarEstadoDocumento(Documento d)
        {
            if (listaDocumentos.Contains(d))
            {
                return d.AvanzarEstado();
            }
            return false;
        }

        /*
        public bool CambiarEstadoDocumento(Documento d)
        {
            bool cambioExitoso = false; // inicializa la variable que almacenará el resultado
            foreach (var doc in ListaDocumentos)
            {
                if (doc == d)
                {
                    cambioExitoso = doc.AvanzarEstado(); // intenta avanzar el estado y guarda el resultado
                    break; // sale del bucle una vez que encuentra el documento
                }
            }
            return cambioExitoso; // devuelve el resultado final
        }
        */

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
