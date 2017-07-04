using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DOCENTES.WEB.Models;
using DOCENTES.WEB.ViewModel.CursosViewModel;

namespace DOCENTES.WEB.Controllers
{
    
    public class CursoController : Controller
    {
        [Authorize]
        public ActionResult ListCurso()
        {
            ListCursoViewModel objViewModel = new ListCursoViewModel();
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult ListCurso(ListCursoViewModel objViewModel)
        {
            objViewModel.fill();
            return View(objViewModel);
        }
        [Authorize]
        public ActionResult AddEditCurso(int? cursoid)
        {
            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            objViewModel.cargarDatos(cursoid);
            return View(objViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddEditCurso(AddEditCursoViewModel objViewModel)
        {
            try
            {
               
                if (objViewModel.tieneValor)
                {
                    objViewModel.objectCurso.cursoID = (int)objViewModel.cursoID;
                    objViewModel.ModificarCurso(objViewModel.objectCurso);
                }
                else
                {
                    objViewModel.RegistrarCurso(objViewModel.objectCurso);
                }                

                if (objViewModel.tieneValor)
                {
                    TempData["Mensaje"] = "Éxito! El curso se editó correctamente";
                }
                else
                {
                    TempData["Mensaje"] = "Éxito! El curso se agregó correctamente";
                }

                return RedirectToAction("ListCurso");
            }
            catch(Exception e)
            {
                TempData["MensajeError"] = "Error! "+e.Message.ToList();
                return View(objViewModel);
            }
        }

        [Authorize]
        public ActionResult DeleteCurso(int cursoid)
        {
            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            try
            {
                objViewModel.EliminarCurso(cursoid);
                TempData["Mensaje"] = "El curso se se eliminó correctamente";

                return RedirectToAction("ListCurso");
            }
            catch(Exception e)
            {
                TempData["MensajeError"] = "Error! " + e.Message.ToList();
                return RedirectToAction("ListCurso");
            }
            
        }

    }
}
