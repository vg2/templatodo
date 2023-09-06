using System;
using System.Collections.Generic;

namespace api_templatodo.DataAccess;

public partial class Template
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int CycleLength { get; set; }

    public string Frequency { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public virtual ICollection<TemplateCycleSlot> TemplateCycleSlots { get; set; } = new List<TemplateCycleSlot>();
}
