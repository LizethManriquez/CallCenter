﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Softv.Entities
{
    /// <summary>
    /// Class                   : Softv.Entities.TipServEntity.cs
    /// Generated by            : Class Generator (c) 2014
    /// Description             : TipServ entity
    /// File                    : TipServEntity.cs
    /// Creation date           : 04/05/2016
    /// Creation time           : 06:40 p. m.
    ///</summary>
    [DataContract]
    [Serializable]
    public class TipServEntity : BaseEntity
    {
        #region Attributes

        /// <summary>
        /// Property Clv_TipSer
        /// </summary>
        [DataMember]
        public int? Clv_TipSer { get; set; }
        /// <summary>
        /// Property Concepto
        /// </summary>
        [DataMember]
        public String Concepto { get; set; }
        /// <summary>
        /// Property Habilitar
        /// </summary>
        [DataMember]
        public short? Habilitar { get; set; }
        [DataMember]
        public LlamadaEntity Llamada { get; set; }

        #endregion
    }
}

