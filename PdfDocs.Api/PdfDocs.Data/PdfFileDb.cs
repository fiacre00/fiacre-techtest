using Dapper;
using PdfDocs.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace PdfDocs.Data
{
    
    public class PdfFileDb:IPdfFileDb
    {
        private readonly string _connectionString;

        public PdfFileDb (string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> InsertPdfFile(string fileName, byte[] fileContent)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FileName",fileName);
                parameters.Add("@FileContent",fileContent);
                return await connection.ExecuteAsync("[dbo].[uspInsertPdfFile]", parameters, commandType:CommandType.StoredProcedure);
            }
        }
    }
}
