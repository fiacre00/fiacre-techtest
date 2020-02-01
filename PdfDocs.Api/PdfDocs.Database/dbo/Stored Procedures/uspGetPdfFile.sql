
CREATE PROCEDURE uspGetPdfFile
@Location UNIQUEIDENTIFIER,
@FileContent NVARCHAR(MAX) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @FileContent = FileContent
	FROM [dbo].[PdfFile]
	WHERE [Location] = @Location
	AND [IsDeleted] = 0;

END