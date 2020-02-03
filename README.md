# fiacre-techtest
Sql Server is used as the data store for files and meta data.
Publish PdfDocs.Database to create a local copy of the database.
Amend the connection string for PdfDocsDb in PdfDocs.Api/appsettings.json

Assumptions

- Newly created file is added to the end of the list
- Location is stored as a Guid
- Deleting a file which has already been deleted does not error
- If incomplete list of files is submitted for ordering any missing files 
are added at the end of the list in their existing order
