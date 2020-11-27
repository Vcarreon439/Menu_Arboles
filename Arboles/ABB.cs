using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Arboles.Arboles
{
    class ABB
    {
        //Variable de apoyo
        private static NodoArbol temp;

        //Raiz del arbol
        private NodoArbol raiz;

        //CONSTRUCTOR POR DEFECTO
        public ABB()
        {
            raiz = null;
        }

        ///Constructor en caso de ya tener un arbol
        public ABB(NodoArbol Arbol)
        {
            raiz = Arbol;
        }

        /// <summary>
        /// Metodo para insertar valores en el nodo y/o raiz
        /// </summary>
        /// <param name="dato">Valor a insertar</param>
        /// <returns></returns>
        static private NodoArbol Insertar(int dato)
        {
            NodoArbol temp;
            return temp = new NodoArbol(dato);
        }

        /// <summary>
        /// Metodo para insertar valores en el nodo y/o raiz
        /// </summary>
        /// <param name="dato">Valor a Insertar (int)</param>
        /// <param name="pNodo">Nodo en el que se va a insertar (Nodo)</param>
        /// <returns></returns>
        static public NodoArbol Insertar(Object dato, NodoArbol pNodo)
        {
            //Variable auxiliar
            NodoArbol temp = null;

            //Comprobacion en caso de pNodo null
            if (pNodo == null)
            {
                temp = new NodoArbol(dato);
                return temp;
            }

            if (Recorridos.DetectaTipo(pNodo) != typeof(int))
            {
                Console.WriteLine("El arbol no es de tipo entero");
                return null;
            }

            ///Determina a que lado se ira el dato ingresado
            //En caso de ser menor al nodo
            if (Convert.ToInt32(dato) <= Convert.ToInt32(pNodo.Valor))
                pNodo.Izq = Insertar(dato, pNodo.Izq);

            //En caso de ser mayor al nodo
            if (Convert.ToInt32(dato) > Convert.ToInt32(pNodo.Valor))
                pNodo.Der = Insertar(dato, pNodo.Der);

            return pNodo;
        }


        /// <summary>
        /// Metodo para buscar el Minimo dentro de un arbol
        /// </summary>
        /// <param name="nodo">"Arbol a evaluar"</param>
        /// <returns>El valor minimo del arbol</returns>
        static private int EncuentraMin(NodoArbol nodo)
        {
            //Variable auxiliar para el proceso
            NodoArbol aux;

            //En caso de estar vacio
            if (nodo == null)
                return 0;
            //Se emplea aux
            aux = nodo;
            //Se convierte el valor de aux en el min.
            int min = Convert.ToInt32(aux.Valor);

            //Ciclo para darle valor el valor izquierdo a AUX 
            while (aux.Izq != null)
            {
                //Aux se convierte en su izquierda
                aux = aux.Izq;
                //min se convierte en valor de aux
                min = Convert.ToInt32(aux.Valor);
            }

            return min;
        }


        /// <summary>
        /// Metodo para buscar el Maximo dentro de un arbol
        /// </summary>
        /// <param name="nodo">"Arbol a evaluar"</param>
        /// <returns>El valor maximo del arbol</returns>
        private static int EncuentraMax(NodoArbol nodo)
        {
            //Variable auxiliar para el proceso
            NodoArbol aux;

            if (nodo == null)
                return 0;

            //Se emplea aux
            aux = nodo;
            //Se convierte el valor de aux en el max.
            int max = Convert.ToInt32(aux.Valor);

            //Ciclo para darle valor el valor derecho a AUX 
            while (aux.Der != null)
            {
                //Aux se convierte en su derecha
                aux = aux.Der;
                //max se convierte en valor de aux
                max = Convert.ToInt32(aux.Valor);
            }

            return max;
        }


        ///<summary>
        ///Metodo para imprimir el arbol de manera transversal (pre-orden).
        ///</summary>
        ///<param name="nodo">Nodo a imprimir</param>
        static public void Transversa(NodoArbol nodo)
        {
            if (nodo==null)
            {
                Console.Clear();
                Console.Title = "Transversa";
                Console.WriteLine("El arbol esta vacio");
            }
            else
            {

                //Contador para facilitar la visualizacion del arbol
                int cont = 0;

                //En caso de estar vacio no hacer nada
                if (nodo == null)
                    return;

                //Imprime los espacios
                for (int n = 0; n < cont; n++)
                    Console.Write(" ");

                //Imprime el valor
                Console.WriteLine(nodo.Valor);

                //Comprobacion del hijo izquierdo
                if (nodo.Izq != null)
                {
                    cont++;
                    Console.Write("I ");
                    Transversa(nodo.Izq);
                    cont--;
                }

                //Comprobacion del hijo derecho
                if (nodo.Der != null)
                {
                    cont++;
                    Console.Write("D ");
                    Transversa(nodo.Der);
                    cont--;
                }

            }

            

        }

        /// <summary>
        /// Este metodo busca al padre del dato en cuestion
        /// </summary>
        /// <param name="dato"></param>
        /// <param name="nodo"></param>
        /// <returns></returns>
        static private NodoArbol BuscarPadre(int dato, NodoArbol nodo)
        {
            NodoArbol aux = null;

            if (nodo == null)
                return null;

            ///Comprobaciones en caso de ser Padre
            //Comprobacion en caso tener izquierda
            if (nodo.Izq != null)
                if (Convert.ToInt32(nodo.Izq.Valor) == dato)
                    return nodo;
            //Comprobacion en caso tener derecha
            if (nodo.Der != null)
                if (Convert.ToInt32(nodo.Der.Valor) == dato)
                    return nodo;

            //En caso de tener izquierda
            if (nodo.Izq != null && dato < Convert.ToInt32(nodo.Valor))
                aux = BuscarPadre(dato, nodo.Izq);
            ////En caso de tener derecha
            if (nodo.Der != null && dato > Convert.ToInt32(nodo.Valor))
                aux = BuscarPadre(dato, nodo.Der);

            return aux;
        }

        /// <summary>
        /// Metodo para borrar nodo
        /// </summary>
        /// <param name="dato">Dato a borrar (int)</param>
        /// <param name="nodo">Nodo en el que se va buscar</param>
        /// <returns>El "arbol" resultante.</returns>
        static public NodoArbol BorrarNodo(int dato, NodoArbol nodo)
        {
            if (Recorridos.DetectaTipo(nodo) != typeof(int))
                Console.WriteLine("El arbol no es de tipo entero");
            return null;

            //Recorrido para comprobar que exista el dato
            if (!Recorridos.Resultado_Buscar(nodo, dato))
            {
                Console.WriteLine($"El dato {dato}, no existe dentro del nodo");
                return nodo;
            }

            //En caso de ser null
            if (nodo == null)
            { return nodo; }

            //En caso de ser menor
            if (dato < Convert.ToInt32(nodo.Valor))
            { nodo.Izq = BorrarNodo(dato, nodo.Izq); }

            //En caso de ser mayor
            if (dato > Convert.ToInt32(nodo.Valor))
            { nodo.Der = BorrarNodo(dato, nodo.Der); }

            //Sin hijos
            if (nodo.Izq == null && nodo.Der == null)
                return nodo = null;

            //Un hijo
            if (nodo.Izq == null)
            {
                var padre = BuscarPadre(dato, nodo);
                padre.Der = nodo.Der;
                return nodo;
            }
            //Dos hijos
            else
            {
                var min = EncuentraMin(nodo.Der);
                nodo.Valor = min;
                nodo.Der = BorrarNodo(min, nodo.Der);
            }
            return nodo;
        }
    }
}
