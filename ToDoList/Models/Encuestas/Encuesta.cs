using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models.Encuestas
{
    public class Encuesta
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        [ManyToMany(typeof(Pregunta))]

        public Pregunta[] Preguntas { get; set; }

        [ManyToMany(typeof(Respuesta))]
        public Respuesta[] Respuestas { get; set; }

        public Encuesta()
        {
            Preguntas = [];
            Respuestas = [];
        }
    }
}
