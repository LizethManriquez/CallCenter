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
    /// Class                   : SoftvMVC.Controllers.PermisoController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : PermisoController
    /// File                    : PermisoController.cs
    /// Creation date           : 26/05/2016
    /// Creation time           : 09:27 a. m.
    ///</summary>
    public partial class PermisoController : BaseController, IDisposable
    {

        private SoftvService.PermisoClient proxy = null;

        private SoftvService.RoleClient proxyRole = null;

        private SoftvService.ModuleClient proxyModule = null;

        public PermisoController()
        {


            proxy = new SoftvService.PermisoClient();

            proxyRole = new SoftvService.RoleClient();

            proxyModule = new SoftvService.ModuleClient();


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

            if (proxyRole != null)
            {
                if (proxyRole.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyRole.Close();
                }
            }

            if (proxyModule != null)
            {
                if (proxyModule.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyModule.Close();
                }
            }

        }



        public ActionResult Index(int? page, int? pageSize)
        {

            List<PermisoEntity> permisos = proxy.GetPermisoList();
            ViewData["Permiso"] = permisos;


            ViewData["Roles"] = proxyRole.GetRoleList();

            ViewData["Module"] = proxyModule.GetModuleList();


            return View();

        }




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


        private List<PermisoEntity> FiltrarContenido(ref int recordFiltered, int start, int length)
        {

            List<PermisoEntity> lista = proxy.GetPermisoList();
            recordFiltered = lista.Count;
            int rango = start + length;
            return lista.Skip(start).Take(length).ToList();
        }


        public class DataTableData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<PermisoEntity> data { get; set; }
        }


























        public ActionResult Details(int id = 0)
        {
            PermisoEntity objQueja = proxy.GetPermiso(id);
            if (objQueja == null)
            {
                return HttpNotFound();
            }
            return PartialView(objQueja);
        }


        public ActionResult Create()
        {
            PermisosAccesoDeniedCreate("Permiso");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            return View();
        }








        [HttpPost]
        public ActionResult Create(PermisoEntity objPermiso)
        {
            if (ModelState.IsValid)
            {

                objPermiso.BaseRemoteIp = RemoteIp;
                objPermiso.BaseIdUser = LoggedUserName;
                int result = proxy.AddPermiso(objPermiso);
                if (result == -1)
                {

                    AssingMessageScript("El Permiso ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objPermiso);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta el Permiso en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objPermiso);
        }


        public ActionResult Edit(int id = 0)
        {
            PermisosAccesoDeniedEdit("Permiso");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            PermisoEntity objPermiso = proxy.GetPermiso(id);

            if (objPermiso == null)
            {
                return HttpNotFound();
            }
            return View(objPermiso);
        }


        [HttpPost]
        public ActionResult Edit(PermisoEntity objPermiso)
        {
            if (ModelState.IsValid)
            {
                objPermiso.BaseRemoteIp = RemoteIp;
                objPermiso.BaseIdUser = LoggedUserName;
                int result = proxy.UpdatePermiso(objPermiso);
                if (result == -1)
                {
                    PermisoEntity objQuejaOld = proxy.GetPermiso(objPermiso.IdRol);
                    //PermisoEntity objA = proxy.GetPermiso(objPermiso.IdModule);

                    AssingMessageScript("El Permiso ya existe en el sistema, .", "error", "Error", true);
                    CheckNotify();
                    return View(objPermiso);
                }
                if (result > 0)
                {
                    AssingMessageScript("El Permiso se modifico en el sistema.", "success", "Éxito", true);
                    CheckNotify();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(objPermiso);
        }



        public ActionResult QuickIndex(int? page, int? pageSize, int? IdRol, int? IdModule, bool? OptAdd, bool? OptSelect, bool? OptUpdate, bool? OptDelete)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<PermisoEntity> listResult = null;
            List<PermisoEntity> listPermiso = new List<PermisoEntity>();
            PermisoEntity objPermiso = new PermisoEntity();
            PermisoEntity objGetPermiso = new PermisoEntity();


            if ((IdRol != null))
            {
                objPermiso.IdRol = IdRol;
            }

            if ((IdModule != null))
            {
                objPermiso.IdModule = IdModule;
            }

            if ((OptAdd != null))
            {
                objPermiso.OptAdd = OptAdd;
            }

            if ((OptSelect != null))
            {
                objPermiso.OptSelect = OptSelect;
            }

            if ((OptUpdate != null ))
            {
                objPermiso.OptUpdate = OptUpdate;
            }

            if ((OptDelete != null ))
            {
                objPermiso.OptDelete = OptDelete;
            }

            
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetPermisoPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objPermiso));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetPermisoPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objPermiso));
            }
            listResult.ToList().ForEach(x => listPermiso.Add(x));

            var PermisoAsIPagedList = new StaticPagedList<PermisoEntity>(listPermiso, pageNumber, pSize, listResult.totalCount);
            if (PermisoAsIPagedList.Count > 0)
            {
                return PartialView(PermisoAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Delete(int id = 0)
        {
            int result = proxy.DeletePermiso(RemoteIp, LoggedUserName, id);
            if (result > 0)
            {
                var resultOk = new { tipomsj = "success", titulomsj = "Aviso", Success = "True", Message = "Registro de Permiso Eliminado." };
                return Json(resultOk, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resultNg = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "El Registro de Permiso No puede ser Eliminado validar dependencias." };
                return Json(resultNg, JsonRequestBehavior.AllowGet);
            }
        }

  

    }

}

