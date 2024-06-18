namespace SuperTraderService.SharePriceDetail.DTOs
{
    public class UpdatePriceDTOs
    {
        public int UserId { get; set; }
        public int ShareId { get; set; }
        public decimal Price { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
