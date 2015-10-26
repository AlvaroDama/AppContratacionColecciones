using System;
using AppContratacionColecciones.Clases;

namespace AppContratacionColecciones.Excepciones
{
    class EstudiosInsuficientesException:Exception
    {
        public EstudiosInsuficientesException(Estudios e, 
            Puestos p):base(String.Format("El {0} no puede ser asignado a " +
                                          "una persona con estudios {1}", p, e)){}
    }
}
