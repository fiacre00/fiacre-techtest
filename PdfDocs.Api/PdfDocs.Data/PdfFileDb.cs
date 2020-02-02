using Dapper;
using DapperParameters;
using PdfDocs.Domain;
using PdfDocs.Domain.Entities;
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

        public async Task<int> DeletePdfFile(Guid location)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Location", location);
                parameters.Add("@DeletedCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                await connection.ExecuteAsync("[dbo].[uspDeletePdfFile]", parameters, commandType: CommandType.StoredProcedure);
                
                return parameters.Get<int>("@DeletedCount");
            }
        }

        public async Task<int> RearrangePdfFileList(ICollection<FileArrangeType> orderedLocations)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.AddTable("@FileArrangeType", "[dbo].[FileArrangeType]", orderedLocations);

                return await connection.ExecuteAsync("[dbo].[uspRearrangePdfFileList]", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<byte[]> GetPdfFile(Guid location)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Location", location);
                parameters.Add("@FileContent", dbType: DbType.Binary, direction: ParameterDirection.Output, size: -1);

                await connection.ExecuteAsync("[dbo].[uspGetPdfFile]", parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<byte[]>("@FileContent");
            }
        }

        public async Task<IEnumerable<PdfFile>> GetPdfFileList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<PdfFile>("[dbo].[uspGetPdfFileList]", commandType:CommandType.StoredProcedure);
            }
        }
    }
}
