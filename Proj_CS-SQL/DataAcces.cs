using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Proj_CS_SQL
{
    public class DataAcces
    {
        //Funcoes de Acesso para Pessoa
        public static List<Pessoa> GetPessoa()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    return connection.Query<Pessoa>("SELECT Nome, CPF, Sexo, DataDeNascimento, Endereco, Telefone FROM Pessoa").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Pessoa_Insert(Pessoa pessoa)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    connection.Execute("dbo.Pessoa_Insert @Nome, @CPF, @Sexo, @DataDeNascimento, @Endereco, @Telefone", pessoa);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Pessoa_Update(Pessoa pessoa)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    connection.Execute("dbo.Pessoa_Update @Nome, @CPF, @Sexo, @DataDeNascimento, @Endereco, @Telefone", pessoa);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Pessoa_Delete(Pessoa pessoa)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    connection.Execute("dbo.Pessoa_Delete @CPF", pessoa);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Funcoes de Acesso para Pet
        public static List<Pet> GetPet()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    return connection.Query<Pet>("SELECT Chip, Familia, Raca, Sexo, Nome FROM Pet").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Pet_Insert(Pet pet)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    connection.Execute("dbo.Pet_Insert @Familia, @Raca, @Sexo, @Nome", pet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Pet_Update(Pet pet)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    connection.Execute("dbo.Pet_Update @Chip, @Familia, @Raca, @Sexo, @Nome", pet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Pet_Delete(Pet pet)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    connection.Execute("dbo.Pet_Delete @Chip", pet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Funcoes de Acesso para Pessoa_Pet
        public static List<Pessoa_Pet> GetPessoa_Pet()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    return connection.Query<Pessoa_Pet>("SELECT CPF, Chip FROM Pessoa_Pet").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Pessoa_Pet_Insert(Pessoa_Pet pessoa_pet)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    connection.Execute("dbo.Pessoa_Pet_Insert @CPF, @Chip", pessoa_pet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Pessoa_Pet_Delete(Pessoa_Pet pessoa_pet)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionString("ONGDB")))
                {
                    connection.Execute("dbo.Pessoa_Pet_Delete @Chip", pessoa_pet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
