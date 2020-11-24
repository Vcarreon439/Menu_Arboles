using System;
using System.Threading;
using Menu_Arboles.Lista_Enlazada;
using Menu_Arboles.Arboles;

namespace Menu_Arboles.Menús
{
    class Menus
    {
        static private bool rep = false;
        static private int opcion = 0;

        public static int MenuPricipal(ref Lista_Enlazad lista)
        {
            bool rep = false;
            int opc = 0;

            do
            {
                try
                {
                    Console.Clear();
                    Console.Title = "Menú Principal";
                    Console.WriteLine("Seleccione un Opción");
                    Console.WriteLine("\t1.-Crear Nuevo Arbol");
                    Console.WriteLine("\t2.-Mostrar Arboles Existentes");
                    Console.WriteLine("\t3.-Crear Nodo Prueba_1 Int32");
                    Console.WriteLine("\t4.-Crear Nodo Prueba_2 String");
                    Console.WriteLine("\t5.-Crear Nodo Prueba_3 Char");
                    Console.WriteLine("\t6.-Salir del Programa");
                    opc = int.Parse(Console.ReadLine());
                    rep = false;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Porfavor ingresa un valor entero");
                    Thread.Sleep(1000);
                    Console.Clear();
                    rep = true;
                }

            } while (rep);

            return opc;
        }

        static public bool MenuCrear(ref Lista_Enlazad lista)
        {
            bool rep = false;
            do
            {
                Console.Clear();
                Console.Title = "Menú Crear Nodo";
                Console.WriteLine("Seleccione un Opción");
                Console.WriteLine("\t1.-Crear Nuevo Arbol Vacio");
                Console.WriteLine("\t2.-Crear Nuevo Arbol");
                Console.WriteLine("\t3.-Salir del menú actual");
                Console.WriteLine("\t4.-Salir del programa");

                try
                {
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.Clear();
                            Console.Title = "Crear Arbol vacio";
                            Console.Write("Nombre del arbol:\t");
                            string nombre = Console.ReadLine();
                            NodoLista arbol = new NodoLista(null, nombre);
                            lista.InsertarALaCabeza(arbol);
                            rep = true;
                            break;

                        case 2:
                            Console.Clear();
                            Console.Title = "Crear Arbol";
                            Console.Write("Nombre del arbol:\t");
                            string nombre2 = Console.ReadLine();
                            NodoLista arbol2 = new NodoLista(null, nombre2);
                            arbol2.Arbol = new NodoArbol(MenuInsercionInt());
                            lista.InsertarALaCabeza(arbol2);
                            break;

                        case 3:
                            rep = false;
                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Seleccione una opción válida");
                            Thread.Sleep(1200);
                            rep = true;
                            break;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Porfavor ingresa un valor entero");
                    Thread.Sleep(1000);
                    Console.Clear();
                    rep = true;
                }

            } while (rep);

            return true;
        }


        static public void MenuMostrar_C1(NodoArbol node, string nombre) 
        {
            bool rep = false;
            
            do
            {
                Console.Clear();
                Console.Title = $"Arbol {nombre}";
                Console.WriteLine("1.- Mostrar Datos del Arbol");
                Console.WriteLine("2.- Recorrido PreOrden");
                Console.WriteLine("3.- Recorrido InOrden");
                Console.WriteLine("4.- Recorrido PostOrden");
                Console.WriteLine("5.- Salir del menu actual");
                Console.WriteLine("6.- Salir del programa");

                try
                {
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            ABB.Transversa(node);
                            System.Threading.Thread.Sleep(2000);
                            rep = true;
                            break;

                        case 2:
                            Recorridos.PreOrden(node);
                            System.Threading.Thread.Sleep(2000);
                            rep = true;
                            break;

                        case 3:
                            Recorridos.InOrden(node);
                            System.Threading.Thread.Sleep(2000);
                            rep = true;
                            break;

                        case 4:
                            Recorridos.PostOrden(node);
                            System.Threading.Thread.Sleep(2000);
                            rep = true;
                            break;

                        case 5:
                            rep = false;
                            break;

                        case 6:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Elija una opcion valida");
                            rep = true;
                            break;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Ingrese un valor numerico");
                    rep = true;
                }
            } while (rep);

            
        }

