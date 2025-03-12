using System;
using System.Collections.Generic;

namespace ApiDemoBatch2.Entities;

public partial class Car
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;
}
