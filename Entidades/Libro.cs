using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        //CAMPOS (ATRIBUTOS)
        private int numPaginas;


        //PROPIEDADES
        public string ISBN => NumNormalizado;
        public int NumPaginas { get { return numPaginas; }}


        //CONSTRUCTOR

        /// <summary>
        /// Crea una instancia de la clase Libro con los datos proporcionados.
        /// </summary>
        /// <param name="titulo">El título del libro.</param>
        /// <param name="autor">El autor del libro.</param>
        /// <param name="anio">El año de publicación del libro.</param>
        /// <param name="numNormalizado">El número normalizado del libro.</param>
        /// <param name="codebar">El código de barras del libro.</param>
        /// <param name="numPaginas">El número de páginas del libro.</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;            
        }


        //SOBRECARGAS

        /// <summary>
        /// Sobrecarga del operador == compara dos libros y determinar si son iguales.
        /// </summary>
        /// <param name="libro1">El primer libro a comparar.</param>
        /// <param name="libro2">El segundo libro a comparar.</param>
        /// <returns>True si los libros son iguales, False en caso contrario.</returns>
        public static bool operator ==(Libro libro1, Libro libro2)
        {
            return libro1.Barcode == libro2.Barcode ||
                   libro1.ISBN == libro2.ISBN ||
                   (libro1.Titulo == libro2.Titulo && libro1.Autor == libro2.Autor);
        }

        /// <summary>
        /// Sobrecarga del operador != compara dos libros y determinar si son diferentes.
        /// </summary>
        /// <param name="libro1">El primer libro a comparar.</param>
        /// <param name="libro2">El segundo libro a comparar.</param>
        /// <returns>True si los libros son diferentes, False si son iguales.</returns>
        public static bool operator !=(Libro libro1, Libro libro2)
        {
            return !(libro1 == libro2);
        }


        //METODOS

        /// <summary>
        /// Retorna una cadena con los datos del libro.
        /// </summary>
        /// <returns>Cadena con los datos del libro.</returns>
        public override string ToString()
        {
            // Divide la cadena resultante de la llamada al método ToString() de la clase base (padre) en un arreglo de subcadenas.
            // La división se realiza utilizando el separador de línea del sistema operativo y eliminando las entradas vacías.
            string[] lineasPadre = base.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            // Recorre cada línea obtenida de la división de la cadena de la clase base.
            foreach (string linea in lineasPadre)
            {
                // Si la línea contiene "Cód. de barras:", se inserta el ISBN antes de esta línea.
                if (linea.Contains("Cód. de barras:"))
                {
                    sb.AppendLine($"ISBN: {ISBN}");
                }
                // Añade la línea de la clase base al StringBuilder.
                sb.AppendLine(linea);
            }

            sb.AppendLine($"Número de páginas: {NumPaginas}.");

            return sb.ToString();
        }

        
    }

}
