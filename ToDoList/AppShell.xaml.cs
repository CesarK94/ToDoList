using ToDoList.Pages;

namespace ToDoList
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ToDoPage), typeof(ToDoPage));
            Routing.RegisterRoute(nameof(RegistroTareaPage), typeof(RegistroTareaPage));
            Routing.RegisterRoute(nameof(RegistroEncuesta), typeof(RegistroEncuesta));
            //Routing.RegisterRoute(nameof(EncuestaPage), typeof(EncuestaPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegistroPage), typeof(RegistroPage));
        }
    }
}
