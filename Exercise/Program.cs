using Exercise.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Estudiante> studentsList = new List<Estudiante>();
        int menu=0;
        double notes;
        do {
            Console.Clear();
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1-Registrar estudiantes");
            Console.WriteLine("2-Salir");
            menu=int.Parse(Console.ReadLine());
            switch (menu) {
                case 1:
                    Estudiante estudents = new Estudiante();
                    estudents.Code = int.Parse(Console.ReadLine());

                    // estudents.Nombre = "Andres";
                    // estudents.Email = "luisandres";
                    // estudents.Edad = 17;
                    // estudents.Direccion = "hola";
                    Console.WriteLine("Ingrese la nota del trabajo");
                    notes=double.Parse(Console.ReadLine());
                    estudents.Trabajos.Add(notes);
                    Console.WriteLine("Ingrese la nota del parcial");
                    notes=double.Parse(Console.ReadLine());
                    estudents.Parciales.Add(notes);
                    // estudents.Quices.Add(1.5);
                    // estudents.Quices.Add(2.5);
                    // estudents.Quices.Add(3.5);
                    studentsList.Add(estudents);
                    Console.Clear();
                    Console.WriteLine(estudents.Trabajos[0]);
                    Console.WriteLine(estudents.Parciales[0]);
                    // Console.WriteLine(estudents.Quices[2]);
                    Console.ReadLine(); 
                break;
                case 2:
                break;
                default:
                    Console.WriteLine(":V");
                    Console.ReadLine(); 
                break;
            }
        } while (menu!=2);
    }
}