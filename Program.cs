using System;
using Menu_Arboles.Lista_Enlazada;
using Menu_Arboles.Menús;
using Menu_Arboles.Arboles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Arboles
{
    class Program
    {
        static Lista_Enlazad Lista = new Lista_Enlazad();
        static bool rep = true;
        static int cont = 0;

        static void Main(string[] args)
        {
            do
            {
                try
                {
                    switch (Menus.MenuPricipal(ref Lista))
                    {
                        case 1:
                            Menus.MenuCrear(ref Lista);
                            break;

                        case 2:
                            Menus.MenuMostrar(Lista);
                            break;

                        case 3:
                            NodoArbol arbol = Recorridos.CrearArbolPrueba_1();
                            NodoLista arb = new NodoLista(arbol, $"Arbol de Prueba #{cont + 1}");
                            Lista.InsertarALaCabeza(arb);
                            cont++;
                            rep = true;
                            break;

                        case 4:
                            NodoArbol arbol1 = Recorridos.CrearArbolPrueba_2();
                            NodoLista arb1 = new NodoLista(arbol1, $"Arbol de Prueba #{cont + 1}");
                            Lista.InsertarALaCabeza(arb1);
                            cont++;
                            rep = true;
                            break;

                        case 5:
                            NodoArbol arbol2 = Recorridos.CrearArbolPrueba_3();
                            NodoLista arb2 = new NodoLista(arbol2, $"Arbol de Prueba #{cont + 1}");
                            Lista.InsertarALaCabeza(arb2);
                            cont++;
                            rep = true;
                            break;

                        case 6:
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            } while (rep);
        }
    }
}
