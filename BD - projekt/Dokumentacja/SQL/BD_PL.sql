-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.

-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.
-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.
-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.

SET XACT_ABORT ON

BEGIN TRANSACTION QUICKDBD

CREATE TABLE [Pracownicy] (
    -- Clustered
    -- Clustered
    -- Clustered
    [id_prac] int  NOT NULL ,
    [imie] String  NOT NULL ,
    [nazwisko] String  NOT NULL ,
    [nr_tel] bigint  NOT NULL ,
    [email] String  NOT NULL ,
    [login] String  NOT NULL ,
    [haslo] String  NOT NULL ,
    CONSTRAINT [PK_Pracownicy] PRIMARY KEY CLUSTERED (
        [id_prac] ASC
    )
)

CREATE TABLE [Kierowcy] (
    -- Clustered
    -- Clustered
    -- Clustered
    [id_prac] int  NOT NULL ,
    [typ_obsl_poj] int  NOT NULL ,
    CONSTRAINT [PK_Kierowcy] PRIMARY KEY CLUSTERED (
        [id_prac] ASC
    )
)

CREATE TABLE [Przydzialy] (
    -- Clustered
    [id_przydz] int  NOT NULL ,
    [id_prac] int  NOT NULL ,
    [nr_linii] int  NOT NULL ,
    [data] date  NOT NULL ,
    [godz_rozp] time  NOT NULL ,
    [godz_zakon] time  NOT NULL ,
    [id_przyst_pocz] int  NOT NULL ,
    CONSTRAINT [PK_Przydzialy] PRIMARY KEY CLUSTERED (
        [id_przydz] ASC
    )
)

CREATE TABLE [Pojazdy] (
    -- Clustered
    -- Clustered
    [id_pojazdu] int  NOT NULL ,
    [nr_rejestr] String  NOT NULL ,
    [nr_boczny] String  NOT NULL ,
    [typ] int  NOT NULL ,
    [pojemnosc] int  NOT NULL ,
    CONSTRAINT [PK_Pojazdy] PRIMARY KEY CLUSTERED (
        [id_pojazdu] ASC
    )
)

CREATE TABLE [Linie] (
    [nr_linii] int  NOT NULL ,
    [typ] int  NOT NULL 
)

CREATE TABLE [Przejazdy] (
    -- Clustered
    -- Clustered
    -- Clustered
    [id_przejazdu] int  NOT NULL ,
    [nr_linii] int  NOT NULL ,
    [id_przyst_pocz] int  NOT NULL ,
    [id_przyst_konc] int  NOT NULL ,
    [dzien_tyg] String  NOT NULL ,
    [typ_dnia] int  NOT NULL ,
    [godz_rozp] time  NOT NULL ,
    [prefer_pojemn_pojazdu] int  NOT NULL ,
    CONSTRAINT [PK_Przejazdy] PRIMARY KEY CLUSTERED (
        [id_przejazdu] ASC
    )
)

CREATE TABLE [Przystanki] (
    -- Clustered
    -- Clustered
    -- Clustered
    [id_przystanku] int  NOT NULL ,
    [nazwa] String  NOT NULL ,
    [dzielnica] String  NOT NULL ,
    [nr] int  NOT NULL ,
    CONSTRAINT [PK_Przystanki] PRIMARY KEY CLUSTERED (
        [id_przystanku] ASC
    )
)

CREATE TABLE [Przystanki_na_trasie] (
    -- Clustered
    -- Clustered
    -- Clustered
    [id_przyst_na_trasie] int  NOT NULL ,
    [id_przyst] int  NOT NULL ,
    [id_nast] int  NOT NULL ,
    [id_poprz] int  NOT NULL ,
    [lb_porzadkowa] int  NOT NULL ,
    [czas_przejazdu] time  NOT NULL ,
    CONSTRAINT [PK_Przystanki_na_trasie] PRIMARY KEY CLUSTERED (
        [id_przyst_na_trasie] ASC
    )
)

CREATE TABLE [Spoznienia] (
    [id_kursu] int  NOT NULL ,
    [id_przyst_na_trasie] int  NOT NULL ,
    [czas] time  NOT NULL 
)

CREATE TABLE [Kursy] (
    -- Clustered
    -- Clustered
    -- Clustered
    [id_kursu] int  NOT NULL ,
    [id_prac] int  NULL ,
    [id_pojazdu] String  NOT NULL ,
    [id_przejazdu] int  NOT NULL ,
    [data] date  NOT NULL ,
    CONSTRAINT [PK_Kursy] PRIMARY KEY CLUSTERED (
        [id_kursu] ASC
    )
)

ALTER TABLE [Kierowcy] WITH CHECK ADD CONSTRAINT [FK_Kierowcy_id_prac] FOREIGN KEY([id_prac])
REFERENCES [Pracownicy] ([id_prac])

ALTER TABLE [Kierowcy] CHECK CONSTRAINT [FK_Kierowcy_id_prac]

ALTER TABLE [Przydzialy] WITH CHECK ADD CONSTRAINT [FK_Przydzialy_id_prac] FOREIGN KEY([id_prac])
REFERENCES [Kierowcy] ([id_prac])

