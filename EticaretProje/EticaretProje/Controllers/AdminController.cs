using EticaretProje.Data;
using EticaretProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace EticaretProje.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly EticaretDBContext _context;

        public AdminController(ILogger<AdminController> logger, EticaretDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(Urun urun)
        {
            var kategoriler = _context.Kategoris.ToList(); // Kategorileri alın
            var kategoriListesi = new SelectList(kategoriler, "Id", "Ad"); // SelectList oluşturun
            ViewBag.KategoriListesi = kategoriListesi;



            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(urun.Aciklamasi)) // Eğer Aciklamasi boşsa veya null ise
                {
                    string script = "<script>alert('Bu alan boş geçilemez');</script>";
                    TempData["Script"] = script; // Uygun bir değer ataması yapın veya hata mesajı gösterin
                    return RedirectToAction("Index");
                }
                else
                {
                    _context.Uruns.Add(urun);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(urun);

        }

        [HttpPost]
        public IActionResult Create(IFormFile formFile, Urun urun)
        {
            
            if (formFile != null)
            {
                var extent = Path.GetExtension(formFile.FileName); //dosya uzantısını alır

                if (formFile.Length > 15000000)
                {
                    return View("Error");
                    //return Json("Hata");
                }
                else
                {
                    if (extent != ".exe")
                    {
                        var randomName = ($"{Guid.NewGuid()}{extent}"); //yeni bir dosya adı üretir
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            formFile.CopyToAsync(stream);
                        }
                        urun.Resim = "img/" + randomName;
                        _context.Uruns.Add(urun);
                        _context.SaveChanges();
                        return View("Urunler", _context.Uruns.ToList());  //ürün ekleme işlemi sonrasında otomatik olarak ürünler sayfasını acacak kod
                    }
                    else
                    {
                        return View("Error");
                    }
                }

            }
            else
            {
                
                urun.Resim = "img/"; // Varsayılan bir resim yolu atanabilir.
                _context.Uruns.Add(urun);
                _context.SaveChanges();
                return View("Urunler");
            }

        }
        public IActionResult KategoriCreate(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kategori.Aciklama)) // Eğer Aciklamasi boşsa veya null ise
                {
                    string script = "<script>alert('Bu alan boş geçilemez');</script>";
                    TempData["Script"] = script; // Uygun bir değer ataması yapın veya hata mesajı gösterin
                    return RedirectToAction("Index");
                }
                else
                {
                    _context.Kategoris.Add(kategori);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var silinecekUrun = _context.Uruns.Where(satir => satir.Id == id).FirstOrDefault();
            return View(silinecekUrun);
        }
        public IActionResult DeleteKategori(int id)
        {
            var silinecekKategori = _context.Kategoris.Where(satir => satir.Id == id).FirstOrDefault();
            return View(silinecekKategori);
        }
        public IActionResult Edit(int id)
        {
            var kategoriler = _context.Kategoris.ToList(); // Kategorileri alın
            var kategoriListesi = new SelectList(kategoriler, "Id", "Ad"); // SelectList oluşturun
            ViewBag.KategoriListesi = kategoriListesi;
            var edit = _context.Uruns.Where(satir=>satir.Id == id).FirstOrDefault();
            return View(edit);
        }
        public IActionResult Urunler()
        {
            var urunler = _context.Uruns.ToList();
            return View(urunler);
        }
        public IActionResult KategoriGetir()
        {
            var kategori = _context.Kategoris.ToList();
            return View(kategori);
        }
        public IActionResult Details(int id)
        {
            var detay = _context.Uruns
        .Include(satir => satir.Kategori) // Kategori ilişkisini Include ile çağırıyorum
        .FirstOrDefault(satir => satir.Id == id); // Id'ye göre ilgili ürünü buluyorum

            return View(detay);
        }
        public IActionResult DetailsKategori(int id)
        {
            var detay = _context.Kategoris.Where(satir => satir.Id == id).FirstOrDefault();


            return View(detay);
        }
        public IActionResult EditKategori(int id)
        {
           
            var edit = _context.Kategoris.Where(satir => satir.Id == id).FirstOrDefault();
            return View(edit);
        }




    }

}
