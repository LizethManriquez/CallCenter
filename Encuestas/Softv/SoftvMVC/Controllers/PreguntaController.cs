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

        public PreguntaController()
        {


            proxy = new SoftvService.PreguntaClient();

            proxyTipoPreguntas = new SoftvService.TipoPreguntasClient();

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

        public ActionResult Details(int id = 0)
        {
            PreguntaEntity objPregunta = proxy.GetPregunta(id);
            if (objPregunta == null)
            {
                return HttpNotFound();
            }
            return PartialView(objPregunta);
        }

        public ActionResult Create()
        {
            PermisosAccesoDeniedCreate("Pregunta");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            ViewBag.VBTipoPreguntas = new SelectList(proxyTipoPreguntas.GetTipoPreguntasList().OrderBy(x => x.Descripcion.Trim()).ToList(), "IdTipoPregunta", "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult Create(PreguntaEntity objPregunta)
        {
            if (ModelState.IsValid)
            {

                objPregunta.BaseRemoteIp = RemoteIp;
                objPregunta.BaseIdUser = LoggedUserName;
                int result = proxy.AddPregunta(objPregunta);
                if (result == -1)
                {

                    ViewBag.VBTipoPreguntas = new SelectList(proxyTipoPreguntas.GetTipoPreguntasList().OrderBy(x => x.Descripcion.Trim()).ToList(), "IdTipoPregunta", "Descripcion", objPregunta.IdTipoPregunta);

                    AssingMessageScript("La Pregunta ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objPregunta);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta la Pregunta en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objPregunta);
        }

        public ActionResult Edit(int id = 0)
        {
            PermisosAccesoDeniedEdit("Pregunta");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            PreguntaEntity objPregunta = proxy.GetPregunta(id);

            ViewBag.VBTipoPreguntas = new SelectList(proxyTipoPreguntas.GetTipoPreguntasList().OrderBy(x => x.Descripcion.Trim()).ToList(), "IdTipoPregunta", "Descripcion");

            if (objPregunta == null)
            {
                return HttpNotFound();
            }
            return View(objPregunta);
        }

        //
        // POST: /Pregunta/Edit/5
        [HttpPost]
        public ActionResult Edit(PreguntaEntity objPregunta)
        {
            if (ModelState.IsValid)
            {
                objPregunta.BaseRemoteIp = RemoteIp;
                objPregunta.BaseIdUser = LoggedUserName;
                int result = proxy.UpdatePregunta(objPregunta);
                if (result == -1)
                {
                    PreguntaEntity objPreguntaOld = proxy.GetPregunta(objPregunta.IdPregunta);

                    ViewBag.VBTipoPreguntas = new SelectList(proxyTipoPreguntas.GetTipoPreguntasList().Where(x => x.IdTipoPregunta == objPreguntaOld.IdTipoPregunta).OrderBy(x => x.Descripcion.Trim()).ToList(), "IdTipoPregunta", "Descripcion", objPregunta.IdTipoPregunta);

                    AssingMessageScript("La Pregunta ya existe en el sistema, .", "error", "Error", true);
                    CheckNotify();
                    return View(objPregunta);
                }
                if (result > 0)
                {
                    AssingMessageScript("La Pregunta se modifico en el sistema.", "success", "Éxito", true);
                    CheckNotify();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(objPregunta);
        }

        public ActionResult QuickIndex(int? page, int? pageSize, String Pregunta, bool? Cerrada, bool? OpcMultiple, bool? Abierta, int? IdTipoPregunta)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<PreguntaEntity> listResult = null;
            List<PreguntaEntity> listPregunta = new List<PreguntaEntity>();
            PreguntaEntity objPregunta = new PreguntaEntity();
            PreguntaEntity objGetPregunta = new PreguntaEntity();


            if ((Pregunta != null && Pregunta.ToString() != ""))
            {
                objPregunta.Pregunta = Pregunta;
            }

            if ((Cerrada != null))
            {
                objPregunta.Cerrada = Cerrada;
            }

            if ((OpcMultiple != null))
            {
                objPregunta.OpcMultiple = OpcMultiple;
            }

            if ((Abierta != null))
            {
                objPregunta.Abierta = Abierta;
            }

            if ((IdTipoPregunta != null))
            {
                objPregunta.IdTipoPregunta = IdTipoPregunta;
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetPreguntaPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objPregunta));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetPreguntaPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objPregunta));
            }
            listResult.ToList().ForEach(x => listPregunta.Add(x));

            var PreguntaAsIPagedList = new StaticPagedList<PreguntaEntity>(listPregunta, pageNumber, pSize, listResult.totalCount);
            if (PreguntaAsIPagedList.Count > 0)
            {
                return PartialView(PreguntaAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
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


    }

}

