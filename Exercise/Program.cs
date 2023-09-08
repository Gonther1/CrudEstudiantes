using System.Security.AccessControl;
using Exercise.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Estudiante> studentsList = new List<Estudiante>();
        byte menu=0;
        string dato;
        long number;
        string AddStudents;
        // double notes;
        do {
            Console.Clear();
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1-Registrar estudiantes");
            Console.WriteLine("2-Registrar Quices");
            Console.WriteLine("3-Registrar Parciales");
            Console.WriteLine("4-Registrar Trabajos");
            Console.WriteLine("5-Salir");
            menu=byte.Parse(Console.ReadLine());
            switch (menu) {
                case 1:
                    do {
                        Console.Clear();
                        Estudiante estudents = new Estudiante();
                        Console.WriteLine("Codigos utilizados: ");
                        if (studentsList.Count > 0) 
                        {
                            for (int i = 0; i < studentsList.Count; i++) 
                            {
                                // Console.Write(studentsList[i].Code);
                                // Console.WriteLine(string.Join(",", studentsList[i].Code));
                            }
                            Console.WriteLine("\nPresione una tecla para continuar");
                            Console.ReadLine();
                        } else 
                        {
                            Console.WriteLine("\nNo hay codigos utilizados aun\nPresione una tecla para continuar");
                            Console.ReadLine();
                        }
                        Console.Clear();
                        Console.WriteLine("Ingrese el codigo del estudiante");
                        dato=Console.ReadLine();
                        while ((!long.TryParse(dato, out number)) || (dato.Length > 15) || (number<1)) {
                            Console.WriteLine("Ingrese un codigo diferente y de 15 caracteres maximo: ");
                            dato=Console.ReadLine();
                        }
                        estudents.Code=number;
                        Console.WriteLine("Ingrese el nombre del estudiante");
                        dato=Console.ReadLine();
                        while (dato.Length > 40 || dato.Length < 1) 
                        {
                            Console.WriteLine("Ingrese un nombre valido para el estudiante");
                            dato=Console.ReadLine();
                        }
                        estudents.Nombre=dato;
                        Console.WriteLine("Ingrese el correo del estudiante");
                        dato=Console.ReadLine();
                        while (dato.Length > 40 || dato.Length < 1) 
                        {
                            Console.WriteLine("Ingrese un nombre valido para el estudiante");
                            dato=Console.ReadLine();
                        }
                        estudents.Email=dato;
                        Console.WriteLine("Ingrese la edad del estudiante");
                        dato=Console.ReadLine();
                        while ((!long.TryParse(dato, out number)) || (dato.Length > 3) || (number<1))  
                        {
                            Console.WriteLine("Ingrese una edad valida para el estudiante");
                            dato=Console.ReadLine();
                        }
                        estudents.Edad=number;
                        Console.WriteLine("Ingrese la direccion del estudiante");
                        dato=Console.ReadLine();
                        while (dato.Length > 35 || dato.Length < 1) 
                        {
                            Console.WriteLine("Ingrese una direccion valida para el estudiante");
                            dato=Console.ReadLine();
                        }
                        estudents.Direccion=dato;
                        Console.WriteLine(estudents.Code);
                        Console.WriteLine(estudents.Nombre);
                        Console.WriteLine(estudents.Edad);
                        Console.WriteLine(estudents.Direccion);
                        Console.WriteLine(estudents.Email);
                        studentsList.Add(estudents);
                        Console.WriteLine("¿Quieres añadir más estudiantes?");
                        Console.WriteLine("Si=Cualquier tecla          No=1");
                        AddStudents=Console.ReadLine();
                    } while (AddStudents != "1");
                break;
                case 2:

                break;
                default:
                    Console.WriteLine(":V");
                    Console.ReadLine(); 
                break;
            }
        } while (menu!=5);
    }
}
