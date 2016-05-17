﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Softv.Entities;
using Softv.Providers;
using SoftvConfiguration;
using Globals;

namespace Softv.DAO
{
    /// <summary>
    /// Class                   : Softv.DAO.CLIENTEData
    /// Generated by            : Class Generator (c) 2014
    /// Description             : CLIENTE Data Access Object
    /// File                    : CLIENTEDAO.cs
    /// Creation date           : 02/05/2016
    /// Creation time           : 06:30 p. m.
    ///</summary>
    public class CLIENTEData : CLIENTEProvider
    {
        /// <summary>
        ///</summary>
        /// <param name="CLIENTE"> Object CLIENTE added to List</param>
        public override int AddCLIENTE(CLIENTEEntity entity_CLIENTE)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEAdd", connection);

                AssingParameter(comandoSql, "@CONTRATO", null, pd: ParameterDirection.Output, IsKey: true);

                AssingParameter(comandoSql, "@NOMBRE", entity_CLIENTE.NOMBRE);

                AssingParameter(comandoSql, "@Clv_Calle", entity_CLIENTE.Clv_Calle);

                AssingParameter(comandoSql, "@NUMERO", entity_CLIENTE.NUMERO);

                AssingParameter(comandoSql, "@ENTRECALLES", entity_CLIENTE.ENTRECALLES);

                AssingParameter(comandoSql, "@Clv_Colonia", entity_CLIENTE.Clv_Colonia);

                AssingParameter(comandoSql, "@CodigoPostal", entity_CLIENTE.CodigoPostal);

                AssingParameter(comandoSql, "@TELEFONO", entity_CLIENTE.TELEFONO);

                AssingParameter(comandoSql, "@CELULAR", entity_CLIENTE.CELULAR);

                AssingParameter(comandoSql, "@DESGLOSA_Iva", entity_CLIENTE.DESGLOSA_Iva);

                AssingParameter(comandoSql, "@SoloInternet", entity_CLIENTE.SoloInternet);

                AssingParameter(comandoSql, "@eshotel", entity_CLIENTE.eshotel);

                AssingParameter(comandoSql, "@Clv_Ciudad", entity_CLIENTE.Clv_Ciudad);

                AssingParameter(comandoSql, "@Email", entity_CLIENTE.Email);

                AssingParameter(comandoSql, "@clv_sector", entity_CLIENTE.clv_sector);

                AssingParameter(comandoSql, "@Clv_Periodo", entity_CLIENTE.Clv_Periodo);

                AssingParameter(comandoSql, "@Clv_Tap", entity_CLIENTE.Clv_Tap);

