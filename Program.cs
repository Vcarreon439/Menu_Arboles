using System;
using Menu_Arboles.Lista_Enlazada;
using Menu_Arboles.Menús;
using Menu_Arboles.Arboles;

namespace Menu_Arboles
{
    class Program
    {
        //Lista en la cual se iran almacenando los arboles
        static Lista_Enlazad Lista = new Lista_Enlazad();
        //variable de control para la repeticion del menu & programa
        static bool rep = true;
        //contador para arboles de prueba
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
                            Console.Clear();
                            Console.Title = "Información del Programa";
                            Console.WriteLine("Materia: Estructura de Datos");
                            Console.WriteLine("Docente: ING. NANCY GABRIELA MARÍN CASTAÑEDA");
                            Console.WriteLine("Tercer Semestre | Grupo A | Agosto - Diciembre");
                            Console.WriteLine("Programa hecho por:");
                            Console.WriteLine("\t Victor Hugo Carreon Pulido - 192310436");
                            Console.WriteLine("\t Andrea Evelyn Mejia Rubio - 192310177");
                            Console.WriteLine("\t Edgar Eduardo Arguijo Vazquez - 192310252");
                            Console.ReadKey();
                            rep = true;
                            break;

                        case 7:
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Ingrese un valor numerico");
                }

            } while (rep);
        }
    }
}
