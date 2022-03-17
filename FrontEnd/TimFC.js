import {Igrac} from "./Igrac.js"
import {Pozicija} from "./Pozicija.js"
import {Nacionalnost} from "./Nacionalnost.js"

var ListaIgraca = [];

export class TimFC
{
    constructor(ListaPozicija, ListaNacionalnosti, ListaMenadzera, Instanca)
    {
        this.NazivTima = null;
        this.Kvalitet = null;
        this.ListaPozicija = ListaPozicija;
        this.ListaNacionalnosti = ListaNacionalnosti;
        this.ListaMenadzera = ListaMenadzera;
        this.Instanca = Instanca;
        this.Menadzer = null;
        this.Kontroler = null;
    }

    postaviKontrolera(host)
    {
        this.Kontroler = document.createElement("div");
        this.Kontroler.classList.add("Body", "Body" + this.Instanca);
        host.appendChild(this.Kontroler);
    }

    crtanjeHedera()
    {
       
        let Navbar = document.createElement("div");
        Navbar.classList.add( "navbar", "navbar" + this.Instanca );
        this.Kontroler.appendChild(Navbar);

        let kontInfo = document.createElement("div");
        kontInfo.classList.add( "info", "info" + this.Instanca );
        Navbar.appendChild(kontInfo);

        let p1 = document.createElement("p");
        p1.innerHTML = "Napravi svoj fudbalski klub i oformi svoj 'Dream Team'!";
        kontInfo.appendChild(p1);      
    }

    crtanjeSadrzaja()
    {
        let KontrolerSadrzaja = document.createElement('div');
        KontrolerSadrzaja.classList.add("SadrzajDiv", "SadrzajDiv" + this.Instanca);
        this.Kontroler.appendChild(KontrolerSadrzaja);
 
        let KontrolerDugmica = document.createElement('div');
        KontrolerDugmica.classList.add("DugmiciDiv", "DugmiciDiv" + this.Instanca);
        KontrolerSadrzaja.appendChild(KontrolerDugmica);
 
        let RadnaPovrsina = document.createElement('div');
        RadnaPovrsina.classList.add("RadnaPovrsinaDiv", "" + this.Instanca);
        KontrolerSadrzaja.appendChild(RadnaPovrsina);
        this.DodajRadnuPovrsinu(RadnaPovrsina);
    }

    DodajRadnuPovrsinu(host)
    {
        // Informacije o klubu
        let Klub = document.createElement('div');
        Klub.classList.add("Zajednicki", "InfoKluba", "InfoKluba" + this.Instanca);
        host.appendChild(Klub);

        // CRUD operacije
        let OperCRUD = document.createElement('div'); 
        OperCRUD.classList.add("Zajednicki", "OperacijeCRUD","OperacijeCRUD" + this.Instanca);
        host.appendChild(OperCRUD);

         // Biranje iz baze podataka
        let BazaPod = document.createElement('div');
        BazaPod.classList.add("Zajednicki", "BiranjeIzBaze", "BiranjeIzBaze" + this.Instanca);
        host.appendChild(BazaPod);

        // Labele i text
        let FudbalskiKlub = document.createElement("label");
        let nazivKluba = document.createElement("label");
        FudbalskiKlub.className = "tekst" + this.Instanca;
        nazivKluba.className = "tekst" + this.Instanca;
        FudbalskiKlub.innerHTML = "Fudbalski Klub:";
        nazivKluba.innerHTML = "Naziv Kluba:";
        //====== Inner CSS ======\\
        FudbalskiKlub.style.marginTop = '15px';
        FudbalskiKlub.style.marginBottom = '5px';
        FudbalskiKlub.style.fontSize = '30px';
        //=======================\\
        // Input
        let InputNaziva = document.createElement("input");

        Klub.appendChild(FudbalskiKlub);
        Klub.appendChild(nazivKluba);
        Klub.appendChild(InputNaziva);

        // SelectList za Menadzere
        let l = document.createElement("label");
        l.innerHTML= "Menadzer:";
        l.className = "tekst" + this.Instanca;
        Klub.appendChild(l);
      
        let ListM = document.createElement("select");
        ListM.classList.add("SelectList", "SelectList" + this.Instanca);
        Klub.appendChild(ListM);
      
        this.ListaMenadzera.forEach(el =>
        {
            let op = document.createElement("option");
            op.innerHTML = el.Ime + " " + el.Prezime + ", " + el.BrojGodina;
            op.value = el.ID;
            ListM.appendChild(op);
        });

        let NapraviKlub = document.createElement("button");
        NapraviKlub.type = "Submit";
        NapraviKlub.classList.add("SubmitButton", "SubmitButton" + this.Instanca);
        NapraviKlub.innerHTML = "Napravi";
        NapraviKlub.onclick = (ev) =>
        { 
            this.DodajFC(InputNaziva, 1, ListM);   
        };
        Klub.appendChild(NapraviKlub);
    }

