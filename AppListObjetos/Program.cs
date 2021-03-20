using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AppListObjetos
{
    class Program
    {
        static Validaciones Vericar = new Validaciones();
        static List<Alumno> ListaAlumnos = new List<Alumno>();

      

        static void Main(string[] args)
        {
            int OpcMen;
            int numero;
            int opc1;

            string temporal;

           
                    do
                    {
                        bool EntradaValida = false;
                        Console.Clear();
                        gui.Marco(1, 119, 1, 25);
                        gui.BorrarLinea(50, 22, 80);
                        Console.SetCursorPosition(50, 5); Console.Write("*** Menu Principal *** ");
                        gui.Linea(30, 90, 6);
                        Console.SetCursorPosition(50, 7); Console.Write("1. Insertar Alumno");
                        Console.SetCursorPosition(50, 8); Console.Write("2. Listar Alumnos");
                        Console.SetCursorPosition(50, 9); Console.Write("3. Buscar Alumnos");
                        Console.SetCursorPosition(50, 10); Console.Write("4. Leer archivo XML");
                        Console.SetCursorPosition(50, 11); Console.Write("5. Escrir Archivo XML");
                        Console.SetCursorPosition(50, 12); Console.Write("6. Modificar Entrada");
                        Console.SetCursorPosition(50, 13); Console.Write("7. Eliminar Entrada");
                        Console.SetCursorPosition(50, 14); Console.Write("8. Salir");

                do
                        {
                            gui.BorrarLinea(40, 15, 80);
                            Console.SetCursorPosition(50, 15); Console.Write("Escoja Opcion: ");
                            temporal = Console.ReadLine();
                            if (!Vericar.Vacio(temporal))
                                if (Vericar.TipoNumero(temporal))
                                    EntradaValida = true;
                        } while (!EntradaValida);


                        OpcMen = Convert.ToInt32(temporal);

                        switch (OpcMen)
                        {
                            case 1:
                                InsertarNombre();
                                break;
                            case 2:
                                ListarNombres();
                                break;
                            case 3:
                                BuscarNombre();
                                break;
                            case 4:
                                LeerArchivoXml();
                                break;
                            case 5:
                                EscrirArchivoXml();
                                break;
                            case 6:
                                gui.BorrarLinea(40, 22, 80);
                                break;
                            case 7:
                                Eliminar();
                                break;
                            case 8:
                                Modificar();
                                break;
                            default:
                                {
                                    gui.BorrarLinea(40, 22, 80);
                                    Console.SetCursorPosition(40, 22); Console.Write(" Opcion Invalida");
                                }
                                break;

                        }
                        gui.BorrarLinea(40, 23, 80);
                        //Console.SetCursorPosition(40, 23); Console.Write("presione cualquier tecla para continuar");
                        //Console.ReadKey();
                    } while (OpcMen !=8);
            Console.SetCursorPosition(40, 23); Console.Write("Gracias vuelva pronto");


        }
        static void InsertarNombre()
        {
            string preg = "s";
            do
            {
                bool EntradaValidaNombre = false;
                bool EntradaValidaCodigo = false;
                bool EntradaValidaApellido = false;
                bool EntradaValidaNota1 = false;
                bool EntradaValidaNota2 = false;
                bool EntradaValidaNota3 = false;
                bool EntradaValidaCaja = false;

                string codigo;
                string nombre;
                string apellido;
                string nota1;
                string nota2;
                string nota3;
                string caja;

                Console.Clear();
                gui.Marco(1, 119, 1, 25);
                Console.SetCursorPosition(40, 5); Console.WriteLine("Insertar nuevo Alumno");
                gui.Linea(40, 6, 30);



                do
                {
                    gui.BorrarLinea(34, 8, 64);
                    Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo del Alumno: ");
                    codigo = Console.ReadLine();
                    if (!Vericar.Vacio(codigo))
                        if (Vericar.TipoNumero(codigo))
                            EntradaValidaCodigo = true;
                } while (!EntradaValidaCodigo);

                if (!Existe(Convert.ToInt32(codigo)))
                {
                    do
                    {
                        gui.BorrarLinea(33, 9, 64);
                        Console.SetCursorPosition(10, 9); Console.Write("Digite solo Nombres Alumno:");
                        nombre = Console.ReadLine();
                        if (!Vericar.Vacio(nombre))
                            if (Vericar.TipoTexto(nombre))
                                EntradaValidaNombre = true;
                    } while (!EntradaValidaNombre);

                    do
                    {
                        gui.BorrarLinea(37, 10, 64);
                        Console.SetCursorPosition(10, 10); Console.Write("Digite apellidos: ");
                        apellido = Console.ReadLine();
                        if (!Vericar.Vacio(apellido))
                            if (Vericar.TipoTexto(apellido))
                                EntradaValidaApellido = true;
                    } while (!EntradaValidaApellido);

                    do
                    {
                        gui.BorrarLinea(28, 11, 64);
                        Console.SetCursorPosition(10, 11); Console.Write("Digite la nota 1: ");
                        nota1 = Console.ReadLine();
                        if (!Vericar.Vacio(nota1))
                            if (Vericar.TipoNumero(nota1))
                                if (Convert.ToDouble(nota1) >= 0 && Convert.ToDouble(nota1) <= 5)
                                {
                                    EntradaValidaNota1 = true;
                                }
                                else
                                {
                                    gui.BorrarLinea(40, 22, 64);
                                    Console.SetCursorPosition(40, 22);
                                    Console.Write("La nota debe estar entre 0 y 5");
                                }
                    } while (!EntradaValidaNota1);

                    do
                    {
                        gui.BorrarLinea(28, 12, 64);
                        Console.SetCursorPosition(10, 12); Console.Write("Digite la nota 2: ");
                        nota2 = Console.ReadLine();
                        if (!Vericar.Vacio(nota2))
                            if (Vericar.TipoNumero(nota2))
                                if (Convert.ToDouble(nota2) >= 0 && Convert.ToDouble(nota2) <= 5)
                                {
                                    EntradaValidaNota2 = true;
                                }
                                else
                                {
                                    gui.BorrarLinea(40, 22, 64);
                                    Console.SetCursorPosition(40, 22);
                                    Console.Write("La nota debe estar entre 0 y 5");
                                }

                    } while (!EntradaValidaNota2);

                    do
                    {
                        gui.BorrarLinea(28, 13, 64);
                        Console.SetCursorPosition(10, 13); Console.Write("Digite la nota 3: ");
                        nota3 = Console.ReadLine();
                        if (!Vericar.Vacio(nota3))
                            if (Vericar.TipoNumero(nota3))
                                if (Convert.ToDouble(nota3) >= 0 && Convert.ToDouble(nota3) <= 5)
                                {
                                    EntradaValidaNota3 = true;
                                }
                                else
                                {
                                    gui.BorrarLinea(40, 22, 64);
                                    Console.SetCursorPosition(40, 22);
                                    Console.Write("La nota debe estar entre 0 y 5");
                                }
                    } while (!EntradaValidaNota3);


                    //..........................................





                    Alumno myAlumno = new Alumno();
                    myAlumno.Codigo = Convert.ToInt32(codigo);
                    myAlumno.Nombre = nombre;
                    myAlumno.Apellido = apellido;
                    myAlumno.Nota1 = Convert.ToDouble(nota1);
                    myAlumno.Nota2 = Convert.ToDouble(nota2);
                    myAlumno.Nota3 = Convert.ToDouble(nota3);
                    myAlumno.NotaDef = (Convert.ToDouble(nota1) + Convert.ToDouble(nota2) + Convert.ToDouble(nota3)) / 3;


                    if (myAlumno.NotaDef >= 3.5)
                    {
                        myAlumno.Caja = "Aprobado";
                    }
                    else
                    {
                        myAlumno.Caja = "Reprobado";
                    }


                    ListaAlumnos.Add(myAlumno);
                }
                else
                {
                    Console.SetCursorPosition(35, 21);
                    Console.WriteLine("El usuario con el codigo " + codigo + " Ya Existe en el sistema");
                }

                Console.SetCursorPosition(20, 22);
                Console.Write("Pulse cualquier tecla para seguir agregando estudianteso de lo contrario pulse n/N: ");
                preg=Console.ReadLine();
            } while (preg != "n" && preg != "N");
        }

        static void ListarNombres()
        {

            Console.Clear();
            gui.Marco(1, 119, 1, 25);
            gui.Marco2(3, 118, 4, 23);
            Console.SetCursorPosition(40, 2); Console.Write(" Cantidad de Alumnos: " + ListaAlumnos.Count);
            int altura = 6;
            gui.Linea(3, 107, 3);
            gui.Linea2(5, 22, 18);
            gui.Linea2(5, 22, 33);
            gui.Linea2(5, 22, 52);
            gui.Linea2(5, 22, 63);
            gui.Linea2(5, 22, 73);
            gui.Linea2(5, 22, 82);
            gui.Linea2(5, 22, 97);

            Console.SetCursorPosition(8, 5); Console.Write("CODIGO");
            Console.SetCursorPosition(23, 5); Console.Write("NOMBRES");
            Console.SetCursorPosition(39, 5); Console.Write("APELLIDOS");
            Console.SetCursorPosition(55, 5); Console.Write("NOTA 1");
            Console.SetCursorPosition(66, 5); Console.Write("NOTA 2");
            Console.SetCursorPosition(75, 5); Console.Write("NOTA 3");
            Console.SetCursorPosition(85, 5); Console.Write("NOTA FINAL");
            Console.SetCursorPosition(103, 5); Console.Write("DEFINITIVA");
            

            foreach (Alumno ObjetoAlumno in ListaAlumnos)
            {


                Console.SetCursorPosition(9, altura); Console.Write(ObjetoAlumno.Codigo);
                Console.SetCursorPosition(19, altura); Console.Write(ObjetoAlumno.Nombre);
                Console.SetCursorPosition(34, altura); Console.Write(ObjetoAlumno.Apellido);
                Console.SetCursorPosition(57, altura); Console.Write("{0:N1}", ObjetoAlumno.Nota1);
                Console.SetCursorPosition(67, altura); Console.Write("{0:N1}", ObjetoAlumno.Nota2);
                Console.SetCursorPosition(77, altura); Console.Write("{0:N1}", ObjetoAlumno.Nota3);
                Console.SetCursorPosition(87, altura); Console.Write("{0:N2}",ObjetoAlumno.NotaDef);
                Console.SetCursorPosition(104, altura); Console.Write(ObjetoAlumno.Caja);

                altura++;
            }
            Console.SetCursorPosition(29, 29);
            Console.WriteLine("Pulse cualquier tecla para continuar");
            Console.SetCursorPosition(66, 29);
            Console.ReadLine();
        }

        static void BuscarNombre()
        {
            string codigo;
            bool EntradaValidaCodigo = false;

            Console.Clear();
            gui.Marco(1, 119, 1, 25);
            Console.SetCursorPosition(50, 5); Console.WriteLine("Alumno a buscar");
            gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Alumno: ");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (Existe(Convert.ToInt32(codigo)))
            {
                Alumno myAlumno = ObtenerDatos(Convert.ToInt32(codigo));
                
                int altura = 11;
                gui.Linea(3, 118, 9);
                gui.Linea(3, 118, 12);
                gui.Linea2(10, 11, 18);
                gui.Linea2(10, 11, 33);
                gui.Linea2(10, 11, 52);
                gui.Linea2(10, 11, 63);
                gui.Linea2(10, 11, 73);
                gui.Linea2(10, 10, 82);
                gui.Linea2(10, 11, 97);

                Console.SetCursorPosition(8, 10); Console.Write("CODIGO");
                Console.SetCursorPosition(23, 10); Console.Write("NOMBRES");
                Console.SetCursorPosition(39, 10); Console.Write("APELLIDOS");
                Console.SetCursorPosition(55, 10); Console.Write("NOTA 1");
                Console.SetCursorPosition(66, 10); Console.Write("NOTA 2");
                Console.SetCursorPosition(75, 10); Console.Write("NOTA 3");
                Console.SetCursorPosition(85, 10); Console.Write("NOTA FINAL");
                Console.SetCursorPosition(103, 10); Console.Write("DEFINITIVA");

                Console.SetCursorPosition(9, altura); Console.Write(myAlumno.Codigo);
                Console.SetCursorPosition(19, altura); Console.Write(myAlumno.Nombre);
                Console.SetCursorPosition(34, altura); Console.Write(myAlumno.Apellido);
                Console.SetCursorPosition(57, altura); Console.Write("{0:N1}", myAlumno.Nota1);
                Console.SetCursorPosition(67, altura); Console.Write("{0:N1}", myAlumno.Nota2);
                Console.SetCursorPosition(77, altura); Console.Write("{0:N1}", myAlumno.Nota3);
                Console.SetCursorPosition(87, altura); Console.Write("{0:N2}", myAlumno.NotaDef);
                Console.SetCursorPosition(104, altura); Console.Write(myAlumno.Caja);



            }
            else { 
            gui.BorrarLinea(40, 22, 80);
            Console.SetCursorPosition(40, 22); Console.Write(" El usuario del codigo " + codigo + " No existe");
            }
            Console.SetCursorPosition(29, 29);
            Console.WriteLine("Pulse cualquier tecla para continuar");
            Console.SetCursorPosition(66, 29);
            Console.ReadLine();




        }

        static void Modificar()
        {
            string codigo;
            bool EntradaValidaCodigo = false;

            Console.Clear();
            gui.Marco(1, 119, 1, 25);
            Console.SetCursorPosition(50, 5); Console.WriteLine("Alumno a modificar ");
            gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Alumno: ");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (Existe(Convert.ToInt32(codigo)))
            {
                Alumno myAlumno = ObtenerDatos(Convert.ToInt32(codigo));
                int posicion=Posicion(Convert.ToInt32(codigo));
                int altura = 11;
                gui.Linea(3, 118, 9);
                gui.Linea(3, 118, 12);
                gui.Linea2(10, 11, 18);
                gui.Linea2(10, 11, 33);
                gui.Linea2(10, 11, 52);
                gui.Linea2(10, 11, 63);
                gui.Linea2(10, 11, 73);
                gui.Linea2(10, 10, 82);
                gui.Linea2(10, 11, 97);


                Console.SetCursorPosition(8, 10); Console.Write("CODIGO");
                Console.SetCursorPosition(23, 10); Console.Write("NOMBRES");
                Console.SetCursorPosition(39, 10); Console.Write("APELLIDOS");
                Console.SetCursorPosition(55, 10); Console.Write("NOTA 1");
                Console.SetCursorPosition(66, 10); Console.Write("NOTA 2");
                Console.SetCursorPosition(75, 10); Console.Write("NOTA 3");
                Console.SetCursorPosition(85, 10); Console.Write("NOTA FINAL");
                Console.SetCursorPosition(103, 10); Console.Write("DEFINITIVA");

                Console.SetCursorPosition(9, altura); Console.Write(myAlumno.Codigo);
                Console.SetCursorPosition(19, altura); Console.Write(myAlumno.Nombre);
                Console.SetCursorPosition(34, altura); Console.Write(myAlumno.Apellido);
                Console.SetCursorPosition(57, altura); Console.Write("{0:N1}", myAlumno.Nota1);
                Console.SetCursorPosition(67, altura); Console.Write("{0:N1}", myAlumno.Nota2);
                Console.SetCursorPosition(77, altura); Console.Write("{0:N1}", myAlumno.Nota3);
                Console.SetCursorPosition(87, altura); Console.Write("{0:N2}", myAlumno.NotaDef);
                Console.SetCursorPosition(104, altura); Console.Write(myAlumno.Caja);

                InsertarNombreModificar(posicion);

            }
            else
            {
                gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 22); Console.Write(" El usuario del codigo " + codigo + " No existe");
            }
            Console.SetCursorPosition(29, 29);
            Console.WriteLine("Pulse cualquier tecla para continuar");
            Console.SetCursorPosition(66, 29);
            Console.ReadLine();




        }


        static void InsertarNombreModificar(int pos)
        {
            bool EntradaValidaNombre = false;
            bool EntradaValidaCodigo = false;
            bool EntradaValidaApellido = false;
            bool EntradaValidaNota1 = false;
            bool EntradaValidaNota2 = false;
            bool EntradaValidaNota3 = false;
            bool EntradaValidaCaja = false;

            string codigo;
            string nombre;
            string apellido;
            string nota1;
            string nota2;
            string nota3;
            string caja;

            
            gui.Marco(1, 119, 1, 25);
            Console.SetCursorPosition(50, 5); Console.WriteLine("Alumno a modificar");
            gui.Linea(40, 6, 30);



            do
            {
                gui.BorrarLinea(34, 13, 64);
                Console.SetCursorPosition(10, 13); Console.Write("Digite nuevo Codigo del Alumno: ");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            
                do
                {
                    gui.BorrarLinea(33, 14, 64);
                    Console.SetCursorPosition(10, 14); Console.Write("Digite Nombres Alumno:");
                    nombre = Console.ReadLine();
                    if (!Vericar.Vacio(nombre))
                        if (Vericar.TipoTexto(nombre))
                            EntradaValidaNombre = true;
                } while (!EntradaValidaNombre);

                do
                {
                    gui.BorrarLinea(37, 15, 64);
                    Console.SetCursorPosition(10, 15); Console.Write("Digite apellidos: ");
                    apellido = Console.ReadLine();
                    if (!Vericar.Vacio(apellido))
                        if (Vericar.TipoTexto(apellido))
                            EntradaValidaApellido = true;
                } while (!EntradaValidaApellido);

                do
                {
                    gui.BorrarLinea(28, 16, 64);
                    Console.SetCursorPosition(10, 16); Console.Write("Digite la nota 1: ");
                    nota1 = Console.ReadLine();
                if (!Vericar.Vacio(nota1))
                    if (Vericar.TipoNumero(nota1))
                        if (Convert.ToDouble(nota1) >= 0 && Convert.ToDouble(nota1) <= 5)
                        {
                            EntradaValidaNota1 = true;
                        }
                        else
                        {
                            gui.BorrarLinea(40, 22, 64);
                            Console.SetCursorPosition(40, 22);
                            Console.Write("La nota debe estar entre 0 y 5");
                        }
                } while (!EntradaValidaNota1);

                do
                {
                    gui.BorrarLinea(28, 17, 64);
                    Console.SetCursorPosition(10, 17); Console.Write("Digite la nota 2: ");
                    nota2 = Console.ReadLine();
                if (!Vericar.Vacio(nota2))
                    if (Vericar.TipoNumero(nota2))
                        if (Convert.ToDouble(nota2) >= 0 && Convert.ToDouble(nota2) <= 5)
                        {
                            EntradaValidaNota2 = true;
                        }
                        else
                        {
                            gui.BorrarLinea(40, 22, 64);
                            Console.SetCursorPosition(40, 22);
                            Console.Write("La nota debe estar entre 0 y 5");
                        }

                } while (!EntradaValidaNota2);

                do
                {
                    gui.BorrarLinea(28, 18, 64);
                    Console.SetCursorPosition(10, 18); Console.Write("Digite la nota 3: ");
                    nota3 = Console.ReadLine();
                if (!Vericar.Vacio(nota3))
                    if (Vericar.TipoNumero(nota3))
                        if (Convert.ToDouble(nota3) >= 0 && Convert.ToDouble(nota3) <= 5)
                        {
                            EntradaValidaNota3 = true;
                        }
                        else
                        {
                            gui.BorrarLinea(40, 22, 64);
                            Console.SetCursorPosition(40, 22);
                            Console.Write("La nota debe estar entre 0 y 5");
                        }
                } while (!EntradaValidaNota3);


                //..........................................





                Alumno myAlumno = new Alumno();
                myAlumno.Codigo = Convert.ToInt32(codigo);
                myAlumno.Nombre = nombre;
                myAlumno.Apellido = apellido;
                myAlumno.Nota1 = Convert.ToDouble(nota1);
                myAlumno.Nota2 = Convert.ToDouble(nota2);
                myAlumno.Nota3 = Convert.ToDouble(nota3);
                myAlumno.NotaDef = (Convert.ToDouble(nota1) + Convert.ToDouble(nota2) + Convert.ToDouble(nota3)) / 3;


                if (myAlumno.NotaDef >= 3.5)
                {
                    myAlumno.Caja = "Aprobado";
                }
                else
                {
                    myAlumno.Caja = "Reprobado";
                }


                ListaAlumnos[pos]=myAlumno;
            
        }



        static void Eliminar()
        {
            string codigo;
            bool EntradaValidaCodigo = false;
            string ans = "No";
            Console.Clear();
            gui.Marco(1, 119, 1, 25);
            Console.SetCursorPosition(50, 5); Console.WriteLine("Alumno a modificar ");
            gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Alumno que desea eliminar: ");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (Existe(Convert.ToInt32(codigo)))
            {
                Alumno myAlumno = ObtenerDatos(Convert.ToInt32(codigo));
                int posicion = Posicion(Convert.ToInt32(codigo));
                int altura = 11;
                gui.Linea(3, 118, 9);
                gui.Linea(3, 118, 12);
                gui.Linea2(10, 11, 18);
                gui.Linea2(10, 11, 33);
                gui.Linea2(10, 11, 52);
                gui.Linea2(10, 11, 63);
                gui.Linea2(10, 11, 73);
                gui.Linea2(10, 10, 82);
                gui.Linea2(10, 11, 97);


                Console.SetCursorPosition(8, 10); Console.Write("CODIGO");
                Console.SetCursorPosition(23, 10); Console.Write("NOMBRES");
                Console.SetCursorPosition(39, 10); Console.Write("APELLIDOS");
                Console.SetCursorPosition(55, 10); Console.Write("NOTA 1");
                Console.SetCursorPosition(66, 10); Console.Write("NOTA 2");
                Console.SetCursorPosition(75, 10); Console.Write("NOTA 3");
                Console.SetCursorPosition(85, 10); Console.Write("NOTA FINAL");
                Console.SetCursorPosition(103, 10); Console.Write("DEFINITIVA");

                Console.SetCursorPosition(9, altura); Console.Write(myAlumno.Codigo);
                Console.SetCursorPosition(19, altura); Console.Write(myAlumno.Nombre);
                Console.SetCursorPosition(34, altura); Console.Write(myAlumno.Apellido);
                Console.SetCursorPosition(57, altura); Console.Write("{0:N1}", myAlumno.Nota1);
                Console.SetCursorPosition(67, altura); Console.Write("{0:N1}", myAlumno.Nota2);
                Console.SetCursorPosition(77, altura); Console.Write("{0:N1}", myAlumno.Nota3);
                Console.SetCursorPosition(87, altura); Console.Write("{0:N2}", myAlumno.NotaDef);
                Console.SetCursorPosition(104, altura); Console.Write(myAlumno.Caja);

                if (ans == "No")
                {
                    gui.BorrarLinea(34, 13, 64);
                    Console.SetCursorPosition(10, 13); Console.Write("Seguro desea borra el registro? Escriba si/no: ");
                    ans = Console.ReadLine();

                    if (ans == "Si" || ans == "si")
                    {
                        ListaAlumnos.RemoveAt(posicion);
                        Console.SetCursorPosition(30, 28); Console.Write("Registro eliminado! ");
                        
                    }

                    else if (ans == "No" || ans == "no")
                    {
                        ListaAlumnos.RemoveAt(posicion);
                        Console.SetCursorPosition(30, 28); Console.Write("Regresará al menu pricipal ");
                        
                    }

                    else
                    {
                        Console.SetCursorPosition(30, 28); Console.Write("Respuesta no valida ");
                    }

                       
                }
                

            }
            else
            {
                gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 22); Console.Write(" El usuario del codigo " + codigo + " No existe");
            }
            Console.SetCursorPosition(29, 29);
            //Console.WriteLine("Pulse cualquier tecla para continuar");
            Console.SetCursorPosition(66, 29);
            Console.ReadLine();




        }






        static bool Existe(int cod)
        {
            bool aux = false;

            foreach (Alumno myAlumno in ListaAlumnos)
            {
                if (myAlumno.Codigo == cod)
                    aux = true;
            }
            return aux;
        }

        static int Posicion(int cod)
        {
            int contador = -1;
            int cont = 0;

            foreach (Alumno myAlumno in ListaAlumnos)
            {
                contador++;
                if (myAlumno.Codigo == cod)
                    cont = contador;
                    

            }
            return cont;
        }


        static Alumno ObtenerDatos(int cod)
        {
            foreach (Alumno myAlumno in ListaAlumnos)
            {
                if (myAlumno.Codigo == cod)
                    return myAlumno;
            }
            return null;

        }

        static void EscrirArchivoXml()
        {
            XmlSerializer codificador = new XmlSerializer(typeof(List<Alumno>));
            TextWriter escribirXml = new StreamWriter("C:/Users/Steven/Documents/Sena/2do/POOB/Colegio/Datos/ArchivoAlumnos.xml");
            codificador.Serialize(escribirXml, ListaAlumnos);
            escribirXml.Close();
            Console.Clear();
            gui.Marco(1, 119, 1, 25);
            gui.BorrarLinea(40, 22, 80);
            Console.SetCursorPosition(40, 22); Console.Write(" Archivo guardado con exito... ");
            Console.SetCursorPosition(69, 22);
            Console.ReadLine();
        }

        static void LeerArchivoXml()
        {
            if (File.Exists("C:/Users/Steven/Documents/Sena/2do/POOB/Colegio/Datos/ArchivoAlumnos.xml"))
            {
                ListaAlumnos.Clear();
                XmlSerializer codificador = new XmlSerializer(typeof(List<Alumno>));
                FileStream leerXml = File.OpenRead("C:/Users/Steven/Documents/Sena/2do/POOB/Colegio/Datos/ArchivoAlumnos.xml");
                ListaAlumnos = (List<Alumno>)codificador.Deserialize(leerXml);
                leerXml.Close();
                Console.Clear();
                gui.Marco(1, 119, 1, 25);
                gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 22); Console.Write(" Archivo cargado con exito... ");
                Console.SetCursorPosition(69, 22);
                Console.ReadLine();
            }

            else
            {
                gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 22); Console.Write("Error, valide por favor ubicáción del archivo ");
            }
        }



    }
}
