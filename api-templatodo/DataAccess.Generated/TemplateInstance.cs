using System;
using System.Collections.Generic;

namespace api_templatodo.DataAccess;

public partial class TemplateInstance
{
    public long Id { get; set; }

    public long TemplateTodoItemId { get; set; }

    public virtual ICollection<InstanceItem> InstanceItems { get; set; } = new List<InstanceItem>();

    public virtual TemplateTodoItem TemplateTodoItem { get; set; } = null!;
}
