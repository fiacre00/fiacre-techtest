using PdfDocs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocs.Data
{
    
    public class PdfFileDb:IPdfFileDb
    {
        private readonly string _connectionString;

        public PdfFileDb (string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
