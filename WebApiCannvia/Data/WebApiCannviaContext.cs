using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiCannvia.Models;

namespace WebApiCannvia.Data
{
    public class WebApiCannviaContext
    {
        private readonly string _connectionString;

        public WebApiCannviaContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        #region Producto
        public async Task<List<Producto>> SP_Producto_Get()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PRODUCTO_GET_ALL", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Producto>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToProducto(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<Producto> SP_Producto_Get_Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PRODUCTO_GET_ID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    Producto response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToProducto(reader);
                        }
                    }

                    return response;
                }
            }

        }

        public async Task<List<Producto>> SP_Producto_Get_Categoria(int IdCategoria)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PRODUCTO_GET_CATEGORIA", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdCategoria", IdCategoria));
                    var response = new List<Producto>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToProducto(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<Producto> SP_Producto_Post(int IdCategoria, string Nombre, string Descripcion, int Unidades)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PRODUCTO_POST", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdCategoria", IdCategoria));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Unidades", Unidades));
                    Producto response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToProducto(reader);
                        }
                    }

                    return response;
                }
            }
        }

        public async Task SP_Producto_Put(int Id, int IdCategoria, string Nombre, string Descripcion, int Unidades)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PRODUCTO_PUT", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    cmd.Parameters.Add(new SqlParameter("@IdCategoria", IdCategoria));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Unidades", Unidades));
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                    return;
                }
            }
        }

        public async Task SP_Producto_Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PRODUCTO_DELETE", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                    return;
                }
            }
        }

        public async Task SP_Producto_Delete_Logico(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PRODUCTO_DELETE_LOGICO", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                    return;
                }
            }
        }

        private Producto MapToProducto(SqlDataReader reader)
        {
            return new Producto()
            {
                Id = (int)reader["Id"],
                Nombre = reader["Nombre"].ToString(),
                Descripcion = reader["Descripcion"].ToString(),
                Unidades = (int)reader["Unidades"],
                IdCategoria = (int)reader["IdCategoria"]
            };
        }
        #endregion

        #region Categoria
        public async Task<List<Categoria>> SP_Categoria_Get()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_CATEGORIA_GET_ALL", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Categoria>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToCategoria(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<Categoria> SP_Categoria_Get_Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_CATEGORIA_GET_ID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    Categoria response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToCategoria(reader);
                        }
                    }

                    return response;
                }
            }

        }

        public async Task<Categoria> SP_Categoria_Post(string Nombre, string Descripcion)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_CATEGORIA_POST", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    Categoria response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToCategoria(reader);
                        }
                    }

                    return response;
                }
            }
        }

        public async Task SP_Categoria_Put(int Id, string Nombre, string Descripcion)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_CATEGORIA_PUT", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                    return;
                }
            }
        }

        public async Task SP_Categoria_Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_CATEGORIA_DELETE", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                    return;
                }
            }
        }

        public async Task SP_Categoria_Delete_Logico(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_CATEGORIA_DELETE_LOGICO", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                    return;
                }
            }
        }

        private Categoria MapToCategoria(SqlDataReader reader)
        {
            return new Categoria()
            {
                Id = (int)reader["Id"],
                Nombre = reader["Nombre"].ToString(),
                Descripcion = reader["Descripcion"].ToString()
            };
        }
        #endregion

    }
}
