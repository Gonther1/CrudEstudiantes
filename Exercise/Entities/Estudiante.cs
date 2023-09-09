namespace Exercise.Entities
{
    public class Estudiante
    {
        private long code;
        private string nombre;
        private string email;
        private long edad;
        private string direccion;
        private List<double> quices = new List<double> ();
        private double[]trabajos = new double[2];
        private double[]parciales = new double[3];

        public long Code
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


        public long Edad
        {
            get { return edad; }
            set { edad = value; }
        }


        public string Direccion
        {
            get { return direccion;}
            set { direccion = value;}
        }

        public List<double> Quices
        {
            get { return quices; }
            set { quices = value; }
        }


        public double[] Trabajos
        {
            get { return trabajos;}
            set { trabajos = value;}
        }


        public double[] Parciales
        {
            get { return parciales;}
            set { parciales = value;}
        } 

        public Estudiante()
        {  
        }
        
        public Estudiante(long code, string nombre, string email,long edad, string direccion, List<double> quices, double[]trabajos, double[]parciales)
        {
            this.code = code;
            this.nombre = nombre;
            this.email = email;
            this.edad = edad;
            this.direccion = direccion;
            this.quices = quices;
            this.trabajos = trabajos;
            this.parciales = parciales;
        } 
    }
}