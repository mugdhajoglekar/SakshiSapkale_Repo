namespace ProductCRUDAPI.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
