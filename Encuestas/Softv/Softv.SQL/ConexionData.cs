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
    /// Class                   : Softv.DAO.ConexionData
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Conexion Data Access Object
    /// File                    : ConexionDAO.cs
    /// Creation date           : 04/05/2016
    /// Creation time           : 01:21 p. m.
    ///</summary>
    public class ConexionData : ConexionProvider
    {
    /// <summary>
    ///</summary>
    /// <param name="Conexion"> Object Conexion added to List</param>
    public override int AddConexion(ConexionEntity entity_Conexion)
    {
    int result=0;
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionAdd", connection);
    
        AssingParameter(comandoSql, "@IdConexion", null, pd: ParameterDirection.Output, IsKey: true);
      
            AssingParameter(comandoSql,"@Plaza",entity_Conexion.Plaza);
          
            AssingParameter(comandoSql,"@Servidor",entity_Conexion.Servidor);
          
            AssingParameter(comandoSql,"@BaseDeDatos",entity_Conexion.BaseDeDatos);
          
            AssingParameter(comandoSql,"@Usuario",entity_Conexion.Usuario);
          
            AssingParameter(comandoSql,"@Password",entity_Conexion.Password);
          
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = ExecuteNonQuery(comandoSql);
    }
    catch (Exception ex)
    {
    throw new Exception("Error adding Conexion " + ex.Message, ex);
    }
    finally
    {
    connection.Close();
    }
    result = (int)comandoSql.Parameters["@IdConexion"].Value;
    }
    return result;
    }

    /// <summary>
    /// Deletes a Conexion
    ///</summary>
    /// <param name="">  IdConexion to delete </param>
    public override int DeleteConexion(int? IdConexion)
    {
    int result=0;
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionDelete", connection);
    
            AssingParameter(comandoSql,"@IdConexion",IdConexion);
          
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = ExecuteNonQuery(comandoSql);
    }
    catch (Exception ex)
    {
    throw new Exception("Error deleting Conexion " + ex.Message, ex);
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
    /// Edits a Conexion
    ///</summary>
    /// <param name="Conexion"> Objeto Conexion a editar </param>
    public override int EditConexion(ConexionEntity entity_Conexion)
    {
    int result=0;
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionEdit", connection);
    
            AssingParameter(comandoSql,"@IdConexion",entity_Conexion.IdConexion);
          
            AssingParameter(comandoSql,"@Plaza",entity_Conexion.Plaza);
          
            AssingParameter(comandoSql,"@Servidor",entity_Conexion.Servidor);
          
            AssingParameter(comandoSql,"@BaseDeDatos",entity_Conexion.BaseDeDatos);
          
            AssingParameter(comandoSql,"@Usuario",entity_Conexion.Usuario);
          
            AssingParameter(comandoSql,"@Password",entity_Conexion.Password);
          
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    
        result = int.Parse(ExecuteNonQuery(comandoSql).ToString());
          
    }
    catch (Exception ex)
    {
    throw new Exception("Error updating Conexion " + ex.Message, ex);
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
    /// Gets all Conexion
    ///</summary>
    public override List<ConexionEntity> GetConexion()
    {
    List<ConexionEntity> ConexionList = new List<ConexionEntity>();
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionGet", connection);
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql);

    while (rd.Read())
    {
    ConexionList.Add(GetConexionFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Conexion "  + ex.Message, ex);
    }
    finally
    {
    if(connection!=null)
    connection.Close();
    if(rd != null)
    rd.Close();
    }
    }
    return ConexionList;
    }

    /// <summary>
    /// Gets all Conexion by List<int>
    ///</summary>
    public override List<ConexionEntity> GetConexion(List<int> lid)
    {
    List<ConexionEntity> ConexionList = new List<ConexionEntity>();
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    DataTable IdDT = BuildTableID(lid);
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionGetByIds", connection);
    AssingParameter(comandoSql, "@IdTable", IdDT);
    
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql);

    while (rd.Read())
    {
    ConexionList.Add(GetConexionFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Conexion "  + ex.Message, ex);
    }
    finally
    {
    if(connection!=null)
    connection.Close();
    if(rd != null)
    rd.Close();
    }
    }
    return ConexionList;
    }

    /// <summary>
    /// Gets Conexion by
    ///</summary>
    public override ConexionEntity GetConexionById(int? IdConexion)
    {
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionGetById", connection);
    ConexionEntity entity_Conexion = null;

    
            AssingParameter(comandoSql,"@IdConexion", IdConexion);
          
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql, CommandBehavior.SingleRow);
    if (rd.Read())
    entity_Conexion = GetConexionFromReader(rd);
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Conexion "  + ex.Message, ex);
    }
    finally
    {
    if(connection!=null)
    connection.Close();
    if(rd != null)
    rd.Close();
    }
    return entity_Conexion;
    }

    }

    
          public override List<ConexionEntity> GetConexionByIdConexion(int? IdConexion)
          {
          List<ConexionEntity> ConexionList = new List<ConexionEntity>();
          using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
          {
          
          SqlCommand comandoSql = CreateCommand("Softv_ConexionGetByIdConexion", connection);
          
          AssingParameter(comandoSql, "@IdConexion", IdConexion);
          IDataReader rd = null;
          try
          {
          if (connection.State == ConnectionState.Closed)
          connection.Open();
          rd = ExecuteReader(comandoSql);

          while (rd.Read())
          {
          ConexionList.Add(GetConexionFromReader(rd));
          }
          }
          catch (Exception ex)
          {
          throw new Exception("Error getting data Conexion "  + ex.Message, ex);
          }
          finally
          {
          if(connection!=null)
          connection.Close();
          if(rd != null)
          rd.Close();
          }
          }
          return ConexionList;
          }
        

    /// <summary>
    ///Get Conexion
    ///</summary>
    public override SoftvList<ConexionEntity> GetPagedList(int pageIndex, int pageSize)
    {
    SoftvList<ConexionEntity> entities = new SoftvList<ConexionEntity>();
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionGetPaged", connection);
    
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
    entities.Add(GetConexionFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Conexion " + ex.Message, ex);
    }
    finally
    {
    if (connection != null)
    connection.Close();
    if (rd != null)
    rd.Close();
    }
    entities.totalCount = GetConexionCount();
    return entities ?? new SoftvList<ConexionEntity>();
    }
    }

    /// <summary>
    ///Get Conexion
    ///</summary>
    public override SoftvList<ConexionEntity> GetPagedList(int pageIndex, int pageSize,String xml)
    {
    SoftvList<ConexionEntity> entities = new SoftvList<ConexionEntity>();
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionGetPagedXml", connection);
    
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
    entities.Add(GetConexionFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Conexion " + ex.Message, ex);
    }
    finally
    {
    if (connection != null)
    connection.Close();
    if (rd != null)
    rd.Close();
    }
    entities.totalCount = GetConexionCount(xml);
    return entities ?? new SoftvList<ConexionEntity>();
    }
    }

    /// <summary>
    ///Get Count Conexion
    ///</summary>
    public int GetConexionCount()
    {
    int result = 0;
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionGetCount", connection);
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = (int)ExecuteScalar(comandoSql);


    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Conexion " + ex.Message, ex);
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
    ///Get Count Conexion
    ///</summary>
    public int GetConexionCount(String xml)
    {
    int result = 0;
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Conexion.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_ConexionGetCountXml", connection);
    
    AssingParameter(comandoSql,"@xml", xml);
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = (int)ExecuteScalar(comandoSql);


    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Conexion " + ex.Message, ex);
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
  