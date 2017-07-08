using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DOCENTES.WEB.Models;

namespace DOCENTES.WEB.ViewModel.DocentesViewModel
{
    public class ListDocenteViewModel
    {
        public List<Docente> ListDocente { get; set; }
        public string Filtro { get; set; }
        public ListDocenteViewModel()
        {
            db_DocentesEntities context = new db_DocentesEntities();
            ListDocente = context.Docente.Where(x => x.estado == "A").ToList();
        }
        public void fill()
        {
            db_DocentesEntities context = new db_DocentesEntities();
            if (!string.IsNullOrEmpty(Filtro)) ListDocente = context.Docente.Where(x => x.estado == "A" && x.nombres.ToUpper().Contains(Filtro.ToUpper())).ToList();
            else ListDocente = context.Docente.Where(x => x.estado == "A").ToList();
        }
    }
}