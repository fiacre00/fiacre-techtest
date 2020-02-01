CREATE TABLE [dbo].[PdfFile] (
    [Location]    UNIQUEIDENTIFIER CONSTRAINT [DF_PdfFile_Location] DEFAULT (newid()) NOT NULL,
    [FileName]    NVARCHAR (256)   NOT NULL,
    [FileSize]    INT              NOT NULL,
    [FileContent] NVARCHAR (MAX)   NOT NULL,
    [FileOrdinal] INT              NOT NULL,
    [IsDeleted]   BIT              CONSTRAINT [DF_PdfFile_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PdfFile] PRIMARY KEY CLUSTERED ([Location] ASC)
);

