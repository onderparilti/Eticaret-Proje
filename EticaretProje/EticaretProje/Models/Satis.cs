using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EticaretProje.Models
{
    public class Satis
    {
        public int Id { get; set; }
        [DisplayName("Ürün")]
        public int UrunId { get; set; }
        [DisplayName("Adet")]

        public int Adet { get; set; }
        [DisplayName("Fiyat")]

        public decimal Fiyat { get; set; }
        [DisplayName("Tarih")]

        public DateTime Tarih { get; set; }
        [DisplayName("Resim")]

        public string? Resim { get; set; }
        [ScaffoldColumn(false)]


        public int KullaniciId { get; set; }
    }
}
