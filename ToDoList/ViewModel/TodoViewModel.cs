using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using ToDoList.Models;
using ToDoList.Pages;
using ToDoList.Services;

namespace ToDoList.ViewModel
{
    public partial class TodoViewModel : ObservableObject
    {
        public ObservableCollection<Tarea> Tareas { get; set; }
        private IDataService fakeService;

        [ObservableProperty]
        private Tarea tareaSeleccionada;
        [ObservableProperty]
        private bool isRefresh;
        public TodoViewModel(IDataService service)
        {
            Tareas = new();
            fakeService = service;
        }
        [RelayCommand]
        public void AgregarTarea()
        {
            IsRefresh = true;
            RefreshItems();
            IsRefresh = false;
        }

        [RelayCommand]
        public async void Logout()
        {
            Preferences.Remove("FreshFirebaseToken");
            Shell.Current.GoToAsync(nameof(LoginPage));
        }

        async Task RefreshItems()
        {
            List<Tarea> nuevasTareas = await fakeService.GetTasks();
            
            Tareas.Clear();

            foreach (var tarea in nuevasTareas)
            {
                Tareas.Add(tarea);
            }
        }

        [RelayCommand]
        public void AbrirRegistro()
        {
            Shell.Current.GoToAsync(nameof(RegistroTareaPage));
        }

        [RelayCommand]
        public void EditarRegistro()
        {
            if (TareaSeleccionada == null) 
            {
                return;
            }

            ShellNavigationQueryParameters parametros = new()
            {
                { "Tarea", TareaSeleccionada }
            };

            Shell.Current.GoToAsync(nameof(RegistroTareaPage), parametros);
        }

        [RelayCommand]
        private void TaskCompleted(Tarea tarea)
        {
            if (tarea == null)
            {
                return;
            }
            if (tarea.TipoTarea == eTipoTarea.Encuesta)
            {
                ShellNavigationQueryParameters parametros = new()
                {
                    { "Tarea_Complete", tarea }
                };
                _ = Shell.Current.GoToAsync(nameof(RegistroTareaPage), parametros);
            }
            
        }




    }
}