    // Dodavanje Fudbalskog Kluba
    DodajFC(naziv, kvalitet, menadzer)
    {
        if(naziv.value.length > 50 || naziv.value.length === 0)
        {
            alert("Nije validan naziv kluba!");
            return false;
        }

        let n = naziv.value;
    
        var f = fetch("https://localhost:5001/TimFC/DodajTim/" + n + "/" + kvalitet +"/" + menadzer.value,
        {
            method:"POST"
        }).then(p => 
            {
                if(p.ok)
                {
                    alert("Uspesno dodat Fudbalski Klub");
                    this.CrtanjeFormi(naziv, kvalitet, menadzer);
                }
                else
                {
                    alert("Doslo je do greske prilikom kreiranja kluba! Klub nije kreiran!");  
                }
            });
        return true;
    }

    // Crtanje potrebnih formi
    CrtanjeFormi(naziv, kvalitet, menadzer)
    {
        if(this.DodajInformacijeKluba(naziv.value, kvalitet.value, menadzer.value))
        {
            this.BrisiUnosKluba(naziv, menadzer);
            this.CrtanjeDetaljaKluba();
            this.DodavanjeIgracaCRUD(); 
        }
    }

    // Postavljanje vrednosti atributa
    DodajInformacijeKluba(naziv, kvalitet, menadzer)
    {
        this.NazivTima = naziv;
        this.Kvalitet = kvalitet;
        this.ListaMenadzera.forEach(el =>
            {
                if(el.ID == menadzer)
                    this.Menadzer = el;
            })
        
        return true;
    }

    BrisiUnosKluba(naziv, menadzer)
    {
        var BrisVrd = document.getElementsByClassName("tekst" + this.Instanca);
        BrisVrd = [].slice.call(BrisVrd)
        BrisVrd.forEach(el =>
            {
                el.remove();
            });
        naziv.remove();
        menadzer.remove();
        BrisVrd = document.getElementsByClassName("SubmitButton" + this.Instanca);
        BrisVrd[0].remove();  
    }

