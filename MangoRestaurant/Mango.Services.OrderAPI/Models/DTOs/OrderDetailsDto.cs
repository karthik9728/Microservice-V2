namespace Mango.Services.OrderAPI.Models.DTOs
{
    public class OrderDetailsDto
    {
        public int OrderDetailsId { get; set; }

        public int OrderHeaderId { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }
    }
}
