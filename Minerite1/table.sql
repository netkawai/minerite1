
/* Minerite1 table for Un1 */
/* To hold the 4 colums data as datasheet even though they can be calculated easily */
CREATE TABLE [dbo].[Un1]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [CD_inch] FLOAT NOT NULL, 
    [DV_ft] INT NOT NULL,
    [CD_mm] FLOAT NOT NULL, 
    [DV_m] INT NOT NULL
) 
