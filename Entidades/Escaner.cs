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
        public enum Departamento
        {
            Nulo,
            Mapoteca,
            ProcesosTecnicos
        }

        public enum TipoDoc
        {
            Libro,
            Mapa
        }

        public List<Documento> ListaDocumentos { get; }
        public Departamento Locacion { get; }
        public string Marca { get; }
        public TipoDoc Tipo { get; }

        public Escaner(string marca, TipoDoc tipo)
        {
            Marca = marca;
            Tipo = tipo;
            ListaDocumentos = new List<Documento>();
            Locacion = tipo == TipoDoc.Libro ? Departamento.ProcesosTecnicos : Departamento.Mapoteca;
        }

        public static bool operator !=(Escaner e, Documento d) => !(e == d);

        public static bool operator +(Escaner e, Documento d)
        {
            if (e.ListaDocumentos.Contains(d) || d.Estado != Paso.Inicio)
                return false;

            d.AvanzarEstado();
            e.ListaDocumentos.Add(d);
            return true;
        }

        //public bool AvanzarEstado()
        //{
        //    bool retorno = true;
        //    if (Estado == Paso.Terminado)
        //    {
        //        retorno = false;
        //    }
        //    else
        //    {
        //        estado++;
        //    }
        //    return retorno;
        //}

        //public static bool operator ==(Escaner e, Documento d)
        //{
        //    return e.ListaDocumentos.Contains(d);
        //}

        public static bool operator ==(Escaner e, Documento d)
        {
            bool isEqual = false;

            // Verifica si el documento es del tipo adecuado para el escáner
            if ((e.Tipo == TipoDoc.Libro && d is Libro) || (e.Tipo == TipoDoc.Mapa && d is Mapa))
            {
                isEqual = e.ListaDocumentos.Contains(d);
            }

            return isEqual;
        }

        public bool CambiarEstadoDocumento(Documento d)
        {
            if (ListaDocumentos.Contains(d))
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

    }
        
}
