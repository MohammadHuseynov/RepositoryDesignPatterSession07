﻿namespace RepositoryDesignPatternSession07.ApplicationServices.Dtos
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
