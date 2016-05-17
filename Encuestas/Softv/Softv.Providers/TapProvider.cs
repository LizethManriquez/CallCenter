﻿
    using System;
    using System.Text;
    using System.Data;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Runtime.Remoting;
    using Softv.Entities;
    using SoftvConfiguration;
    using Globals;

    namespace Softv.Providers
    {
    /// <summary>
    /// Class                   : Softv.Providers.TapProvider
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Tap Provider
    /// File                    : TapProvider.cs
    /// Creation date           : 04/05/2016
    /// Creation time           : 01:31 p. m.
    /// </summary>
    public abstract class TapProvider : Globals.DataAccess
    {

    /// <summary>
    /// Instance of Tap from DB
    /// </summary>
    private static TapProvider _Instance = null;

    private static ObjectHandle obj;
    /// <summary>
    /// Generates a Tap instance
    /// </summary>
    public static TapProvider Instance
    {
    get
    {
    if (_Instance == null)
    {
    obj = Activator.CreateInstance(
    SoftvSettings.Settings.Tap.Assembly,
    SoftvSettings.Settings.Tap.DataClass);
    _Instance = (TapProvider)obj.Unwrap();
    }
    return _Instance;
    }
    }

    /// <summary>
    /// Provider's default constructor
    /// </summary>
    public TapProvider()
    {
    }
    /// <summary>
    /// Abstract method to add Tap
    ///  /summary>
    /// <param name="Tap"></param>
    /// <returns></returns>
    public abstract int AddTap(TapEntity entity_Tap);

    /// <summary>
    /// Abstract method to delete Tap
    /// </summary>
    public abstract int DeleteTap(int? IdTap);

    /// <summary>
    /// Abstract method to update Tap
    /// </summary>
    public abstract int EditTap(TapEntity entity_Tap);

    /// <summary>
    /// Abstract method to get all Tap
    /// </summary>
    public abstract List<TapEntity> GetTap();

    /// <summary>
    /// Abstract method to get all Tap List<int> lid
    /// </summary>
    public abstract List<TapEntity> GetTap(List<int> lid);

    /// <summary>
    /// Abstract method to get by id
    /// </summary>
    public abstract TapEntity GetTapById(int? IdTap);

    

    /// <summary>
    ///Get Tap
    ///</summary>
    public abstract SoftvList<TapEntity> GetPagedList(int pageIndex, int pageSize);

    /// <summary>
    ///Get Tap
    ///</summary>
    public abstract SoftvList<TapEntity> GetPagedList(int pageIndex, int pageSize,String xml);

    /// <summary>
    /// Converts data from reader to entity
    /// </summary>
    protected virtual TapEntity GetTapFromReader(IDataReader reader)
    {
    TapEntity entity_Tap = null;
    try
    {
      entity_Tap = new TapEntity();
    entity_Tap.IdTap = (int?)(GetFromReader(reader,"IdTap"));
          entity_Tap.Clv_Sector = (int?)(GetFromReader(reader,"Clv_Sector"));
          entity_Tap.Clv_Colonia = (int?)(GetFromReader(reader,"Clv_Colonia"));
          entity_Tap.Clv_Calle = (int?)(GetFromReader(reader,"Clv_Calle"));
          entity_Tap.IdPoste = (int?)(GetFromReader(reader,"IdPoste"));
          entity_Tap.Ingenieria = (int?)(GetFromReader(reader,"Ingenieria"));
          entity_Tap.Salidas = (int?)(GetFromReader(reader,"Salidas"));
          entity_Tap.Clave = (String)(GetFromReader(reader,"Clave", IsString : true));
        entity_Tap.NoCasas = (int?)(GetFromReader(reader,"NoCasas"));
          entity_Tap.NoNegocios = (int?)(GetFromReader(reader,"NoNegocios"));
          entity_Tap.NoLotes = (int?)(GetFromReader(reader,"NoLotes"));
          entity_Tap.NoServicios = (int?)(GetFromReader(reader,"NoServicios"));
          entity_Tap.FrenteANumero = (String)(GetFromReader(reader,"FrenteANumero", IsString : true));
        
    }
    catch (Exception ex)
    {
    throw new Exception("Error converting Tap data to entity", ex);
    }
    return entity_Tap;
    }
    
    }

    #region Customs Methods
    
    #endregion
    }

  