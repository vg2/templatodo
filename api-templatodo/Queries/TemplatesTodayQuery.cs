using api_templatodo.DataAccess;
using api_templatodo.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace api_templatodo.Queries;

public class TemplatesTodayQuery : IRequest<ICollection<TemplateToday>>
{ }

public class TemplatesTodayQueryHandler : IRequestHandler<TemplatesTodayQuery, ICollection<TemplateToday>>
{
    private readonly TemplatodoContext context;
    public TemplatesTodayQueryHandler(TemplatodoContext context) => this.context = context;

    public async Task<ICollection<TemplateToday>> Handle(TemplatesTodayQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(this.context.Templates
        .Include(t => t.TemplateCycleSlots).ThenInclude(tcs => tcs.TemplateTodoItems).ThenInclude(tti => tti.TodoItem)
        .Select(template => new TemplateToday(
            template.Name,
            GetTodayItemsForTemplate(template)
        ))
        .ToList());
    }

    private static ICollection<TodoToday> GetTodayItemsForTemplate(Template template)
    {
        var today = DateTime.UtcNow;
        if (today < template.StartDate) { return new List<TodoToday>(); }

        if (template.Frequency == "Daily")
        {
            var daysDiff = (today - template.StartDate).Days;
            var pointInCycle = daysDiff % template.CycleLength;
            return template.TemplateCycleSlots.SelectMany(c => c.TemplateTodoItems).Where(i => i.PointInCycle == pointInCycle)
            .Select(i => new TodoToday(i.TodoItem.Name, i.TodoItem.Description, i.TodoItem.DurationInMinutes, i.TemplateCycleSlot.Description, i.Note)).ToList();
        }

        // todo: implement other frequencies
        return new List<TodoToday>();
    }
}