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
/// Generated by            : Class Generator (c) 2015
/// Description             : PermisoBussines
/// File                    : PermisoBussines.cs
/// Creation date           : 19/09/2015
/// Creation time           : 04:34 p. m.
///</summary>
namespace Softv.BAL
{

    [DataObject]
    [Serializable]
    public class Permiso
    {

        #region Constructors
        public Permiso() { }
        #endregion

        /// <summary>
        ///Adds Permiso
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int MargePermiso(String xml)
        {
            int result = ProviderSoftv.Permiso.MargePermiso(xml);
            return result;
        }

        /// <summary>
        ///Get Permiso
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SoftvList<PermisoEntity> GetXml(String xml)
        {
            SoftvList<PermisoEntity> entities = new SoftvList<PermisoEntity>();
            entities = ProviderSoftv.Permiso.GetXml(xml);
            return entities ?? new SoftvList<PermisoEntity>();
        }

    }
}
