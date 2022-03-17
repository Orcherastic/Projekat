SET IDENTITY_INSERT Pozicije ON;

INSERT INTO Pozicije(ID, Naziv) VALUES (1,'Goalkeeper');
INSERT INTO Pozicije(ID, Naziv) VALUES (2,'Left Back');
INSERT INTO Pozicije(ID, Naziv) VALUES (3,'Center Back');
INSERT INTO Pozicije(ID, Naziv) VALUES (4,'Right Back');
INSERT INTO Pozicije(ID, Naziv) VALUES (5,'Defensive Midfielder');
INSERT INTO Pozicije(ID, Naziv) VALUES (6,'Left Midfielder');
INSERT INTO Pozicije(ID, Naziv) VALUES (7,'Central Midfielder');
INSERT INTO Pozicije(ID, Naziv) VALUES (8,'Right Midfielder');
INSERT INTO Pozicije(ID, Naziv) VALUES (9,'Attacking Midfielder');
INSERT INTO Pozicije(ID, Naziv) VALUES (10,'Left Wing');
INSERT INTO Pozicije(ID, Naziv) VALUES (11,'Striker');
INSERT INTO Pozicije(ID, Naziv) VALUES (12,'Right Wing');

SET IDENTITY_INSERT Pozicije OFF;

SET IDENTITY_INSERT Nacionalnosti ON;

INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (1,'Srbin');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (2,'Spanac');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (3,'Portugalac');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (4,'Nemac');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (5,'Englez');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (6,'Francuz');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (7,'Italijan');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (8,'Belgijanac');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (9,'Rus');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (10,'Holandjanin');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (11,'Argentinac');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (12,'Brazilac');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (13,'Cileanac');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (14,'Urugvajac');
INSERT INTO Nacionalnosti(ID, Drzavljanstvo) VALUES (15,'Meksikanac');
  
SET IDENTITY_INSERT Nacionalnosti OFF;

SET IDENTITY_INSERT Menadzeri ON;

INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (1,'Pep','Guardiola', 51);
INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (2,'Jurgen','Klopp', 54);
INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (3,'Antonio','Conte', 52);
INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (4,'Jose','Mourinho', 59);
INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (5,'Karlo','Anceloti', 62);
INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (6,'Zinedine','Zidane', 49);
INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (7,'Thomas','Tuchel', 48);
INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (8,'Claudio','Ranieri', 70);
INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (9,'Diego','Simeone', 51);
INSERT INTO Menadzeri(ID, Ime, Prezime, BrojGodina) VALUES (10,'Dragan','Stojkovic', 57);
  
SET IDENTITY_INSERT Menadzeri OFF;	

