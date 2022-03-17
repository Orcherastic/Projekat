import {TimFC} from "./TimFC.js"
import {Pozicija} from "./Pozicija.js"
import {Nacionalnost} from "./Nacionalnost.js"
import {Menadzer} from "./Menadzer.js"

var ListaPozicija = [];
var ListaNacionalnosti = [];
var ListaMenadzera = [];

fetch("https://localhost:5001/Pozicija/PreuzmiPoziciju").then(p =>
{
    p.json().then(m => 
    {
        m.forEach(el => 
        {
            var obj = new Pozicija(el.id, el.naziv);
            ListaPozicija.push(obj);
        });
    })
    fetch("https://localhost:5001/Nacionalnost/PreuzmiNacionalnost").then(p =>
    {
        p.json().then(m => 
        {
            m.forEach(el => 
            {
                var obj = new Nacionalnost(el.id, el.drzavljanstvo);
                ListaNacionalnosti.push(obj);
            });
        })
        fetch("https://localhost:5001/Menadzer/PreuzmiMenadzera").then(p =>
        {
            p.json().then(m => 
            {
                m.forEach(el => 
                {
                    var obj = new Menadzer(el.id, el.ime, el.prezime, el.brojGodina);
                    ListaMenadzera.push(obj);
                });

                for(let i=1; i<=2; i++)
                {
                    var f = new TimFC(ListaPozicija, ListaNacionalnosti, ListaMenadzera, i);
                    f.postaviKontrolera(document.body);
                    if(i == 1)
                        f.crtanjeHedera();
                    f.crtanjeSadrzaja();
                }
            })
        })
    })
})
