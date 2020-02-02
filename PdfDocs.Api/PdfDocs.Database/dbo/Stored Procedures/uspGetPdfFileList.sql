
CREATE PROCEDURE [dbo].[uspGetPdfFileList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Location]
		  ,[FileName]
		  ,[FileSize]
	FROM [dbo].[PdfFile]
	WHERE [IsDeleted] = 0
	ORDER BY [FileOrdinal];

END