using System;
using System.Collections.Generic;

namespace api_templatodo.DataAccess;

public partial class TemplateCycleSlot
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int DurationInMinutes { get; set; }

    public TimeSpan TimeOfDay { get; set; }

    public long TemplateId { get; set; }

    public virtual Template Template { get; set; } = null!;

    public virtual ICollection<TemplateTodoItem> TemplateTodoItems { get; set; } = new List<TemplateTodoItem>();
}
