using BankaSiraSistemi.Models;

namespace BankaSiraSistemi.Services
{
    public class SiraYonetimi
    {
        private Queue<Müşteri> _müşteriKuyruğu = new();
        private int bilinmeyenSayac = 1;
        private int bankaSiraSayac = 1;
        private int normalSiraSayac = 1;

        private readonly List<Müşteri> kayıtlıMüşteriler = new()
        {
            new Müşteri { Ad = "Ahmet", Soyad = "Yılmaz", TC = "11111111111", Yaş = 68 },
            new Müşteri { Ad = "Ayşe", Soyad = "Demir", TC = "22222222222", Yaş = 30 },
            new Müşteri { Ad = "Mehmet", Soyad = "Kaya", TC = "33333333333", Yaş = 66 },
            new Müşteri { Ad="Kadir"   , Soyad = "Demir",TC = "12345678901", Yaş=33}
        };

        public void SiraAl(string? tc)
        {
            Müşteri müşteri;

            if (!string.IsNullOrWhiteSpace(tc))
            {
                var kayıtlı = kayıtlıMüşteriler.FirstOrDefault(m => m.TC == tc);
                if (kayıtlı != null)
                {
                    müşteri = new Müşteri
                    {
                        Ad = kayıtlı.Ad,
                        Soyad = kayıtlı.Soyad,
                        TC = kayıtlı.TC,
                        Yaş = kayıtlı.Yaş,
                        Öncelik = kayıtlı.Yaş >= 65 ? 1 : 2,
                        SiraNo = $"M-{bankaSiraSayac++.ToString("D3")}"
                    };
                }
                else
                {
                    müşteri = new Müşteri
                    {
                        Ad = "Bilinmeyen",
                        Soyad = "",
                        TC = tc,
                        Yaş = 0,
                        Öncelik = 3,
                        SiraNo = $"B-{normalSiraSayac++.ToString("D3")}"
                    };
                }
            }
            else
            {
                müşteri = new Müşteri
                {
                    Ad = $"Bilinmeyen Müşteri {bilinmeyenSayac++}",
                    Soyad = "",
                    TC = "",
                    Yaş = 0,
                    Öncelik = 4,
                    SiraNo = $"B-{normalSiraSayac++.ToString("D3")}"
                };
            }

            _müşteriKuyruğu.Enqueue(müşteri);
            _müşteriKuyruğu = new Queue<Müşteri>(_müşteriKuyruğu.OrderBy(m => m.Öncelik));
        }

        public Müşteri? SiraCagir()
        {
            if (_müşteriKuyruğu.Any())
                return _müşteriKuyruğu.Dequeue();
            return null;
        }

        public IEnumerable<Müşteri> SiraDurumu() => _müşteriKuyruğu;
    }
}
