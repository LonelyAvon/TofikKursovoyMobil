using System;
namespace TofikKursovoyModels.ClassesCombine
{
	public class DiscountCombiner
	{
		public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhotoName { get; set; }
        public int? NewCost { get; set; }
        public int? OldCost { get; set; }
        public string? Existance { get; set; }
        public string? ShortDescription { get; set; }
    }
}