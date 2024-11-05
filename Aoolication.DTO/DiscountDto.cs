using Application.DTO.Enums;

namespace Application.DTO
{
    public sealed record DiscountDto
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Percent {  get; set; }
        public DiscountStatusDTO Status { get; set; }
    }
}
