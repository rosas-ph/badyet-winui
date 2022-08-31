namespace Badyet.App.Models
{
    public class Income
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Allowance { get; set; }
        public decimal Bonus { get; set; } = 0;
    }
}