SET IDENTITY_INSERT Igraci ON;

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(1, 'Dusan', 'Tadic', 20, 33, 4, 9, 1);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(2, 'Dusan', 'Vlahovic', 12, 22, 3, 11, 1);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(3, 'Sergej', 'Milinkovic Savic', 16, 27, 3, 7, 1);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(4, 'Predrag', 'Rajkovic', 25, 26, 2, 1, 1);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(5, 'Cesar', 'Azpilicueta', 2, 32, 3, 4, 2);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(6, 'Jordi', 'Alba', 13, 32, 3, 2, 2);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(7, 'David', 'de Gea', 21, 31, 4, 1, 2);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(8, 'Sergio', 'Busquets', 5, 33, 4, 5, 2);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(9, 'Kepa', 'Arrizabalaga', 18, 27, 2, 1, 2);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(10, 'Sergio', 'Ramos', 4, 35, 5, 3, 2);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(11, 'Alvaro', 'Morata', 19, 29, 3, 11, 2);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(12, 'Cristiano', 'Ronaldo', 7, 37, 5, 11, 3);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(13, 'Bernardo', 'Silva', 17, 27, 4, 10, 3);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(14, 'Bruno', 'Fernandes', 28, 27, 3, 9, 3);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(15, 'Pepe', 'Ferreira', 14, 39, 4, 3, 3);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(16, 'Joao', 'Cancelo', 33, 27, 3, 4, 3);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(17, 'Rui', 'Patricio', 25, 34, 3, 1, 3);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(18, 'Joao', 'Felix', 22, 20, 3, 12, 3);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(19, 'Thomas', 'Muller', 15, 32, 4, 9, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(20, 'Leroy', 'Sane', 23, 26, 3, 12, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(21, 'Marco', 'Reus', 29, 32, 4, 10, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(22, 'Leon', 'Goretzka', 36, 27, 3, 7, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(23, 'Kai', 'Havertz', 43, 22, 3, 9, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(24, 'Antonio', 'Rudiger', 39, 29, 2, 3, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(25, 'Ilkay', 'Gundogan', 31, 31, 3, 7, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(26, 'Joshua', 'Kimmich', 44, 27, 4, 4, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(27, 'Timo', 'Werner', 40, 26, 2, 11, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(28, 'Manuel', 'Neuer', 1, 35, 5, 1, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(29, 'Marc Andre', 'ter Stegen', 32, 29, 3, 1, 4);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(30, 'Mats', 'Hummels', 41, 33, 3, 3, 4);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(31, 'Trent', 'Alexander Arnold', 50, 23, 4, 4, 5);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(32, 'Harry', 'Maguire', 69, 29, 1, 3, 5);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(33, 'Phil', 'Foden', 72, 21, 3, 9, 5);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(34, 'Harry', 'Kane', 9, 28, 4, 11, 5);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(35, 'Luke', 'Shaw', 61, 26, 2, 2, 5);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(36, 'Jordan', 'Henderson', 53, 31, 3, 5, 5);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(37, 'Jordan', 'Pickford', 88, 28, 2, 1, 5);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(38, 'Kylian', 'Mbappe', 11, 23, 5, 12, 6);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(39, 'Karim', 'Benzema', 30, 34, 4, 11, 6);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(40, 'Antoine', 'Griezmann', 45, 30, 3, 10, 6);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(41, 'Hugo', 'Lloris', 24, 35, 4, 1, 6);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(42, 'Benjamin', 'Pavard', 38, 25, 3, 2, 6);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(43, 'NGolo', 'Kante', 6, 30, 4, 7, 6);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(44, 'Gianluigi', 'Donnarumma', 60, 23, 4, 1, 7);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(45, 'Leonardo', 'Bonucci', 68, 34, 4, 3, 7);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(46, 'Giorgio', 'Chiellini', 3, 37, 5, 3, 7);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(47, 'Ciro', 'Immobile', 99, 32, 3, 11, 7);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(48, 'Jorginho', 'Fiho', 47, 30, 4, 6, 7);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(49, 'Thorgan', 'Hazard', 64, 28, 3, 8, 8);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(50, 'Kevin', 'De Bruyne', 8, 30, 5, 9, 8);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(51, 'Yannick', 'Carrasco', 71, 28, 2, 6, 8);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(52, 'Axel', 'Witsel', 58, 33, 2, 5, 8);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(53, 'Divock', 'Origi', 55, 26, 2, 11, 8);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(54, 'Thibaut', 'Courtois', 2, 29, 4, 1, 8);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(55, 'Romelu', 'Lukaku', 66, 28, 3, 11, 8);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(56, 'Fyodor', 'Smolov', 76, 32, 2, 11, 9);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(57, 'Alexandr', 'Golovin', 81, 25, 3, 9, 9);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(58, 'Denis', 'Cheryshev', 89, 31, 2, 10, 9);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(59, 'Virgil', 'van Dijk', 37, 30, 4, 3, 10);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(60, 'Tim', 'Krul', 90, 33, 2, 1, 10);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(61, 'Georginio', 'Wijnaldum', 98, 31, 3, 7, 10);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(62, 'Memphis', 'Depay', 74, 28, 3, 12, 10);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(63, 'Frankie', 'de Jong', 63, 24, 3, 7, 10);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(64, 'Matthijs', 'de Ligt', 95, 22, 3, 3, 10);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(65, 'Lionel', 'Messi', 10, 34, 5, 12, 11);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(66, 'Angel', 'Di Maria', 57, 34, 3, 6, 11);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(67, 'Paulo', 'Dybala', 46, 28, 3, 9, 11);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(68, 'Neymar', 'Junior', 42, 30, 5, 10, 12);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(69, 'Roberto', 'Firmino', 78, 30, 3, 11, 12);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(70, 'Danilo', 'da Silva', 82, 30, 2, 4, 12);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(71, 'Alisson', 'Becker', 79, 29, 4, 1, 12);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(72, 'Ederson', 'de Moraes', 59, 28, 4, 1, 12);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(73, 'Thiago', 'Silva', 51, 37, 4, 3, 12);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(74, 'Dani', 'Alves', 85, 38, 4, 4, 12);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(75, 'Carlos', 'Casemiro', 63, 30, 3, 5, 12);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(76, 'Vinicius', 'Junior', 67, 21, 3, 10, 12);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(77, 'Alexis', 'Sanchez', 75, 33, 3, 12, 13);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(78, 'Arturo', 'Vidal', 96, 34, 3, 7, 13);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(79, 'Luis', 'Suarez', 93, 35, 4, 11, 14);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(80, 'Diego', 'Godin', 62, 36, 3, 3, 14);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(81, 'Edison', 'Cavani', 83, 35, 3, 11, 14);

INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(83, 'Guillermo', 'Ochoa', 87, 36, 3, 1, 15);
INSERT INTO Igraci(ID, Ime, Prezime, BrojDresa, BrojGodina, Kvalitet, PozicijaID, NacionalnostID) VALUES(84, 'Jesus', 'Corona', 92, 29, 2, 12, 15);

SET IDENTITY_INSERT Igraci OFF;