using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DOCENTES.WEB.Models;
using DOCENTES.WEB.ViewModel.IndexViewModel;
using System.Web.Security;

namespace DOCENTES.WEB.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            IndexValueViewModel objViewModel = new IndexValueViewModel();
            return View(objViewModel);
        }

        public ActionResult Login()
        {
            LoginViewModel objViewModel = new LoginViewModel();
            return View(objViewModel);
        }
        
        [HttpPost]
        public ActionResult Login(LoginViewModel objViewModel)
        {
            try
            {
                db_DocentesEntities context = new db_DocentesEntities();
                Usuario objUsuario = context.Usuario.FirstOrDefault(x => x.codigo == objViewModel.codigo && x.password == objViewModel.password);

                if (objUsuario == null)
                {
                    TempData["MensajeLogin"] = "Error! usuario y contraseña incorrectas";
                    return View(objViewModel);
                }
                FormsAuthentication.SetAuthCookie(objUsuario.codigo, false);
                Session["objUsuario"] = objUsuario;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["MensajeLoginError"] = "Error! " + ex.Message.ToList();
                return View(objViewModel);
            }
        }

        [Authorize]
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            LoginViewModel objViewModel = new LoginViewModel();
            return RedirectToAction("Login", "Home");
        }
    }
}