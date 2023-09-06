using System;
using System.Collections.Generic;

namespace api_templatodo.DataAccess;

public partial class InstanceItem
{
    public long Id { get; set; }

    public string Status { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public long TemplateInstanceId { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual TemplateInstance TemplateInstance { get; set; } = null!;
}
