using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DOCENTES.WEB.Models;
namespace DOCENTES.WEB.ViewModel.IndexViewModel
{
    public class IndexValueViewModel
    {
        public int nroCurso { get; set; }
        public int nroDocente { get; set; }
        public IndexValueViewModel()
        {
            db_DocentesEntities context = new db_DocentesEntities();
            nroCurso = context.Curso.Count();
            nroDocente = context.Docente.Count();
        }
    }
}