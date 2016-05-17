﻿
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.ComponentModel;
    using System.Linq;
    using Softv.Providers;
    using Softv.Entities;
    using Globals;

    /// <summary>
    /// Class                   : Softv.BAL.Client.cs
    /// Generated by            : Class Generator (c) 2014
    /// Description             : DatoFiscalBussines
    /// File                    : DatoFiscalBussines.cs
    /// Creation date           : 04/05/2016
    /// Creation time           : 01:31 p. m.
    ///</summary>
    namespace Softv.BAL
    {

    [DataObject]
    [Serializable]
    public class DatoFiscal
    {

    #region Constructors
    public DatoFiscal(){}
    #endregion

    /// <summary>
    ///Adds DatoFiscal
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Add(DatoFiscalEntity objDatoFiscal)
  {
  int result = ProviderSoftv.DatoFiscal.AddDatoFiscal(objDatoFiscal);
    return result;
    }

    /// <summary>
    ///Delete DatoFiscal
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static int Delete(long? Contrato)
    {
    int resultado = ProviderSoftv.DatoFiscal.DeleteDatoFiscal(Contrato );
    return resultado;
    }

    /// <summary>
    ///Update DatoFiscal
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Edit(DatoFiscalEntity objDatoFiscal)
    {
    int result = ProviderSoftv.DatoFiscal.EditDatoFiscal(objDatoFiscal);
    return result;
    }

    /// <summary>
    ///Get DatoFiscal
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static List<DatoFiscalEntity> GetAll()
    {
    List<DatoFiscalEntity> entities = new List<DatoFiscalEntity> ();
    entities = ProviderSoftv.DatoFiscal.GetDatoFiscal();
    
    return entities ?? new List<DatoFiscalEntity>();
    }

    /// <summary>
    ///Get DatoFiscal List<lid>
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static List<DatoFiscalEntity> GetAll(List<int> lid)
    {
    List<DatoFiscalEntity> entities = new List<DatoFiscalEntity> ();
    entities = ProviderSoftv.DatoFiscal.GetDatoFiscal(lid);    
    return entities ?? new List<DatoFiscalEntity>();
    }

    /// <summary>
    ///Get DatoFiscal By Id
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static DatoFiscalEntity GetOne(long? Contrato)
    {
    DatoFiscalEntity result = ProviderSoftv.DatoFiscal.GetDatoFiscalById(Contrato );
    
    return result;
    }

    /// <summary>
    ///Get DatoFiscal By Id
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static DatoFiscalEntity GetOneDeep(long? Contrato)
    {
    DatoFiscalEntity result = ProviderSoftv.DatoFiscal.GetDatoFiscalById(Contrato );
    
    return result;
    }
    

    
      /// <summary>
      ///Get DatoFiscal
      ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static SoftvList<DatoFiscalEntity> GetPagedList(int pageIndex, int pageSize)
    {
    SoftvList<DatoFiscalEntity> entities = new SoftvList<DatoFiscalEntity>();
    entities = ProviderSoftv.DatoFiscal.GetPagedList(pageIndex, pageSize);
    
    return entities ?? new SoftvList<DatoFiscalEntity>();
    }

    /// <summary>
    ///Get DatoFiscal
    ///</summary>
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static SoftvList<DatoFiscalEntity> GetPagedList(int pageIndex, int pageSize,String xml)
    {
    SoftvList<DatoFiscalEntity> entities = new SoftvList<DatoFiscalEntity>();
    entities = ProviderSoftv.DatoFiscal.GetPagedList(pageIndex, pageSize,xml);
    
    return entities ?? new SoftvList<DatoFiscalEntity>();
    }


    }




    #region Customs Methods
    
    #endregion
    }
  