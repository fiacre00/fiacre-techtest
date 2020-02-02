
CREATE PROCEDURE [dbo].[uspDeletePdfFile]
	@Location UNIQUEIDENTIFIER,
	@DeletedCount INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE [dbo].[PdfFile] 
	SET [IsDeleted] = 1,
	[FileOrdinal] = 0
	WHERE [Location] = @Location;

	SET @DeletedCount = @@ROWCOUNT;

END