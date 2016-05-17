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
    /// Class                   : Softv.DAO.TapData
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Tap Data Access Object
    /// File                    : TapDAO.cs
    /// Creation date           : 04/05/2016
    /// Creation time           : 01:31 p. m.
    ///</summary>
    public class TapData : TapProvider
    {
    /// <summary>
    ///</summary>
    /// <param name="Tap"> Object Tap added to List</param>
    public override int AddTap(TapEntity entity_Tap)
    {
    int result=0;
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TapAdd", connection);
    
        AssingParameter(comandoSql, "@IdTap", null, pd: ParameterDirection.Output, IsKey: true);
      
            AssingParameter(comandoSql,"@Clv_Sector",entity_Tap.Clv_Sector);
          
            AssingParameter(comandoSql,"@Clv_Colonia",entity_Tap.Clv_Colonia);
          
            AssingParameter(comandoSql,"@Clv_Calle",entity_Tap.Clv_Calle);
          
            AssingParameter(comandoSql,"@IdPoste",entity_Tap.IdPoste);
          
            AssingParameter(comandoSql,"@Ingenieria",entity_Tap.Ingenieria);
          
            AssingParameter(comandoSql,"@Salidas",entity_Tap.Salidas);
          
            AssingParameter(comandoSql,"@Clave",entity_Tap.Clave);
          
            AssingParameter(comandoSql,"@NoCasas",entity_Tap.NoCasas);
          
            AssingParameter(comandoSql,"@NoNegocios",entity_Tap.NoNegocios);
          
            AssingParameter(comandoSql,"@NoLotes",entity_Tap.NoLotes);
          
            AssingParameter(comandoSql,"@NoServicios",entity_Tap.NoServicios);
          
            AssingParameter(comandoSql,"@FrenteANumero",entity_Tap.FrenteANumero);
          
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = ExecuteNonQuery(comandoSql);
    }
    catch (Exception ex)
    {
    throw new Exception("Error adding Tap " + ex.Message, ex);
    }
    finally
    {
    connection.Close();
    }
    result = (int)comandoSql.Parameters["@IdTap"].Value;
    }
    return result;
    }

    /// <summary>
    /// Deletes a Tap
    ///</summary>
    /// <param name="">  IdTap to delete </param>
    public override int DeleteTap(int? IdTap)
    {
    int result=0;
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TapDelete", connection);
    
            AssingParameter(comandoSql,"@IdTap",IdTap);
          
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = ExecuteNonQuery(comandoSql);
    }
    catch (Exception ex)
    {
    throw new Exception("Error deleting Tap " + ex.Message, ex);
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
    /// Edits a Tap
    ///</summary>
    /// <param name="Tap"> Objeto Tap a editar </param>
    public override int EditTap(TapEntity entity_Tap)
    {
    int result=0;
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TapEdit", connection);
    
            AssingParameter(comandoSql,"@IdTap",entity_Tap.IdTap);
          
            AssingParameter(comandoSql,"@Clv_Sector",entity_Tap.Clv_Sector);
          
            AssingParameter(comandoSql,"@Clv_Colonia",entity_Tap.Clv_Colonia);
          
            AssingParameter(comandoSql,"@Clv_Calle",entity_Tap.Clv_Calle);
          
            AssingParameter(comandoSql,"@IdPoste",entity_Tap.IdPoste);
          
            AssingParameter(comandoSql,"@Ingenieria",entity_Tap.Ingenieria);
          
            AssingParameter(comandoSql,"@Salidas",entity_Tap.Salidas);
          
            AssingParameter(comandoSql,"@Clave",entity_Tap.Clave);
          
            AssingParameter(comandoSql,"@NoCasas",entity_Tap.NoCasas);
          
            AssingParameter(comandoSql,"@NoNegocios",entity_Tap.NoNegocios);
          
            AssingParameter(comandoSql,"@NoLotes",entity_Tap.NoLotes);
          
            AssingParameter(comandoSql,"@NoServicios",entity_Tap.NoServicios);
          
            AssingParameter(comandoSql,"@FrenteANumero",entity_Tap.FrenteANumero);
          
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    
        result = int.Parse(ExecuteNonQuery(comandoSql).ToString());
          
    }
    catch (Exception ex)
    {
    throw new Exception("Error updating Tap " + ex.Message, ex);
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
    /// Gets all Tap
    ///</summary>
    public override List<TapEntity> GetTap()
    {
    List<TapEntity> TapList = new List<TapEntity>();
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TapGet", connection);
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql);

    while (rd.Read())
    {
    TapList.Add(GetTapFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Tap "  + ex.Message, ex);
    }
    finally
    {
    if(connection!=null)
    connection.Close();
    if(rd != null)
    rd.Close();
    }
    }
    return TapList;
    }

    /// <summary>
    /// Gets all Tap by List<int>
    ///</summary>
    public override List<TapEntity> GetTap(List<int> lid)
    {
    List<TapEntity> TapList = new List<TapEntity>();
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    DataTable IdDT = BuildTableID(lid);
    
    SqlCommand comandoSql = CreateCommand("Softv_TapGetByIds", connection);
    AssingParameter(comandoSql, "@IdTable", IdDT);
    
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql);

    while (rd.Read())
    {
    TapList.Add(GetTapFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Tap "  + ex.Message, ex);
    }
    finally
    {
    if(connection!=null)
    connection.Close();
    if(rd != null)
    rd.Close();
    }
    }
    return TapList;
    }

    /// <summary>
    /// Gets Tap by
    ///</summary>
    public override TapEntity GetTapById(int? IdTap)
    {
    using(SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TapGetById", connection);
    TapEntity entity_Tap = null;

    
            AssingParameter(comandoSql,"@IdTap", IdTap);
          
    IDataReader rd = null;
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    rd = ExecuteReader(comandoSql, CommandBehavior.SingleRow);
    if (rd.Read())
    entity_Tap = GetTapFromReader(rd);
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Tap "  + ex.Message, ex);
    }
    finally
    {
    if(connection!=null)
    connection.Close();
    if(rd != null)
    rd.Close();
    }
    return entity_Tap;
    }

    }

    

    /// <summary>
    ///Get Tap
    ///</summary>
    public override SoftvList<TapEntity> GetPagedList(int pageIndex, int pageSize)
    {
    SoftvList<TapEntity> entities = new SoftvList<TapEntity>();
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TapGetPaged", connection);
    
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
    entities.Add(GetTapFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Tap " + ex.Message, ex);
    }
    finally
    {
    if (connection != null)
    connection.Close();
    if (rd != null)
    rd.Close();
    }
    entities.totalCount = GetTapCount();
    return entities ?? new SoftvList<TapEntity>();
    }
    }

    /// <summary>
    ///Get Tap
    ///</summary>
    public override SoftvList<TapEntity> GetPagedList(int pageIndex, int pageSize,String xml)
    {
    SoftvList<TapEntity> entities = new SoftvList<TapEntity>();
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TapGetPagedXml", connection);
    
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
    entities.Add(GetTapFromReader(rd));
    }
    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Tap " + ex.Message, ex);
    }
    finally
    {
    if (connection != null)
    connection.Close();
    if (rd != null)
    rd.Close();
    }
    entities.totalCount = GetTapCount(xml);
    return entities ?? new SoftvList<TapEntity>();
    }
    }

    /// <summary>
    ///Get Count Tap
    ///</summary>
    public int GetTapCount()
    {
    int result = 0;
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TapGetCount", connection);
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = (int)ExecuteScalar(comandoSql);


    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Tap " + ex.Message, ex);
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
    ///Get Count Tap
    ///</summary>
    public int GetTapCount(String xml)
    {
    int result = 0;
    using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Tap.ConnectionString))
    {
    
    SqlCommand comandoSql = CreateCommand("Softv_TapGetCountXml", connection);
    
    AssingParameter(comandoSql,"@xml", xml);
    try
    {
    if (connection.State == ConnectionState.Closed)
    connection.Open();
    result = (int)ExecuteScalar(comandoSql);


    }
    catch (Exception ex)
    {
    throw new Exception("Error getting data Tap " + ex.Message, ex);
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
  