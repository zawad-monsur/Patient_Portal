using System;
using System.Collections.Generic;

namespace SharedModels.Models;

public partial class NcdDetail
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public int? Ncdid { get; set; }

    public virtual Ncd? Ncd { get; set; }

    public virtual PatientsInformation? Patient { get; set; }

    public static object Select(Func<object, Ncd> value)
    {
        throw new NotImplementedException();
    }
}
