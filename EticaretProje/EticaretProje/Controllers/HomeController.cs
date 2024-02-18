using EticaretProje.Data;
using EticaretProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EticaretProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EticaretDBContext _context;

        public HomeController(ILogger<HomeController> logger, EticaretDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Getir()
        {
            var urunler = _context.Uruns.ToList();
            return View(urunler);
        }

        public IActionResult UrunDetails(int id)
        {
            var detay = _context.Uruns.Include(satir => satir.Id).Include(satir => satir.Adi).Include(satir => satir.Fiyat).Include(satir => satir.Adet).Include(satir=>satir.Kategori).FirstOrDefault(satir=>satir.KategoriId == id);
            return View(detay);
        }
    }
}