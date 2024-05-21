using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        //CAMPOS (ATRIBUTOS)
        private int alto;
        private int ancho;

        //PROPIEDADES
        public int Alto { get { return alto; } }
        public int Ancho { get { return ancho; } }
        public int Superficie => Alto * Ancho;


        //CONSTRUCTOR

        /// <summary>
        /// Crea una instancia de la clase Mapa con los datos proporcionados.
        /// </summary>
        /// <param name="titulo">El título del mapa.</param>
        /// <param name="autor">El autor del mapa.</param>
        /// <param name="anio">El año de publicación del mapa.</param>
        /// <param name="numNormalizado">El número normalizado del documento (no utilizado en mapas).</param>
        /// <param name="codebar">El código de barras del mapa.</param>
        /// <param name="ancho">El ancho del mapa.</param>
        /// <param name="alto">El alto del mapa.</param>
        public Mapa(string titulo, string autor, int anio,string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            // ignorar el parámetro numNormalizado (Mapas no tienen)
            this.ancho = ancho;
            this.alto = alto;
        }


        //SOBRECARGAS

        /// <summary>
        /// Sobrecarga del operador == compara dos mapas y determinar si son iguales.
        /// </summary>
        /// <param name="mapa1">El primer mapa a comparar.</param>
        /// <param name="mapa2">El segundo mapa a comparar.</param>
        /// <returns>True si los mapas son iguales, False en caso contrario.</returns>
        public static bool operator ==(Mapa mapa1, Mapa mapa2)
        {
            // Verificar si alguno de los campos es igual en ambos mapas
            return mapa1.Barcode == mapa2.Barcode ||
                   (mapa1.Titulo == mapa2.Titulo && mapa1.Autor == mapa2.Autor &&
                    mapa1.Anio == mapa2.Anio && mapa1.Superficie == mapa2.Superficie);
        }


        /// <summary>
        /// Sobrecarga del operador != compara dos mapas y determinar si son diferentes.
        /// </summary>
        /// <param name="mapa1">El primer mapa a comparar.</param>
        /// <param name="mapa2">El segundo mapa a comparar.</param>
        /// <returns>True si los mapas son diferentes, False si son iguales.</returns>
        public static bool operator !=(Mapa mapa1, Mapa mapa2)
        {
            // Invertimos el resultado de la sobrecarga del operador ==
            return !(mapa1 == mapa2);
        }


        //METODOS

        /// <summary>
        /// Retorna una cadena con los datos del mapa.
        /// </summary>
        /// <returns>Cadena con los datos del mapa.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Superficie: {Ancho} * {Alto} = {Superficie} cm2.");
            return sb.ToString();
        }


    }
}
