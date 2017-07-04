using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DOCENTES.WEB.Models;

namespace DOCENTES.WEB.ViewModel.CursosViewModel
{
    public class ListCursoViewModel
    {
        public List<Curso> ListCurso { get; set; }
        public string Filtro { get; set; }
        public ListCursoViewModel()
        {
            db_DocentesEntities context = new db_DocentesEntities();
            ListCurso = context.Curso.Where(x => x.estado == "A").ToList();
        }
        public void fill()
        {
            db_DocentesEntities context = new db_DocentesEntities();
            if (!string.IsNullOrEmpty(Filtro)) ListCurso = context.Curso.Where(x =>x.estado=="A" && x.nombrecurso.ToUpper().Contains(Filtro.ToUpper())).ToList();
        }
    }
}