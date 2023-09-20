using System.Security.AccessControl;
using Exercise.Entities;
using Newtonsoft.Json;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        int entero1=0;
        int entero2=0;
        int entero3=0;
        byte menu;
        string AddStudents;
        string anotherMenu="";
        List<Estudiante> studentsList = new List<Estudiante>();
        if (File.Exists("boletin.json"))
        {
            studentsList = MyFunctions.LoadData();
            for (int i = 0; i < studentsList.Count; i++)
            {
                if (studentsList[i].Quices.Count > 4)
                {
                    entero1+=1;
                }
                if (studentsList[i].Parciales.Count > 3)
                {
                    entero2+=1;
                }
                if (studentsList[i].Trabajos.Count > 2)
                {
                    entero3+=1;
                }
            }
        }
        else 
        {
            MyFunctions.SaveData(studentsList);
        }
        do {
            Console.Clear();
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1-Registrar estudiantes");
            Console.WriteLine("2-Eliminar estudiantes");
            Console.WriteLine("3-Registrar notas");
            Console.WriteLine("4-Editar informacion");
            Console.WriteLine("5-Reportes e informes");
/*
            Console.WriteLine("5.1-Notas Generales");
            Console.WriteLine("5.2-Notas Finales"); */
            Console.WriteLine("6-Salir");
            menu=byte.Parse(Console.ReadLine());
            switch (menu) {
                case 1:
                    do {
                        MyFunctions.RegisterStudents(studentsList);
                        Console.WriteLine("¿Quieres añadir más estudiantes?");
                        Console.WriteLine("Si=1          No=Cualquier tecla");
                        AddStudents=Console.ReadLine();
                    } while (AddStudents == "1");
                    break;
                case 2:
                    if (studentsList.Count > 0 && studentsList.Count<=entero1 && studentsList.Count<=entero2 && studentsList.Count<=entero3 )
                    {
                        do {                        
                            (entero1, entero2, entero3)=MyFunctions.RemoveItem(studentsList, entero1, entero2, entero3);
                            if (studentsList.Count > 0)
                            {
                                Console.WriteLine("¿Quieres eliminar más estudiantes?");
                                Console.WriteLine("Si=1          No=Cualquier tecla");
                                AddStudents=Console.ReadLine();
                            }
                            else 
                            {
                                Console.WriteLine("Ya fueron eliminados todos los estudiantes\n\nRegistre más estudiantes para acceder a esta opcion\n\nPresione enter para continuar");
                                Console.ReadLine();
                                AddStudents="0";
                            }
                        } while (AddStudents == "1");
                    }
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("Para poder eliminar un estudiante debe registrar todos los estudiantes con sus respectivas notas\n\nPresione enter para continuar");
                        Console.ReadLine();
                    }
                        break;
                case 3:
                    Console.Clear();
                    (entero1, entero2, entero3)=MyFunctions.MenuNotas(studentsList, entero1, entero2, entero3);
                        break;
                case 4:
                    Console.Clear();
                    MyFunctions.MenuEditarInfo(studentsList, entero1, entero2, entero3);
                        break;
                case 5:
                    do {                        
                        Console.Clear();
                        Console.WriteLine("Ingrese una opcion");
                        Console.WriteLine("1-Reporte notas");
                        Console.WriteLine("2-Reporte definitivas");
                        Console.WriteLine("3-Volver");
                        anotherMenu=Console.ReadLine(); 
                        switch (anotherMenu)
                        {
                            case "1":
                                MyFunctions.printNotes(studentsList, entero1, entero2, entero3);
                                break;
                            case "2":
                                MyFunctions.printDefNotes(studentsList, entero1, entero2, entero3);
                                break;
                            case "3":
                                break; 
                            default:
                                Console.Clear();
                                Console.WriteLine("Opcion invalida\n\nPresione enter para continuar");
                                Console.ReadLine();
                                break;                                    
                        }                       
                    } while (anotherMenu != "3");
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Adios...");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ingrese una opcion valida");
                    Console.ReadLine(); 
                    break;
            }
        } while (menu!=6);
    }
    
}