    CrtanjeDetaljaKluba()
    {
        // Naziv i Menadzer Kluba
        let vek = document.getElementsByClassName("InfoKluba" + this.Instanca);
        let host = vek[0];
        let InfoDiv = document.createElement("div");
        InfoDiv.classList.add("Klub","Klub" + this.Instanca);
        host.appendChild(InfoDiv);
      
        let nazivKluba = document.createElement("label");
        nazivKluba.className = "NazivKluba" + this.Instanca;
        nazivKluba.innerHTML = this.NazivTima;
        //====== Inner CSS ======\\
        nazivKluba.style.fontSize = '45px';
        nazivKluba.style.fontStyle = 'italic';
        nazivKluba.style.fontWeight = 'bold';
        //=======================\\
      
        let menadzer = document.createElement("label");
        menadzer.className = "MenadzerKluba" + this.Instanca;
        menadzer.innerHTML = "Menadzer: " + this.Menadzer.Ime + " " + this.Menadzer.Prezime + " (" + this.Menadzer.BrojGodina + ")";
        //====== Inner CSS ======\\
        menadzer.style.fontSize = '30px';
        menadzer.style.fontStyle = 'italic';
        //=======================\\
        
        InfoDiv.append(nazivKluba);
        InfoDiv.append(menadzer);
        
        // Biranje igraca iz baze
        vek = document.getElementsByClassName("BiranjeIzBaze" + this.Instanca);
        let host2 = vek[0];
      
        let Objasnjenje = document.createElement("label");
        Objasnjenje.innerHTML = "Unesite poziciju ili nacionalnost igraca koju zelite u svom timu.";
        //====== Inner CSS ======\\
        Objasnjenje.style.margin = "5px 5px";
        Objasnjenje.style.padding = "2px 2px";
        Objasnjenje.style.fontSize = '25px';
        //=======================\\
        host2.appendChild(Objasnjenje);
        
        let l = document.createElement("label");
        l.innerHTML= "Pozicija:";
        l.className = "tekst" + this.Instanca;
        host2.appendChild(l);

        // Biranje preko Pozicije
        let ListP = document.createElement("select");
        ListP.classList.add("SelectList", "SelectList" + this.Instanca);
        host2.appendChild(ListP);
      
        this.ListaPozicija.forEach(el =>
        {
            let op = document.createElement("option");
            op.innerHTML = el.Naziv;
            op.value = el.ID;
            ListP.appendChild(op);
        });

        // Dugme za pretrazivanje
        let PretraziIgrace = document.createElement("button");
        PretraziIgrace.type = "Submit";
        PretraziIgrace.classList.add("SubmitButton", "SubmitButton" + this.Instanca);
        PretraziIgrace.innerHTML = "Pretrazi";
        PretraziIgrace.onclick = (ev) =>
        { 
            this.VratiIgracePoz(ListP.value);
        }
        host2.appendChild(PretraziIgrace);

        let l1 = document.createElement("label");
        l1.innerHTML= "Nacionalnost:";
        l1.className = "tekst" + this.Instanca;
        host2.appendChild(l1);

        // Biranje preko Nacionalnosti
        let ListN = document.createElement("select");
        ListN.classList.add("SelectList", "SelectList" + this.Instanca);
        host2.appendChild(ListN);
      
        this.ListaNacionalnosti.forEach(el =>
        {
            let op = document.createElement("option");
            op.innerHTML = el.Drzavljanstvo;
            op.value = el.ID;
            ListN.appendChild(op);
        });

        // Dugme za pretrazivanje
        let PretraziIgrace1 = document.createElement("button");
        PretraziIgrace1.type = "Submit";
        PretraziIgrace1.classList.add("SubmitButton", "SubmitButton" + this.Instanca);
        PretraziIgrace1.innerHTML = "Pretrazi";
        PretraziIgrace1.onclick = (ev) =>
        { 
            this.VratiIgraceNac(ListN.value);
        }
        host2.appendChild(PretraziIgrace1);
    }

    OdrediKvalitet(ListaIgraca)
    {
        let i = 0, kvalitet = 0;
        ListaIgraca.forEach(el => 
            {
                kvalitet = kvalitet + el.Kvalitet;
                i++;
            })
        kvalitet = Math.round(kvalitet / i);
        if(kvalitet < 1)
            kvalitet = 1;
        else if (kvalitet > 5)
            kvalitet = 5;
        return kvalitet;
    }

