using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        public int Alto { get; }
        public int Ancho { get; }
        public int Superficie => Alto * Ancho;

        public Mapa(string titulo, string autor, int anio,string numNormalizado, string barcode, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, barcode)
        {
            Ancho = ancho;
            Alto = alto;
        }

        public static bool operator !=(Mapa m1, Mapa m2) => !(m1 == m2);

        public static bool operator ==(Mapa m1, Mapa m2)
        {
            if (ReferenceEquals(m1, m2)) return true;
            if (ReferenceEquals(m1, null) || ReferenceEquals(m2, null)) return false;

            return m1.Barcode == m2.Barcode ||
                   (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Superficie: {Ancho} * {Alto} = {Superficie} cm2.");
            return sb.ToString();
        }
    }
}