ALTER TABLE [Przydzialy] CHECK CONSTRAINT [FK_Przydzialy_id_prac]

ALTER TABLE [Przydzialy] WITH CHECK ADD CONSTRAINT [FK_Przydzialy_nr_linii] FOREIGN KEY([nr_linii])
REFERENCES [Linie] ([nr_linii])

ALTER TABLE [Przydzialy] CHECK CONSTRAINT [FK_Przydzialy_nr_linii]

ALTER TABLE [Przydzialy] WITH CHECK ADD CONSTRAINT [FK_Przydzialy_id_przyst_pocz] FOREIGN KEY([id_przyst_pocz])
REFERENCES [Przystanki_na_trasie] ([id_przyst_na_trasie])

ALTER TABLE [Przydzialy] CHECK CONSTRAINT [FK_Przydzialy_id_przyst_pocz]

ALTER TABLE [Przejazdy] WITH CHECK ADD CONSTRAINT [FK_Przejazdy_nr_linii] FOREIGN KEY([nr_linii])
REFERENCES [Linie] ([nr_linii])

ALTER TABLE [Przejazdy] CHECK CONSTRAINT [FK_Przejazdy_nr_linii]

ALTER TABLE [Przejazdy] WITH CHECK ADD CONSTRAINT [FK_Przejazdy_id_przyst_pocz] FOREIGN KEY([id_przyst_pocz])
REFERENCES [Przystanki_na_trasie] ([id_przyst_na_trasie])

ALTER TABLE [Przejazdy] CHECK CONSTRAINT [FK_Przejazdy_id_przyst_pocz]

ALTER TABLE [Przejazdy] WITH CHECK ADD CONSTRAINT [FK_Przejazdy_id_przyst_konc] FOREIGN KEY([id_przyst_konc])
REFERENCES [Przystanki_na_trasie] ([id_przyst_na_trasie])

ALTER TABLE [Przejazdy] CHECK CONSTRAINT [FK_Przejazdy_id_przyst_konc]

ALTER TABLE [Przystanki_na_trasie] WITH CHECK ADD CONSTRAINT [FK_Przystanki_na_trasie_id_przyst] FOREIGN KEY([id_przyst])
REFERENCES [Przystanki] ([id_przystanku])

ALTER TABLE [Przystanki_na_trasie] CHECK CONSTRAINT [FK_Przystanki_na_trasie_id_przyst]

ALTER TABLE [Przystanki_na_trasie] WITH CHECK ADD CONSTRAINT [FK_Przystanki_na_trasie_id_nast] FOREIGN KEY([id_nast])
REFERENCES [Przystanki_na_trasie] ([id_przyst_na_trasie])

ALTER TABLE [Przystanki_na_trasie] CHECK CONSTRAINT [FK_Przystanki_na_trasie_id_nast]

ALTER TABLE [Przystanki_na_trasie] WITH CHECK ADD CONSTRAINT [FK_Przystanki_na_trasie_id_poprz] FOREIGN KEY([id_poprz])
REFERENCES [Przystanki_na_trasie] ([id_przyst_na_trasie])

ALTER TABLE [Przystanki_na_trasie] CHECK CONSTRAINT [FK_Przystanki_na_trasie_id_poprz]

ALTER TABLE [Spoznienia] WITH CHECK ADD CONSTRAINT [FK_Spoznienia_id_kursu] FOREIGN KEY([id_kursu])
REFERENCES [Kursy] ([id_kursu])

ALTER TABLE [Spoznienia] CHECK CONSTRAINT [FK_Spoznienia_id_kursu]

ALTER TABLE [Spoznienia] WITH CHECK ADD CONSTRAINT [FK_Spoznienia_id_przyst_na_trasie] FOREIGN KEY([id_przyst_na_trasie])
REFERENCES [Przystanki_na_trasie] ([id_przyst_na_trasie])

ALTER TABLE [Spoznienia] CHECK CONSTRAINT [FK_Spoznienia_id_przyst_na_trasie]

ALTER TABLE [Kursy] WITH CHECK ADD CONSTRAINT [FK_Kursy_id_prac] FOREIGN KEY([id_prac])
REFERENCES [Kierowcy] ([id_prac])

ALTER TABLE [Kursy] CHECK CONSTRAINT [FK_Kursy_id_prac]

ALTER TABLE [Kursy] WITH CHECK ADD CONSTRAINT [FK_Kursy_id_pojazdu] FOREIGN KEY([id_pojazdu])
REFERENCES [Pojazdy] ([id_pojazdu])

ALTER TABLE [Kursy] CHECK CONSTRAINT [FK_Kursy_id_pojazdu]

ALTER TABLE [Kursy] WITH CHECK ADD CONSTRAINT [FK_Kursy_id_przejazdu] FOREIGN KEY([id_przejazdu])
REFERENCES [Przejazdy] ([id_przejazdu])

ALTER TABLE [Kursy] CHECK CONSTRAINT [FK_Kursy_id_przejazdu]

COMMIT TRANSACTION QUICKDBD