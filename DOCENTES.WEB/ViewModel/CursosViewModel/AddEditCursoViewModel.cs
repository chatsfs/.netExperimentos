using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DOCENTES.WEB.Models;

namespace DOCENTES.WEB.ViewModel.CursosViewModel
{
    public class AddEditCursoViewModel
    {
        public int? cursoID { get; set; }

        public Curso objectCurso { get; set; }
        public bool tieneValor { get; set; }
        public AddEditCursoViewModel()
        {
            objectCurso = new Curso();
        }

        public void cargarDatos(int? cursoid)
        {
            
            db_DocentesEntities context = new db_DocentesEntities();
            
            tieneValor = false;
            if (cursoid.HasValue)
            {
                Curso objCurso = context.Curso.FirstOrDefault(x => x.cursoID == cursoid);
                this.cursoID = cursoid;
                objectCurso.cursoID =objCurso.cursoID;
                objectCurso.nombrecurso = objCurso.nombrecurso;
                objectCurso.credito = objCurso.credito;
                tieneValor = true;
            }
        }
        public void RegistrarCurso(Curso _objCurso)
        {
            db_DocentesEntities context = new db_DocentesEntities();
            _objCurso.estado = "A";
            context.Curso.Add(_objCurso);
            context.SaveChanges();
        }
        public void ModificarCurso(Curso _objCurso)
        {
            db_DocentesEntities context = new db_DocentesEntities();
            Curso objCurso = context.Curso.FirstOrDefault(x => x.cursoID == _objCurso.cursoID);
            objCurso.nombrecurso = _objCurso.nombrecurso;
            objCurso.credito= _objCurso.credito;
            context.SaveChanges();

        }
        public void EliminarCurso(int CursoId)
        {
            db_DocentesEntities context = new db_DocentesEntities();
            Curso objCurso = context.Curso.FirstOrDefault(x => x.cursoID == CursoId);
            objCurso.estado = "I";
            context.SaveChanges();
        }
        public bool CursoExiste(string _nombrecurso)
        {
            db_DocentesEntities context = new db_DocentesEntities();
            Curso objProducto = context.Curso.FirstOrDefault(x => x.nombrecurso == _nombrecurso);
            if (objProducto != null) return true;
            return false;
        }
    }
}