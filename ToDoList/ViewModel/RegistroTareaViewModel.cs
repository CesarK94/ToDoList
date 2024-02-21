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
    public partial class RegistroTareaViewModel : ObservableObject
    {
        [ObservableProperty]
        private Tarea tarea;

        private FakeTaskService fakeService;

        public RegistroTareaViewModel(FakeTaskService service)
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
    }
}
