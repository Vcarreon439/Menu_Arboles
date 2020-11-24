using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Arboles.Arboles
{
    class NodoArbol
    {
        //Valor es el contenido que tendra el nodo
        public Object Valor { get; set; }
        //Izq es el contenido que tendra el nodo izquierdo
        public NodoArbol Izq { get; set; }
        //Izq es el contenido que tendra el nodo derecho
        public NodoArbol Der { get; set; }

        public Type tipoElemento { get; set; }

        /// <summary>
        /// Constructor secundario
        /// </summary>
        /// <param name="valor">El valor que tendrá el nodo</param>
        /// <param name="izq">Su hijo izquierdo</param>
        /// <param name="der">Su hijo derecho</param>
        public NodoArbol(Object valor, NodoArbol izq = null, NodoArbol der = null)
        {
            this.Valor = valor;
            this.tipoElemento = valor.GetType();
            this.Izq = izq;
            this.Der = der;
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public NodoArbol()
        {
            this.Valor = null;
            this.Izq = null;
            this.Der = null;
        }

        public void InsertarNodo(Object valor)
        {
            this.Valor = valor;
        }

    }
}
