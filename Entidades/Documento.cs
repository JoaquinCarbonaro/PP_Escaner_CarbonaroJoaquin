using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        public int Anio { get; }
        public string Autor { get; }
        public string Barcode { get; }
        public Paso Estado { get; private set; }
        protected string NumNormalizado { get; }
        public string Titulo { get; }

        public bool AvanzarEstado()
        {
            if (Estado == Paso.Terminado)
                return false;

            Estado++;
            return true;
        }

        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            Titulo = titulo;
            Autor = autor;
            Anio = anio;
            NumNormalizado = numNormalizado;
            Barcode = barcode;
            Estado = Paso.Inicio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Título: {Titulo}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Año: {Anio}");
            sb.AppendLine($"Cód. de barras: {Barcode}");
            return sb.ToString();
        }

        

    }

}
