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
            
            try
            {
                return Ok(await PovVrd.Select(i => new {i.ID, i.Ime, i.Prezime, i.BrojDresa, i.BrojGodina, i.Kvalitet, i.Pozicija, i.Nacionalnost, i.Tim.Naziv}).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiIgraca/{Nacionalnost}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiIgraca(string Nacionalnost) 
        {
            if(Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Nacionalnost).FirstOrDefault() == null)
            {
                return BadRequest("Nije validno Nacionalnost!");
            }

            var PovVrd = Context.Igraci.Include(i => i.Nacionalnost)
                                       .Where(i => i.Nacionalnost.Drzavljanstvo == Nacionalnost);
            try
            {
                return Ok(await PovVrd.Select(i => new {i.ID, i.Ime, i.Prezime, i.BrojDresa, i.BrojGodina, i.Kvalitet, i.Pozicija, i.Nacionalnost, i.Tim.Naziv}).ToListAsync());
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

        [Route("DodajIgraca/{Ime}/{Prezime}/{BrojDresa}/{BrojGodina}/{Kvalitet}/{NazivPozicije}/{Drzavljanstvo}/{NazivTima}")]
        [HttpPost]
        public async Task<ActionResult> DodajIgraca(string Ime, string Prezime, int BrojDresa, int BrojGodina, int Kvalitet, string NazivPozicije, string Drzavljanstvo, string NazivTima)
        {
            if(string.IsNullOrWhiteSpace(Ime) || Ime.Length > 30 || 
                Ime.Any(c => char.IsDigit(c)))
            {
                return BadRequest("Ne validno ime igraca!");
            }
            if(string.IsNullOrWhiteSpace(Prezime) || Prezime.Length > 30 || 
                Prezime.Any(c => char.IsDigit(c)))
            {
                return BadRequest("Ne validno prezime igraca!");
            }
            if(BrojDresa < 1 || BrojDresa > 99 || Context.Igraci
                .Where(i => i.BrojDresa == BrojDresa).FirstOrDefault() != null)
            {
                return BadRequest("Ne validan broj dresa igraca ili je uneti broj vec dodeljen!");
            }
            if(BrojGodina < 16 || BrojGodina > 42)
            {
                return BadRequest("Ne validan broj godina igraca!");
            }
            if(Kvalitet < 1 || Kvalitet > 5)
            {
                return BadRequest("Ne validan kvalitet igraca!");
            }
            if(Context.Pozicije.Where(poz => poz.Naziv == NazivPozicije)
                .FirstOrDefault() == null)
            {
                return BadRequest("Nije validna pozicija igraca!");
            }
            if(Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Drzavljanstvo)
                .FirstOrDefault() == null)
            {
                return BadRequest("Nije validna nacionalnost igraca!");
            }
            if(Context.Timovi.Where(t => t.Naziv == NazivTima).FirstOrDefault() == null)
            {
                return BadRequest("Nije validan naziv kluba!");
            }

            try
            {
                Igrac NoviIgrac = new Igrac
                {
                    Ime = Ime,
                    Prezime = Prezime, 
                    BrojDresa = BrojDresa,
                    BrojGodina = BrojGodina,
                    Kvalitet = Kvalitet,
                    Pozicija = Context.Pozicije.Where(poz => poz.Naziv == NazivPozicije).FirstOrDefault(),
                    Nacionalnost = Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Drzavljanstvo).FirstOrDefault(),
                    Tim = Context.Timovi.Where(t => t.Naziv == NazivTima).FirstOrDefault()
                };

                Context.Igraci.Add(NoviIgrac);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno dodat novi igrac {NoviIgrac.BrojDresa} {NoviIgrac.Ime} {NoviIgrac.Prezime} u tim {NazivTima}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniIgraca/{ID}/{PozicijaID}/{Nacionalnost}/{NazivTima}")]
        [HttpPut]
        public async Task<ActionResult> PromeniIgraca(int ID, int PozicijaID, string Nacionalnost, string NazivTima)
        {
            if(Context.Igraci.Where(i => i.ID == ID).FirstOrDefault() == null)
            {
                return BadRequest("Ne validan ID igraca!");
            }
            if(Context.Pozicije.Where(poz => poz.ID == PozicijaID).FirstOrDefault() == null)
            {
                return BadRequest("Nije validna pozicija!");
            }
            if(Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Nacionalnost).FirstOrDefault() == null)
            {
                return BadRequest("Nije validna nacionalnost!");
            }
            if(Context.Timovi.Where(t => t.Naziv == NazivTima).FirstOrDefault() == null)
            {
                return BadRequest("Nije validan naziv kluba!");
            }

            try
            {
                var PostojeciIgrac = Context.Igraci.Where(i => i.ID == ID).FirstOrDefault();

                Igrac NoviIgrac = new Igrac
                {
                    ID = PostojeciIgrac.ID,
                    Ime = PostojeciIgrac.Ime,
                    Prezime = PostojeciIgrac.Prezime,
                    BrojDresa = PostojeciIgrac.BrojDresa,
                    BrojGodina = PostojeciIgrac.BrojGodina,
                    Kvalitet = PostojeciIgrac.Kvalitet,
                    Pozicija = Context.Pozicije.Where(poz => poz.ID == PozicijaID).FirstOrDefault(),
                    Nacionalnost = Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Nacionalnost).FirstOrDefault(),
                    Tim = Context.Timovi.Where(t => t.Naziv == NazivTima).FirstOrDefault()
                };

                Context.Igraci.Remove(PostojeciIgrac);
                Context.Igraci.Add(NoviIgrac);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno dodat igrac {PostojeciIgrac.Ime} {PostojeciIgrac.Prezime} u {NazivTima}");
            }  
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniIgraca/{ID}/{PozicijaID}/{Nacionalnost}")]
        [HttpPut]
        public async Task<ActionResult> PromeniIgraca(int ID, int PozicijaID, string Nacionalnost)
        {
            if(Context.Igraci.Where(i => i.ID == ID).FirstOrDefault() == null)
            {
                return BadRequest("Ne validan ID igraca!");
            }
            if(Context.Pozicije.Where(poz => poz.ID == PozicijaID).FirstOrDefault() == null)
            {
                return BadRequest("Nije validna pozicija!");
            }
            if(Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Nacionalnost).FirstOrDefault() == null)
            {
                return BadRequest("Nije validna nacionalnost!");
            }

            try
            {
                var PostojeciIgrac = Context.Igraci.Where(i => i.ID == ID).FirstOrDefault();

                Igrac NoviIgrac = new Igrac
                {
                    ID = PostojeciIgrac.ID,
                    Ime = PostojeciIgrac.Ime,
                    Prezime = PostojeciIgrac.Prezime,
                    BrojDresa = PostojeciIgrac.BrojDresa,
                    BrojGodina = PostojeciIgrac.BrojGodina,
                    Kvalitet = PostojeciIgrac.Kvalitet,
                    Pozicija = Context.Pozicije.Where(poz => poz.ID == PozicijaID).FirstOrDefault(),
                    Nacionalnost = Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Nacionalnost).FirstOrDefault()
                };

                Context.Igraci.Remove(PostojeciIgrac);
                Context.Igraci.Add(NoviIgrac);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno promenjena pozicija igraca {PostojeciIgrac.Ime} {PostojeciIgrac.Prezime} u {NoviIgrac.Pozicija.Naziv} i nacionalnost u {Nacionalnost}");
            }  
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ObrisiIgraca/{ID}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiIgraca(int ID)
        {
            if(Context.Igraci.Where(i => i.ID == ID).FirstOrDefault() == null)
            {
                return BadRequest("Ne validan ID igraca!");
            }

            try
            {
                var IgracZaBrisanje = Context.Igraci.Where(i => i.ID == ID).FirstOrDefault();
                Context.Igraci.Remove(IgracZaBrisanje);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno obrisan igrac {IgracZaBrisanje.Ime}, {IgracZaBrisanje.Prezime}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
