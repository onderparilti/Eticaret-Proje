using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EticaretProje.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [DisplayName("Adı")]
        [StringLength(50,ErrorMessage ="Max 50 karakter olmalıdır!")]
        public string? Ad { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [DisplayName("Açıklama")]
        public string? Aciklama { get; set; }
        public virtual List<Urun>? Uruns { get; set; }
    }
}
