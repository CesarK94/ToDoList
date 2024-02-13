using ToDoList.Pages;

namespace ToDoList
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("TO_DO", typeof(ToDoPage));
        }
    }
}
