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
    /// Class                   : Softv.DAO.RelEnProcesosData
    /// Generated by            : Class Generator (c) 2014
    /// Description             : RelEnProcesos Data Access Object
    /// File                    : RelEnProcesosDAO.cs
    /// Creation date           : 27/04/2016
    /// Creation time           : 05:19 p. m.
    ///</summary>
    public class RelEnProcesosData : RelEnProcesosProvider
    {
        /// <summary>
        ///</summary>
        /// <param name="RelEnProcesos"> Object RelEnProcesos added to List</param>
        public override int AddRelEnProcesos(RelEnProcesosEntity entity_RelEnProcesos)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosAdd", connection);

                AssingParameter(comandoSql, "@IdProceso", entity_RelEnProcesos.IdProceso);

                AssingParameter(comandoSql, "@IdPregunta", entity_RelEnProcesos.IdPregunta);

                AssingParameter(comandoSql, "@Id_ResOpcMult", entity_RelEnProcesos.Id_ResOpcMult);

                AssingParameter(comandoSql, "@RespAbi", entity_RelEnProcesos.RespAbi);

                AssingParameter(comandoSql, "@RespCerrada", entity_RelEnProcesos.RespCerrada);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding RelEnProcesos " + ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }
                result = (int)comandoSql.Parameters["@IdRelEnProcesos"].Value;
            }
            return result;
        }

        /// <summary>
        /// Deletes a RelEnProcesos
        ///</summary>
        /// <param name="">   to delete </param>
        public override int DeleteRelEnProcesos(int? IdProceso)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosDelete", connection);
                AssingParameter(comandoSql, "@IdProceso", IdProceso);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting RelEnProcesos " + ex.Message, ex);
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
        /// Edits a RelEnProcesos
        ///</summary>
        /// <param name="RelEnProcesos"> Objeto RelEnProcesos a editar </param>
        public override int EditRelEnProcesos(RelEnProcesosEntity entity_RelEnProcesos)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosEdit", connection);

                AssingParameter(comandoSql, "@IdProceso", entity_RelEnProcesos.IdProceso);

                AssingParameter(comandoSql, "@IdPregunta", entity_RelEnProcesos.IdPregunta);

                AssingParameter(comandoSql, "@Id_ResOpcMult", entity_RelEnProcesos.Id_ResOpcMult);

                AssingParameter(comandoSql, "@RespAbi", entity_RelEnProcesos.RespAbi);

                AssingParameter(comandoSql, "@RespCerrada", entity_RelEnProcesos.RespCerrada);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    result = int.Parse(ExecuteNonQuery(comandoSql).ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating RelEnProcesos " + ex.Message, ex);
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
        /// Gets all RelEnProcesos
        ///</summary>
        public override List<RelEnProcesosEntity> GetRelEnProcesos()
        {
            List<RelEnProcesosEntity> RelEnProcesosList = new List<RelEnProcesosEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGet", connection);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        RelEnProcesosList.Add(GetRelEnProcesosFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return RelEnProcesosList;
        }

        /// <summary>
        /// Gets all RelEnProcesos by List<int>
        ///</summary>
        public override List<RelEnProcesosEntity> GetRelEnProcesos(List<int> lid)
        {
            List<RelEnProcesosEntity> RelEnProcesosList = new List<RelEnProcesosEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {
                DataTable IdDT = BuildTableID(lid);

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGetByIds", connection);
                AssingParameter(comandoSql, "@IdTable", IdDT);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        RelEnProcesosList.Add(GetRelEnProcesosFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return RelEnProcesosList;
        }

        /// <summary>
        /// Gets RelEnProcesos by
        ///</summary>
        public override RelEnProcesosEntity GetRelEnProcesosById(int? IdProceso)
        {
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGetById", connection);
                RelEnProcesosEntity entity_RelEnProcesos = null;

                AssingParameter(comandoSql, "@IdProceso", IdProceso);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql, CommandBehavior.SingleRow);
                    if (rd.Read())
                        entity_RelEnProcesos = GetRelEnProcesosFromReader(rd);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                return entity_RelEnProcesos;
            }

        }


        public override List<RelEnProcesosEntity> GetRelEnProcesosByIdPregunta(int? IdPregunta)
        {
            List<RelEnProcesosEntity> RelEnProcesosList = new List<RelEnProcesosEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGetByIdPregunta", connection);

                AssingParameter(comandoSql, "@IdPregunta", IdPregunta);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        RelEnProcesosList.Add(GetRelEnProcesosFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return RelEnProcesosList;
        }

        public override List<RelEnProcesosEntity> GetRelEnProcesosById_ResOpcMult(int? Id_ResOpcMult)
        {
            List<RelEnProcesosEntity> RelEnProcesosList = new List<RelEnProcesosEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGetById_ResOpcMult", connection);

                AssingParameter(comandoSql, "@Id_ResOpcMult", Id_ResOpcMult);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        RelEnProcesosList.Add(GetRelEnProcesosFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return RelEnProcesosList;
        }

        public override List<RelEnProcesosEntity> GetRelEnProcesosByIdProceso(int? IdProceso)
        {
            List<RelEnProcesosEntity> RelEnProcesosList = new List<RelEnProcesosEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGetByIdProceso", connection);

                AssingParameter(comandoSql, "@IdProceso", IdProceso);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        RelEnProcesosList.Add(GetRelEnProcesosFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return RelEnProcesosList;
        }


        /// <summary>
        ///Get RelEnProcesos
        ///</summary>
        public override SoftvList<RelEnProcesosEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<RelEnProcesosEntity> entities = new SoftvList<RelEnProcesosEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGetPaged", connection);

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
                        entities.Add(GetRelEnProcesosFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetRelEnProcesosCount();
                return entities ?? new SoftvList<RelEnProcesosEntity>();
            }
        }

        /// <summary>
        ///Get RelEnProcesos
        ///</summary>
        public override SoftvList<RelEnProcesosEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<RelEnProcesosEntity> entities = new SoftvList<RelEnProcesosEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGetPagedXml", connection);

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
                        entities.Add(GetRelEnProcesosFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetRelEnProcesosCount(xml);
                return entities ?? new SoftvList<RelEnProcesosEntity>();
            }
        }

        /// <summary>
        ///Get Count RelEnProcesos
        ///</summary>
        public int GetRelEnProcesosCount()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGetCount", connection);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
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
        ///Get Count RelEnProcesos
        ///</summary>
        public int GetRelEnProcesosCount(String xml)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.RelEnProcesos.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_RelEnProcesosGetCountXml", connection);

                AssingParameter(comandoSql, "@xml", xml);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data RelEnProcesos " + ex.Message, ex);
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
