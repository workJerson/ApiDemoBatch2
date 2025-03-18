using System;
using System.Collections.Generic;

namespace ApiDemoBatch2.Entities;

public partial class CarBrand
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
