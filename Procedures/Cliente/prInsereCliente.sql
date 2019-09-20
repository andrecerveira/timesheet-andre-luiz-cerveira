CREATE PROCEDURE [dbo].[prInsereCliente]
(
	@nome						VARCHAR(50)=NOTNULL
)

AS

INSERT Cliente
( 
	Nome
)

OUTPUT Inserted.Id

	VALUES 
( 
	@nome
)
GO