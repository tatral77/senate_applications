using DataAccess.Services.LegislativeDrafting;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.OrdersOfTheDay
{
    public class OrdersOfTheDayRepository : IOrdersOfTheDayRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<OrdersOfTheDayRepository> _logger;
        SqlConnection connection = null;

        public OrdersOfTheDayRepository(IConfiguration configuration, ILogger<OrdersOfTheDayRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");
            _logger = logger;
        }

        #region Read

        public async Task<List<OrdersOfTheDayType>> GetAllOdTypesAsync()
        {
            connection = new SqlConnection(_connectionString);
            List<OrdersOfTheDayType> temp = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("[dbo].[MOBILE_API]", connection);
                sqlCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_OD_TYPES";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    temp = new List<OrdersOfTheDayType>();
                    while (await reader.ReadAsync())
                    {
                        OrdersOfTheDayType record = new OrdersOfTheDayType();
                        record.OdTypeId = Convert.ToInt32(reader["ORDER_OF_DAY_TYPES_ID"]);
                        record.OdTypeDescription = Convert.ToString(reader["ORDER_OF_DAY_TYPE_DESC"]);
                        record.RuleDescription = Convert.ToString(reader["RULE_DESCRIPTION"]);
                        record.DisplayOrder = Convert.ToInt32(reader["DISPLAY_ORDER"]);
                        record.IsActive = Convert.ToInt32(reader["IS_ACTIVE"]);
                        temp.Add(record);
                    }
                    _logger.LogInformation("Retrieved [{Count}] orders of the day type record.", temp.Count);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the orders of the day type record by executing stored procedure [{Procedure}].", "GET_ALL_OD_TYPES");
                throw;
            }
            finally
            {
                connection?.Dispose();
            }
            return temp;
        }

        public async Task<OrdersOfTheDayType> GetOdTypesByIdAsync(int odTypeId)
        {
            connection = new SqlConnection(_connectionString);
            OrdersOfTheDayType record = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("[dbo].[MOBILE_API]", connection);
                sqlCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_OD_TYPE_BY_ID";
                sqlCommand.Parameters.Add("@OdTypeId", SqlDbType.Int).Value = odTypeId;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    record = new OrdersOfTheDayType();
                    await reader.ReadAsync();
                    record.OdTypeId = Convert.ToInt32(reader["ORDER_OF_DAY_TYPES_ID"]);
                    record.OdTypeDescription = Convert.ToString(reader["ORDER_OF_DAY_TYPE_DESC"]);
                    record.RuleDescription = Convert.ToString(reader["RULE_DESCRIPTION"]);
                    record.DisplayOrder = Convert.ToInt32(reader["DISPLAY_ORDER"]);
                    record.IsActive = Convert.ToInt32(reader["IS_ACTIVE"]);
                    _logger.LogInformation("Retrieved orders of the day type record for OdTypeId [{OdTypeId}]", odTypeId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the orders of the day type record for OdTypeId [{OdTypeId}] by executing stored procedure [{Procedure}].", "GET_OD_TYPE_BY_ID", odTypeId);
                throw;
            }
            finally
            {
                connection?.Dispose();
            }
            return record;
        }

        public async Task<int> GetMaxOdTypeIdAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand("[dbo].[MOBILE_API]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("@Action", SqlDbType.VarChar, 50).Value = "GET_MAX_OD_TYPE_ID";

            await connection.OpenAsync();

            var result = await command.ExecuteScalarAsync();

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result) + 1;
            }

            return 1; // Default starting ID if table is empty
        }

        #region OldApproach
        //public async Task<int> GetMaxOdTypeIdAsync()
        //{
        //    SqlConnection connection = new SqlConnection(_connectionString);
        //    int typeId = 0;
        //    try
        //    {
        //        SqlCommand sqlCommand = new SqlCommand("[dbo].[MOBILE_API]", connection);
        //        sqlCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MAX_OD_TYPE_ID";
        //        sqlCommand.CommandType = CommandType.StoredProcedure;

        //        await connection.OpenAsync();
        //        SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
        //        if (reader.Read())
        //        {
        //            if (reader["OD_TYPE_ID"] != DBNull.Value) { typeId = Convert.ToInt32(reader["OD_TYPE_ID"]); }
        //            if (typeId > 0)
        //                typeId += 1;
        //            else
        //                typeId++;
        //        }
        //        return typeId;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        connection?.Dispose();
        //    }
        //} 
        #endregion

        #endregion

        #region Create

        public async Task<bool> AddOdTypeAsync(OrdersOfTheDayType entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand("[dbo].[MOBILE_API]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Explicit parameters avoid SQL index degradation and type mismatches
            command.Parameters.Add("@Action", SqlDbType.VarChar, 50).Value = "INSERT_OD_TYPE";
            command.Parameters.Add("@OdTypeId", SqlDbType.Int).Value = entity.OdTypeId;
            command.Parameters.Add("@OdTypeDescription", SqlDbType.NVarChar, 200).Value = (object?)entity.OdTypeDescription ?? DBNull.Value;
            command.Parameters.Add("@RuleDescription", SqlDbType.NVarChar, 200).Value = (object?)entity.RuleDescription ?? DBNull.Value;
            command.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = entity.DisplayOrder;

            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to insert Order of the Day Type with ID [{OdTypeId}] using procedure [{Procedure}].",
                    entity.OdTypeId,
                    "INSERT_OD_TYPE"
                );
                throw; // Preserves the original stack trace cleanly
            }
        }

        #region OldApproach
        //public async Task AddOdTypeAsync(OrdersOfTheDayType entity)
        //{
        //    SqlConnection connection = new SqlConnection(_connectionString);
        //    try
        //    {
        //        SqlCommand sqlCommand = new SqlCommand("[dbo].[MOBILE_API]", connection);
        //        sqlCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_OD_TYPE";
        //        sqlCommand.CommandType = CommandType.StoredProcedure;

        //        sqlCommand.Parameters.AddWithValue("@OdTypeId", entity.OdTypeId);
        //        sqlCommand.Parameters.AddWithValue("@OdTypeDescription", entity.OdTypeDescription);
        //        sqlCommand.Parameters.AddWithValue("@DisplayOrder", entity.DisplayOrder);

        //        await connection.OpenAsync();
        //        await sqlCommand.ExecuteNonQueryAsync();

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred while retrieving the research service record for OdTypeId [{OdTypeId}] by executing stored procedure [{Procedure}].", "INSERT_OD_TYPE", entity.OdTypeId);
        //        throw;
        //    }
        //    finally
        //    {
        //        connection?.Dispose();
        //    }
        //} 
        #endregion

        #endregion

        #region Update

        public async Task<bool> EditOdTypeAsync(OrdersOfTheDayType entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand("[dbo].[MOBILE_API]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Explicit parameters avoid SQL index degradation and type mismatches
            command.Parameters.Add("@Action", SqlDbType.VarChar, 50).Value = "UPDATE_OD_TYPE";
            command.Parameters.Add("@OdTypeId", SqlDbType.Int).Value = entity.OdTypeId;
            command.Parameters.Add("@OdTypeDescription", SqlDbType.NVarChar, 200).Value = (object?)entity.OdTypeDescription ?? DBNull.Value;
            command.Parameters.Add("@RuleDescription", SqlDbType.NVarChar, 200).Value = (object?)entity.RuleDescription ?? DBNull.Value;
            command.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = entity.DisplayOrder;

            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to edit Order of the Day Type with ID [{OdTypeId}] using procedure [{Procedure}].",
                    entity.OdTypeId,
                    "UPDATE_OD_TYPE"
                );
                throw; // Preserves the original stack trace cleanly
            }
        }

        #endregion

    }
}
