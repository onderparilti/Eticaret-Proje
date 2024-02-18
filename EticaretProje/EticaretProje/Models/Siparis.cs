using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EticaretProje.Models
{
    public class Siparis
    {
        [ScaffoldColumn(false)]

        public int SiparisId { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Sipariş Tarihi")]
        public System.DateTime SiparisTarihi { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [StringLength(40)]

        public string Ad { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [StringLength(40)]

        public string Soyad { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [StringLength(40)]

        public string? Adres { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [DisplayName("İl")]
        [StringLength(40)]

        public string? Il { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [DisplayName("İlçe")]
        [StringLength(40)]

        public string? Ilce { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [DisplayName("Ülke")]
        [StringLength(40)]

        public string? Ulke { get; set; }
        [DisplayName("Posta Kodu")]
        [StringLength(10)]


        public int PostaKodu { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilmez")]
        [DisplayName("Eposta")]

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Eposta geçerli değil.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public decimal Total { get; set; }

    }
}
