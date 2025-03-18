using System;
using System.Collections.Generic;

namespace ApiDemoBatch2.Entities;

public partial class Car
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public string Color { get; set; } = null!;

    public int? CarBrandId { get; set; }

    public virtual CarBrand? CarBrand { get; set; }
}
