namespace Exercise.Entities
{
    public class Estudiante
    {
        private int code;
        private string nombre;
        private string email;
        private int edad;
        private string direccion;
        // private List<double> quices;
        // private List<double> trabajos;
        // private List<double> parciales;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }


        public string Direccion
        {
            get { return direccion;}
            set { direccion = value;}
        }


/*         public List<double> Quices
        {
            get { return quices; }
            set { quices = value; }
        }


        public List<double> Trabajos
        {
            get { return trabajos;}
            set { trabajos = value;}
        }


        public List<double> Parciales
        {
            get { return parciales;}
            set { parciales = value;}
        } */

        public Estudiante()
        {
            
        }
        public Estudiante(int code, string nombre, string email,int edad, string direccion)
        {
            this.code = code;
            this.nombre = nombre;
            this.email = email;
            this.edad = edad;
            this.direccion = direccion;
            // this.quices = quices;
            // this.trabajos = trabajos;
            // this.parciales = parciales;
        } 
    }
}