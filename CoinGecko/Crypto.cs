public class Crypto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public decimal Current_price { get; set; }
    public long Market_cap { get; set; }
    public string? Description { get; set; } // Nullable to handle potential null values from the API
}