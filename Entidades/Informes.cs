using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public static class Informes
    {
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        private static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen)
        {
            // Filtra los documentos del escáner que tienen el estado especificado
            var documentos = e.ListaDocumentos.Where(d => d.Estado == estado).ToList();
            // Calcula la extensión total sumando el número de páginas de los libros y la superficie de los mapas
            extension = documentos.OfType<Libro>().Sum(l => l.NumPaginas) + documentos.OfType<Mapa>().Sum(m => m.Superficie);
            // Calcula la cantidad de documentos filtrados
            cantidad = documentos.Count;
            // Construye un resumen de los documentos filtrados
            var sb = new StringBuilder();
            foreach (var doc in documentos)
            {
                sb.AppendLine(doc.ToString());
            }
            resumen = sb.ToString();
        }

        /*
        private static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            StringBuilder sb = new StringBuilder();

            foreach (var doc in e.ListaDocumentos.Where(d => d.Estado == estado))
            {
                cantidad++;
                sb.AppendLine(doc.ToString());

                if (doc is Libro libro)
                {
                    extension += libro.NumPaginas;
                }
                else if (doc is Mapa mapa)
                {
                    extension += mapa.Superficie;
                }
            }
            resumen = sb.ToString();
        }
        */

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }

    }
}
