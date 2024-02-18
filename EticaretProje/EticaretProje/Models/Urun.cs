using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EticaretProje.Models
{
    public class Urun
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [DisplayName("Adı")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır!")]
        public string? Adi { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [DisplayName("Fiyatı")]
        
        public decimal Fiyat { get; set; }
       
        [DisplayName("Açıklaması")]
     
        public string? Aciklamasi { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [DisplayName("Resim")]
       
        public string? Resim { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [DisplayName("Adeti")]

        public int Adet { get; set; }
     
        [DisplayName("Popüler mi?")]
     
        public bool Populer { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [DisplayName("Kategori")]
        public int KategoriId { get; set; }
        public virtual Kategori? Kategori { get; set; }
    }
}
