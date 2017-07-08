using NUnit.Framework;
using DOCENTES.WEB.ViewModel.CursosViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOCENTES.WEB.ViewModel.CursosViewModel.Tests
{
    [TestFixture()]
    public class ListCursoViewModelTests
    {

        [Test()]
        public void Fill()
        {
            ListCursoViewModel objViewModel = new ListCursoViewModel();
            Assert.AreNotEqual(0, objViewModel.ListCurso.Count);
        }

        [Test()]
        public void FillBuscar()
        {
            ListCursoViewModel objViewModel = new ListCursoViewModel();
            objViewModel.Filtro = "999";
            objViewModel.fill();
            Assert.AreEqual(0, objViewModel.ListCurso.Count);
        }

        [Test()]
        public void FillBuscarFlujoAlternativo()
        {
            ListCursoViewModel objViewModel = new ListCursoViewModel();
            objViewModel.Filtro = "assa7fs89a7f";
            objViewModel.fill();
            Assert.AreEqual(0, objViewModel.ListCurso.Count);
        }

        
    }
}