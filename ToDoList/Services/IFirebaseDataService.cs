using Firebase.Database;
using Firebase.Database.Query;
using System;
using ToDoList.Models;

namespace ToDoList.Services
{
	public class IFirebaseDataService : IDataService
	{
        public List<Tarea> Tasks { get; set; } = new();
        FirebaseClient firebaseClient;

        public IFirebaseDataService()
        {
            firebaseClient = new FirebaseClient("https://todolist-7e01a-default-rtdb.firebaseio.com/");
            firebaseClient
                .Child("Todo")
                .AsObservable<Tarea>()
                .Subscribe(item => Tasks.Add(item.Object));
        }

        public async Task AddTask(Tarea tarea)
        {
           await firebaseClient.Child("Todo").PostAsync(tarea);
        }
        public List<Tarea> GetTasks()
        {
            return Tasks;
        }

    }
}

