/* =====================================================================
   Softverski sistem za prodaju suplementacije
   Projektovanje softvera - FON, Katedra za softversko inzenjerstvo
   Student: Veljko Djuric 2023/0039

   01_CreateDatabase.sql
   Kreiranje baze podataka na osnovu relacionog modela (poglavlje 3.5)
   i tabela strukturnih i vrednosnih ogranicenja (poglavlje 3.6).

   VAZNO: Redosled kolona u svakoj tabeli MORA da odgovara redosledu
   atributa u relacionom modelu, zato sto Broker izvrsava
        INSERT INTO tabela VALUES (...)
   bez navodjenja liste kolona.
   ===================================================================== */

USE master;
GO

IF DB_ID('SuplementiDB') IS NOT NULL
BEGIN
    ALTER DATABASE SuplementiDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SuplementiDB;
END
GO

CREATE DATABASE SuplementiDB;
GO

USE SuplementiDB;
GO

/* ---------------------------------------------------------------------
   1. GRAD   (sifarnik)
   Grad (idGrad, nazivGrad, postanskiBroj)
   --------------------------------------------------------------------- */
CREATE TABLE grad
(
    idGrad          int             IDENTITY(1,1)   NOT NULL,
    nazivGrad       varchar(50)                     NOT NULL,
    postanskiBroj   varchar(5)                      NOT NULL,

    CONSTRAINT PK_grad              PRIMARY KEY (idGrad),
    CONSTRAINT CK_grad_postanski    CHECK (LEN(postanskiBroj) = 5)
);
GO

/* ---------------------------------------------------------------------
   2. KVALIFIKACIJA   (sifarnik)
   Kvalifikacija (idKvalifikacija, nazivKvalifikacija, nivoStrucnosti)
   --------------------------------------------------------------------- */
CREATE TABLE kvalifikacija
(
    idKvalifikacija     int             IDENTITY(1,1)   NOT NULL,
    nazivKvalifikacija  varchar(50)                     NOT NULL,
    nivoStrucnosti      varchar(50)                     NOT NULL,

    CONSTRAINT PK_kvalifikacija     PRIMARY KEY (idKvalifikacija),
    CONSTRAINT CK_kvalifikacija_naziv CHECK
        (nazivKvalifikacija IN ('Nutricionisticki savetnik',
                                'Specijalista za sportsku ishranu',
                                'Farmaceutski tehnicar')),
    CONSTRAINT CK_kvalifikacija_nivo CHECK
        (nivoStrucnosti IN ('Junior', 'Senior', 'Master'))
);
GO

/* ---------------------------------------------------------------------
   3. SUPLEMENTACIJA   (sifarnik)
   Suplementacija (idSuplementacija, nazivSuplementacija,
                   brendSuplementacija, cena, netoKolicina)
   --------------------------------------------------------------------- */
CREATE TABLE suplementacija
(
    idSuplementacija        int             IDENTITY(1,1)   NOT NULL,
    nazivSuplementacija     varchar(50)                     NOT NULL,
    brendSuplementacija     varchar(50)                     NOT NULL,
    cena                    float                           NOT NULL,
    netoKolicina            varchar(50)                     NOT NULL,

    CONSTRAINT PK_suplementacija    PRIMARY KEY (idSuplementacija),
    CONSTRAINT CK_suplementacija_cena CHECK (cena > 0)
);
GO

/* ---------------------------------------------------------------------
   4. PRODAVAC   (pruzalac usluge)
   Prodavac (idProdavac, imeProdavac, prezimeProdavac,
             korisnickoIme, sifra, emailProdavac, datumZaposlenja)
   --------------------------------------------------------------------- */
CREATE TABLE prodavac
(
    idProdavac          int             IDENTITY(1,1)   NOT NULL,
    imeProdavac         varchar(50)                     NOT NULL,
    prezimeProdavac     varchar(50)                     NOT NULL,
    korisnickoIme       varchar(50)                     NOT NULL,
    sifra               varchar(50)                     NOT NULL,
    emailProdavac       varchar(100)                    NOT NULL,
    datumZaposlenja     date                            NOT NULL,

    CONSTRAINT PK_prodavac              PRIMARY KEY (idProdavac),
    CONSTRAINT UQ_prodavac_korisnickoIme UNIQUE (korisnickoIme),
    CONSTRAINT CK_prodavac_email        CHECK (emailProdavac LIKE '%@%'),
    CONSTRAINT CK_prodavac_datum        CHECK (datumZaposlenja <= GETDATE())
);
GO

