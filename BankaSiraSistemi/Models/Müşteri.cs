namespace BankaSiraSistemi.Models
{
    public class Müşteri
    {
        public string Ad { get; set; } = "";
        public string Soyad { get; set; } = "";
        public string TC { get; set; } = "";
        public int Yaş { get; set; }
        public int Öncelik { get; set; }
        public string SiraNo { get; set; } = "";
    }
}