        static public void MenuMostrar_C2(ref NodoArbol node, string nombre)
        {
            bool rep = false;

            do
            {
                Console.Clear();
                Console.Title = $"Arbol {nombre}";
                Console.WriteLine("1.- Mostrar Datos del Arbol");
                Console.WriteLine("2.- Insertar nodo");
                Console.WriteLine("3.- Eliminar nodo");
                Console.WriteLine("4.- Buscar nodo en el arbol");
                Console.WriteLine("5.- Recorrido PreOrden");
                Console.WriteLine("6.- Recorrido InOrden");
                Console.WriteLine("7.- Recorrido PostOrden");
                Console.WriteLine("8.- Salir del Menu Actual");
                Console.WriteLine("9.- Salir del Programa");

                try
                {
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            ABB.Transversa(node);
                            System.Threading.Thread.Sleep(2000);
                            rep = true;
                            break;

                        case 2:
                            var valor = MenuInsercionInt();
                            ABB.Insertar(valor, node);
                            rep = true;
                            break;

                        case 3:
                            ABB.BorrarNodo(int.Parse(Console.ReadLine()),node);
                            rep = true;
                            break;

                        case 4:

                            if (Recorridos.Resultado_Buscar(node, int.Parse(Console.ReadLine())))
                                Console.WriteLine("El elemento si existe");
                            else
                                Console.WriteLine("El elemento no existe");

                            rep = true;
                            break;


                        case 5:
                            Recorridos.PreOrden(node);
                            rep = true;
                            break;

                        case 6:
                            Recorridos.InOrden(node);
                            rep = true;
                            break;

                        case 7:
                            Recorridos.PostOrden(node);
                            rep = true;
                            break;

                        case 8:
                            rep = false;
                            break;

                        case 9:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Ingrese una opcion valida");
                            rep = true;
                            break;
                    }


                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Ingrese un valor numerico");
                }

            } while (rep);

            
        }


        static private Type tipo = null;
        static public void MenuMostrar(Lista_Enlazad Lista) 
        {
            Console.Clear();
            Console.Title = "Menu Mostrar";
            Lista_Enlazad.Mostrar(Lista);
            bool rep = false;

            if (!Lista_Enlazad.Verifica_Vacia(Lista))
            {
                Console.Write("Escriba el nombre de un arbol: ");
                string nombre = Console.ReadLine();

                if (Lista_Enlazad.Existe(Lista, nombre))
                {
                    do
                    {
                        NodoArbol node = Lista_Enlazad.Solicitar(Lista, nombre);
                        Console.Clear();
                        
                        if (Recorridos.DetectaTipo(node) == typeof(Int32)|| Recorridos.DetectaTipo(node) == null)
                        {
                            MenuMostrar_C2(ref node, nombre);
                        }
                        else
                        {
                            MenuMostrar_C1(node, nombre);
                        }
                        
                    } while (rep);
                }
            }
        }

        public static Object MenuInsercionInt()
        {
            Object valor = null;
            bool rep = false;

            do
            {
                try
                {
                    Console.Clear();
                    Console.Title = "Menú Insertar dato";
                    Console.WriteLine("Seleccione un Opción");
                    Console.WriteLine("\t1.-Tipo Int");
                    Console.WriteLine("\t2.-Salir");

                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.Clear();
                            Console.Title = "Tipo Int";
                            Console.Write("Ingrese un valor: \t");
                            valor = Convert.ToInt32(Console.ReadLine());
                            break;

                        case 2:
                            Console.Clear();
                            rep = false;
                            break;

                        default:
                            Console.WriteLine("Seleccione una opción válida");
                            rep = true;
                            break;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Porfavor ingresa un valor entero");
                    Thread.Sleep(1000);
                    Console.Clear();
                    rep = true;
                }

            }
            while (rep);

            return valor;
        }

    }
}
