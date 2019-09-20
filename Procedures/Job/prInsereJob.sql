CREATE PROCEDURE [dbo].[prInsereJob]
(
	@nome						VARCHAR(50)=NOTNULL,
	@idCampanha				INT=NOTNULL
)

AS

INSERT Job
( 
	Nome,
	idCampanha
)

OUTPUT Inserted.Id

	VALUES 
( 
	@nome,
	@idCampanha
)
GO