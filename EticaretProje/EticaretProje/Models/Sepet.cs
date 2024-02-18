using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EticaretProje.Models
{
  public class Sepet
    {
        public int SepetId { get; set; }
        public int CartId { get; set; }
        [DisplayName("Ürün")]
        public int UrunId { get; set; }
        [DisplayName("Adet")]

        public int Adet { get; set; }
        [DisplayName("Fiyat")]

        public decimal Fiyat { get; set; }
        [DisplayName("Tarih")]

        public DateTime Tarih { get; set; }
        [DisplayName("Resim")]

        public string Resim { get; set; }
        
    }
}
