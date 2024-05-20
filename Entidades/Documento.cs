using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        //TIPOS ANIDADOS (ENUM)
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        //CAMPOS (ATRIBUTOS)
        private int anio;
        private string autor;
        private string barcode;
        private Paso estado;
        private string numNormalizado;
        private string titulo;

        //PROPIEDADES
        public int Anio { get { return anio; } }
        public string Autor { get { return autor; } }
        public string Barcode { get { return barcode; } }

        //PREGUNTAR: debo poner set para usar en metodo
        public Paso Estado
        {
            get { return estado; }
            private set { estado = value; }
        }

        protected string NumNormalizado { get { return numNormalizado; } }
        public string Titulo { get { return titulo; } }

        //METODOS
        public bool AvanzarEstado()
        {
            if (Estado == Paso.Terminado)
                return false;

            Estado++;
            return true;
        }

        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
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
