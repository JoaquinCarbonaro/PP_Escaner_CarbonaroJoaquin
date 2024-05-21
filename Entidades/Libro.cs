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
        /// Crea una nueva instancia de la clase Libro con los datos proporcionados.
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
        /// Sobrecarga del operador == para compara dos libros y determinar si son iguales.
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
        /// <returns>Cadena con los datos del libro o vacio si ocurrió un error.</returns>
        public override string ToString()
        {
            /*
            "string[] lineasPadre": Esta declaración crea un arreglo de cadenas llamado lineasPadre y asigna las subcadenas resultantes de la división anterior a este arreglo.
            "Split()" sobre la cadena padre. Este método divide la cadena en un arreglo de subcadenas, utilizando el separador especificado 
            "Environment.NewLine", representa el separador de línea de acuerdo con el sistema operativo en uso ("\r\n" en Windows)
            "StringSplitOptions.RemoveEmptyEntries": Este parámetro indica que se deben omitir las cadenas vacías resultantes de la división
                */
            string[] lineasPadre = base.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Creamos un StringBuilder para construir el resultado
            StringBuilder sb = new StringBuilder();

            // Añadimos las líneas de la clase padre en el orden especificado, insertando el ISBN antes del código de barras
            foreach (string linea in lineasPadre)
            {
                // Si la línea contiene "Cód. de barras:", insertamos el ISBN antes de esta línea
                if (linea.Contains("Cód. de barras:"))
                {
                    sb.AppendLine($"ISBN: {ISBN}");
                }
                // Añadimos la línea de la clase padre
                sb.AppendLine(linea);
            }

            // Añadimos el número de páginas al final
            sb.AppendLine($"Número de páginas: {NumPaginas}.");

            return sb.ToString();
        }

        
    }

}
