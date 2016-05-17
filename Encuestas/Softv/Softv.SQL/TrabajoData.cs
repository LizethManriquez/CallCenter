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
    /// Class                   : Softv.DAO.TrabajoData
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Trabajo Data Access Object
    /// File                    : TrabajoDAO.cs
    /// Creation date           : 04/05/2016
    /// Creation time           : 01:21 p. m.
    ///</summary>
    public class TrabajoData : TrabajoProvider
    {
    /// <summary>
    ///</summary>
    /// <param name="Trabajo"> Object Trabajo added to List</param>
    public override int AddTrabajo(TrabajoEntity entity_Trabajo)
    {
    int result=0;
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoAdd", connection);
    
        AssingParameter(comandoSql, "@Clv_Trabajo", null, pd: ParameterDirection.Output, IsKey: true);
      
            AssingParameter(comandoSql,"@TRABAJO",entity_Trabajo.TRABAJO);
          
            AssingParameter(comandoSql,"@Clv_TipSer",entity_Trabajo.Clv_TipSer);
          
            AssingParameter(comandoSql,"@DESCRIPCION",entity_Trabajo.DESCRIPCION);
          
            AssingParameter(comandoSql,"@PUNTOS",entity_Trabajo.PUNTOS);
          
            AssingParameter(comandoSql,"@Cobranza",entity_Trabajo.Cobranza);
          
            AssingParameter(comandoSql,"@Tipo",entity_Trabajo.Tipo);
          
            AssingParameter(comandoSql,"@Prospectos",entity_Trabajo.Prospectos);
          
            AssingParameter(comandoSql,"@SICA",entity_Trabajo.SICA);
          
            AssingParameter(comandoSql,"@SeCobraMaterial",entity_Trabajo.SeCobraMaterial);
          
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = ExecuteNonQuery(comandoSql);
    }
    catch (Exception ex)
    {
    throw new Exception("Error adding Trabajo " + ex.Message, ex);
    }
    finally
    {
    connection.Close();
    }
    result = (int)comandoSql.Parameters["@IdTrabajo"].Value;
    }
    return result;
    }

    /// <summary>
    /// Deletes a Trabajo
    ///</summary>
    /// <param name="">  Clv_Trabajo to delete </param>
    public override int DeleteTrabajo(int? Clv_Trabajo)
    {
    int result=0;
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoDelete", connection);
    
            AssingParameter(comandoSql,"@Clv_Trabajo",Clv_Trabajo);
          
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = ExecuteNonQuery(comandoSql);
    }
    catch (Exception ex)
    {
    throw new Exception("Error deleting Trabajo " + ex.Message, ex);
    }
    finally
    {
    if(connection != null)
    connection.Close();
    }
    }
    return result;
    }

    /// <summary>
    /// Edits a Trabajo
    ///</summary>
    /// <param name="Trabajo"> Objeto Trabajo a editar </param>
    public override int EditTrabajo(TrabajoEntity entity_Trabajo)
    {
    int result=0;
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoEdit", connection);
    
            AssingParameter(comandoSql,"@Clv_Trabajo",entity_Trabajo.Clv_Trabajo);
          
            AssingParameter(comandoSql,"@TRABAJO",entity_Trabajo.TRABAJO);
          
            AssingParameter(comandoSql,"@Clv_TipSer",entity_Trabajo.Clv_TipSer);
          
            AssingParameter(comandoSql,"@DESCRIPCION",entity_Trabajo.DESCRIPCION);
          
            AssingParameter(comandoSql,"@PUNTOS",entity_Trabajo.PUNTOS);
          
            AssingParameter(comandoSql,"@Cobranza",entity_Trabajo.Cobranza);
          
            AssingParameter(comandoSql,"@Tipo",entity_Trabajo.Tipo);
          
            AssingParameter(comandoSql,"@Prospectos",entity_Trabajo.Prospectos);
          
            AssingParameter(comandoSql,"@SICA",entity_Trabajo.SICA);
          
            AssingParameter(comandoSql,"@SeCobraMaterial",entity_Trabajo.SeCobraMaterial);
          
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    
        result = int.Parse(ExecuteNonQuery(comandoSql).ToString());
          
    }
    catch (Exception ex)
    {
    throw new Exception("Error updating Trabajo " + ex.Message, ex);
    }
    finally
    {
    if(connection != null)
    connection.Close();
    }
    }
    return result;
    }

    /// <summary>
    /// Gets all Trabajo
    ///</summary>
    public override List<TrabajoEntity> GetTrabajo()
    {
    List<TrabajoEntity> TrabajoList = new List<TrabajoEntity>();
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoGet", connection);
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql);

    while (rd.Read())
    {
    TrabajoList.Add(GetTrabajoFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Trabajo "  + ex.Message, ex);
    }
    finally
    {
    if(connection!=null)
    connection.Close();
    if(rd != null)
    rd.Close();
    }
    }
    return TrabajoList;
    }

    /// <summary>
    /// Gets all Trabajo by List<int>
    ///</summary>
    public override List<TrabajoEntity> GetTrabajo(List<int> lid)
    {
    List<TrabajoEntity> TrabajoList = new List<TrabajoEntity>();
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    DataTable IdDT = BuildTableID(lid);
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoGetByIds", connection);
    AssingParameter(comandoSql, "@IdTable", IdDT);
    
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql);

    while (rd.Read())
    {
    TrabajoList.Add(GetTrabajoFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Trabajo "  + ex.Message, ex);
    }
    finally
    {
    if(connection!=null)
    connection.Close();
    if(rd != null)
    rd.Close();
    }
    }
    return TrabajoList;
    }

    /// <summary>
    /// Gets Trabajo by
    ///</summary>
    public override TrabajoEntity GetTrabajoById(int? Clv_Trabajo)
    {
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoGetById", connection);
    TrabajoEntity entity_Trabajo = null;

    
            AssingParameter(comandoSql,"@Clv_Trabajo", Clv_Trabajo);
          
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql, CommandBehavior.SingleRow);
    if (rd.Read())
    entity_Trabajo = GetTrabajoFromReader(rd);
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Trabajo "  + ex.Message, ex);
    }
    finally
    {
    if(connection!=null)
    connection.Close();
    if(rd != null)
    rd.Close();
    }
    return entity_Trabajo;
    }

    }

    
          public override List<TrabajoEntity> GetTrabajoByClv_Trabajo(int? Clv_Trabajo)
          {
          List<TrabajoEntity> TrabajoList = new List<TrabajoEntity>();
          using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
          {
          
          SqlCommand comandoSql = CreateCommand("Softv_TrabajoGetByClv_Trabajo", connection);
          
          AssingParameter(comandoSql, "@Clv_Trabajo", Clv_Trabajo);
          IDataReader rd = null;
          try
          {
          if (connection.State == ConnectionState.Closed)
          connection.Open();
          rd = ExecuteReader(comandoSql);

          while (rd.Read())
          {
          TrabajoList.Add(GetTrabajoFromReader(rd));
          }
          }
          catch (Exception ex)
          {
          throw new Exception("Error getting data Trabajo "  + ex.Message, ex);
          }
          finally
          {
          if(connection!=null)
          connection.Close();
          if(rd != null)
          rd.Close();
          }
          }
          return TrabajoList;
          }
        

    /// <summary>
    ///Get Trabajo
    ///</summary>
    public override SoftvList<TrabajoEntity> GetPagedList(int pageIndex, int pageSize)
    {
    SoftvList<TrabajoEntity> entities = new SoftvList<TrabajoEntity>();
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoGetPaged", connection);
    
    AssingParameter(comandoSql,"@pageIndex", pageIndex);
    AssingParameter(comandoSql,"@pageSize", pageSize);
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql);
    while (rd.Read())
    {
    entities.Add(GetTrabajoFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Trabajo " + ex.Message, ex);
    }
    finally
    {
    if (connection != null)
    connection.Close();
    if (rd != null)
    rd.Close();
    }
    entities.totalCount = GetTrabajoCount();
    return entities ?? new SoftvList<TrabajoEntity>();
    }
    }

    /// <summary>
    ///Get Trabajo
    ///</summary>
    public override SoftvList<TrabajoEntity> GetPagedList(int pageIndex, int pageSize,String xml)
    {
    SoftvList<TrabajoEntity> entities = new SoftvList<TrabajoEntity>();
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoGetPagedXml", connection);
    
    AssingParameter(comandoSql,"@pageSize", pageSize);
    AssingParameter(comandoSql,"@pageIndex", pageIndex);
    AssingParameter(comandoSql,"@xml", xml);
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql);
    while (rd.Read())
    {
    entities.Add(GetTrabajoFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Trabajo " + ex.Message, ex);
    }
    finally
    {
    if (connection != null)
    connection.Close();
    if (rd != null)
    rd.Close();
    }
    entities.totalCount = GetTrabajoCount(xml);
    return entities ?? new SoftvList<TrabajoEntity>();
    }
    }

    /// <summary>
    ///Get Count Trabajo
    ///</summary>
    public int GetTrabajoCount()
    {
    int result = 0;
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoGetCount", connection);
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = (int)ExecuteScalar(comandoSql);


    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Trabajo " + ex.Message, ex);
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
    ///Get Count Trabajo
    ///</summary>
    public int GetTrabajoCount(String xml)
    {
    int result = 0;
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Trabajo.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TrabajoGetCountXml", connection);
    
    AssingParameter(comandoSql,"@xml", xml);
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = (int)ExecuteScalar(comandoSql);


    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Trabajo " + ex.Message, ex);
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
  