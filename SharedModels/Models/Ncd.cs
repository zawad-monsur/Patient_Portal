using System;
using System.Collections.Generic;

namespace SharedModels.Models;

public partial class Ncd
{
    public int Ncdid { get; set; }

    public string? Ncdname { get; set; }

    public virtual ICollection<NcdDetail> NcdDetails { get; set; } = new List<NcdDetail>();
}
