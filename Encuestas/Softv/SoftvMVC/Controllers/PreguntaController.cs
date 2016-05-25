﻿
using SoftvMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Softv.Entities;
using Globals;

namespace SoftvMVC.Controllers
{
    /// <summary>
    /// Class                   : SoftvMVC.Controllers.PreguntaController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : PreguntaController
    /// File                    : PreguntaController.cs
    /// Creation date           : 27/04/2016
    /// Creation time           : 05:16 p. m.
    ///</summary>
    public partial class PreguntaController : BaseController, IDisposable
    {
        private SoftvService.PreguntaClient proxy = null;
        private SoftvService.TipoPreguntasClient proxyTipoPreguntas = null;
        private SoftvService.RelPreguntaOpcMultsClient relpregunta_resp = null;
        private SoftvService.ResOpcMultsClient RespuestasOM = null;

        public PreguntaController()
        {


            proxy = new SoftvService.PreguntaClient();

            proxyTipoPreguntas = new SoftvService.TipoPreguntasClient();

             relpregunta_resp=new SoftvService.RelPreguntaOpcMultsClient();

             RespuestasOM= new SoftvService.ResOpcMultsClient();
        }

        new public void Dispose()
        {
            if (proxy != null)
            {
                if (proxy.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxy.Close();
                }
            }

            proxyTipoPreguntas = new SoftvService.TipoPreguntasClient();
            if (proxyTipoPreguntas != null)
            {
                if (proxyTipoPreguntas.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyTipoPreguntas.Close();
                }
            }

        }

        public ActionResult Index(int? page, int? pageSize)
        {
            PermisosAcceso("Pregunta");
            ViewData["Title"] = "Pregunta";
            ViewData["Message"] = "Pregunta";
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            int pageNumber = (page ?? 1);
            SoftvList<PreguntaEntity> listResult = proxy.GetPreguntaPagedListXml(pageNumber, pSize, SerializeTool.Serialize<PreguntaEntity>(new PreguntaEntity()));


            List<TipoPreguntasEntity> lstTipoPreguntas = new List<TipoPreguntasEntity>();
            lstTipoPreguntas.Add(new TipoPreguntasEntity() { IdTipoPregunta = null, Descripcion = "Todos" });
            lstTipoPreguntas.AddRange(proxyTipoPreguntas.GetTipoPreguntasList().OrderBy(x => x.Descripcion.Trim()));
            ViewBag.IdTipoPreguntatxt = new SelectList(lstTipoPreguntas, "IdTipoPregunta", "Descripcion");

            CheckNotify();
            ViewBag.CustomScriptsDefault = BuildScriptsDefault("Pregunta");
            return View(new StaticPagedList<PreguntaEntity>(listResult.ToList(), pageNumber, pSize, listResult.totalCount));
        }



        public class Pregunta
        {
            public PreguntaEntity pregunta { get; set; }

            public List<ResOpcMultsEntity> respuestas { get; set; }

        }



        public ActionResult GetOnePregunta(int id)
        {
                   PreguntaEntity pregunta= proxy.GetPreguntaList().Where(x=>x.IdPregunta==id).FirstOrDefault();
                   Pregunta p = new Pregunta();
                   p.pregunta = pregunta;
                   List<ResOpcMultsEntity> respuestas = new List<ResOpcMultsEntity>();     
                   List<RelPreguntaOpcMultsEntity> rel=  relpregunta_resp.GetRelPreguntaOpcMultsList().Where(o => o.IdPregunta == id).ToList();
                   foreach(var a in rel){
                     ResOpcMultsEntity respuesta = RespuestasOM.GetResOpcMultsList().Where(s => s.Id_ResOpcMult == a.Id_ResOpcMult).FirstOrDefault();
                     respuestas.Add(respuesta);
                   }
                   p.respuestas = respuestas;


                
            return Json(p,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            proxy.DeletePregunta(id);

            String mensaje = "{mensaje:'Se ha eliminado la Pregunta'}";
            return Json(mensaje, JsonRequestBehavior.AllowGet);
        }

        //Nuevas funciones 

        public ActionResult GetList(string data, int draw, int start, int length)
        {
            DataTableData dataTableData = new DataTableData();
            dataTableData.draw = draw;
            dataTableData.recordsTotal = 0;
            int recordsFiltered = 0;
            dataTableData.data = FiltrarContenido(ref recordsFiltered, start, length);
            dataTableData.recordsFiltered = recordsFiltered;

            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        private List<PreguntaEntity> FiltrarContenido(ref int recordFiltered, int start, int length)
        {

            List<PreguntaEntity> lista = proxy.GetPreguntaList();
            recordFiltered = lista.Count;
            int rango = start + length;
            return lista.Skip(start).Take(length).ToList();
        }

        public class DataTableData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<PreguntaEntity> data { get; set; }
        }

        public class Detalle_pregunta
        {
            public PreguntaEntity Pregunta { get; set; }
            public List<ResOpcMultsEntity> Respuestas { get; set; }

        }
        public ActionResult GetDetallePregunta(string data, int tipo, int draw, int start, int length)
       {
            List<Detalle_pregunta> datos = new List<Detalle_pregunta>();
            DataTableDataDetalle dataTableData = new DataTableDataDetalle();
            dataTableData.draw = draw;
            dataTableData.recordsTotal = 0;
            int recordsFiltered = 0;
            if ( data != "" )
            {
                int t = 0;
               datos = FiltrarPreguntas(ref recordsFiltered, start, length).Where(x => x.Pregunta.Pregunta.Contains(data)).ToList();
            }
             if (tipo>0)
            {
                datos = FiltrarPreguntas(ref recordsFiltered, start, length).Where(x => x.Pregunta.IdTipoPregunta==tipo).ToList();
            }
            else
            {
              datos = FiltrarPreguntas(ref recordsFiltered, start, length);
            }

             dataTableData.data = datos;
             dataTableData.recordsFiltered = recordsFiltered;


           
            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        private List<Detalle_pregunta> FiltrarPreguntas(ref int recordFiltered, int start, int length)
        {
            List<Detalle_pregunta> Lista_Preguntas = new List<Detalle_pregunta>();
            List<PreguntaEntity> preguntas = proxy.GetPreguntaList().ToList();
            foreach (var a in preguntas)
            {
                Detalle_pregunta Pregunta = new Detalle_pregunta();

                List<ResOpcMultsEntity> Respuestas = new List<ResOpcMultsEntity>();
                List<RelPreguntaOpcMultsEntity> relaciones = relpregunta_resp.GetRelPreguntaOpcMultsList().Where(x => x.IdPregunta == a.IdPregunta).ToList();
                foreach (var resp in relaciones)
                {
                    ResOpcMultsEntity respuestas = RespuestasOM.GetResOpcMultsList().Where(o => o.Id_ResOpcMult == resp.Id_ResOpcMult).Select(o => o).First();
                    Respuestas.Add(respuestas);
                }
                Pregunta.Pregunta = a;
                Pregunta.Respuestas = Respuestas;
                Lista_Preguntas.Add(Pregunta);

            }            
            recordFiltered = Lista_Preguntas.Count;
            return Lista_Preguntas.Skip(start).Take(length).ToList();
        }

        public class DataTableDataDetalle
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<Detalle_pregunta> data { get; set; }
        }


    }

}

