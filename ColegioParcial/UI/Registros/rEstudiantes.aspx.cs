using AsiginaturaBLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ColegioParcial.UI.Registros
{
    public partial class rEstudiantes : System.Web.UI.Page
    {
        public Estudiantes estudiantes = null;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        private void Limpiar()
        {
            
            NombreTextBox.Text = "";
            apellidoTextBox.Text = "";
            FechaTextBox.Text = "";
            EmailTextBox.Text = "";
            //CargoDropDownList.Text = "Usuario";
            //FechaIngresoTextBox.Text = "";
        }

        private void LlenarCampos()
        {
            IDTextBox.Text = estudiantes.EstudianteId.ToString();
            NombreTextBox.Text = estudiantes.Nombre;
            apellidoTextBox.Text = estudiantes.Apellido;
            EmailTextBox.Text = estudiantes.Email;
            FechaTextBox.Text = estudiantes.FechaIngreso.GetDateTimeFormats()[80].ToString().Substring(0, 10);
  
        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                interruptor = false;
            }
            if (string.IsNullOrEmpty(apellidoTextBox.Text))
            {
                interruptor = false;
            }
            if (string.IsNullOrEmpty(FechaTextBox.Text))
            {
                interruptor = false;
            }
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                interruptor = false;
            }
       

            return interruptor;
        }
        private void LlenarCamposInstancia()
        {
            int id = 0;
            if (IDTextBox.Text != "")
            {
                id = Utilidades.TOINT(IDTextBox.Text);
            }
            estudiantes = new Estudiantes(id, NombreTextBox.Text, apellidoTextBox.Text, EmailTextBox.Text,  DateTime.Parse(FechaTextBox.Text));
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            LlenarCamposInstancia();
            if (EstudiantesBLL.Guardar(estudiantes))
            {
                IDTextBox.Text = estudiantes.EstudianteId.ToString();
                //MensajeGuardado.Text = "Gardo";
                Limpiar();




            }

        }
    }
}