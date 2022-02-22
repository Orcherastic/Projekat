using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenadzerController : ControllerBase
    {
        public FudbalskiKlubContext Context { get; set; }

        public MenadzerController(FudbalskiKlubContext context)
        {
            Context = context;
        }

        [Route("PreuzmiMenadzera")]
        [HttpGet]
        public ActionResult PreuzmiMenadzera()
        {
            var PovVrd = Context.Menadzeri.Include(m => m.Tim).Where(m => m.Tim == null);
            return Ok(Context.Menadzeri.Select(m => new {m.ID, m.Ime, m.Prezime, m.BrojGodina}));
        }

        [Route("DodajMenadzera/{Ime}/{Prezime}/{BrojGodina}")]
        [HttpPost]
        public async Task<ActionResult> DodajMenadzera(string Ime, string Prezime, int BrojGodina)
        {
            if(string.IsNullOrWhiteSpace(Ime) || Ime.Length > 30 ) 
            {
                return BadRequest("Nije validno ime menadzera!");
            }
            if(string.IsNullOrWhiteSpace(Prezime) || Prezime.Length > 30 ) 
            {
                return BadRequest("Nije validno prezime menadzera!");
            }
            if(BrojGodina < 35 || BrojGodina > 65) 
            {
                return BadRequest("Nije validan broj godina menadzera!");
            }
            
            try
            {
                Menadzer NoviMenadzer = new Menadzer
                {
                    Ime = Ime,
                    Prezime = Prezime,
                    BrojGodina = BrojGodina,
                    Tim = null
                };
                Context.Menadzeri.Add(NoviMenadzer);
                await Context.SaveChangesAsync();
                return Ok($"Dodat novi menadzer {Ime}, {Prezime}, {BrojGodina}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniMenadzera/{ID}/{Ime}/{Prezime}/{BrojGodina}")]
        [HttpPut]
        public async Task<ActionResult> PromeniPoziciju(int ID, string Ime, string Prezime, int BrojGodina)
        {
            if(Context.Menadzeri.Where(m => m.ID == ID).FirstOrDefault() == null)
            {
                return BadRequest("Nepostojeci menadzer!");
            }
            if(string.IsNullOrWhiteSpace(Ime) || Ime.Length > 30)
            {
                return BadRequest("Nije validno ime menadzera!");
            }
            if(string.IsNullOrWhiteSpace(Prezime) || Prezime.Length > 30)
            {
                return BadRequest("Nije validno prezime menadzera!");
            }
            if(BrojGodina < 35 || BrojGodina > 65)
            {
                return BadRequest("Nije validan broj godina menadzera!");
            }

            try
            {
                var PostojeciMenadzer = Context.Menadzeri.Where(m => m.ID == ID).FirstOrDefault();
                Menadzer NoviMenadzer = new Menadzer
                {
                    ID = PostojeciMenadzer.ID,
                    Ime = Ime,
                    Prezime = Prezime,
                    BrojGodina = BrojGodina
                };

                Context.Menadzeri.Remove(PostojeciMenadzer);
                Context.Menadzeri.Add(NoviMenadzer);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno promenjen menadzer u {Ime}, {Prezime}, {BrojGodina}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ObrisiMenadzera/{ID}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiMenadzera(int ID)
        {
            if(Context.Menadzeri.Where(m => m.ID == ID).FirstOrDefault() == null)
            {
                return BadRequest("Nije validan ID menadzera!");
            }

            try
            {
                Context.Menadzeri.Remove(Context.Menadzeri.Where(m => m.ID == ID).FirstOrDefault());
                await Context.SaveChangesAsync();
                return Ok($"Obrisan menadzer sa ID-jem {ID}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}