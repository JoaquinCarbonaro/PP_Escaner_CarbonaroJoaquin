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

        //METODOS
        public Mapa(string titulo, string autor, int anio,string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            // ignoramos el parámetro numNormalizado (Mapas no tienen)
            this.ancho = ancho;
            this.alto = alto;
        }

        /*
        public static bool operator !=(Mapa m1, Mapa m2) => !(m1 == m2);

        public static bool operator ==(Mapa m1, Mapa m2)
        {
            if (ReferenceEquals(m1, m2)) return true;
            if (ReferenceEquals(m1, null) || ReferenceEquals(m2, null)) return false;

            return m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
        }
        */

        // Sobrecarga del operador ==
        public static bool operator ==(Mapa mapa1, Mapa mapa2)
        {
            // Verificar si alguno de los campos es igual en ambos mapas
            return mapa1.Barcode == mapa2.Barcode ||
                   (mapa1.Titulo == mapa2.Titulo && mapa1.Autor == mapa2.Autor &&
                    mapa1.Anio == mapa2.Anio && mapa1.Superficie == mapa2.Superficie);
        }

        // Sobrecarga del operador !=
        public static bool operator !=(Mapa mapa1, Mapa mapa2)
        {
            // Invertimos el resultado de la sobrecarga del operador ==
            return !(mapa1 == mapa2);
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Superficie: {Ancho} * {Alto} = {Superficie} cm2.");
            return sb.ToString();
        }
    }
}
