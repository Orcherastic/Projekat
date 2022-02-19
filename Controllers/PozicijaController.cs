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

        [Route("DodajPoziciju/{Naziv}")]
        [HttpPost]
        public async Task<ActionResult> DodajPoziciju(string naziv)
        {
            if(string.IsNullOrWhiteSpace(naziv) || naziv.Length > 30 || Context.Pozicije
                .Where(poz => poz.Naziv == naziv).FirstOrDefault() != null)
            {
                return BadRequest("Ne validna pozicija ili uneta pozicija vec postoji u bazi!");
            }

            try
            {
                Pozicija NovaPozicija = new Pozicija
                {
                    Naziv = naziv
                };

                Context.Pozicije.Add(NovaPozicija);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno dodata nova pozicija {NovaPozicija.Naziv}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}