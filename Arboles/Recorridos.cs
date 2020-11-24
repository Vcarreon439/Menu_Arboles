using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Arboles.Arboles
{
    class Recorridos
    {
        static private Type Aux = null;

        #region DetectaTipo
        
        
        static public Type DetectaTipo(NodoArbol nodo)
        {

            if (nodo == null)
            {
                return null;
            }
            else
            {
                //Comprobacion del hijo izquierdo
                if (nodo.Izq != null)
                {
                    DetectaTipo(nodo.Izq);
                }

                //Comprobacion del hijo derecho
                if (nodo.Der != null)
                {
                    DetectaTipo(nodo.Der);
                }

                if (nodo.Valor.GetType() != typeof(Int32))
                {
                    Aux = nodo.tipoElemento;
                }
                else
                {
                    Aux = typeof(Int32);
                }
            }

            return Aux;
        }
        

        #endregion

        #region Metodos_Buscar

        /// <summary>
        /// Sirve para buscar un elemento dentro de un "arbol" (Metodo Recursivo)
        /// </summary>
        /// <param name="Arbol">Nodo a evaluar</param>
        /// <param name="valor">Valor a buscar</param>
        /// <returns>El valor, con sus propiedades {Izq Der}</returns>
        private static NodoArbol Buscar(NodoArbol Arbol, Object valor)
        {
            //En caso de ser nulo
            if (Arbol == null) return Arbol;
            //En caso de ser el valor buscado
            if (valor == Arbol.Valor) return Arbol;
            //En caso de ser diferente al valor buscado (Resursividad)
            if (valor != Arbol.Valor) return Buscar(Arbol.Izq, valor);

            //Recursividad
            return Buscar(Arbol.Der, valor);
        }

        /// <summary>
        /// De
        /// </summary>
        /// <param name="Arbol"></param>
        /// <param name="valor"></param>
        /// <returns>Boolena para comprobación interna</returns>
        public static bool Resultado_Buscar(NodoArbol Arbol, Object valor)
        {
            if (Recorridos.Buscar(Arbol, valor) == null)
                return false;
            else
                return true;
        }

        #endregion

        #region Recorridos Pre,Post,In
        /// <summary>
        /// Imprime el arbol en preorden
        /// </summary>
        /// <param name="nodo">"Arbol" a evaluar</param>
        /// <param name="nivel">Para definir a partir de donde se hace el recorrido</param>
        public static void PreOrden(NodoArbol nodo, int nivel = 0)
        {
            if (null == nodo) return;

            string separador = new string('-', nivel);
            Console.WriteLine($"{separador}{nodo.Valor}");

            PreOrden(nodo.Izq, nivel + 1);
            PreOrden(nodo.Der, nivel + 1);
        }

        /// <summary>
        /// Imprime el arbol en postorden
        /// </summary>
        /// <param name="nodo">"Arbol" a evaluar</param>
        /// <param name="nivel">Para definir a partir de donde se hace el recorrido</param>
        public static void PostOrden(NodoArbol nodo, int nivel = 0)
        {
            if (null == nodo) return;

            PostOrden(nodo.Izq, nivel + 1);
            PostOrden(nodo.Der, nivel + 1);
            string separador = new string('-', nivel);
            Console.WriteLine($"{separador}{nodo.Valor}");
        }

        /// <summary>
        /// Imprime el arbol en InOrden
        /// </summary>
        /// <param name="nodo">"Arbol" a evaluar</param>
        /// <param name="nivel">Para definir a partir de donde se hace el recorrido</param>
        public static void InOrden(NodoArbol nodo, int nivel = 0)
        {
            if (null == nodo) return;

            InOrden(nodo.Izq, nivel + 1);
            string separador = new string('-', nivel);
            Console.WriteLine($"{separador}{nodo.Valor}");
            InOrden(nodo.Der, nivel + 1);
        }
        #endregion

        #region Arboles_de_Prueba

        public static NodoArbol CrearArbolPrueba_1()
        {
            return new NodoArbol(60,
                        new NodoArbol(30,

                            new NodoArbol(10,
                                new NodoArbol(1),
                                new NodoArbol(20)),

                            new NodoArbol(40,
                                new NodoArbol(35),
                                new NodoArbol(50))),

                        new NodoArbol(100,
                            new NodoArbol(80,
                                new NodoArbol(70),
                                new NodoArbol(90)),
                            new NodoArbol(120,
                                    izq: new NodoArbol(21))));
        }

        public static NodoArbol CrearArbolPrueba_2()
        {
            return new NodoArbol("Hola",

                            new NodoArbol("Soy",

                                new NodoArbol("Arbol",
                                    new NodoArbol("Uno",
                                        der: new NodoArbol("UnoUno")),
                                    new NodoArbol("Dos")),

                                new NodoArbol("Un",
                                    new NodoArbol("G"),
                                    new NodoArbol("H",
                                        new NodoArbol("J"),
                                        new NodoArbol("K")))));
        }

        public static NodoArbol CrearArbolPrueba_3()
        {
            return new NodoArbol("F",
                        new NodoArbol("B",
                            new NodoArbol("A"),
                            new NodoArbol("D",
                                new NodoArbol("C"),
                                new NodoArbol("E"))),
                        new NodoArbol("G",
                            der: new NodoArbol("I",
                                izq: new NodoArbol("H"))));
        }

        #endregion
    }
}
