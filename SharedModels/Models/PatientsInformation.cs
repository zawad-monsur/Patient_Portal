using System;
using System.Collections.Generic;

namespace SharedModels.Models;

public partial class PatientsInformation
{
    public int PatientId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool? HasEpilepsy { get; set; }

    public virtual ICollection<AllergiesDetail> AllergiesDetails { get; set; } = new List<AllergiesDetail>();

    public virtual ICollection<NcdDetail> NcdDetails { get; set; } = new List<NcdDetail>();
}
