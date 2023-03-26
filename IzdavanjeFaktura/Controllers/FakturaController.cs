using IzdavanjeFaktura.Data;
using IzdavanjeFaktura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IzdavanjeFaktura.Controllers
{
    public class FakturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FakturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {

            List<Faktura> fakture;

            fakture = _context.Fakture.ToList();

            return View(fakture);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Faktura faktura = new Faktura();
            faktura.FakturaStavki.Add(new FakturaStavka() { FakturaId = 1 });

            return View(faktura);
        }

        [HttpPost]
        public IActionResult Create(Faktura faktura, int Tax)
        {
            faktura.FakturaStavki.RemoveAll(n => n.UkupnaCijenaStavkeBezPoreza == 0);
            faktura.FakturaStavki.RemoveAll(n => n.IsDeleted == true);

            //Another way is to create property(foreignkey in Faktura) and table Porezi
            //1 ili 2
            //faktura.PorezId = Tax;
            //0.17 or 0.25
            //decimal porezIznos = _context.Porezi.FirstOrDefault(p => p.Id == Tax).IznosPoreza;

            if (Tax == 1)
            {
                faktura.UkupnaCijenaSaPorezom = faktura.UkupnaCijenaBezPoreza + faktura.UkupnaCijenaBezPoreza * (decimal)0.17;
            }
            else if(Tax == 2)
            {
                faktura.UkupnaCijenaSaPorezom = faktura.UkupnaCijenaBezPoreza + faktura.UkupnaCijenaBezPoreza * (decimal)0.25;
            }

            _context.Add(faktura);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Details(int Id)
        {
            Faktura faktura = _context.Fakture
                .Include(s => s.FakturaStavki)
                .Where(f => f.Id == Id).FirstOrDefault();

            return View(faktura);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Faktura faktura = _context.Fakture
                .Include(s => s.FakturaStavki)
                .Where(f => f.Id == Id).FirstOrDefault();

            return View(faktura);
        }


        [HttpPost]
        public IActionResult Delete(Faktura faktura)
        {
            _context.Attach(faktura);
            _context.Entry(faktura).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Faktura faktura = _context.Fakture
                .Include(s => s.FakturaStavki)
                .Where(f => f.Id == Id).FirstOrDefault();

            return View(faktura);
        }

        [HttpPost]
        public IActionResult Edit(Faktura faktura, int Tax)
        {
            List<FakturaStavka> fakturaStavkaDetails = _context.FakturaStavke.Where(d => d.FakturaId == faktura.Id).ToList();
            _context.FakturaStavke.RemoveRange(fakturaStavkaDetails);
            _context.SaveChanges();

            faktura.FakturaStavki.RemoveAll(n => n.UkupnaCijenaStavkeBezPoreza == 0);
            faktura.FakturaStavki.RemoveAll(n => n.IsDeleted == true);

            if (Tax == 1)
            {
                faktura.UkupnaCijenaSaPorezom = faktura.UkupnaCijenaBezPoreza + faktura.UkupnaCijenaBezPoreza * (decimal)0.17;
            }
            else if (Tax == 2)
            {
                faktura.UkupnaCijenaSaPorezom = faktura.UkupnaCijenaBezPoreza + faktura.UkupnaCijenaBezPoreza * (decimal)0.25;
            }

            _context.Attach(faktura);

            //Informing the EF COre that received faktura from the form post is modified and it has to start tracking
            //because we already call method SaveChanges() in previous step, so all tracking info may be commited
            _context.Entry(faktura).State = EntityState.Modified;

            //We are adding the stavke details, which are submited by user through the model
            _context.FakturaStavke.AddRange(faktura.FakturaStavki);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
