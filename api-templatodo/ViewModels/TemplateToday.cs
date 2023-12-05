using api_templatodo.ViewModels;

namespace api_templatodo;

public class TemplateToday
{
    public TemplateToday(string name, ICollection<TodoToday> todos)
    {
        Name = name;
        Todos = todos;
    }

    public string Name { get; }

    public ICollection<TodoToday> Todos { get; }
}