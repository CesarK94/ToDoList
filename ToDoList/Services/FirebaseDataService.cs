using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using ToDoList.Models;

namespace ToDoList.Services
{
	public class FirebaseDataService : IDataService
	{
        public List<Tarea> Tasks { get; set; } = new();
        FirebaseClient firebaseClient;
        string UserId = null;


        public FirebaseDataService()
        {
            firebaseClient = new FirebaseClient("https://todolist-7e01a-default-rtdb.firebaseio.com/");
        }

        public async Task AddTask(Tarea tarea)
        {
            UserId = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", "")).User.LocalId;
            Console.WriteLine(UserId);

            if (UserId != null)
            {
                await firebaseClient.Child(UserId).Child("Todo").PostAsync(tarea);
            }
            return;
        }
        public async Task<List<Tarea>> GetTasks()
        {
            UserId = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", "")).User.LocalId;
            Console.WriteLine(UserId);


            if (UserId != null)
            {
                return (await firebaseClient.Child(UserId).Child("Todo").OnceAsync<Tarea>()).Select(item => new Tarea
                {
                    Id = item.Key,
                    Titulo = item.Object.Titulo,
                    Descripcion = item.Object.Descripcion,
                    FechaInicial = item.Object.FechaInicial,
                    FechaFinal = item.Object.FechaFinal,
                    TipoTarea = item.Object.TipoTarea,
                    Prioridad = item.Object.Prioridad,
                    Estado = item.Object.Estado,
                    Encuesta = item.Object.Encuesta,
                    URl = item.Object.URl

                }).ToList();

            }
            else
            {
                return null;
            }
           
        }

        /*
        public async Task<bool> DeleteTaskAsync(Tarea tarea)
        {
            try
            {
                await firebaseClient.Child("Todo").Child(tarea.Id).DeleteAsync();
                return true; // La eliminación fue exitosa
            }
            catch (Exception)
            {
                return false; // La eliminación falló
            }
        }
        */

        public async Task<bool> EditTaskAsync(Tarea tarea)
        {
            UserId = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", "")).User.LocalId;
            try
            {
                await firebaseClient.Child(UserId).Child("Todo").Child(tarea.Id).PutAsync(tarea);
                return true; // La edición fue exitosa
            }
            catch (Exception)
            {
                return false; // La edición falló
            }
        }
        
    }

}


