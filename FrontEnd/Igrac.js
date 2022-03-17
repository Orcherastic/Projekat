export class Igrac
{
    constructor(Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, NazivPozicije, Drzavljanstvo)
    {
        this.Ime = Ime;
        this.Prezime = Prezime;
        this.BrojDresa = BrojDresa;
        this.BrojGodina = BrojGodina;
        this.Kvalitet = Kvalitet;
        this.NazivPozicije = NazivPozicije;
        this.Drzavljanstvo = Drzavljanstvo;
    }
        
    PopuniTabelu(tr)
    {
        var td = document.createElement("td");
        td.innerHTML = this.BrojDresa;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = this.Ime;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = this.Prezime;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = this.BrojGodina;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = this.Kvalitet;
        tr.appendChild(td);
    }
}