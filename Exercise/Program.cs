using System.Security.AccessControl;
using Exercise.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Estudiante> studentsList = new List<Estudiante>();
        byte menu=0;
        string AddStudents;
        int entero=0;
        // double notes;
        do {
            Console.Clear();
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1-Registrar estudiantes");
            Console.WriteLine("2-Registrar Quices");
            Console.WriteLine("3-Registrar Parciales");
            Console.WriteLine("4-Registrar Trabajos");
            Console.WriteLine("5-Notas Generales");
            Console.WriteLine("6-Notas Finales");
            Console.WriteLine("7-Salir");
            menu=byte.Parse(Console.ReadLine());
            switch (menu) {
                case 1:
                    do {
                        RegisterStudents(studentsList);
                        Console.WriteLine("¿Quieres añadir más estudiantes?");
                        Console.WriteLine("Si=1          No=Cualquier tecla");
                        AddStudents=Console.ReadLine();
                    } while (AddStudents == "1");
                break;
                case 2:
                    if (studentsList.Count > 0) 
                    {
                        if (studentsList.Count > entero) 
                        {
                            entero=ResgisterQuices(studentsList,entero);
                        }    
                        else 
                        {
                            Console.Clear();
                            Console.WriteLine("Ya fueron registrados los quices de todos los estudiantes\n\nRegistre más estudiantes para acceder a esta opcion\n\nPresione una tecla para continuar");
                            Console.ReadLine();
                        }                    
                    } 
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("No es posible realizar esta accion\n\nPresione enter para continuar");
                        Console.ReadLine();
                    }
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Console.WriteLine("---Codigo---Nombre---Quices---");
                    for (byte i = 0; i < studentsList.Count; i++)
                    {
                        Console.WriteLine($"---{studentsList[i].Code}---{studentsList[i].Nombre}--{studentsList[i].Quices[0]}--{studentsList[i].Quices[1]}--{studentsList[i].Quices[2]}--{studentsList[i].Quices[3]--}");
                    }
                    Console.ReadLine();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine(":V");
                    Console.ReadLine(); 
                break;
            }
        } while (menu!=7);
    }
    public static string returnString(string texto byte max)
    {   
        Console.Clear();
        string dato;
        Console.WriteLine($"{texto} del estudiante");
        dato=Console.ReadLine();
        while (dato.Length > max || dato.Length < 1) 
        {
            Console.WriteLine($"{texto} valido(a) para el estudiante");
            dato=Console.ReadLine();
        }
        return dato;
    } 
    public static long returnNumber(string texto, byte max)
    {
        Console.Clear();
        long number;
        string dato;
        Console.WriteLine($"{texto} del estudiante");
        dato=Console.ReadLine();
        while ((!long.TryParse(dato, out number)) || (dato.Length > max) || (number<1))  
        {
            Console.WriteLine($"{texto} valido(a) para el estudiante");
            dato=Console.ReadLine();
        }
        return number;
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
        number=returnNumber("Codigo",15);
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
        dato=returnString("Nombre",40);
        estudents.Nombre=dato;
        dato=returnString("Correo",40);
        estudents.Email=dato;
        number=returnNumber("Edad",3);
        estudents.Edad=number;
        dato=returnString("Direccion",35);
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
    public static void PrintCodes(List<Estudiante> studentsList)
    {
        Console.WriteLine("Codigos disponibles: ");
        for (byte i = 0; i < studentsList.Count; i++) 
        {
            if (studentsList[i].Quices.Count <1) 
            {
                Console.Write($"--{studentsList[i].Code}");  
            }
        }
    }
    public static long CodeRepeat(List<Estudiante> studentsList)
    {
        Console.Clear();
        string datoString;
        long longNumber;
        PrintCodes(studentsList);
        Console.WriteLine("\n\nIngrese el codigo del estudiante");
        datoString=Console.ReadLine();
        while ((!long.TryParse(datoString, out longNumber)) || (longNumber<1)) {
            Console.Clear();
            PrintCodes(studentsList);
            Console.WriteLine("\n\nIngrese un codigo exitente: ");
            datoString=Console.ReadLine();
        }
        return longNumber;
    }
    public static void RegisterNotes(List<Estudiante> studentsList,string option, byte cantNotes,byte i)
    {
        string dato;
        double numDouble;
        for (byte x=0; x <= cantNotes; x++)
        {
            Console.WriteLine($"Ingrese la nota del {option} {x+1}: ");
            dato=Console.ReadLine();
            while ((!double.TryParse(dato, out numDouble)) || (numDouble<1) || (numDouble>100)) {
                Console.Clear();
                Console.WriteLine($"Ingrese una nota valida del {option} {x+1}: ");
                dato=Console.ReadLine();
            }
            switch (option)
            {
                case "quiz":
                    studentsList[i].Quices.Add(numDouble);
                    break;
                case "parcial":
                    studentsList[i].Parciales.Add(numDouble);
                    break;
                case "trabajo":
                    studentsList[i].Trabajos.Add(numDouble);
                    break;
            }
        }
    }
    public static int ResgisterQuices(List<Estudiante> studentsList, int entero)
    {
        string dato;
        long number;
        double numDouble;
        bool Flag;
        int NumShort=entero;
        do 
        {
            Console.Clear();
            Flag=true;
            do 
            {
                number=CodeRepeat(studentsList);
                for (byte i = 0; i < studentsList.Count; i++) 
                {
                    if (number==studentsList[i].Code)
                    {
                        if (studentsList[i].Quices.Count <1 )
                        {
                            RegisterNotes(studentsList,"quiz",3,i);
                            NumShort++;
                            Flag=false;
                            Console.WriteLine(studentsList[i].Quices.Count);
                        }
                        else 
                        {
                            Console.WriteLine("Np es posible realizar esta accion");
                        }
                    }
                }
            } while (Flag);
            if (studentsList.Count > NumShort)
            {
                Console.WriteLine("¿Quieres añadir las notas de quices de otro estudiante?");
                Console.WriteLine("Si=1          No=Cualquier tecla");
                dato=Console.ReadLine();
            }
            else 
            {   
                Console.Clear();
                Console.WriteLine("No quedan más estudiantes por registrar los quices\n\nPresione enter para continuar");
                Console.ReadLine();
                dato="0";
            }
        } while (dato=="1");
        return NumShort;
    }   
}
