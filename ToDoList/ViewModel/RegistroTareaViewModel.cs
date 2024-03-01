using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Models.Encuestas;
using ToDoList.Pages;
using ToDoList.Services;

namespace ToDoList.ViewModel
{
    public partial class RegistroTareaViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Tarea tarea;

        private IDataService fakeService;
        public string[] TiposTarea { get; set; } = (string[])Enum.GetNames(typeof(eTipoTarea));

        public RegistroTareaViewModel(IDataService service)
        {
            tarea = new Tarea();
            fakeService = service;
        }

        [RelayCommand]
        private void Guardar()
        {
            fakeService.AddTask(Tarea);
            Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            object value = null;

            if (query.TryGetValue("TAREA", out value))
            {
                Tarea = value as Tarea;
            }

            if (query.TryGetValue("ENCUESTA", out value))
            {
                Tarea.Encuesta = value as Encuesta;
            }
        }
        [RelayCommand]
        public void AbrirRegistroEcuesta()
        {
            Shell.Current.GoToAsync(nameof(RegistroEncuesta));
        }

    }
}
