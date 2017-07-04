using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DOCENTES.WEB.Models;
using System.ComponentModel.DataAnnotations;

namespace DOCENTES.WEB.ViewModel.DocentesViewModel
{
    public class AddEditDocenteViewModel
    {
        public int? docenteID { get; set; }

       
        public Docente objectDocente { get; set; }
        public List<TipoDocumento> ListDocumento { get; set; }

        public List<GradoInstruccion> ListGrado { get; set; }

        public List<Curso> ListCurso { get; set; }
        public bool tieneValor { get; set; }
        public AddEditDocenteViewModel()
        {
            objectDocente = new Docente();
        }
        
        public void cargarDatos(int? docenteid)
        {
            db_DocentesEntities context = new db_DocentesEntities();            
            this.ListDocumento = context.TipoDocumento.ToList();
            this.ListGrado = context.GradoInstruccion.ToList();
            this.ListCurso = context.Curso.ToList();
            tieneValor = false;
            if(docenteid.HasValue)
            {
                Docente objdocente = context.Docente.FirstOrDefault(x => x.docenteID == docenteid);
                docenteID = docenteid;
                objectDocente.docenteID = objdocente.docenteID;
                objectDocente.nombres = objdocente.nombres;
                objectDocente.apellidopaterno = objdocente.apellidopaterno;
                objectDocente.apellidomaterno = objdocente.apellidomaterno;
                objectDocente.tipodocumentoID = objdocente.TipoDocumento.tipodocumentoID;
                objectDocente.documento = objdocente.documento;
                objectDocente.fechanacimiento = objdocente.fechanacimiento;
                objectDocente.fechacontratacion = objdocente.fechacontratacion;
                objectDocente.gradoinstruccionID = objdocente.GradoInstruccion.gradoinstruccionID;
                objectDocente.telefono = objdocente.telefono;
                objectDocente.cursoID = objdocente.Curso.cursoID;
                objectDocente.correo = objdocente.correo;
                objectDocente.direccion = objdocente.direccion;
                tieneValor = true;
            }
        }
        public void RegistrarDocente(Docente _objDocente)
        {
            db_DocentesEntities context = new db_DocentesEntities();
            _objDocente.estado = "A";
            context.Docente.Add(_objDocente);
            context.SaveChanges();
        }
        public void ModificarDocente(Docente _objDocente)
        {
            db_DocentesEntities context = new db_DocentesEntities();
            Docente objDocente = context.Docente.FirstOrDefault(x => x.docenteID == _objDocente.docenteID);

            objDocente.nombres =_objDocente.nombres;
            objDocente.apellidopaterno =_objDocente.apellidopaterno;
            objDocente.apellidomaterno =_objDocente.apellidomaterno;
            objDocente.tipodocumentoID =_objDocente.tipodocumentoID;
            objDocente.documento =_objDocente.documento;
            objDocente.fechanacimiento = _objDocente.fechanacimiento;
            objDocente.fechacontratacion = _objDocente.fechacontratacion;
            objDocente.gradoinstruccionID =_objDocente.gradoinstruccionID;
            objDocente.cursoID =_objDocente.cursoID;
            objDocente.telefono =_objDocente.telefono;
            objDocente.correo =_objDocente.correo;
            objDocente.direccion =_objDocente.direccion;            
            context.SaveChanges();

        }
        public void EliminarDocente(int docenteId)
        {
            db_DocentesEntities context = new db_DocentesEntities();
            Docente objDocente = context.Docente.FirstOrDefault(x => x.docenteID ==docenteId);
            objDocente.estado = "I";
            context.SaveChanges();
        }
        public bool DocenteExiste(string _nombres)
        {
            db_DocentesEntities context = new db_DocentesEntities();
            Docente objProducto = context.Docente.FirstOrDefault(x => x.nombres == _nombres);
            if (objProducto != null) return true;
            return false;
        }
    }
}