using System;
using Menu_Arboles.Arboles;

namespace Menu_Arboles.Lista_Enlazada
{
    class NodoLista
    {
        //Añadir la clase Nodo

        //Atributo que almacena el valor del nodo
        public NodoArbol Arbol;

        /*Clase autorefenciada, atributo que indica en que 
        localidad de memoria esta el sigueinte nodo*/
        public NodoLista SiguienteNodo;

        ////Nombre con el que se identificara al nodo
        public string Nombre;

        public NodoLista(NodoArbol arbol, string nombre) 
        {
            this.Arbol = arbol;
            this.Nombre = nombre;
        }

        public NodoLista()
        {

        }
    }
}

