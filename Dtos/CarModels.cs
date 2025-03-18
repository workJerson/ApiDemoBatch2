﻿namespace ApiDemoBatch2.Dtos
{
    public class CreateCarModel
    {
        public string? Model { get; set; } = null!;
        public int Year { get; set; }
        public string? Color { get; set; } = null!;
        public int? CarBrandId { get; set; }
    }

    public class UpdateCarModel : CreateCarModel
    {
        public int Id { get; set; }
    }

    public class GetCarModel
    {
        public int Id { get; set; }
        public string CarModel { get; set; } = null!;
        public int CarYear { get; set; }
        public string CarColor { get; set; } = null!;
        public int? CarBrandId { get; set; }
    }
}
