using Exercise.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Estudiante> studentsList = new List<Estudiante>();
        int menu=0;
        do {
            Console.Clear();
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1-Registrar estudiantes");
            Console.WriteLine("2-Salir");
            menu=int.Parse(Console.ReadLine());
            switch (menu) {
                case 1:
                    Estudiante estudents = new Estudiante();
                    estudents.Code = 1;
                    estudents.Nombre = "Andres";
                    estudents.Email = "luisandres";
                    estudents.Edad = 17;
                    estudents.Direccion = "hola";
                    studentsList.Add(estudents);
                    // estudents.Trabajos.Add(1.7);
                    // estudents.Parciales.Add(4.5);
                    // estudents.Quices.Add(1.5);
                    // estudents.Quices.Add(2.5);
                    // estudents.Quices.Add(3.5);
                    // studentsList.Add(estudents);
                    // Console.WriteLine("Hello World");
                    // Console.ReadLine(); 
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