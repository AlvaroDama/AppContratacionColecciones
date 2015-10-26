using AppContratacionColecciones.Excepciones;

namespace AppContratacionColecciones.Clases
{
    public enum Estudios { Basico = 1, Medio, Superior, Doctor }
    public enum Puestos { Programador = 1, Analista, DirectorProyectos, DirectorIT }

    public class Empleado
    {
        
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public Estudios Estudios { get; set; }
        private Puestos _puesto;

        public Puestos Puesto
        {
            get { return _puesto; }
            set
            {
                if ((int)Estudios<(int)value)
                    throw new EstudiosInsuficientesException(Estudios, value);

                _puesto = value;
            }
        }

        public override string ToString() => string.Format("{2}: {0} ({1})", Nombre, Edad, Puesto);
    }
}
