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
        /*
        [RelayCommand]
        public async Task RemoveTask(Tarea tarea)
        {
            if (tarea == null)
            {
                return;
            }

            // Eliminar la tarea de Firebase
            bool deletedFromFirebase = await fakeService.DeleteTaskAsync(tarea);

            if (deletedFromFirebase)
            {
                // Si la tarea se eliminó correctamente de Firebase, también la eliminamos de nuestra colección local
                Tareas.Remove(tarea);
            }
            else
            {
                // Manejar el caso en que la eliminación de la tarea de Firebase falla
                Debug.WriteLine("La eliminación de la tarea de Firebase falló.");
            }
        }
        */
        [RelayCommand]
        private async Task TaskCompleted(Tarea tarea)
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
            } else
            {
                await fakeService.EditTaskAsync(tarea);
            }
            
        }




    }
}
