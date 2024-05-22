using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidades
{
    public static class Informes
    {
        //METODOS

        /// <summary>
        /// Muestra los documentos que están en estado 'Distribuido' del escáner.
        /// </summary>
        /// <param name="e">El escáner del cual se obtendrán los documentos.</param>
        /// <param name="extension">Extensión total de los documentos distribuidos.</param>
        /// <param name="cantidad">Cantidad de documentos distribuidos.</param>
        /// <param name="resumen">Resumen de los documentos distribuidos.</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos del escáner que están en el estado especificado.
        /// </summary>
        /// <param name="e">El escáner del cual se obtendrán los documentos.</param>
        /// <param name="estado">El estado de los documentos a filtrar.</param>
        /// <param name="extension">Extensión total de los documentos en el estado especificado.</param>
        /// <param name="cantidad">Cantidad de documentos en el estado especificado.</param>
        /// <param name="resumen">Resumen de los documentos en el estado especificado.</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen)
        {
            // Inicializamos las variables de salida
            extension = 0;
            cantidad = 0;
            resumen = "";

            // Recorremos todos los documentos en la lista del escáner
            foreach (Documento d in e.ListaDocumentos)
            {
                // Si el documento está en el estado especificado
                if (d.Estado == estado)
                {
                    // Si el tipo de documento del escáner es un libro, sumamos el número de páginas a la extensión total
                    if (e.Tipo == Escaner.TipoDoc.libro)
                    {
                        Libro libro = (Libro)d;
                        extension += libro.NumPaginas;
                    }
                    // Si el tipo de documento del escáner es un mapa, sumamos la superficie a la extensión total
                    else if (e.Tipo == Escaner.TipoDoc.mapa)
                    {
                        Mapa mapa = (Mapa)d;
                        extension += mapa.Superficie;
                    }

                    // Agregamos el documento al resumen
                    resumen += d.ToString();

                    // Incrementamos la cantidad de documentos que cumplen con el estado especificado
                    cantidad++;
                }
            }
        }


        /// <summary>
        /// Muestra los documentos que están en estado 'En Escaner' del escáner.
        /// </summary>
        /// <param name="e">El escáner del cual se obtendrán los documentos.</param>
        /// <param name="extension">Extensión total de los documentos en escáner.</param>
        /// <param name="cantidad">Cantidad de documentos en escáner.</param>
        /// <param name="resumen">Resumen de los documentos en escáner.</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos que están en estado 'En Revision' del escáner.
        /// </summary>
        /// <param name="e">El escáner del cual se obtendrán los documentos.</param>
        /// <param name="extension">Extensión total de los documentos en revisión.</param>
        /// <param name="cantidad">Cantidad de documentos en revisión.</param>
        /// <param name="resumen">Resumen de los documentos en revisión.</param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos que están en estado 'Terminado' del escáner.
        /// </summary>
        /// <param name="e">El escáner del cual se obtendrán los documentos.</param>
        /// <param name="extension">Extensión total de los documentos terminados.</param>
        /// <param name="cantidad">Cantidad de documentos terminados.</param>
        /// <param name="resumen">Resumen de los documentos terminados.</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }


    }
}
