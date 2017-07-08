using NUnit.Framework;
using DOCENTES.WEB.ViewModel.DocentesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOCENTES.WEB.ViewModel.DocentesViewModel.Tests
{
    [TestFixture()]
    public class ListDocenteViewModelTests
    {
        [Test()]
        public void Fill()
        {
            ListDocenteViewModel objViewModel = new ListDocenteViewModel();
            Assert.AreNotEqual(0, objViewModel.ListDocente.Count);
        }

        [Test()]
        public void FillBuscar()
        {
            ListDocenteViewModel objViewModel = new ListDocenteViewModel();
            objViewModel.Filtro = "agasgasdgsadgag";
            objViewModel.fill();
            Assert.AreEqual(0, objViewModel.ListDocente.Count);
        }

        [Test()]
        public void FillBuscarFlujoAlternativo()
        {
            ListDocenteViewModel objViewModel = new ListDocenteViewModel();
            objViewModel.Filtro = "rgaegeargaergearerg";
            objViewModel.fill();
            Assert.AreEqual(0, objViewModel.ListDocente.Count);
        }

        
    }
}