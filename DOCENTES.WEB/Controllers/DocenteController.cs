using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DOCENTES.WEB.Models;
using DOCENTES.WEB.ViewModel.DocentesViewModel;

namespace DOCENTES.WEB.Controllers
{
    
    public class DocenteController : Controller
    {
        [Authorize]
        public ActionResult ListDocente()
        {
            ListDocenteViewModel objViewModel = new ListDocenteViewModel();
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult ListDocente(ListDocenteViewModel objViewModel)
        {
            objViewModel.fill();
            return View(objViewModel);
        }
        [Authorize]
        public ActionResult AddEditDocente(int? docenteid)
        {
            AddEditDocenteViewModel objViewModel = new AddEditDocenteViewModel();
            objViewModel.cargarDatos(docenteid);
            return View(objViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddEditDocente(AddEditDocenteViewModel objViewModel)
        {
            try
            {
                              
                if(objViewModel.tieneValor)
                {
                    objViewModel.objectDocente.docenteID = (int)objViewModel.docenteID;
                    objViewModel.ModificarDocente(objViewModel.objectDocente);
                }
                else
                {
                    objViewModel.RegistrarDocente(objViewModel.objectDocente);
                } 
              

                if (objViewModel.tieneValor)
                {
                    TempData["Mensaje"] = "Éxito! El docente se editó correctamente";
                }
                else
                {
                    TempData["Mensaje"] = "Éxito! El docente se agregó correctamente";
                }

                return RedirectToAction("ListDocente", "Docente");
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = "Error! " + e.Message.ToList();
                objViewModel.cargarDatos(objViewModel.docenteID);
                return View(objViewModel);
            }
        }

        [Authorize]
        public ActionResult DeleteDocente(int docenteid)
        {
            AddEditDocenteViewModel objViewModel = new AddEditDocenteViewModel();
            try
            {
                objViewModel.EliminarDocente(docenteid);
                TempData["Mensaje"] = "El docente se se eliminó correctamente";
                return RedirectToAction("ListDocente", "Docente");
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = "Error! " + e.Message.ToList();
                return RedirectToAction("ListDocente");
            }

        }
    }
}
