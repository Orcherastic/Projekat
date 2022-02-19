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

        [Route("DodajNacionalnost/{Drzavljanstvo}")]
        [HttpPost]
        public async Task<ActionResult> DodajNacionalnost(string drzavljanstvo)
        {
            if(string.IsNullOrWhiteSpace(drzavljanstvo) || drzavljanstvo.Length > 50 || Context.Nacionalnostsi
                .Where(nac => nac.Drzavljanstvo == drzavljanstvo).FirstOrDefault() != null)
            {
                return BadRequest("Ne validno drzavljanstvo ili uneto drzavljanstvo vec postoji u bazi!");
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
    }
}