    VratiIgracePoz(PozicijaID)
    {
        if(PozicijaID < 0)
        {
            alert("Nije validna pozicija igraca!");
            return false;
        }

        fetch("https://localhost:5001/Igrac/Preuzmi/" + PozicijaID,
        {
            method:"GET"
        }).then(p =>
            {
                if(p.ok)
                {
                    let Tabela = this.CrtajTabelu();
                    let Kolone = ["#", "Ime", "Prezime", "God", "Kvalitet", "DodajUKlub"];
                    Kolone.forEach(el =>
                    {
                        let head = document.createElement("th");
                        head.innerHTML = el;
                        Tabela.appendChild(head);
                    })
                    p.json().then(m => 
                        {
                            m.forEach(el => 
                                {
                                    var tr = document.createElement("tr");
                                    Tabela.appendChild(tr);

                                    var pObj = new Pozicija(PozicijaID, el.naziv);
                                    const iObj = new Igrac(el.ime, el.prezime, el.brojDresa, el.brojGodina, el.kvalitet, pObj, el.nacionalnost);
                                    let brojDresa = el.brojDresa;
                                    iObj.PopuniTabelu(tr); 

                                    let dodaj = document.createElement("button");
                                    dodaj.type = "Submit";
                                    dodaj.classList.add("DodajUKlubBtn", "DodajUKlubBtn" + this.Instanca);
                                    dodaj.innerHTML = "Dodaj";
                                    dodaj.onclick = (ev) =>
                                    { 
                                        ListaIgraca.push(iObj);
                                        this.DodajIgracaUTim(brojDresa);
                                    }
                                    var td = document.createElement("td");
                                    td = dodaj;
                                    tr.appendChild(td);
                                }); 
                        });
                }
                else
                    alert("Nema igraca sa ovom pozicijom u bazi!");
            })
    }

    VratiIgraceNac(NacionalnostID)
    {
        if(NacionalnostID < 0)
        {
            alert("Nije validna nacionalnost igraca!");
            return false;
        }

        fetch("https://localhost:5001/Igrac/PreuzmiIgraca/" + NacionalnostID,
        {
            method:"GET"
        }).then(p =>
            {
                if(p.ok)
                {
                    let Tabela = this.CrtajTabelu();
                    let Kolone = ["#", "Ime", "Prezime", "God", "Kvalitet", "DodajUKlub"];
                    Kolone.forEach(el =>
                    {
                        let head = document.createElement("th");
                        head.innerHTML = el;
                        Tabela.appendChild(head);
                    })
                    p.json().then(m => 
                        {
                            m.forEach(el => 
                                {
                                    var tr = document.createElement("tr");
                                    Tabela.appendChild(tr);

                                    var nObj = new Nacionalnost(NacionalnostID, el.Drzavljanstvo);
                                    const iObj = new Igrac(el.ime, el.prezime, el.brojDresa, el.brojGodina, el.kvalitet, el.nazivPozicije, nObj);
                                    let brojDresa = el.brojDresa;
                                    iObj.PopuniTabelu(tr); 

                                    let dodaj = document.createElement("button");
                                    dodaj.type = "Submit";
                                    dodaj.classList.add("DodajUKlubBtn", "DodajUKlubBtn" + this.Instanca);
                                    dodaj.innerHTML = "Dodaj";
                                    dodaj.onclick = (ev) =>
                                    { 
                                        ListaIgraca.push(iObj);
                                        this.DodajIgracaUTim(brojDresa);
                                    }
                                    var td = document.createElement("td");
                                    td = dodaj;
                                    tr.appendChild(td);
                                }); 
                        });
                }
                else
                    alert("Nema igraca sa ovom nacionalnoscu u bazi!");
            })
    }

    // Tabela za preuzimanje igraca iz baze
    CrtajTabelu()
    {
        let host = document.getElementsByClassName("BiranjeIzBaze" + this.Instanca);
        var tabela = document.getElementsByClassName("BazaTabela/" + this.Instanca);
        tabela = tabela[0];
        if(tabela != null)
            tabela.remove();
    
        host = host[0];
        let tBody = document.createElement("tbody"); 
        tBody.classList.add("BazaTabela", "BazaTabela/" + this.Instanca);
        host.appendChild(tBody); 
        return tBody;
    }

    // Tabela za dodavanje igraca iz baze u klub
    CrtajGlavnuTabelu()
    {
        let host = document.getElementsByClassName("InfoKluba" + this.Instanca);
        var tabela = document.getElementsByClassName("Header" + this.Instanca);
        tabela = tabela[0];
        if(tabela != null)
            tabela.remove();
    
        host = host[0];
        let tBody = document.createElement("tbody"); 
        tBody.classList.add("Header", "Header" + this.Instanca);
        host.appendChild(tBody); 

        return tBody;
    }   

