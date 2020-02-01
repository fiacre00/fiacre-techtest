CREATE PROCEDURE [dbo].[uspRearrangePdfFileList]
	@FileArrangeType FileArrangeType READONLY
AS
BEGIN
	SET NOCOUNT ON;
	--set the new file order
	UPDATE [dbo].[PdfFile]
	SET FileOrdinal = FA.FileOrdinal
	FROM [dbo].[PdfFile] FL INNER JOIN @FileArrangeType FA
	ON FL.[Location] = FA.[Location];

	--move any files not in order list maintaining the current order
	;WITH CTE_Ordinal([Location], Ordinal)
	 AS
	 (
	SELECT [Location], RANK() OVER (ORDER BY FileOrdinal)
	FROM [dbo].[PdfFile]
	WHERE [Location] NOT IN (SELECT [Location] FROM  @FileArrangeType)
	)
	UPDATE [dbo].[PdfFile]
	SET FileOrdinal = Ordinal + (SELECT COUNT(*) FROM  @FileArrangeType)
	FROM [dbo].[PdfFile] FL INNER JOIN CTE_Ordinal CT
	ON FL.[Location] = CT.[Location];

END