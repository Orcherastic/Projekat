using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NacionalnostController : ControllerBase
    {
        public FudbalskiKlubContext Context { get; set; }

        public NacionalnostController(FudbalskiKlubContext context)
        {
            Context = context;
        }

        [Route("PreuzmiNacionalnost")]
        [HttpGet]
        public ActionResult PreuzmiNacionalnost()
        {
            return Ok(Context.Nacionalnostsi.Select(nac => new{nac.ID, nac.Drzavljanstvo}));
        }

        [Route("DodajNacionalnost/{Drzavljanstvo}")]
        [HttpPost]
        public async Task<ActionResult> DodajNacionalnost(string drzavljanstvo)
        {
            if(string.IsNullOrWhiteSpace(drzavljanstvo) || drzavljanstvo.Length > 50 || Context.Nacionalnostsi
                .Where(nac => nac.Drzavljanstvo == drzavljanstvo).FirstOrDefault() != null)
            {
                return BadRequest("Nije validno drzavljanstvo ili uneto drzavljanstvo vec postoji u bazi!");
            }

            try
            {
                Nacionalnost NovaNacionalnost = new Nacionalnost
                {
                    Drzavljanstvo = drzavljanstvo
                };

                Context.Nacionalnostsi.Add(NovaNacionalnost);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno dodato novo drzavljanstvo {NovaNacionalnost.Drzavljanstvo}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniNacionalnost/{ID}/{Drzavljanstvo}")]
        [HttpPut]
        public async Task<ActionResult> PromeniNacionalnost(int ID, string Drzavljanstvo)
        {
            if(Context.Nacionalnostsi.Where(nac => nac.ID == ID).FirstOrDefault() == null)
            {
                return BadRequest("Nepostojeca nacionalnost!");
            }
            if(string.IsNullOrWhiteSpace(Drzavljanstvo) || Drzavljanstvo.Length > 30 || 
                Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Drzavljanstvo)
                .FirstOrDefault() != null)
            {
                return BadRequest("Nije validna nacionalnost ili uneta nacionalnost vec postoji u bazi!");
            }

            try
            {
                var PostojecaNac = Context.Nacionalnostsi.Where(nac => nac.ID == ID).FirstOrDefault();
                Nacionalnost NovaNac = new Nacionalnost
                {
                    ID = PostojecaNac.ID,
                    Drzavljanstvo = Drzavljanstvo
                };

                Context.Nacionalnostsi.Remove(PostojecaNac);
                Context.Nacionalnostsi.Add(NovaNac);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno promenjena pozicija {PostojecaNac.Drzavljanstvo} u {Drzavljanstvo}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DObrisiNacionalnost/{Drzavljanstvo}")]
        [HttpDelete]
        public async Task<ActionResult> DObrisiNacionalnost(string Drzavljanstvo)
        {
            if(Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Drzavljanstvo).FirstOrDefault() == null)
            {
                return BadRequest("Nepostojeca nacionalnost!");
            }

            try
            {
                var NacZaBris = Context.Nacionalnostsi.Where(nac => nac.Drzavljanstvo == Drzavljanstvo).FirstOrDefault();
                Context.Nacionalnostsi.Remove(NacZaBris);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno obrisana pozicija {Drzavljanstvo}.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}