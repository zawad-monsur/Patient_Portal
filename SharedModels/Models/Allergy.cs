using System;
using System.Collections.Generic;

namespace SharedModels.Models;

public partial class Allergy
{
    public int AllergiesId { get; set; }

    public string? AllergiesName { get; set; }

    public virtual ICollection<AllergiesDetail> AllergiesDetails { get; set; } = new List<AllergiesDetail>();
}
