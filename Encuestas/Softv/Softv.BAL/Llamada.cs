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
/// Description             : LlamadaBussines
/// File                    : LlamadaBussines.cs
/// Creation date           : 04/05/2016
/// Creation time           : 06:40 p. m.
///</summary>
namespace Softv.BAL
{

    [DataObject]
    [Serializable]
    public class Llamada
    {

        #region Constructors
        public Llamada() { }
        #endregion

        /// <summary>
        ///Adds Llamada
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int Add(LlamadaEntity objLlamada)
        {
            int result = ProviderSoftv.Llamada.AddLlamada(objLlamada);
            return result;
        }

        /// <summary>
        ///Delete Llamada
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static int Delete(int? IdLlamada)
        {
            int resultado = ProviderSoftv.Llamada.DeleteLlamada(IdLlamada);
            return resultado;
        }

        /// <summary>
        ///Update Llamada
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Edit(LlamadaEntity objLlamada)
        {
            int result = ProviderSoftv.Llamada.EditLlamada(objLlamada);
            return result;
        }

        /// <summary>
        ///Get Llamada
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<LlamadaEntity> GetAll()
        {
            List<LlamadaEntity> entities = new List<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetLlamada();

            List<UsuarioEntity> lUsuario = ProviderSoftv.Usuario.GetUsuario(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).ToList());
            lUsuario.ForEach(XUsuario => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XUsuario.IdUsuario).ToList().ForEach(y => y.Usuario = XUsuario));

            List<TurnoEntity> lTurnos = ProviderSoftv.Turno.GetTurno(entities.Where(x => x.IdTurno.HasValue).Select(x => x.IdTurno.Value).ToList());
            lTurnos.ForEach(XTurnos => entities.Where(x => x.IdTurno.HasValue).Where(x => x.IdTurno == XTurnos.IdTurno).ToList().ForEach(y => y.Turno = XTurnos));

            List<ConexionEntity> lConexion = ProviderSoftv.Conexion.GetConexion(entities.Where(x => x.IdConexion.HasValue).Select(x => x.IdConexion.Value).ToList());
            lConexion.ForEach(XConexion => entities.Where(x => x.IdConexion.HasValue).Where(x => x.IdConexion == XConexion.IdConexion).ToList().ForEach(y => y.Conexion = XConexion));

            List<TrabajoEntity> lTrabajo = ProviderSoftv.Trabajo.GetTrabajo(entities.Where(x => x.Clv_Trabajo.HasValue).Select(x => x.Clv_Trabajo.Value).ToList());
            lTrabajo.ForEach(XTrabajo => entities.Where(x => x.Clv_Trabajo.HasValue).Where(x => x.Clv_Trabajo == XTrabajo.Clv_Trabajo).ToList().ForEach(y => y.Trabajo = XTrabajo));

            List<TipServEntity> lTipServ = ProviderSoftv.TipServ.GetTipServ(entities.Where(x => x.Clv_TipSer.HasValue).Select(x => x.Clv_TipSer.Value).ToList());
            lTipServ.ForEach(XTipServ => entities.Where(x => x.Clv_TipSer.HasValue).Where(x => x.Clv_TipSer == XTipServ.Clv_TipSer).ToList().ForEach(y => y.TipServ = XTipServ));

            List<CLIENTEEntity> lCLIENTE = ProviderSoftv.CLIENTE.GetCLIENTE(entities.Where(x => x.Contrato.HasValue).Select(x => x.Contrato.Value).ToList());
            lCLIENTE.ForEach(XCLIENTE => entities.Where(x => x.Contrato.HasValue).Where(x => x.Contrato == XCLIENTE.CONTRATO).ToList().ForEach(y => y.CLIENTE = XCLIENTE));

