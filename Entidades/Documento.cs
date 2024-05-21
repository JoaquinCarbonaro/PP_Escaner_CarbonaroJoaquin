using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
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
        public Paso Estado {get { return estado; }}
        protected string NumNormalizado { get { return numNormalizado; } }
        public string Titulo { get { return titulo; } }


        //CONSTRUCTOR

        /// <summary>
        /// Crea una nueva instancia de la clase Documento con los datos proporcionados.
        /// </summary>
        /// <param name="titulo">El título del documento.</param>
        /// <param name="autor">El autor del documento.</param>
        /// <param name="anio">El año de publicación del documento.</param>
        /// <param name="numNormalizado">El número normalizado del documento.</param>
        /// <param name="barcode">El código de barras del documento.</param>
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }


        //METODOS

        /// <summary>
        /// Avanza el estado del documento al siguiente paso.
        /// </summary>
        /// <returns>True si el estado se pudo avanzar, false si ya estaba en el estado final o si ocurrió un error.</returns>
        public bool AvanzarEstado()
        {
            if (Estado == Paso.Terminado)
            {
                return false;
            }

            estado++;
            return true;
        }

        /// <summary>
        /// Retorna una cadena con los datos del documento.
        /// </summary>
        /// <returns>Cadena con los datos del documento o vacio si ocurrió un error.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Título: {Titulo}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Año: {Anio}");
            sb.AppendLine($"Cód. de barras: {Barcode}");
            return sb.ToString();
        }


        //TIPOS ANIDADOS (ENUM)
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }


    }

}
