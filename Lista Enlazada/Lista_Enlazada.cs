using System;
using Menu_Arboles.Arboles;

namespace Menu_Arboles.Lista_Enlazada
{
    class Lista_Enlazad
    {

        static public NodoLista aux;
        public NodoLista cabeza;
        public NodoLista final;
        private int cont = 1;

        public Lista_Enlazad()
        {
            cabeza = null;
        }

        static public void Vaciar(ref Lista_Enlazad lista)
        {
            lista = null;
        }

        public void InsertarALaCabeza(NodoLista dato)
        {
            NodoLista nuevo;

            if (dato.Nombre != null)
                nuevo = new NodoLista(dato.Arbol, dato.Nombre);
            else
            {
                nuevo = new NodoLista(dato.Arbol, $"Arbol sin nombre #{cont}");
                cont++;
            }

            //Se establece la sigueinte referencia
            nuevo.SiguienteNodo = cabeza;
            cabeza = nuevo;
        }

        public void InsertarAlFinal(NodoLista dato)
        {
            //Se verifica que haya elementos en la lista
            if (cabeza == null)
            {
                //De no haberlos crea el primer elemento
                InsertarALaCabeza(dato);
            }
            else
            {
                //Variable final como variable temporal
                final = cabeza;
                //Cabeza = nuevo nodo
                cabeza = new NodoLista(dato.Arbol, dato.Nombre);
                //Se reestablecen los apuntadores con la variable final
                cabeza.SiguienteNodo = final;

                #region Comentario
                /*
                 * En este caso realmente se puede pasar por alto la variable final,
                 * ya que podemos hacer uso de la variable auxiliar para poder
                 * "reestablecer" el orden de la lista.
                */
                #endregion
            }
        }

        static public void Mostrar(Lista_Enlazad lista)
        {
            Console.Clear();
            Console.Title = "Mostrar Lista";

            NodoLista aux = lista.cabeza;
            int cont = 1;

            //Ciclo para imprimir hasta que el sig apuntador sea null
            while (aux != null)
            {
                Console.WriteLine($"{cont}.- {aux.Nombre}");
                cont++;
                //Se cambia auxiliar por el apuntador del siguiente
                aux = aux.SiguienteNodo;
            }

            //Imprimir null en caso de que el apuntador sea null
            if (aux == null)
            {
                Console.WriteLine("No hay más arboles");
            }
            
            aux = null;
            
            Console.WriteLine();
        }

        public int ContarElementos()
        {
            var aux = cabeza;
            int contador = 0;

            while (aux != null)
            {
                aux = aux.SiguienteNodo;
                contador -= -1;
            }

            Console.WriteLine("Hay {0} elementos en la lista", contador);

            return contador;
        }

        static public bool Verifica_Vacia(Lista_Enlazad list)
        {
            if (list.cabeza == null)
                return true;
            else
                return false;
        }

        static public bool Existe(Lista_Enlazad lista, string nombre)
        {
            //Error lista
            aux = lista.cabeza;
            bool existe = false;
            
            //Ciclo para hacer recorrido
            while (aux != null)
            {
                if (aux.Nombre == nombre)
                { existe = true; }
                
                aux = aux.SiguienteNodo;
            }

            if (!existe)
            {
                Console.Clear();
                Console.Beep();
                Console.WriteLine("El arbol no existe dentro de la lista");
                System.Threading.Thread.Sleep(2000);
            }

            return existe;
        }


        private static NodoArbol nodoAux;
        static public NodoArbol Solicitar(Lista_Enlazad lista, string nombre) 
        {
            aux = lista.cabeza;
            
            while (aux != null)
            {
                if (aux.Nombre == nombre)
                    nodoAux = aux.Arbol;

                aux = aux.SiguienteNodo;
            }

            return nodoAux;
        }

        static public int ContarElementos(Lista_Enlazad lista)
        {
            Lista_Enlazad aux = lista;
            int contador = 1;
            
            while (aux != null)
            {
                aux.cabeza = aux.cabeza.SiguienteNodo;
                contador -= -1;
            }

            Console.WriteLine($"Tiene {contador} elementos en la lista");

            return contador;
        }

        static public Lista_Enlazad Eliminar(NodoLista Lista, string nombre)
        {
            Lista_Enlazad Aux = new Lista_Enlazad();

            if (Lista.Nombre == nombre)
            {
                Aux.InsertarALaCabeza(Lista.SiguienteNodo);
                return Aux;
            }
            else
            {
                while (Lista.SiguienteNodo != null)
                {
                    if (Lista.Nombre == nombre)
                    {
                        Aux.InsertarALaCabeza(Lista.SiguienteNodo);
                    }
                    
                    Aux.InsertarALaCabeza(Lista);
                    Lista = Lista.SiguienteNodo;
                }
            }

            return Aux;
        }

    }
}
