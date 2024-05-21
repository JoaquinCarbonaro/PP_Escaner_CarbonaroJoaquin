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
            // Filtra los documentos del escáner("e"), recorriendo c/documento ("d") que tienen el estado especificado("estado")
            // convierte el resultado en una lista de documentos
            var documentos = e.ListaDocumentos.Where(d => d.Estado == estado).ToList();

            // Calcula la cantidad de documentos (en el estado especifico)
            cantidad = documentos.Count;

            // Inicializa la extensión en 0
            extension = 0;

            // construye StringBuilder para el resumen
            var sb = new StringBuilder();

            //Itera sobre cada documento filtrado.
            foreach (var doc in documentos)
            {
                // Agrega la representación textual del documento al resumen
                sb.AppendLine(doc.ToString());

                // Si el documento es un libro (compara creando instancia del objeto libro), suma el número de páginas
                if (doc is Libro libro)
                {
                    extension += libro.NumPaginas;
                }
                // Si el documento es un mapa, suma la superficie
                else if (doc is Mapa mapa)
                {
                    extension += mapa.Superficie;
                }
            }
            resumen = sb.ToString();
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
