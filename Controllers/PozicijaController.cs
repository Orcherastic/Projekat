using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PozicijaController : ControllerBase
    {
        public FudbalskiKlubContext Context { get; set; }

        public PozicijaController(FudbalskiKlubContext context)
        {
            Context = context;
        }

        [Route("PreuzmiPoziciju")]
        [HttpGet]
        public ActionResult PreuzmiPoziciju()
        {
            return Ok(Context.Pozicije.Select(poz => new{poz.ID, poz.Naziv}));
        }

        [Route("DodajPoziciju/{Naziv}")]
        [HttpPost]
        public async Task<ActionResult> DodajPoziciju(string Naziv)
        {
            if(string.IsNullOrWhiteSpace(Naziv) || Naziv.Length > 30 || Context.Pozicije
                .Where(poz => poz.Naziv == Naziv).FirstOrDefault() != null)
            {
                return BadRequest("Nije validna pozicija ili uneta pozicija vec postoji u bazi!");
            }

            try
            {
                Pozicija NovaPozicija = new Pozicija
                {
                    Naziv = Naziv
                };

                Context.Pozicije.Add(NovaPozicija);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno dodata nova pozicija {Naziv}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniPoziciju/{ID}/{Naziv}")]
        [HttpPut]
        public async Task<ActionResult> PromeniPoziciju(int ID, string Naziv)
        {
            if(Context.Pozicije.Where(poz => poz.ID == ID).FirstOrDefault() == null)
            {
                return BadRequest("Nepostojeca pozicija!");
            }
            if(string.IsNullOrWhiteSpace(Naziv) || Naziv.Length > 30 || Context.Pozicije
                .Where(poz => poz.Naziv == Naziv).FirstOrDefault() != null)
            {
                return BadRequest("Nije validna pozicija ili uneta pozicija vec postoji u bazi!");
            }

            try
            {
                var PostojecaPoz = Context.Pozicije.Where(poz => poz.ID == ID).FirstOrDefault();
                Pozicija NovaPoz = new Pozicija
                {
                    ID = PostojecaPoz.ID,
                    Naziv = Naziv
                };

                Context.Pozicije.Remove(PostojecaPoz);
                Context.Pozicije.Add(NovaPoz);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno promenjena pozicija {PostojecaPoz.Naziv} u {Naziv}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ObrisiPoziciju/{ID}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiPoziciju(int ID)
        {
            if(Context.Pozicije.Where(poz => poz.ID == ID).FirstOrDefault() == null)
            {
                return BadRequest("Nepostojeca pozicija!");
            }

            try
            {
                var PozZaBris = Context.Pozicije.Where(poz => poz.ID == ID).FirstOrDefault();
                Context.Pozicije.Remove(PozZaBris);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno obrisana pozicija {PozZaBris.Naziv}.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}