using Xunit;
using DOCENTES.WEB.ViewModel.CursosViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOCENTES.WEB.ViewModel.CursosViewModel.Tests
{
    public class ListCursoViewModelTests
    {
       
        [Fact]
        public void Fill()
        {
            ListCursoViewModel objViewModel = new ListCursoViewModel();
            Assert.NotEqual(0, objViewModel.ListCurso.Count);
        }

        [Fact]
        public void FillBuscar()
        {
            ListCursoViewModel objViewModel = new ListCursoViewModel();
            objViewModel.Filtro = "999";
            objViewModel.fill();
            Assert.Equal(0, objViewModel.ListCurso.Count);
        }

        [Fact]
        public void FillBuscarFlujoAlternativo()
        {
            ListCursoViewModel objViewModel = new ListCursoViewModel();
            objViewModel.Filtro = "assa7fs89a7f";
            objViewModel.fill();
            Assert.Equal(0, objViewModel.ListCurso.Count);
        }
    }
}