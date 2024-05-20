using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        public string ISBN => NumNormalizado;
        public int NumPaginas { get; }

        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, barcode)
        {
            NumPaginas = numPaginas;
        }

        public static bool operator !=(Libro l1, Libro l2) => !(l1 == l2);

        public static bool operator ==(Libro l1, Libro l2)
        {
            if (ReferenceEquals(l1, l2)) return true;
            if (ReferenceEquals(l1, null) || ReferenceEquals(l2, null)) return false;

            return l1.Barcode == l2.Barcode ||
                   l1.ISBN == l2.ISBN ||
                   (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
        }

        public override string ToString()
        {
            // Llamamos al ToString de la clase padre y lo dividimos en líneas
            string[] lineasPadre = base.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Creamos un StringBuilder para construir el resultado
            StringBuilder sb = new StringBuilder();

            // Añadimos las líneas de la clase padre en el orden especificado, insertando el ISBN antes del código de barras
            foreach (string linea in lineasPadre)
            {
                if (linea.Contains("Cód. de barras:"))
                {
                    sb.AppendLine($"ISBN: {ISBN}");
                }
                sb.AppendLine(linea);
            }

            // Añadimos el número de páginas al final
            sb.AppendLine($"Número de páginas: {NumPaginas}");

            return sb.ToString();
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    // Llamamos al ToString de la clase padre y lo almacenamos en una variable
        //    string padreString = base.ToString();
        //    // Agregamos las líneas en el orden especificado
        //    sb.AppendLine(padreString);
        //    // Buscamos la posición donde se encuentra el código de barras y lo insertamos antes
        //    int posicionCodigoBarras = padreString.IndexOf("Cód. de barras:");
        //    if (posicionCodigoBarras != -1)
        //    {
        //        sb.Insert(posicionCodigoBarras, $"ISBN: {ISBN}\n");
        //    }
        //    sb.AppendLine($"Número de páginas: {NumPaginas}.");
        //    return sb.ToString();
        //}

        /*
        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"ISBN: {ISBN}");
            sb.AppendLine($"Número de páginas: {NumPaginas}");
            return sb.ToString();
        }
        */
    }

}
