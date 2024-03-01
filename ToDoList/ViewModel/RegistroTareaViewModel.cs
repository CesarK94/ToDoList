using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModel
{
    public partial class RegistroTareaViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Tarea tarea;

        private IDataService fakeService;

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
            if (query.TryGetValue("TAREA", out object value))
            {
                Tarea = value as Tarea;
            }
        }
    }
}
