﻿
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    namespace Softv.Entities
    {
    /// <summary>
    /// Class                   : Softv.Entities.RelEncuestaClientesEntity.cs
    /// Generated by            : Class Generator (c) 2014
    /// Description             : RelEncuestaClientes entity
    /// File                    : RelEncuestaClientesEntity.cs
    /// Creation date           : 02/05/2016
    /// Creation time           : 06:39 p. m.
    ///</summary>
    [DataContract]
    [Serializable]
    public class RelEncuestaClientesEntity : BaseEntity
    {
    #region Attributes
    
      /// <summary>
      /// Property IdProceso
      /// </summary>
      [DataMember]
      public int? IdProceso { get; set; }
      /// <summary>
      /// Property IdEncuesta
      /// </summary>
      [DataMember]
      public int? IdEncuesta { get; set; }
      /// <summary>
      /// Property Contrato
      /// </summary>
      [DataMember]
      public long? Contrato { get; set; }
      /// <summary>
      /// Property FechaApli
      /// </summary>
      [DataMember]
      public DateTime? FechaApli { get; set; }
          [DataMember]
          public EncuestaEntity Encuesta { get; set; }
        
          [DataMember]
          public CLIENTEEntity CLIENTE { get; set; }
        
          [DataMember]
          public RelEnProcesosEntity RelEnProcesos { get; set; }
        
    #endregion
    }
    }

  