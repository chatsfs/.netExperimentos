using NUnit.Framework;

using DOCENTES.WEB.ViewModel.CursosViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DOCENTES.WEB.Models;

namespace DOCENTES.WEB.ViewModel.CursosViewModel.Tests
{
    [TestFixture()]

    public class AddEditCursoViewModelTests
    {
        [Test()]
        public void D_cargarDatos()
        {
            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            objViewModel.tieneValor = false;
            objViewModel.cargarDatos(null);
            Assert.False(objViewModel.tieneValor);
        }

        [Test()]
        public void B_CursoExiste()
        {
            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            Assert.True(objViewModel.CursoExiste("Programación I"));
        }

        [Test()]
        public void CursoExisteFlujoAlternativo()
        {
            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            Assert.False(objViewModel.CursoExiste("fgfdgregerg"));
        }

        [Test()]
        public void A_RegistrarCurso()
        {
            ListCursoViewModel a = new ListCursoViewModel();
            a.fill();
            int codigo = a.ListCurso[a.ListCurso.Count - 1].cursoID + 1;
            Curso objCurso = new Curso();

            objCurso.cursoID = codigo;
            objCurso.nombrecurso = "Test";
            objCurso.credito = 3;
            objCurso.estado = "A";

            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            objViewModel.RegistrarCurso(objCurso);
            Assert.True(!"0".Equals(objCurso.nombrecurso));
        }

        [Test()]
        public void C_ModificarCurso()
        {
            ListCursoViewModel a = new ListCursoViewModel();
            Curso objCurso = new Curso();
            a.fill();
            int codigo = a.ListCurso[a.ListCurso.Count - 1].cursoID;
            objCurso.cursoID = codigo;
            objCurso.nombrecurso = "TestChange";
            objCurso.credito = 5;

            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            objViewModel.ModificarCurso(objCurso);
            a.fill();
            Assert.True(a.ListCurso[a.ListCurso.Count - 1].nombrecurso.Equals("TestChange"));
        }

        [Test()]
        public void E_EliminarCurso()
        {
            ListCursoViewModel a = new ListCursoViewModel();
            a.fill();
            int codigo = a.ListCurso[a.ListCurso.Count - 1].cursoID;
            Curso objCurso = new Curso();
            objCurso.cursoID = codigo;
            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            objViewModel.EliminarCurso(objCurso.cursoID);
            Assert.True(true);
        }
    }
}
    

