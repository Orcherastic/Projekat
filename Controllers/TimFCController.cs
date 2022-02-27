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
    public class TimFCController : ControllerBase
    {
        public FudbalskiKlubContext Context { get; set; }

        public TimFCController(FudbalskiKlubContext context)
        {
            Context = context;
        }

        [Route("PreuzmiTim/{Naziv}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiTim(string Naziv)
        {
            if(Context.Timovi.Where(t => t.Naziv == Naziv).FirstOrDefault() == null)
            {
                return BadRequest("Nije validan naziv tima!");
            }

            var PovVrd = Context.Timovi
            .Include(t => t.Igraci)
            .Where(t => t.Naziv == Naziv);

            try
            {
                return Ok(await PovVrd.Select(t => new {t.ID, t.Naziv, t.Kvalitet}).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajTim")]
        [HttpPost]
        public async Task<ActionResult> DodajTim([FromBody] TimFC Tim)
        {
            if(string.IsNullOrWhiteSpace(Tim.Naziv) || Tim.Naziv.Length > 50 || 
                Context.Timovi.Where(t => t.Naziv == Tim.Naziv).FirstOrDefault() == null)
            {
                return BadRequest("Nije validan naziv tima!");
            }
            if(Tim.Kvalitet < 1 || Tim.Kvalitet > 5)
            {
                return BadRequest("Nije validan kvalitet tima!");
            }

            try
            {
                Context.Timovi.Add(Tim);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno dodat tim {Tim.Naziv} sa kvalitetom {Tim.Kvalitet}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajTim/{Naziv}/{Kvalitet}/{MenadzerID}")]
        [HttpPost]
        public async Task<ActionResult> DodajTim(string Naziv, int Kvalitet, int MenadzerID)
        {
            var TimVrd = Context.Menadzeri
            .Include(m => m.Tim)
            .Where(m => m.Tim == null)
            .Where(m => m.ID == MenadzerID);

            if(string.IsNullOrWhiteSpace(Naziv) || Naziv.Length > 50 || 
                Context.Timovi.Where(t => t.Naziv == Naziv).FirstOrDefault() != null)
            {
                return BadRequest("Nije validan naziv tima!");
            }
            if(Kvalitet < 1 || Kvalitet > 5)
            {
                return BadRequest("Nije validan kvalitet tima!");
            }
            if(Context.Menadzeri.Where(m => m.ID == MenadzerID).FirstOrDefault() == null)
            {
                return BadRequest("Nije validan ID menadzera!");
            }

            try
            {
                TimFC NoviTim = new TimFC
                {
                    Naziv = Naziv,
                    Kvalitet = Kvalitet
                };
                Menadzer NoviMenadzer = new Menadzer
                {
                    ID = MenadzerID,
                    Ime = Context.Menadzeri.Where(p=>p.ID == MenadzerID).FirstOrDefault().Ime,
                    Prezime = Context.Menadzeri.Where(p=>p.ID == MenadzerID).FirstOrDefault().Prezime,
                    Tim = NoviTim
                };

                Context.Menadzeri.Remove(Context.Menadzeri.Where(m => m.ID == MenadzerID).FirstOrDefault());
                Context.Timovi.Add(NoviTim);
                Context.Menadzeri.Add(NoviMenadzer);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno dodat tim {Naziv} sa menadzerom {NoviMenadzer.Ime}, {NoviMenadzer.Prezime}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniTim/{TimID}/{MenadzerID}")]
        [HttpPut]
        public async Task<ActionResult> PromeniTim(int TimID, int MenadzerID)
        {
            if(Context.Timovi.Where(t => t.ID == TimID).FirstOrDefault() == null)
            {
                return BadRequest("Nijev validan ID tima!");
            }
            if(Context.Menadzeri.Where(m => m.ID == MenadzerID).FirstOrDefault() == null)
            {
                return BadRequest("Nije validan ID menadzera!");
            }

            try
            {
                var PostojeciMenadzer = Context.Menadzeri.Where(m => m.Tim.ID == TimID).FirstOrDefault();

                TimFC NoviTim = new TimFC
                {
                    ID = TimID,
                    Naziv = Context.Timovi.Where(t => t.ID == TimID).FirstOrDefault().Naziv,
                    Kvalitet = Context.Timovi.Where(t => t.ID == TimID).FirstOrDefault().Kvalitet,
                };
                Menadzer NoviMenadzer = new Menadzer
                {
                    ID = MenadzerID,
                    Ime = Context.Menadzeri.Where(p=>p.ID == MenadzerID).FirstOrDefault().Ime,
                    Prezime = Context.Menadzeri.Where(p=>p.ID == MenadzerID).FirstOrDefault().Prezime,
                    BrojGodina = Context.Menadzeri.Where(p=>p.ID == MenadzerID).FirstOrDefault().BrojGodina,
                    Tim = NoviTim
                };

                PostojeciMenadzer.Tim = null;
                Context.Timovi.Remove(Context.Timovi.Where(t => t.ID == TimID).FirstOrDefault());
                Context.Timovi.Add(NoviTim);
                Context.Menadzeri.Add(NoviMenadzer);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno otpusten prethodni menadzer tima i doveden {NoviMenadzer.Ime}, {NoviMenadzer.Prezime}");

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajIgracaUTim/{TimID}/{BrojDresa}/{PozicijaID}")]
        [HttpPut]
        public async Task<ActionResult> DodajIgracaUTim(int TimID, int BrojDresa, int PozicijaID)
        {
            if(Context.Timovi.Where(t => t.ID == TimID).FirstOrDefault() == null)
            {
                return BadRequest("Nije validan ID tima!");
            }
            if(Context.Igraci.Where(i => i.BrojDresa == BrojDresa).FirstOrDefault() == null)
            {
                return BadRequest("Nije validan broj dresa igraca!");
            }
            if(Context.Igraci.Where(i => i.BrojDresa == BrojDresa).FirstOrDefault().Tim != null)
            {
                return BadRequest("Igrac sa ovim brojem dresa vec ima tim!");
            }
            if(Context.Pozicije.Where(p => p.ID == PozicijaID).FirstOrDefault() == null)
            {
                return BadRequest("Nije validna pozicija!");
            }

            try
            {
                var PovVrd = Context.Igraci
                .Include(i => i.Pozicija)
                .Where(i => i.Pozicija.ID == PozicijaID)
                .Where(i => i.BrojDresa == BrojDresa)
                .Where(i => i.Tim == null);

                var PostojeciIgrac = PovVrd.FirstOrDefault();
                var PostojeciTim = Context.Timovi.Where(t => t.ID == TimID).FirstOrDefault();
                Igrac NoviIgrac = new Igrac
                {
                    ID = PostojeciIgrac.ID,
                    Ime = PostojeciIgrac.Ime,
                    Prezime = PostojeciIgrac.Prezime,
                    BrojDresa = PostojeciIgrac.BrojDresa,
                    BrojGodina = PostojeciIgrac.BrojGodina,
                    Kvalitet = PostojeciIgrac.Kvalitet,
                    Pozicija = Context.Pozicije.Where(p => p.ID == PozicijaID).FirstOrDefault(),
                    Nacionalnost = PostojeciIgrac.Nacionalnost,
                    Tim = PostojeciTim
                };

                Context.Igraci.Remove(PostojeciIgrac);
                Context.Igraci.Add(NoviIgrac);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno doveden {NoviIgrac.Ime}, {NoviIgrac.Prezime} u tim {PostojeciTim.Naziv}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ObrisiTim/{ID}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiTim(int ID)
        {
            if(Context.Timovi.Where(t => t.ID == ID).FirstOrDefault() == null)
            {
                return BadRequest("Ne postojeci tim!");
            }

            try
            {
                if(Context.Menadzeri.Where(m => m.Tim.ID == ID).FirstOrDefault() != null)           
                    Context.Menadzeri.Where(m => m.Tim.ID == ID).FirstOrDefault().Tim = null;
                if(Context.Igraci.Where(p => p.Tim.ID == ID).ToList() != null)
                {
                    var Igraci = Context.Igraci.Where(p => p.Tim.ID == ID).ToList();

                    foreach(var i in Igraci)
                    {
                        i.Tim = null;
                    }
                }

                Context.Timovi.Remove(Context.Timovi.Where(p => p.ID == ID).FirstOrDefault());
                await Context.SaveChangesAsync();
                return Ok($"Uspesno obrisan tim {Context.Timovi.Where(p => p.ID == ID).FirstOrDefault().Naziv}"); 
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}