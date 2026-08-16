/* =====================================================================
   02_SeedData.sql
   Test podaci za bazu SuplementiDB.

   Skript se moze pokretati vise puta. Identifikatori se upisuju
   eksplicitno preko SET IDENTITY_INSERT, pa su uvek isti bez obzira
   na to u kakvom je stanju baza bila pre pokretanja.
   ===================================================================== */

USE SuplementiDB;
GO

/* --- Brisanje postojecih podataka (obrnuto od redosleda zavisnosti) --- */
DELETE FROM stavkaRacuna;
DELETE FROM racun;
DELETE FROM prodavacKvalifikacija;
DELETE FROM kupac;
DELETE FROM prodavac;
DELETE FROM suplementacija;
DELETE FROM kvalifikacija;
DELETE FROM grad;
GO

/* --- 1. GRAD --- */
SET IDENTITY_INSERT grad ON;
INSERT INTO grad (idGrad, nazivGrad, postanskiBroj) VALUES
    (1, 'Beograd',    '11000'),
    (2, 'Novi Sad',   '21000'),
    (3, 'Nis',        '18000'),
    (4, 'Smederevo',  '11300'),
    (5, 'Kragujevac', '34000');
SET IDENTITY_INSERT grad OFF;
DBCC CHECKIDENT ('grad', RESEED, 5);
GO

/* --- 2. KVALIFIKACIJA --- */
SET IDENTITY_INSERT kvalifikacija ON;
INSERT INTO kvalifikacija (idKvalifikacija, nazivKvalifikacija, nivoStrucnosti) VALUES
    (1, 'Nutricionisticki savetnik',        'Junior'),
    (2, 'Nutricionisticki savetnik',        'Senior'),
    (3, 'Specijalista za sportsku ishranu', 'Senior'),
    (4, 'Specijalista za sportsku ishranu', 'Master'),
    (5, 'Farmaceutski tehnicar',            'Junior');
SET IDENTITY_INSERT kvalifikacija OFF;
DBCC CHECKIDENT ('kvalifikacija', RESEED, 5);
GO

/* --- 3. SUPLEMENTACIJA --- */
SET IDENTITY_INSERT suplementacija ON;
INSERT INTO suplementacija
    (idSuplementacija, nazivSuplementacija, brendSuplementacija, cena, netoKolicina) VALUES
    (1, 'Whey protein',       'Optimum Nutrition', 5900, '900g'),
    (2, 'Kreatin monohidrat', 'MyProtein',         2400, '500g'),
    (3, 'BCAA 2:1:1',         'Scitec Nutrition',  3100, '300g'),
    (4, 'Omega 3',            'Now Foods',         1850, '180 kapsula'),
    (5, 'Magnezijum',         'Solgar',            1450, '100 tableta'),
    (6, 'Vitamin D3',         'Now Foods',          990, '120 kapsula');
SET IDENTITY_INSERT suplementacija OFF;
DBCC CHECKIDENT ('suplementacija', RESEED, 6);
GO

/* --- 4. PRODAVAC ---
   Podaci za prijavu na sistem:
        korisnicko ime: veljko    sifra: veljko123
        korisnicko ime: marija    sifra: marija123          */
SET IDENTITY_INSERT prodavac ON;
INSERT INTO prodavac
    (idProdavac, imeProdavac, prezimeProdavac, korisnickoIme, sifra, emailProdavac, datumZaposlenja) VALUES
    (1, 'Veljko', 'Djuric',  'veljko', 'veljko123', 'veljko.djuric@gmail.com',  '2023-03-01'),
    (2, 'Marija', 'Jovanic', 'marija', 'marija123', 'marija.jovanic@gmail.com', '2024-06-15');
SET IDENTITY_INSERT prodavac OFF;
DBCC CHECKIDENT ('prodavac', RESEED, 2);
GO

/* --- 5. KUPAC --- */
SET IDENTITY_INSERT kupac ON;
INSERT INTO kupac (idKupac, imeKupac, prezimeKupac, emailKupac, adresaKupac, idGrad) VALUES
    (1, 'Nikola', 'Petrovic', 'nikola.petrovic@gmail.com', 'Knez Mihailova 12', 1),
    (2, 'Ana',    'Ilic',     'ana.ilic@yahoo.com',        'Zmaj Jovina 5',     2),
    (3, 'Stefan', 'Markovic', 'stefan.markovic@gmail.com', 'Karadjordjeva 88',  4),
    (4, 'Jelena', 'Nikolic',  'jelena.nikolic@gmail.com',  'Obilicev venac 3',  1);
SET IDENTITY_INSERT kupac OFF;
DBCC CHECKIDENT ('kupac', RESEED, 4);
GO

/* --- 6. PRODAVAC-KVALIFIKACIJA --- */
INSERT INTO prodavacKvalifikacija (idProdavac, idKvalifikacija, datumSticanja) VALUES
    (1, 1, '2023-05-10'),
    (1, 3, '2024-02-20'),
    (2, 5, '2024-09-01');
GO

/* --- 7. RACUN + STAVKE ---
   ukupanIznos svakog racuna = suma iznosa njegovih stavki   */
SET IDENTITY_INSERT racun ON;

-- Racun 1: 1 x Whey (5900) + 2 x Kreatin (4800) = 10700
INSERT INTO racun (idRacun, ukupanIznos, datumIzvrsenja, idProdavac, idKupac)
    VALUES (1, 10700, '2025-11-10', 1, 1);

-- Racun 2: 3 x Omega 3 (5550) + 1 x Magnezijum (1450) = 7000
INSERT INTO racun (idRacun, ukupanIznos, datumIzvrsenja, idProdavac, idKupac)
    VALUES (2, 7000, '2025-11-18', 1, 2);

-- Racun 3: 2 x BCAA (6200) = 6200
INSERT INTO racun (idRacun, ukupanIznos, datumIzvrsenja, idProdavac, idKupac)
    VALUES (3, 6200, '2025-11-25', 2, 3);

SET IDENTITY_INSERT racun OFF;
DBCC CHECKIDENT ('racun', RESEED, 3);
GO

INSERT INTO stavkaRacuna (idRacun, rb, cena, kolicina, iznos, idSuplementacija) VALUES
    (1, 1, 5900, 1, 5900, 1),
    (1, 2, 2400, 2, 4800, 2),
    (2, 1, 1850, 3, 5550, 4),
    (2, 2, 1450, 1, 1450, 5),
    (3, 1, 3100, 2, 6200, 3);
GO

PRINT 'Test podaci su uspesno ubaceni.';
GO

/* --- Provera --- */
SELECT 'grad' AS tabela, COUNT(*) AS brojSlogova FROM grad
UNION ALL SELECT 'kvalifikacija',         COUNT(*) FROM kvalifikacija
UNION ALL SELECT 'suplementacija',        COUNT(*) FROM suplementacija
UNION ALL SELECT 'prodavac',              COUNT(*) FROM prodavac
UNION ALL SELECT 'kupac',                 COUNT(*) FROM kupac
UNION ALL SELECT 'prodavacKvalifikacija', COUNT(*) FROM prodavacKvalifikacija
UNION ALL SELECT 'racun',                 COUNT(*) FROM racun
UNION ALL SELECT 'stavkaRacuna',          COUNT(*) FROM stavkaRacuna;
GO