            return entities ?? new List<LlamadaEntity>();
        }

        /// <summary>
        ///Get Llamada List<lid>
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<LlamadaEntity> GetAll(List<int> lid)
        {
            List<LlamadaEntity> entities = new List<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetLlamada(lid);
            return entities ?? new List<LlamadaEntity>();
        }

        /// <summary>
        ///Get Llamada By Id
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static LlamadaEntity GetOne(int? IdLlamada)
        {
            LlamadaEntity result = ProviderSoftv.Llamada.GetLlamadaById(IdLlamada);

            if (result.IdUsuario != null)
                result.Usuario = ProviderSoftv.Usuario.GetUsuarioById(result.IdUsuario);

            if (result.IdTurno != null)
                result.Turno = ProviderSoftv.Turno.GetTurnoById(result.IdTurno);

            if (result.IdConexion != null)
                result.Conexion = ProviderSoftv.Conexion.GetConexionById(result.IdConexion);

            if (result.Clv_Trabajo != null)
                result.Trabajo = ProviderSoftv.Trabajo.GetTrabajoById(result.Clv_Trabajo);

            if (result.Clv_TipSer != null)
                result.TipServ = ProviderSoftv.TipServ.GetTipServById(result.Clv_TipSer);

            if (result.Contrato != null)
                result.CLIENTE = ProviderSoftv.CLIENTE.GetCLIENTEById(result.Contrato);

            return result;
        }

        /// <summary>
        ///Get Llamada By Id
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static LlamadaEntity GetOneDeep(int? IdLlamada)
        {
            LlamadaEntity result = ProviderSoftv.Llamada.GetLlamadaById(IdLlamada);

            if (result.IdUsuario != null)
                result.Usuario = ProviderSoftv.Usuario.GetUsuarioById(result.IdUsuario);

            if (result.IdTurno != null)
                result.Turno = ProviderSoftv.Turno.GetTurnoById(result.IdTurno);

            if (result.IdConexion != null)
                result.Conexion = ProviderSoftv.Conexion.GetConexionById(result.IdConexion);

            if (result.Clv_Trabajo != null)
                result.Trabajo = ProviderSoftv.Trabajo.GetTrabajoById(result.Clv_Trabajo);

            if (result.Clv_TipSer != null)
                result.TipServ = ProviderSoftv.TipServ.GetTipServById(result.Clv_TipSer);

            if (result.Contrato != null)
                result.CLIENTE = ProviderSoftv.CLIENTE.GetCLIENTEById(result.Contrato);

            return result;
        }

        public static List<LlamadaEntity> GetLlamadaByIdUsuario(int? IdUsuario)
        {
            List<LlamadaEntity> entities = new List<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetLlamadaByIdUsuario(IdUsuario);
            return entities ?? new List<LlamadaEntity>();
        }

        public static List<LlamadaEntity> GetLlamadaByIdTurno(int? IdTurno)
        {
            List<LlamadaEntity> entities = new List<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetLlamadaByIdTurno(IdTurno);
            return entities ?? new List<LlamadaEntity>();
        }

        public static List<LlamadaEntity> GetLlamadaByIdConexion(int? IdConexion)
        {
            List<LlamadaEntity> entities = new List<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetLlamadaByIdConexion(IdConexion);
            return entities ?? new List<LlamadaEntity>();
        }

        public static List<LlamadaEntity> GetLlamadaByClv_Trabajo(int? Clv_Trabajo)
        {
            List<LlamadaEntity> entities = new List<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetLlamadaByClv_Trabajo(Clv_Trabajo);
            return entities ?? new List<LlamadaEntity>();
        }

        public static List<LlamadaEntity> GetLlamadaByClv_TipSer(int? Clv_TipSer)
        {
            List<LlamadaEntity> entities = new List<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetLlamadaByClv_TipSer(Clv_TipSer);
            return entities ?? new List<LlamadaEntity>();
        }

        public static List<LlamadaEntity> GetLlamadaByContrato(long? Contrato)
        {
            List<LlamadaEntity> entities = new List<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetLlamadaByContrato(Contrato);
            return entities ?? new List<LlamadaEntity>();
        }



        /// <summary>
        ///Get Llamada
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SoftvList<LlamadaEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<LlamadaEntity> entities = new SoftvList<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetPagedList(pageIndex, pageSize);

            List<UsuarioEntity> lUsuario = ProviderSoftv.Usuario.GetUsuario(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            lUsuario.ForEach(XUsuario => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XUsuario.IdUsuario).ToList().ForEach(y => y.Usuario = XUsuario));

            List<TurnoEntity> lTurnos = ProviderSoftv.Turno.GetTurno(entities.Where(x => x.IdTurno.HasValue).Select(x => x.IdTurno.Value).Distinct().ToList());
            lTurnos.ForEach(XTurnos => entities.Where(x => x.IdTurno.HasValue).Where(x => x.IdTurno == XTurnos.IdTurno).ToList().ForEach(y => y.Turno = XTurnos));

            List<ConexionEntity> lConexion = ProviderSoftv.Conexion.GetConexion(entities.Where(x => x.IdConexion.HasValue).Select(x => x.IdConexion.Value).Distinct().ToList());
            lConexion.ForEach(XConexion => entities.Where(x => x.IdConexion.HasValue).Where(x => x.IdConexion == XConexion.IdConexion).ToList().ForEach(y => y.Conexion = XConexion));

            List<TrabajoEntity> lTrabajo = ProviderSoftv.Trabajo.GetTrabajo(entities.Where(x => x.Clv_Trabajo.HasValue).Select(x => x.Clv_Trabajo.Value).Distinct().ToList());
            lTrabajo.ForEach(XTrabajo => entities.Where(x => x.Clv_Trabajo.HasValue).Where(x => x.Clv_Trabajo == XTrabajo.Clv_Trabajo).ToList().ForEach(y => y.Trabajo = XTrabajo));

            List<TipServEntity> lTipServ = ProviderSoftv.TipServ.GetTipServ(entities.Where(x => x.Clv_TipSer.HasValue).Select(x => x.Clv_TipSer.Value).Distinct().ToList());
            lTipServ.ForEach(XTipServ => entities.Where(x => x.Clv_TipSer.HasValue).Where(x => x.Clv_TipSer == XTipServ.Clv_TipSer).ToList().ForEach(y => y.TipServ = XTipServ));

            List<CLIENTEEntity> lCLIENTE = ProviderSoftv.CLIENTE.GetCLIENTE(entities.Where(x => x.Contrato.HasValue).Select(x => x.Contrato.Value).Distinct().ToList());
            lCLIENTE.ForEach(XCLIENTE => entities.Where(x => x.Contrato.HasValue).Where(x => x.Contrato == XCLIENTE.CONTRATO).ToList().ForEach(y => y.CLIENTE = XCLIENTE));

            return entities ?? new SoftvList<LlamadaEntity>();
        }

        /// <summary>
        ///Get Llamada
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SoftvList<LlamadaEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<LlamadaEntity> entities = new SoftvList<LlamadaEntity>();
            entities = ProviderSoftv.Llamada.GetPagedList(pageIndex, pageSize, xml);

            List<UsuarioEntity> lUsuario = ProviderSoftv.Usuario.GetUsuario(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            lUsuario.ForEach(XUsuario => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XUsuario.IdUsuario).ToList().ForEach(y => y.Usuario = XUsuario));

            List<TurnoEntity> lTurnos = ProviderSoftv.Turno.GetTurno(entities.Where(x => x.IdTurno.HasValue).Select(x => x.IdTurno.Value).Distinct().ToList());
            lTurnos.ForEach(XTurnos => entities.Where(x => x.IdTurno.HasValue).Where(x => x.IdTurno == XTurnos.IdTurno).ToList().ForEach(y => y.Turno = XTurnos));

            List<ConexionEntity> lConexion = ProviderSoftv.Conexion.GetConexion(entities.Where(x => x.IdConexion.HasValue).Select(x => x.IdConexion.Value).Distinct().ToList());
            lConexion.ForEach(XConexion => entities.Where(x => x.IdConexion.HasValue).Where(x => x.IdConexion == XConexion.IdConexion).ToList().ForEach(y => y.Conexion = XConexion));

            List<TrabajoEntity> lTrabajo = ProviderSoftv.Trabajo.GetTrabajo(entities.Where(x => x.Clv_Trabajo.HasValue).Select(x => x.Clv_Trabajo.Value).Distinct().ToList());
            lTrabajo.ForEach(XTrabajo => entities.Where(x => x.Clv_Trabajo.HasValue).Where(x => x.Clv_Trabajo == XTrabajo.Clv_Trabajo).ToList().ForEach(y => y.Trabajo = XTrabajo));

            List<TipServEntity> lTipServ = ProviderSoftv.TipServ.GetTipServ(entities.Where(x => x.Clv_TipSer.HasValue).Select(x => x.Clv_TipSer.Value).Distinct().ToList());
            lTipServ.ForEach(XTipServ => entities.Where(x => x.Clv_TipSer.HasValue).Where(x => x.Clv_TipSer == XTipServ.Clv_TipSer).ToList().ForEach(y => y.TipServ = XTipServ));

            List<CLIENTEEntity> lCLIENTE = ProviderSoftv.CLIENTE.GetCLIENTE(entities.Where(x => x.Contrato.HasValue).Select(x => x.Contrato.Value).Distinct().ToList());
            lCLIENTE.ForEach(XCLIENTE => entities.Where(x => x.Contrato.HasValue).Where(x => x.Contrato == XCLIENTE.CONTRATO).ToList().ForEach(y => y.CLIENTE = XCLIENTE));

            return entities ?? new SoftvList<LlamadaEntity>();
        }


    }




    #region Customs Methods

    #endregion
}
