using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IgracController : ControllerBase
    {
        public FudbalskiKlubContext Context { get; set; }

        public IgracController(FudbalskiKlubContext context)
        {
            Context = context;
        }

        [Route("Preuzmi/{Pozicija}")]
        [HttpGet]
        public async Task<ActionResult> Preuzmi(string Pozicija)
        {
            if(Context.Pozicije.Where(poz => poz.Naziv == Pozicija).FirstOrDefault() == null)
            {
                return BadRequest("Nije validna pozicija!");
            }

            var PovVrd = Context.Igraci.Include(i => i.Pozicija)
                                       .Where(i => i.Pozicija.Naziv == Pozicija);
                                       //.Where(i => i.Tim == null);
            
            try
            {
                return Ok(await PovVrd.Select(i => new {i.Ime, i.Prezime, i.BrojDresa, i.BrojGodina, i.Kvalitet, i.Pozicija, i.Nacionalnost}).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Preuzmi/{Nacionalnost}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiIgraca(string Nacionalnost)
        {
            if(Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Nacionalnost).FirstOrDefault() == null)
            {
                return BadRequest("Nije validno Nacionalnost!");
            }

            var PovVrd = Context.Igraci.Include(i => i.Nacionalnost)
                                       .Where(i => i.Nacionalnost.Drzavljanstvo == Nacionalnost);
                                       //.Where(i => i.Tim == null);
            
            try
            {
                return Ok(await PovVrd.Select(i => new {i.Ime, i.Prezime, i.BrojDresa, i.BrojGodina, i.Kvalitet, i.Pozicija, i.Nacionalnost}).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajIgraca")]
        [HttpPost]
        public async Task<ActionResult> DodajIgraca([FromBody] Igrac igrac)
        {
            // Provera unetih podataka novog igraca
            if(string.IsNullOrWhiteSpace(igrac.Ime) || igrac.Ime.Length > 30 || 
                igrac.Ime.Any(c => char.IsDigit(c)))
            {
                return BadRequest("Ne validno ime igraca!");
            }
            if(string.IsNullOrWhiteSpace(igrac.Prezime) || igrac.Prezime.Length > 30 || 
                igrac.Prezime.Any(c => char.IsDigit(c)))
            {
                return BadRequest("Ne validno prezime igraca!");
            }
            if(igrac.BrojDresa < 1 || igrac.BrojDresa > 99 || Context.Igraci
                .Where(i => i.BrojDresa == igrac.BrojDresa).FirstOrDefault() != null)
            {
                return BadRequest("Ne validan broj dresa igraca ili je uneti broj vec dodeljen!");
            }
            if(igrac.BrojGodina < 16 || igrac.BrojGodina > 42)
            {
                return BadRequest("Ne validan broj godina igraca!");
            }
            if(igrac.Kvalitet < 1 || igrac.Kvalitet > 5)
            {
                return BadRequest("Ne validan kvalitet igraca!");
            }
            if(Context.Pozicije.Where(poz => poz.ID == igrac.Pozicija.ID)
                .FirstOrDefault() == null)
            {
                return BadRequest("Nije validna pozicija igraca!");
            }
            if(Context.Nacionalnostsi.Where(nac => nac.ID == igrac.Nacionalnost.ID)
                .FirstOrDefault() == null)
            {
                return BadRequest("Nije validna nacionalnost igraca!");
            }

            try
            {
                Igrac NoviIgrac = new Igrac
                {
                    ID = igrac.ID,
                    Ime = igrac.Ime,
                    Prezime = igrac.Prezime,
                    BrojDresa = igrac.BrojDresa,
                    BrojGodina = igrac.BrojGodina,
                    Kvalitet = igrac.Kvalitet,
                    Pozicija = Context.Pozicije.Where(poz => poz.ID == igrac.Pozicija.ID)
                        .FirstOrDefault(),
                    Nacionalnost = Context.Nacionalnostsi.Where(nac => nac.ID == igrac.Nacionalnost.ID)
                        .FirstOrDefault()
                };

                Context.Igraci.Add(NoviIgrac);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno dodat novi igrac {NoviIgrac.BrojDresa} {NoviIgrac.Ime} {NoviIgrac.Prezime}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
