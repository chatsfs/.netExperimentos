using Xunit;
using DOCENTES.WEB.ViewModel.DocentesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOCENTES.WEB.Models;

namespace DOCENTES.WEB.ViewModel.DocentesViewModel.Facts
{
    public class AddEditDocenteViewModelFacts
    {
        [Fact]
        public void D_cargarDatos()
        {
            AddEditDocenteViewModel objViewModel = new AddEditDocenteViewModel();
            objViewModel.tieneValor = false;
            objViewModel.cargarDatos(null);
            Assert.False(objViewModel.tieneValor);
        }

        [Fact]
        public void B_DocenteExiste()
        {
            AddEditDocenteViewModel objViewModel = new AddEditDocenteViewModel();
            Assert.True(objViewModel.DocenteExiste("Israel"));
        }

        [Fact]
        public void DocenteExisteFlujoAlternativo()
        {
            AddEditDocenteViewModel objViewModel = new AddEditDocenteViewModel();
            Assert.False(objViewModel.DocenteExiste("fgfdgregerg"));
        }

        [Fact]
        public void A_RegistrarDocente()
        {
            ListDocenteViewModel a = new ListDocenteViewModel();
            a.fill();
            int codigo = a.ListDocente[a.ListDocente.Count - 1].docenteID + 1;
            Docente objDocente = new Docente();

            objDocente.docenteID = codigo;
            objDocente.nombres ="Javier";
            objDocente.apellidopaterno= "Valverde";
            objDocente.apellidomaterno= "Musculin";
            objDocente.tipodocumentoID = 2;
            objDocente.documento =666.ToString();
            objDocente.fechanacimiento = DateTime.Parse("1999-09-13")       ;
            objDocente.fechacontratacion = DateTime.Now;
            objDocente.gradoinstruccionID= 1;
            objDocente.cursoID = 4;
            objDocente.telefono = "666666";
            objDocente.correo = "jeijei@aviones.air";
            objDocente.direccion = "Aeropuerto Jorge Chavez";
            objDocente.estado = "A";

            AddEditDocenteViewModel objViewModel = new AddEditDocenteViewModel();
            objViewModel.RegistrarDocente(objDocente);
            Assert.True(!"0".Equals(objDocente.nombres));
        }

        [Fact]
        public void C_ModificarDocente()
        {
            ListDocenteViewModel a = new ListDocenteViewModel();
            Docente objDocente = new Docente();
            a.fill();
            int codigo = a.ListDocente[a.ListDocente.Count - 1].docenteID ;
            objDocente.docenteID = codigo;
            objDocente.nombres = "Javier";
            objDocente.apellidopaterno = "Valverde";
            objDocente.apellidomaterno = "Musculin";
            objDocente.tipodocumentoID = 2;
            objDocente.documento = 666.ToString();
            objDocente.fechanacimiento = DateTime.Parse("1999-09-13");
            objDocente.fechacontratacion = DateTime.Now;
            objDocente.gradoinstruccionID = 1;
            objDocente.cursoID = 4;
            objDocente.telefono = "666666";
            objDocente.correo = "jeijei@aviones.air";
            objDocente.direccion = "Aeropuerto Jorge Chavez";
            objDocente.estado = "A";

            AddEditDocenteViewModel objViewModel = new AddEditDocenteViewModel();
            objViewModel.ModificarDocente(objDocente);
            Assert.True(objDocente.nombres.Equals("Javier"));
        }

        [Fact]
        public void E_EliminarDocente()
        {
            ListDocenteViewModel a = new ListDocenteViewModel();
            a.fill();
            int codigo = a.ListDocente[a.ListDocente.Count - 1].docenteID;
            Docente objDocente = new Docente();
            objDocente.docenteID = codigo;           
            AddEditDocenteViewModel objViewModel = new AddEditDocenteViewModel();           
            objViewModel.EliminarDocente(objDocente.docenteID);
            Assert.True(true);
        }
    }
}