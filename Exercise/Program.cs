using System.Security.AccessControl;
using Exercise.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Estudiante> studentsList = new List<Estudiante>();
        byte menu=0;
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
                        RegisterStudents(studentsList);
                        Console.WriteLine("¿Quieres añadir más estudiantes?");
                        Console.WriteLine("Si=Cualquier tecla          No=1");
                        AddStudents=Console.ReadLine();
                    } while (AddStudents != "1");
                break;
                case 2:
                    if (studentsList.Count > 0) 
                    {
                        do {
                            ResgisterQuices(studentsList);
                            Console.WriteLine("¿Quieres registrar los quices de otro estudiante?");
                            Console.WriteLine("Si=Cualquier tecla          No=1");
                            AddStudents=Console.ReadLine();
                        } while (AddStudents != "1");
                    } 
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("No es posible realizar esta accion\n\nPresione enter para continuar");
                        Console.ReadLine();
                    }
                break;
                default:
                    Console.WriteLine(":V");
                    Console.ReadLine(); 
                break;
            }
        } while (menu!=5);
    }
    public static void RegisterStudents(List<Estudiante> studentsList)
    {
        Console.Clear();
        string dato;
        long number;
        bool Flag;
        byte NumShort;
        Flag=true;
        Estudiante estudents = new Estudiante();
        if (studentsList.Count > 0) 
        {
            Console.WriteLine("Codigos utilizados: ");
            for (int i = 0; i < studentsList.Count; i++) 
            {
                Console.Write($"--{studentsList[i].Code}");
            }
        } 
        Console.WriteLine("\n\nIngrese el codigo del estudiante");
        dato=Console.ReadLine();
        while ((!long.TryParse(dato, out number)) || (dato.Length > 15) || (number<1)) {
            Console.Clear();
            Console.WriteLine("Ingrese un codigo diferente y de 15 caracteres maximo: ");
            dato=Console.ReadLine();
        }
        while (Flag) 
        {
            Console.Clear();
            NumShort=0;
            for (int i = 0; i < studentsList.Count; i++) 
            {
                if (number==studentsList[i].Code)
                {   
                    Console.Clear();
                    Console.WriteLine("Codigos utilizados: ");
                    for (int x = 0; x < studentsList.Count; x++) 
                    {
                        Console.Write($"--{studentsList[x].Code}");
                    }                    
                    Console.WriteLine("\n\nIngrese un codigo diferente para el estudiante");
                    dato=Console.ReadLine();
                    while ((!long.TryParse(dato, out number)) || (dato.Length > 15) || (number<1)) {
                        Console.WriteLine("Ingrese un codigo diferente y de 15 caracteres maximo: ");
                        dato=Console.ReadLine();
                    }
                    NumShort=1;                                    
                }
            }
            if (NumShort<1)
            {
                Flag=false;
            }
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
/*         
        Console.WriteLine(estudents.Code);
        Console.WriteLine(estudents.Nombre);
        Console.WriteLine(estudents.Edad);
        Console.WriteLine(estudents.Direccion);
        Console.WriteLine(estudents.Email); 
*/
        studentsList.Add(estudents);
    }
    public static void ResgisterQuices(List<Estudiante> studentsList)
    {
        Console.Clear();
        string dato;
        long number;
        bool Flag;
        byte NumShort;
        do {
            NumShort=0;
            Console.WriteLine("Codigos disponibles: ");
            for (int i = 0; i < studentsList.Count; i++) 
            {
                Console.Write($"--{studentsList[i].Code}");
            }
            Console.WriteLine("\n\nIngrese el codigo del estudiante");
            dato=Console.ReadLine();
            while ((!long.TryParse(dato, out number)) || (number<1)) {
                Console.Clear();
                Console.WriteLine("Ingrese un codigo exitente: ");
                dato=Console.ReadLine();
            }
            for (int i = 0; i < studentsList.Count; i++) 
            {
                if (number==studentsList[i].Code)
                {
                    studentsList[i].Quices.Add(1.5);
                    studentsList[i].Quices.Add(2.5);
                    studentsList[i].Quices.Add(3.5);
                    studentsList[i].Quices.Add(4.5);
                    Console.WriteLine(studentsList[i].Quices.Count);
                    Console.ReadLine();
                    Console.WriteLine(studentsList[i].Quices[0]);
                    Console.WriteLine(studentsList[i].Quices[1]);
                    Console.WriteLine(studentsList[i].Quices[2]);
                    Console.WriteLine(studentsList[i].Quices[3]);
                    Console.ReadLine();
                    NumShort=1;
                }
            }
        } while (NumShort<1);

        Console.WriteLine("\n\n");
    }
}