    DodajIgracaUTim(brojDresa)
    {
        fetch("https://localhost:5001/TimFC/DodajIgracaUTim/" + this.NazivTima + "/" + brojDresa,
        {
            method:"PUT"
        }).then(p =>
            {
                if(p.ok)
                {
                    // Tabela/Graf igraca u klubu
                    let Tabela = this.CrtajGlavnuTabelu();
                    let Kolone = ["#", "Ime", "Prezime", "God", "Kvalitet"];
                    Kolone.forEach(el =>
                    {
                        let head = document.createElement("th");
                        head.innerHTML = el;
                        Tabela.appendChild(head);
                    })

                    ListaIgraca.forEach(el =>
                        {
                            var tr = document.createElement("tr");
                            Tabela.appendChild(tr);

                            const iObj = new Igrac(el.Ime, el.Prezime, el.BrojDresa, el.BrojGodina, el.Kvalitet, el.Naziv, el.Drzavljanstvo);
                            iObj.PopuniTabelu(tr);
                            this.Kvalitet = this.OdrediKvalitet(ListaIgraca);
                        })
                    
                    let kvalitetKluba = document.createElement("label");
                    kvalitetKluba.className = "KvalitetKluba" + this.Instanca;
                    kvalitetKluba.innerHTML = "Kvalitet: " + this.Kvalitet;
                    //====== Inner CSS ======\\
                    kvalitetKluba.style.fontSize = '30px';
                    kvalitetKluba.style.fontStyle = 'italic';
                    //=======================\\
                    Tabela.append(kvalitetKluba);
                }           
                else
                alert("Doslo je do greske igrac nije dodat");
            });
    }
    
    DodavanjeIgracaCRUD()
    {
        let host = document.getElementsByClassName("OperacijeCRUD" + this.Instanca);
        host = host[0];
        let dodaj = document.createElement("label");
        dodaj.innerHTML = "ADD";
        //====== Inner CSS ======\\
        dodaj.style.fontWeight = 'bold';
        dodaj.style.outline = '1px solid black';
        dodaj.style.background = 'rgb(97, 194, 73)';
        dodaj.style.color = 'black';
        //=======================\\
        dodaj.classList.add("tekst" + this.Instanca, "labelaCRUD", "lableDodaj");
        host.appendChild(dodaj);

        // Atributi igraca
        let ime = document.createElement("label");
        ime.innerHTML = "Ime: ";
        ime.className = "tekst" + this.Instanca;

        let prezime = document.createElement("label");
        prezime.innerHTML = "Prezime: ";
        prezime.className = "tekst" + this.Instanca;

        let brojDresa = document.createElement("label");
        brojDresa.innerHTML = "Broj Dresa: ";
        brojDresa.className = "tekst" + this.Instanca;

        let brojGodina = document.createElement("label");
        brojGodina.innerHTML = "Broj Godina: "
        brojGodina.className = "tekst" + this.Instanca;

        let kvalitet = document.createElement("label");
        kvalitet.innerHTML = "Kvalitet: "
        kvalitet.className = "tekst" + this.Instanca;
    
        let inputImena = document.createElement("input");
        inputImena.className = "tekst" + this.Instanca;

        let inputPrezimena = document.createElement("input");
        inputPrezimena.className = "tekst" + this.Instanca;

        let inputBrojaDresa = document.createElement("input");
        inputBrojaDresa.className = "tekst" + this.Instanca;
        inputBrojaDresa.type = "number";

        let inputBrojaGodina = document.createElement("input");
        inputBrojaGodina.className = "tekst" + this.Instanca;
        inputBrojaGodina.type = "number";

        let inputKvaliteta = document.createElement("input");
        inputKvaliteta.className = "tekst" + this.Instanca;
        inputKvaliteta.type = "number";

        host.appendChild(ime);
        host.appendChild(inputImena);

        host.appendChild(prezime);
        host.appendChild(inputPrezimena);

        host.appendChild(brojDresa);
        host.appendChild(inputBrojaDresa);

        host.appendChild(brojGodina);
        host.appendChild(inputBrojaGodina);

        host.appendChild(kvalitet);
        host.appendChild(inputKvaliteta);
        
        // Select za pozicije
        let l = document.createElement("label");
        l.innerHTML= "Pozicija: ";
        l.className = "tekst" + this.Instanca;
        host.appendChild(l);

        let ListP = document.createElement("select");
        ListP.classList.add("SelectList", "SelectList" + this.Instanca);
        host.appendChild(ListP);

        this.ListaPozicija.forEach(el =>
            {
                let op = document.createElement("option");
                op.innerHTML = el.Naziv;
                op.value = el.ID;
                ListP.appendChild(op);
            });

        // Select za nacionalnost
        let l1 = document.createElement("label");
        l1.innerHTML= "Nacionalnost: ";
        l1.className = "tekst" + this.Instanca;
        host.appendChild(l1);

        let ListN = document.createElement("select");
        ListN.classList.add("SelectList", "SelectList" + this.Instanca);
        host.appendChild(ListN);

        this.ListaNacionalnosti.forEach(el =>
            {
                let op = document.createElement("option");
                op.innerHTML = el.Drzavljanstvo;
                op.value = el.ID;
                ListN.appendChild(op);
            });

        let dodajBtn = document.createElement("button");
        dodajBtn.type = "Submit";
        dodajBtn.classList.add("SubmitButton", "SubmitButton" + this.Instanca);
        dodajBtn.innerHTML = "Dodaj";
        dodajBtn.onclick = (ev) =>
        { 
            this.DodajIgraca(inputImena, inputPrezimena, inputBrojaDresa, inputBrojaGodina, inputKvaliteta, ListP, ListN);   
        }
    
        host.appendChild(dodajBtn);
        this.MenjanjeIgracaCRUD(host);
    }

