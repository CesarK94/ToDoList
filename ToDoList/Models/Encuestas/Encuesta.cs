using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models.Encuestas
{
    public class Encuesta
    {
        public List<Pregunta> Preguntas { get; set; }
        public List<Respuesta> Respuestas { get; set; }

        public Encuesta()
        {
            Preguntas = new();
            Respuestas = new();
        }
    }
}
