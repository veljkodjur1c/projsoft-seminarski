/* =====================================================================
   02_SeedData.sql
   Test podaci za bazu SuplementiDB.

   Skript se moze pokretati vise puta - prvo brise sve podatke
   i resetuje IDENTITY brojace, pa tek onda upisuje.
   ===================================================================== */

USE SuplementiDB;
GO

/* --- Brisanje postojecih podataka (obrnutim redosledom od zavisnosti) --- */
DELETE FROM stavkaRacuna;
DELETE FROM racun;
DELETE FROM prodavacKvalifikacija;
DELETE FROM kupac;
DELETE FROM prodavac;
DELETE FROM suplementacija;
DELETE FROM kvalifikacija;
DELETE FROM grad;
GO

DBCC CHECKIDENT ('grad',           RESEED, 0);
DBCC CHECKIDENT ('kvalifikacija',  RESEED, 0);
DBCC CHECKIDENT ('suplementacija', RESEED, 0);
DBCC CHECKIDENT ('prodavac',       RESEED, 0);
DBCC CHECKIDENT ('kupac',          RESEED, 0);
DBCC CHECKIDENT ('racun',          RESEED, 0);
GO

/* --- 1. GRAD --- */
INSERT INTO grad VALUES ('Beograd',    '11000');
INSERT INTO grad VALUES ('Novi Sad',   '21000');
INSERT INTO grad VALUES ('Nis',        '18000');
INSERT INTO grad VALUES ('Smederevo',  '11300');
INSERT INTO grad VALUES ('Kragujevac', '34000');
GO

/* --- 2. KVALIFIKACIJA --- */
INSERT INTO kvalifikacija VALUES ('Nutricionisticki savetnik',       'Junior');
INSERT INTO kvalifikacija VALUES ('Nutricionisticki savetnik',       'Senior');
INSERT INTO kvalifikacija VALUES ('Specijalista za sportsku ishranu','Senior');
INSERT INTO kvalifikacija VALUES ('Specijalista za sportsku ishranu','Master');
INSERT INTO kvalifikacija VALUES ('Farmaceutski tehnicar',           'Junior');
GO

/* --- 3. SUPLEMENTACIJA --- */
INSERT INTO suplementacija VALUES ('Whey protein',      'Optimum Nutrition', 5900,  '900g');
INSERT INTO suplementacija VALUES ('Kreatin monohidrat','MyProtein',         2400,  '500g');
INSERT INTO suplementacija VALUES ('BCAA 2:1:1',        'Scitec Nutrition',  3100,  '300g');
INSERT INTO suplementacija VALUES ('Omega 3',           'Now Foods',         1850,  '180 kapsula');
INSERT INTO suplementacija VALUES ('Magnezijum',        'Solgar',            1450,  '100 tableta');
INSERT INTO suplementacija VALUES ('Vitamin D3',        'Now Foods',         990,   '120 kapsula');
GO

/* --- 4. PRODAVAC ---
   Podaci za prijavu na sistem:
        korisnicko ime: veljko    sifra: veljko123
        korisnicko ime: marija    sifra: marija123          */
INSERT INTO prodavac VALUES
    ('Veljko', 'Djuric',  'veljko', 'veljko123', 'veljko.djuric@gmail.com',  '2023-03-01');
INSERT INTO prodavac VALUES
    ('Marija', 'Jovanic', 'marija', 'marija123', 'marija.jovanic@gmail.com', '2024-06-15');
GO

/* --- 5. KUPAC --- */
INSERT INTO kupac VALUES ('Nikola', 'Petrovic', 'nikola.petrovic@gmail.com', 'Knez Mihailova 12', 1);
INSERT INTO kupac VALUES ('Ana',    'Ilic',     'ana.ilic@yahoo.com',        'Zmaj Jovina 5',     2);
INSERT INTO kupac VALUES ('Stefan', 'Markovic', 'stefan.markovic@gmail.com', 'Karadjordjeva 88',  4);
INSERT INTO kupac VALUES ('Jelena', 'Nikolic',  'jelena.nikolic@gmail.com',  'Obilicev venac 3',  1);
GO

/* --- 6. PRODAVAC-KVALIFIKACIJA --- */
INSERT INTO prodavacKvalifikacija VALUES (1, 1, '2023-05-10');
INSERT INTO prodavacKvalifikacija VALUES (1, 3, '2024-02-20');
INSERT INTO prodavacKvalifikacija VALUES (2, 5, '2024-09-01');
GO

/* --- 7. RACUN + STAVKE ---
   ukupanIznos svakog racuna = suma iznosa njegovih stavki   */

-- Racun 1: 1 x Whey (5900) + 2 x Kreatin (4800) = 10700
INSERT INTO racun VALUES (10700, '2025-11-10', 1, 1);
INSERT INTO stavkaRacuna VALUES (1, 1, 5900, 1, 5900, 1);
INSERT INTO stavkaRacuna VALUES (1, 2, 2400, 2, 4800, 2);

-- Racun 2: 3 x Omega 3 (5550) + 1 x Magnezijum (1450) = 7000
INSERT INTO racun VALUES (7000, '2025-11-18', 1, 2);
INSERT INTO stavkaRacuna VALUES (2, 1, 1850, 3, 5550, 4);
INSERT INTO stavkaRacuna VALUES (2, 2, 1450, 1, 1450, 5);

-- Racun 3: 2 x BCAA (6200) = 6200
INSERT INTO racun VALUES (6200, '2025-11-25', 2, 3);
INSERT INTO stavkaRacuna VALUES (3, 1, 3100, 2, 6200, 3);
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
