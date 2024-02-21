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
        private FakeTaskService fakeService;

        [ObservableProperty]
        private bool isRefresh;
        public TodoViewModel(FakeTaskService service)
        {
            Tareas = new();
            fakeService = service;
        }
        [RelayCommand]
        public void AgrearTarea()
        {
            IsRefresh = true;
            RefreshItems();
            IsRefresh = false;
        }

        void RefreshItems()
        {
            Tareas.Clear();
            fakeService.Tasks.ForEach(Tareas.Add);
        }

        [RelayCommand]
        public void AbrirRegistro()
        {
            Shell.Current.GoToAsync(nameof(RegistroTareaPage));
        }


    }
}