    MenjanjeIgracaCRUD(host)
    {
        let promeni = document.createElement("label");
        promeni.innerHTML = "UPDATE";
        //====== Inner CSS ======\\
        promeni.style.outline = '1px solid black';
        promeni.style.background = 'rgb(255 255 0)';
        promeni.style.fontWeight = 'bold';
        promeni.style.color = 'black';
        //=======================\\
        promeni.classList.add("tekst" + this.Instanca, "labelaCRUD");
        host.appendChild(promeni);
        
        let brojDresa = document.createElement("label");
        brojDresa.innerHTML = "Broj Dresa: "
        brojDresa.className = "tekst" + this.Instanca;

        let inputBrojaDresa = document.createElement("input");
        inputBrojaDresa.className = "tekst" + this.Instanca;

        host.appendChild(brojDresa);
        host.appendChild(inputBrojaDresa);

        let l = document.createElement("label");
        l.innerHTML= "Pozicija: ";
        l.className = "tekst" + this.Instanca;
        host.appendChild(l);

        // Select za poziciju
        let ListP = document.createElement("select");
        ListP.classList.add("SelectList", "SelectList" + this.Instanca);
        host.appendChild(ListP);

        this.ListaPozicija.forEach(el =>
            {
                let op = document.createElement("option");
                op.innerHTML = el.Naziv;
                op.value = el.ID;
                ListP.appendChild(op);
            });

        let l1 = document.createElement("label");
        l1.innerHTML= "Nacionalnost: ";
        l1.className = "tekst" + this.Instanca;
        host.appendChild(l1);
        
        // Select za nacionalnost
        let ListN = document.createElement("select");
        ListN.classList.add("SelectList", "SelectList" + this.Instanca);
        host.appendChild(ListN);

        this.ListaNacionalnosti.forEach(el =>
            {
                let op = document.createElement("option");
                op.innerHTML = el.Drzavljanstvo;
                op.value = el.ID;
                ListN.appendChild(op);
            });

        let menjajBtb = document.createElement("button");
        menjajBtb.type = "Submit";
        menjajBtb.classList.add("SubmitButton", "SubmitButton" + this.Instanca);
        menjajBtb.innerHTML = "Promeni";
        menjajBtb.onclick = (ev) =>
        { 
            this.IzmeniIgraca(inputBrojaDresa, ListP, ListN);
        }

        host.appendChild(menjajBtb);
        this.BrisanjeIgracaCRUD(host);
    }

