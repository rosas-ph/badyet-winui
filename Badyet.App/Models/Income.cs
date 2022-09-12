namespace Badyet.App.Models
{
    public class Income
    {
        public int ID { get; set; }
        public string Employment { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Allowance { get; set; }
        public decimal Bonus { get; set; } = 0;
    }
}
