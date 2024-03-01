using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Encuestas;

namespace ToDoList.ViewModel
{
    public partial class RegistroEncuestaViewModel : ObservableObject
    {
        public RegistroEncuestaViewModel()
        {
        }

        [RelayCommand]
       public void RegistrarEncuesta()
        {
            var pregunta = new Pregunta
            {
                Id = 1,
                Descripcion = "¿Te gustó el curso?",
                TipoPregunta = eTipoPregunta.Abierta
            };
            var fakeEncuesta = new Encuesta
            {
                Id = 1,
                Preguntas = [pregunta]
            };

            Dictionary<string, object> parameros = new()
            {
                ["ENCUESTA"] = fakeEncuesta
            };
            Shell.Current.GoToAsync("..", parameros);
        }
    }
}
