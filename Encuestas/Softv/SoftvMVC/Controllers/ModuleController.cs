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
    /// Class                   : SoftvMVC.Controllers.ModuleController.cs
    /// Generated by            : Class Generator (c) 2014
    /// Description             : ModuleController
    /// File                    : ModuleController.cs
    /// Creation date           : 19/09/2015
    /// Creation time           : 03:47 p. m.
    ///</summary>
    public partial class ModuleController : BaseController, IDisposable
    {
        private SoftvService.ModuleClient proxy = null;

        public ModuleController()
        {
            proxy = new SoftvService.ModuleClient();

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

        }

        public ActionResult Index(int? page, int? pageSize)
        {
            ViewData["Title"] = "Module";
            ViewData["Message"] = "Module";
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            int pageNumber = (page ?? 1);
            SoftvList<ModuleEntity> listResult = null;
            List<ModuleEntity> listModule = new List<ModuleEntity>();
            listResult = proxy.GetModulePagedListXml(pageNumber, pSize, SerializeTool.Serialize<ModuleEntity>(new ModuleEntity()));
            listResult.ToList().ForEach(x => listModule.Add(x));


            CheckNotify();
            ViewBag.CustomScriptsDefault = BuildScriptsDefault("Module");
            return View(new StaticPagedList<ModuleEntity>(listModule, pageNumber, pSize, listResult.totalCount));
        }

        public ActionResult Details(int id = 0)
        {
            ModuleEntity objModule = proxy.GetModule(id);
            if (objModule == null)
            {
                return HttpNotFound();
            }
            return PartialView(objModule);
        }

        public ActionResult Create()
        {
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            return View();
        }

        [HttpPost]
        public ActionResult Create(ModuleEntity objModule)
        {
            if (ModelState.IsValid)
            {

                objModule.BaseRemoteIp = RemoteIp;
                objModule.BaseIdUser = LoggedUserName;
                int result = proxy.AddModule(objModule);
                if (result == -1)
                {

                    AssingMessageScript("El Module ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objModule);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta el Module en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objModule);
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            ModuleEntity objModule = proxy.GetModule(id);

            if (objModule == null)
            {
                return HttpNotFound();
            }
            return View(objModule);
        }

        //
        // POST: /Module/Edit/5
        [HttpPost]
        public ActionResult Edit(ModuleEntity objModule)
        {
            if (ModelState.IsValid)
            {
                objModule.BaseRemoteIp = RemoteIp;
                objModule.BaseIdUser = LoggedUserName;
                int result = proxy.UpdateModule(objModule);
                if (result == -1)
                {
                    ModuleEntity objModuleOld = proxy.GetModule(objModule.IdModule);

                    AssingMessageScript("El Module ya existe en el sistema, .", "error", "Error", true);
                    CheckNotify();
                    return View(objModule);
                }
                if (result > 0)
                {
                    AssingMessageScript("El Module se modifico en el sistema.", "success", "Éxito", true);
                    CheckNotify();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(objModule);
        }

        public ActionResult QuickIndex(int? page, int? pageSize, String Description, String ModulePath, String ModuleView, int? ParentId, int? SortOrder, bool? OptAdd, bool? OptSelect, bool? OptUpdate, bool? OptDelete)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<ModuleEntity> listResult = null;
            List<ModuleEntity> listModule = new List<ModuleEntity>();
            ModuleEntity objModule = new ModuleEntity();
            ModuleEntity objGetModule = new ModuleEntity();


            if ((Description != null && Description.ToString() != ""))
            {
                objModule.Description = Description;
            }

            if ((ModulePath != null && ModulePath.ToString() != ""))
            {
                objModule.ModulePath = ModulePath;
            }

            if ((ModuleView != null && ModuleView.ToString() != ""))
            {
                objModule.ModuleView = ModuleView;
            }

            if ((ParentId != null))
            {
                objModule.ParentId = ParentId;
            }

            if ((SortOrder != null))
            {
                objModule.SortOrder = SortOrder;
            }

            if ((OptAdd != null))
            {
                objModule.OptAdd = OptAdd;
            }

            if ((OptSelect != null))
            {
                objModule.OptSelect = OptSelect;
            }

            if ((OptUpdate != null))
            {
                objModule.OptUpdate = OptUpdate;
            }

            if ((OptDelete != null))
            {
                objModule.OptDelete = OptDelete;
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetModulePagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objModule));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetModulePagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objModule));
            }
            listResult.ToList().ForEach(x => listModule.Add(x));

            var ModuleAsIPagedList = new StaticPagedList<ModuleEntity>(listModule, pageNumber, pSize, listResult.totalCount);
            if (ModuleAsIPagedList.Count > 0)
            {
                return PartialView(ModuleAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

    }

}

