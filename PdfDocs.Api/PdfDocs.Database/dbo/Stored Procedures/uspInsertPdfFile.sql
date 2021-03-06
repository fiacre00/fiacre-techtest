﻿
CREATE PROCEDURE [dbo].[uspInsertPdfFile]
	@FileName NVARCHAR(256),
	@FileContent VARBINARY(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @FileOrdinal INT;

	SELECT @FileOrdinal =  COALESCE(MAX(FileOrdinal), 0) + 1 from PdfFile where IsDeleted = 0;

	
	INSERT INTO [dbo].[PdfFile]
			   ([Location]
			   ,[FileName]
			   ,[FileSize]
			   ,[FileContent]
			   ,[FileOrdinal]
			   ,[IsDeleted])
		 VALUES
			   (NEWID()
			   ,@FileName
			   ,DATALENGTH(@FileContent)
			   ,@FileContent
			   ,@FileOrdinal
			   ,0);

END