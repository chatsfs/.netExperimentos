using Xunit;
using DOCENTES.WEB.ViewModel.DocentesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOCENTES.WEB.ViewModel.DocentesViewModel.Tests
{
    public class ListDocenteViewModelTests
    {
        [Fact]
        public void Fill()
        {
            ListDocenteViewModel objViewModel = new ListDocenteViewModel();
            Assert.NotEqual(0, objViewModel.ListDocente.Count);
        }

        [Fact]
        public void FillBuscar()
        {
            ListDocenteViewModel objViewModel = new ListDocenteViewModel();
            objViewModel.Filtro = "agasgasdgsadgag";
            objViewModel.fill();
            Assert.Equal(0, objViewModel.ListDocente.Count);
        }

        [Fact]
        public void FillBuscarFlujoAlternativo()
        {
            ListDocenteViewModel objViewModel = new ListDocenteViewModel();
            objViewModel.Filtro = "rgaegeargaergearerg";
            objViewModel.fill();
            Assert.Equal(0, objViewModel.ListDocente.Count);
        }
    }
}