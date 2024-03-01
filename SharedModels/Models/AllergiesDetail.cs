using System;
using System.Collections.Generic;

namespace SharedModels.Models;

public partial class AllergiesDetail
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public int? AllergiesId { get; set; }

    public virtual Allergy? Allergies { get; set; }

    public virtual PatientsInformation? Patient { get; set; }
}