                AssingParameter(comandoSql, "@Zona2", entity_CLIENTE.Zona2);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }
                result = (int)comandoSql.Parameters["@IdCLIENTE"].Value;
            }
            return result;
        }

        /// <summary>
        /// Deletes a CLIENTE
        ///</summary>
        /// <param name="">  CONTRATO to delete </param>
        public override int DeleteCLIENTE(long? CONTRATO)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEDelete", connection);

                AssingParameter(comandoSql, "@CONTRATO", CONTRATO);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Edits a CLIENTE
        ///</summary>
        /// <param name="CLIENTE"> Objeto CLIENTE a editar </param>
        public override int EditCLIENTE(CLIENTEEntity entity_CLIENTE)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEEdit", connection);

                AssingParameter(comandoSql, "@Contrato", entity_CLIENTE.CONTRATO);

                AssingParameter(comandoSql, "@NOMBRE", entity_CLIENTE.NOMBRE);

                AssingParameter(comandoSql, "@Clv_Calle", entity_CLIENTE.Clv_Calle);

                AssingParameter(comandoSql, "@NUMERO", entity_CLIENTE.NUMERO);

                AssingParameter(comandoSql, "@ENTRECALLES", entity_CLIENTE.ENTRECALLES);

                AssingParameter(comandoSql, "@Clv_Colonia", entity_CLIENTE.Clv_Colonia);

                AssingParameter(comandoSql, "@CodigoPostal", entity_CLIENTE.CodigoPostal);

                AssingParameter(comandoSql, "@TELEFONO", entity_CLIENTE.TELEFONO);

                AssingParameter(comandoSql, "@CELULAR", entity_CLIENTE.CELULAR);

                AssingParameter(comandoSql, "@DESGLOSA_Iva", entity_CLIENTE.DESGLOSA_Iva);

                AssingParameter(comandoSql, "@SoloInternet", entity_CLIENTE.SoloInternet);

                AssingParameter(comandoSql, "@eshotel", entity_CLIENTE.eshotel);

                AssingParameter(comandoSql, "@Clv_Ciudad", entity_CLIENTE.Clv_Ciudad);

                AssingParameter(comandoSql, "@Email", entity_CLIENTE.Email);

                AssingParameter(comandoSql, "@clv_sector", entity_CLIENTE.clv_sector);

                AssingParameter(comandoSql, "@Clv_Periodo", entity_CLIENTE.Clv_Periodo);

                AssingParameter(comandoSql, "@Clv_Tap", entity_CLIENTE.Clv_Tap);

                AssingParameter(comandoSql, "@Zona2", entity_CLIENTE.Zona2);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    result = int.Parse(ExecuteNonQuery(comandoSql).ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Gets all CLIENTE
        ///</summary>
        public override List<CLIENTEEntity> GetCLIENTE()
        {
            List<CLIENTEEntity> CLIENTEList = new List<CLIENTEEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEGet", connection);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        CLIENTEList.Add(GetCLIENTEFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return CLIENTEList;
        }

        /// <summary>
        /// Gets all CLIENTE by List<int>
        ///</summary>
        public override List<CLIENTEEntity> GetCLIENTE(List<long> lid)
        {
            List<CLIENTEEntity> CLIENTEList = new List<CLIENTEEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {
                DataTable IdDT = BuildTableID(lid);

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEGetByIds", connection);
                AssingParameter(comandoSql, "@IdTable", IdDT);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        CLIENTEList.Add(GetCLIENTEFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return CLIENTEList;
        }

        /// <summary>
        /// Gets CLIENTE by
        ///</summary>
        public override CLIENTEEntity GetCLIENTEById(long? CONTRATO)
        {
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEGetById", connection);
                CLIENTEEntity entity_CLIENTE = null;


                AssingParameter(comandoSql, "@CONTRATO", CONTRATO);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql, CommandBehavior.SingleRow);
                    if (rd.Read())
                        entity_CLIENTE = GetCLIENTEFromReader(rd);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                return entity_CLIENTE;
            }

        }


        public override List<CLIENTEEntity> GetCLIENTEByContrato(long? CONTRATO)
        {
            List<CLIENTEEntity> CLIENTEList = new List<CLIENTEEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEGetByContrato", connection);

                AssingParameter(comandoSql, "@CONTRATO", CONTRATO);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        CLIENTEList.Add(GetCLIENTEFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return CLIENTEList;
        }


        /// <summary>
        ///Get CLIENTE
        ///</summary>
        public override SoftvList<CLIENTEEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<CLIENTEEntity> entities = new SoftvList<CLIENTEEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEGetPaged", connection);

                AssingParameter(comandoSql, "@pageIndex", pageIndex);
                AssingParameter(comandoSql, "@pageSize", pageSize);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);
                    while (rd.Read())
                    {
                        entities.Add(GetCLIENTEFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetCLIENTECount();
                return entities ?? new SoftvList<CLIENTEEntity>();
            }
        }

        /// <summary>
        ///Get CLIENTE
        ///</summary>
        public override SoftvList<CLIENTEEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<CLIENTEEntity> entities = new SoftvList<CLIENTEEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEGetPagedXml", connection);

                AssingParameter(comandoSql, "@pageSize", pageSize);
                AssingParameter(comandoSql, "@pageIndex", pageIndex);
                AssingParameter(comandoSql, "@xml", xml);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);
                    while (rd.Read())
                    {
                        entities.Add(GetCLIENTEFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetCLIENTECount(xml);
                return entities ?? new SoftvList<CLIENTEEntity>();
            }
        }

        /// <summary>
        ///Get Count CLIENTE
        ///</summary>
        public int GetCLIENTECount()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEGetCount", connection);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }


        /// <summary>
        ///Get Count CLIENTE
        ///</summary>
        public int GetCLIENTECount(String xml)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.CLIENTE.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_CLIENTEGetCountXml", connection);

                AssingParameter(comandoSql, "@xml", xml);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data CLIENTE " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }

        #region Customs Methods

        #endregion
    }
}