/* ---------------------------------------------------------------------
   5. KUPAC   (primalac usluge)
   Kupac (idKupac, imeKupac, prezimeKupac, emailKupac, adresaKupac, idGrad)
   --------------------------------------------------------------------- */
CREATE TABLE kupac
(
    idKupac         int             IDENTITY(1,1)   NOT NULL,
    imeKupac        varchar(50)                     NOT NULL,
    prezimeKupac    varchar(50)                     NOT NULL,
    emailKupac      varchar(100)                    NOT NULL,
    adresaKupac     varchar(100)                    NOT NULL,
    idGrad          int                             NOT NULL,

    CONSTRAINT PK_kupac         PRIMARY KEY (idKupac),
    CONSTRAINT FK_kupac_grad    FOREIGN KEY (idGrad)
        REFERENCES grad (idGrad)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT CK_kupac_email   CHECK (emailKupac LIKE '%@%')
);
GO

/* ---------------------------------------------------------------------
   6. RACUN   (dokument)
   Racun (idRacun, ukupanIznos, datumIzvrsenja, idProdavac, idKupac)
   --------------------------------------------------------------------- */
CREATE TABLE racun
(
    idRacun         int         IDENTITY(1,1)   NOT NULL,
    ukupanIznos     float                       NOT NULL,
    datumIzvrsenja  date                        NOT NULL,
    idProdavac      int                         NOT NULL,
    idKupac         int                         NOT NULL,

    CONSTRAINT PK_racun             PRIMARY KEY (idRacun),
    CONSTRAINT FK_racun_prodavac    FOREIGN KEY (idProdavac)
        REFERENCES prodavac (idProdavac)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT FK_racun_kupac       FOREIGN KEY (idKupac)
        REFERENCES kupac (idKupac)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT CK_racun_iznos       CHECK (ukupanIznos >= 0)
);
GO

/* ---------------------------------------------------------------------
   7. STAVKA RACUNA   (slabi entitet)
   StavkaRacuna (idRacun, rb, cena, kolicina, iznos, idSuplementacija)

   NAPOMENA: rb NIJE IDENTITY. Redni broj se dodeljuje u aplikaciji
   (1, 2, 3 ... u okviru jednog racuna) i salje se u INSERT-u.
   --------------------------------------------------------------------- */
CREATE TABLE stavkaRacuna
(
    idRacun             int         NOT NULL,
    rb                  int         NOT NULL,
    cena                float       NOT NULL,
    kolicina            int         NOT NULL,
    iznos               float       NOT NULL,
    idSuplementacija    int         NOT NULL,

    CONSTRAINT PK_stavkaRacuna              PRIMARY KEY (idRacun, rb),
    CONSTRAINT FK_stavkaRacuna_racun        FOREIGN KEY (idRacun)
        REFERENCES racun (idRacun)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT FK_stavkaRacuna_suplementacija FOREIGN KEY (idSuplementacija)
        REFERENCES suplementacija (idSuplementacija)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT CK_stavkaRacuna_rb           CHECK (rb > 0),
    CONSTRAINT CK_stavkaRacuna_cena         CHECK (cena > 0),
    CONSTRAINT CK_stavkaRacuna_kolicina     CHECK (kolicina > 0),
    -- slozeno vrednosno ogranicenje: iznos = kolicina * cena
    -- (tolerancija zbog racunanja u pokretnom zarezu)
    CONSTRAINT CK_stavkaRacuna_iznos        CHECK (ABS(iznos - cena * kolicina) < 0.01)
);
GO

/* ---------------------------------------------------------------------
   8. PRODAVAC-KVALIFIKACIJA   (veza M:N sa atributom)
   ProdavacKvalifikacija (idProdavac, idKvalifikacija, datumSticanja)
   --------------------------------------------------------------------- */
CREATE TABLE prodavacKvalifikacija
(
    idProdavac      int     NOT NULL,
    idKvalifikacija int     NOT NULL,
    datumSticanja   date    NOT NULL,

    CONSTRAINT PK_prodavacKvalifikacija PRIMARY KEY (idProdavac, idKvalifikacija),
    CONSTRAINT FK_pk_prodavac       FOREIGN KEY (idProdavac)
        REFERENCES prodavac (idProdavac)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT FK_pk_kvalifikacija  FOREIGN KEY (idKvalifikacija)
        REFERENCES kvalifikacija (idKvalifikacija)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT CK_pk_datum          CHECK (datumSticanja <= GETDATE())
);
GO

PRINT 'Baza SuplementiDB je uspesno kreirana sa 8 tabela.';
GO
