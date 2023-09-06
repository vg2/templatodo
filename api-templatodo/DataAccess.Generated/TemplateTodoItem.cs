using System;
using System.Collections.Generic;

namespace api_templatodo.DataAccess;

public partial class TemplateTodoItem
{
    public long Id { get; set; }

    public int PointInCycle { get; set; }

    public string Note { get; set; } = null!;

    public long TemplateCycleSlotId { get; set; }

    public long TodoItemId { get; set; }

    public virtual TemplateCycleSlot TemplateCycleSlot { get; set; } = null!;

    public virtual ICollection<TemplateInstance> TemplateInstances { get; set; } = new List<TemplateInstance>();

    public virtual TodoItem TodoItem { get; set; } = null!;
}