    BrisanjeIgracaCRUD(host)
    {
        let brisi = document.createElement("label");
        brisi.innerHTML = "DELETE";
        //====== Inner CSS ======\\
        brisi.style.outline = '1px solid black';
        brisi.style.background = 'rgb(255 0 0)';
        brisi.style.fontWeight = 'bold';
        brisi.style.color = 'white';
        //=======================\\
        brisi.classList.add("tekst" + this.Instanca, "labelaCRUD");
        host.appendChild(brisi);
    
        let brojDresa = document.createElement("label");
        brojDresa.innerHTML = "Broj Dresa: "
        brojDresa.className = "tekst" + this.Instanca;

        let inputBrojaDresa = document.createElement("input");
        inputBrojaDresa.className = "tekst" + this.Instanca;

        host.appendChild(brojDresa);
        host.appendChild(inputBrojaDresa);

        let brisiBtn = document.createElement("button");
        brisiBtn.type = "Submit";
        brisiBtn.classList.add("SubmitButton", "SubmitButton" + this.Instanca );
        brisiBtn.innerHTML = "Obrisi";
        brisiBtn.onclick = (ev) =>
        { 
            this.ObrisiIgraca(inputBrojaDresa);
        }
        host.appendChild(brisiBtn);
    }

    DodajIgraca(Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, Poz, Nac)
    {
        if(Ime.value.lenght > 30 || Ime.value.lenght == 0)
        {
            alert("Nije validno ime igraca!");
            return false;
        }
        if(Prezime.value.lenght > 30 || Prezime.value.lenght == 0)
        {
            alert("Nije validno prezime igraca!");
            return false;
        }
        if(BrojDresa.value > 99 || BrojDresa.value < 1)
        {
            alert("Nije validan broj dresa igraca!");
            return false;
        }
        if(BrojGodina.value > 42 || BrojGodina.value < 16)
        {
            alert("Nije validan broj godina igraca!");
            return false;
        }
        if(Poz < 0)
        {
            alert("Unesite poziciju igraca!");
            return false;
        }
        if(Nac < 0)
        {
            alert("Unesite nacionalnost igraca!");
            return false;
        }
        fetch("https://localhost:5001/Igrac/DodajIgraca/" + Ime.value + "/" + Prezime.value + "/" + BrojDresa.value + "/" + BrojGodina.value + "/" + Kvalitet.value + "/" + Poz.value + "/" + Nac.value + "/" + this.NazivTima,
        {
            method:"POST"
        }).then(p =>
            {
                if(p.ok)
                {
                    alert("Uspesno dodat igrac u bazu!");    
                }           
                else
                    alert("Doslo je do greske prilikom dodavanja igraca, igrac nije dodat u bazu!");
            });
    }

    IzmeniIgraca(BrojDresa, Poz, Nac)
    {
        if(BrojDresa.value > 99 || BrojDresa.value < 1)
        {
            alert("Nije validan broj dresa igraca!");
            return false;
        }
        if(Poz < 0)
        {
            alert("Unesite poziciju igraca!");
            return false;
        }
        if(Nac < 0)
        {
            alert("Unesite nacionalnost igraca!");
            return false;
        }

        fetch("https://localhost:5001/Igrac/PromeniIgraca/" + BrojDresa.value +"/" + Poz.value + "/" + Nac.value + "/" + this.NazivTima,
        {
            method:"PUT"
        }).then(p =>
            {
                if(p.ok)
                {
                    alert("Uspesno izmenjen igrac!");
                }           
                else
                    alert("Doslo je do greske prilikom promene igraca, igrac nije promenjen!");
        });
    }

    ObrisiIgraca(BrojDresa)
    {
        if(BrojDresa.value > 99 || BrojDresa.value < 1)
        {
            alert("Nije validan broj dresa igraca!");
            return false;
        }

        fetch("https://localhost:5001/Igrac/ObrisiIgraca/" + BrojDresa.value,
        {
            method:"DELETE"
        }).then(p =>
            {
                if(p.ok)
                {
                    alert("Uspesno obrisan igrac!");
                }           
                else
                    alert("Doslo je do greske prilikom brisanja igraca, igrac nije izbrisan!");
        });       
    }
}