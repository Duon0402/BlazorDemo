namespace BlazorDemo.Components.Pages.TodoList
{
    public partial class TodoList
    {
        private List<TodoItem> todos = [];
        private string? newTodo;

        private void AddTodo()
        {
            if(!string.IsNullOrEmpty(newTodo))
            {
                todos.Add(new TodoItem { Title = newTodo });
                newTodo = string.Empty; 
            }
        }
    }

    public class TodoItem
    {
        public string? Title { get; set; }
        public bool IsDone { get; set; }
    }
}
