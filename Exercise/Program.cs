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
        byte menu=0;
        byte menuThree=0;
        string AddStudents;
        List<Estudiante> studentsList = new List<Estudiante>();
        if (File.Exists("boletin.json"))
        {
            studentsList = LoadData();
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
            Console.WriteLine("El archivo no esta creado y creo uno nuevo");
            Console.ReadLine();
            SaveData(studentsList);
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
                        RegisterStudents(studentsList);
                        Console.WriteLine("¿Quieres añadir más estudiantes?");
                        Console.WriteLine("Si=1          No=Cualquier tecla");
                        AddStudents=Console.ReadLine();
                    } while (AddStudents == "1");
                break;
                case 2:
                    if (studentsList.Count > 0 && studentsList.Count<=entero1 && studentsList.Count<=entero2 && studentsList.Count<=entero3 )
                    {
                        RemoveItem(studentsList);
                        entero1-=1;
                        entero2-=1;
                        entero3-=1;
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
                    (entero1, entero2, entero3)=MenuNotas(studentsList, entero1, entero2, entero3);
                    break;
                case 4:
                    Console.Clear();
                    MenuEditarInfo(studentsList);
/*                     Console.Clear();
                    printNotes(studentsList,entero1,entero2,entero3); */
                    break;
                case 5:
/*                     Console.Clear();
                    printDefNotes(studentsList,entero1,entero2,entero3); */
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
        Console.WriteLine(entero1);
        Console.WriteLine(entero2);
        Console.WriteLine(entero3);
        Console.ReadLine();
    }
    public static string returnString(string texto, byte max)
    {   
        Console.Clear();
        string dato;
        Console.WriteLine($"\n\n{texto} del estudiante");
        dato=Console.ReadLine();
        while (dato.Length > max || dato.Length < 1) 
        {
            Console.Clear();
            Console.WriteLine($"\n\n{texto} valido(a) para el estudiante");
            dato=Console.ReadLine();
        }
        return dato;
    } 
    public static long returnNumber(string texto, byte max, List<Estudiante> studentsList)
    {
        Console.Clear();
        long number;
        string dato;
        if (max==15 && studentsList.Count > 0)
        {
            Console.WriteLine("Codigos registrados: ");
            for (byte i = 0; i < studentsList.Count; i++) 
            {
                Console.Write($"--{studentsList[i].Code}");  
            }
        }
        Console.WriteLine($"\n\n{texto} del estudiante");
        dato=Console.ReadLine();
        while ((!long.TryParse(dato, out number)) || (dato.Length > max) || (number<1))  
        {
            Console.Clear();
            Console.WriteLine($"\n\n{texto} invalido(a)\n\nIngrese otro");
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
        number=returnNumber("Codigo",15, studentsList);
        while (Flag) 
        {
            Console.Clear();
            NumShort=0;
            for (int i = 0; i < studentsList.Count; i++) 
            {
                if (number==studentsList[i].Code)
                {   
                    Console.Clear();
                    number=returnNumber("Codigo",15, studentsList);
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
        dato=returnString("Email",40);
        estudents.Email=dato;
        number=returnNumber("Edad",3, studentsList);
        estudents.Edad=number;
        dato=returnString("Direccion",35);
        estudents.Direccion=dato;
        studentsList.Add(estudents);
        SaveData(studentsList);
    }
    public static void PrintCodes(List<Estudiante> studentsList, string option)
    {
        int type=0;
        Console.WriteLine("Codigos registrados: ");
        for (byte i = 0; i < studentsList.Count; i++) 
        {
            switch (option)
            {
                case "quiz":
                    type=studentsList[i].Quices.Count;
                    break;
                case "parcial":
                    type=studentsList[i].Parciales.Count;
                    break;
                case "trabajo":
                    type=studentsList[i].Trabajos.Count;
                    break;
            }
            if (type <1) 
            {
                Console.Write($"--{studentsList[i].Code}");  
            }
        }
    }
    public static long CodeRepeat(List<Estudiante> studentsList, string option)
    {
        Console.Clear();
        string datoString;
        long longNumber;
        PrintCodes(studentsList, option);
        Console.WriteLine("\n\nIngrese el codigo del estudiante");
        datoString=Console.ReadLine();
        while ((!long.TryParse(datoString, out longNumber)) || (longNumber<1)) {
            Console.Clear();
            PrintCodes(studentsList,option);
            Console.WriteLine("\n\nIngrese un codigo exitente: ");
            datoString=Console.ReadLine();
        }
        return longNumber;
    }
    public static void RegisterNotes(List<Estudiante> studentsList,string option, byte cantNotes,byte i)
    {
        string dato;
        double numDouble;
        double contNotes=0;
        double defNote;
        double littleDouble;
        double factor=0;
        for (byte x=0; x <= cantNotes; x++)
        {
            Console.WriteLine($"Ingrese la nota del {option} {x+1}: ");
            dato=Console.ReadLine();
            while ((!double.TryParse(dato, out numDouble)) || (numDouble<1) || (numDouble>100)) {
                Console.Clear();
                Console.WriteLine($"Ingrese una nota valida del {option} {x+1}: ");
                dato=Console.ReadLine();
            }
            factor=Math.Pow(10,1);
            littleDouble=Math.Floor(numDouble * factor) / factor;
            switch (option)
            {
                case "quiz":
                    studentsList[i].Quices.Add(littleDouble);
                    SaveData(studentsList);
                    break;
                case "parcial":
                    studentsList[i].Parciales.Add(littleDouble);
                    SaveData(studentsList);
                    break;
                case "trabajo":
                    studentsList[i].Trabajos.Add(littleDouble);
                    SaveData(studentsList);
                    break;
            }
            contNotes+=littleDouble;
        }
        switch (option)
        {
            case "quiz":
                defNote=(contNotes/4)*0.25;
                littleDouble=Math.Floor(defNote * factor) / factor;
                studentsList[i].Quices.Add(littleDouble);
                SaveData(studentsList);
                break;
            case "parcial":
                defNote=(contNotes/3)*0.60;
                littleDouble=Math.Floor(defNote * factor) / factor;
                studentsList[i].Parciales.Add(littleDouble);
                SaveData(studentsList);
                break;
            case "trabajo":
                defNote=(contNotes/2)*0.15;
                littleDouble=Math.Floor(defNote * factor) / factor;
                studentsList[i].Trabajos.Add(littleDouble);
                SaveData(studentsList);
                break;
        }
    }
    public static int RegisterSubjects(List<Estudiante> studentsList, int entero, string option, byte range)
    {
        string dato;
        long number;
        bool Flag;
        int NumShort=entero;
        int type=0;
        do 
        {
            Console.Clear();
            Flag=true;
            do 
            {
                number=CodeRepeat(studentsList,option);
                for (byte i = 0; i < studentsList.Count; i++) 
                {
                    if (number==studentsList[i].Code)
                    {
                        switch (option)
                        {
                            case "quiz":
                                type=studentsList[i].Quices.Count;
                                break;
                            case "parcial":
                                type=studentsList[i].Parciales.Count;
                                break;
                            case "trabajo":
                                type=studentsList[i].Trabajos.Count;
                                break;
                        }
                        if (type <1)
                        {
                            RegisterNotes(studentsList,option,range,i);
                            NumShort++;
                            Flag=false;
                        }
                        else 
                        {
                            Console.WriteLine("No es posible realizar esta accion");
                        }
                    }
                }
            } while (Flag);
            if (studentsList.Count > NumShort)
            {
                Console.WriteLine("¿Quieres añadir las notas de otro estudiante?");
                Console.WriteLine("Si=1          No=Cualquier tecla");
                dato=Console.ReadLine();
            }
            else 
            {   
                Console.Clear();
                Console.WriteLine("No quedan más estudiantes por registrar en esta area\n\nPresione enter para continuar");
                Console.ReadLine();
                dato="0";
            }
        } while (dato=="1");
        return NumShort;
    }   
    public static void printNotes(List<Estudiante> studentsList, int entero1, int entero2, int entero3)
    {
        if ((studentsList.Count > 0)&&(studentsList.Count == entero1)&&(studentsList.Count == entero2)&&(studentsList.Count == entero3))
        {
            Console.Clear();
            Console.WriteLine("---Codigo---Nombre---Quices---Trabajos---Parciales---");
            for (byte i = 0; i < studentsList.Count; i++)
            {
                Console.WriteLine($"---{studentsList[i].Code}---{studentsList[i].Nombre}--Q--{Math.Round(studentsList[i].Quices[0],1)}--{studentsList[i].Quices[1]}--{studentsList[i].Quices[2]}--{studentsList[i].Quices[3]}---T---{studentsList[i].Trabajos[0]}--{studentsList[i].Trabajos[1]}---P---{studentsList[i].Parciales[0]}--{studentsList[i].Parciales[1]}--{studentsList[i].Parciales[2]}");
            }
            
            Console.ReadLine();
        }
        else 
        {
            Console.WriteLine("No puedes realizar esta accion\n\nRevisa que hayas registrado estudiantes y que todos tengan todas las notas registradas\n\nPresione enter para continuar...");
            Console.Read();
        }
    }
    public static void printDefNotes(List<Estudiante> studentsList, int entero1, int entero2, int entero3)
    {
        if ((studentsList.Count > 0)&&(studentsList.Count == entero1)&&(studentsList.Count == entero2)&&(studentsList.Count == entero3))
        {
            Console.Clear();
            Console.WriteLine("---Codigo---Nombre---Definitiva Quices---Definitiva Trabajos---Definitiva Parciales--");
            for (byte i = 0; i < studentsList.Count; i++)
            {
                Console.WriteLine($"---{studentsList[i].Code}---{studentsList[i].Nombre}---{studentsList[i].Quices[4]}---{studentsList[i].Trabajos[2]}---{studentsList[i].Parciales[3]}");
            }
            Console.Read();
        }
        else 
        {
            Console.WriteLine("No puedes realizar esta accion\n\nRevisa que hayas registrado estudiantes y que todos tengan todas las notas registradas\n\nPresione enter para continuar...");
            Console.Read();
        }
    }
    public static void SaveData(List<Estudiante> studentsList)
    {
        string json = JsonConvert.SerializeObject(studentsList,Formatting.Indented);
        File.WriteAllText("boletin.json",json);
    }

    // Para cargar
    public static List<Estudiante> LoadData()
    {
        using (StreamReader reader = new StreamReader("boletin.json"))
        {
            string json = reader.ReadToEnd();
            return System.Text.Json.JsonSerializer
            .Deserialize<List<Estudiante>>(json, new System.Text.Json.JsonSerializerOptions()
            { PropertyNameCaseInsensitive = true }) ?? new List<Estudiante>();
        }
    }
    public static void RemoveItem(List<Estudiante> studentsList)
    {
        long longNumber;
        longNumber=returnNumber("Codigo",15,studentsList);
        Estudiante studentToRemove = studentsList.FirstOrDefault(x => x.Code.Equals(longNumber)) ?? new Estudiante();
        if (studentToRemove != null)
        {
            Console.WriteLine($"El estudiante {studentToRemove.Nombre} fue eliminado con exito\n\nPresione enter para continuar");
            Console.ReadLine();
            studentsList.Remove(studentToRemove);
            SaveData(studentsList);
        }
    }
    public static (int, int, int) MenuNotas(List <Estudiante> studentsList, int entero1, int entero2, int entero3)
    {
        byte menuThree=0;
        do 
        {
            Console.Clear();
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1-Registrar quices");
            Console.WriteLine("2-Registrar parciales");
            Console.WriteLine("3-Registrar trabajos");
            Console.WriteLine("4-Volver");
            menuThree=byte.Parse(Console.ReadLine());
            switch (menuThree)
            {
            case 1:
                if (studentsList.Count > 0) 
                {
                    if (studentsList.Count > entero1) 
                    {
                        entero1=RegisterSubjects(studentsList,entero1,"quiz",3);
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
            case 2:
                if (studentsList.Count > 0) 
                {
                    if (studentsList.Count > entero2) 
                    {
                        entero2=RegisterSubjects(studentsList,entero2,"parcial",2);
                    }    
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("Ya fueron registrados los parciales de todos los estudiantes\n\nRegistre más estudiantes para acceder a esta opcion\n\nPresione una tecla para continuar");
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
                if (studentsList.Count > 0) 
                {
                    if (studentsList.Count > entero3) 
                    {
                        entero3=RegisterSubjects(studentsList,entero3,"trabajo",1);
                    }    
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("Ya fueron registrados los trabajos de todos los estudiantes\n\nRegistre más estudiantes para acceder a esta opcion\n\nPresione una tecla para continuar");
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
            case 4:
                break;
            default:
                Console.Clear();
                Console.WriteLine("Ingrese una opcion valida\n\nPresione enter para continuar...");
                Console.ReadLine();
                break;
            }
        } while (menuThree!=4);
        return (entero1, entero2, entero3);
    }
    public static void MenuEditarInfo(List <Estudiante> studentsList)
    {
        byte menu=0;
        long number=0;
        string dato;
        bool Flag;
        do 
        {
            Console.Clear();
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1-Editar datos del estudiante");
            Console.WriteLine("2-Editar notas del estudiante");
            Console.WriteLine("3-Volver");
            menu=byte.Parse(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    if (studentsList.Count > 0)
                    {
                        do 
                        {
                            Console.Clear();
                            Flag=true;
                            number=returnNumber("Codigo", 15, studentsList);
                            for (byte i = 0; i < studentsList.Count; i++) 
                            {
                                if (number==studentsList[i].Code)
                                {
                                    do 
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ingrese que el numero del dato que quiere editar");
                                        Console.WriteLine("\n1-Nombre\n2-Email\n3-Edad\n4-Direccion\n5-Volver");
                                        dato=Console.ReadLine();
                                        switch (dato)
                                        {
                                            case "1":
                                                Console.Clear();
                                                dato=returnString("Nombre",40);
                                                studentsList[i].Nombre=dato;
                                                SaveData(studentsList);
                                                break;
                                            case "2":
                                                Console.Clear();
                                                dato=returnString("Email",40);
                                                studentsList[i].Email=dato;
                                                SaveData(studentsList);
                                                break;
                                            case "3":
                                                Console.Clear();
                                                number=returnNumber("Edad",3, studentsList);
                                                studentsList[i].Edad=number;
                                                SaveData(studentsList);
                                                break;
                                            case "4":
                                                Console.Clear();
                                                dato=returnString("Direccion",35);
                                                studentsList[i].Direccion=dato;
                                                SaveData(studentsList);
                                                break;
                                            default:
                                                break;
                                        }
                                    } while (dato != "5");
                                }
                            }
                            Console.WriteLine("¿Quieres editar más estudiantes?");
                            Console.WriteLine("Si=1          No=Cualquier tecla");
                            dato=Console.ReadLine();
                        } while (dato == "1");
                    }
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("No se puede realizar esta opcion\n\nPresione enter para continuar...");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    if (studentsList.Count > 0)
                    {
                        do 
                        {
                            Console.Clear();
                            Flag=true;
                            number=returnNumber("Codigo", 15, studentsList);
                            for (byte i = 0; i < studentsList.Count; i++) 
                            {
                                if (number==studentsList[i].Code)
                                {
                                    do 
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ingrese que el numero del dato que quiere editar");
                                        Console.WriteLine("\n1-Nombre\n2-Email\n3-Edad\n4-Direccion\n5-Volver");
                                        dato=Console.ReadLine();
                                        switch (dato)
                                        {
                                            case "1":
                                                Console.Clear();
                                                dato=returnString("Nombre",40);
                                                studentsList[i].Nombre=dato;
                                                SaveData(studentsList);
                                                break;
                                            case "2":
                                                Console.Clear();
                                                dato=returnString("Email",40);
                                                studentsList[i].Email=dato;
                                                SaveData(studentsList);
                                                break;
                                            case "3":
                                                Console.Clear();
                                                number=returnNumber("Edad",3, studentsList);
                                                studentsList[i].Edad=number;
                                                SaveData(studentsList);
                                                break;
                                            case "4":
                                                Console.Clear();
                                                dato=returnString("Direccion",35);
                                                studentsList[i].Direccion=dato;
                                                SaveData(studentsList);
                                                break;
                                            default:
                                                break;
                                        }
                                    } while (dato != "5");
                                }
                            }
                            Console.WriteLine("¿Quieres editar más estudiantes?");
                            Console.WriteLine("Si=1          No=Cualquier tecla");
                            dato=Console.ReadLine();
                        } while (dato == "1");
                    }
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("No se puede realizar esta opcion\n\nPresione enter para continuar...");
                        Console.ReadLine();
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ingrese una opcion valida");
                    Console.ReadLine();
                    break;
            }
        } while (menu!=3);
    }
}
