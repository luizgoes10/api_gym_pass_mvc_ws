using ApiGymPassMVC.Models;
using ApiGymPassMVC.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ApiGymPassMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "ImgLogo,NmEmpresa,AddrEndereco,TelTelefone,BoolGostei,VlrMinPreco,VlrMaxPreco,TxtSobre,TxtCortesia,TxtLocalizacao,IdLocalizacao")]Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                return Json(BackEnd.PostEmpresa(empresa), JsonRequestBehavior.AllowGet);
            }
            return Json("{Error:Houve um erro}", JsonRequestBehavior.AllowGet);
        }

        public ActionResult MakeBox()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeBox([Bind(Exclude = "IdBox")]Box box)
        {
            if (ModelState.IsValid)
            {
                BackEnd.PostBox(box);
                return View();
               // return RedirectToAction("MakeTime");
               // return Json(BackEnd.PostBox(box), JsonRequestBehavior.AllowGet);
            }
            return Json("{Error:Houve um erro}", JsonRequestBehavior.AllowGet);
        }

        public ActionResult MakeTime()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MakeTime([Bind(Exclude = "IdPeriodo")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                BackEnd.PostTime(periodo);
                // return Json(BackEnd.PostTime(periodo), JsonRequestBehavior.AllowGet);
                return View();
            }
            return Json("{Error:Houve um erro}", JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChangeTime()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangeTime(string nmBox)
        {
            var box = BackEnd.GetBoxByNm(nmBox);
            return View(box.Periodo);
        }
        public ActionResult ChangeTimeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var periodo = BackEnd.GetTimeById(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }
        [HttpPost]
        public ActionResult ChangeTimeEdit(Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                var p = BackEnd.PutTime(periodo);
                return Json(new object[] { "sucesso:", "alteração salva.", p }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public ActionResult DeleteTime(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (BackEnd.DeleteTime(id))
            {
                return Json(new object[] { "sucesso:", "período excluído.", true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new object[] { "erro:", "não foi possível realizar exclusão." }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChangeCompany()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangeCompany(string nmEmpresa)
        {
            var empresa = BackEnd.GetEmpresaByNm(nmEmpresa);
            return View(empresa.ToList());
        }

        public ActionResult ChangeCompanyEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empresa = BackEnd.GetEmpresaById(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }
        [HttpPost]
        public ActionResult ChangeCompanyEdit(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                var p = BackEnd.PutEmpresa(empresa);
                return Json(new object[] { "sucesso:", "alteração salva.", p }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
    }
}
