using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ColegioParcial.UI.Registros
{
    public partial class rProfesores : System.Web.UI.Page
    {
        public Profesores profesores = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {

            NombreTextBox.Text = "";
            apellidoTextBox.Text = "";
            TandaTextBox.Text = "";


        }

        private void LlenarCampos()
        {
            IDTextBox.Text = profesores.ProfesorId.ToString();
            NombreTextBox.Text = profesores.Nombre;
            apellidoTextBox.Text = profesores.Apellido;
            TandaTextBox.Text = profesores.Tanda;


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

            if (string.IsNullOrEmpty(TandaTextBox.Text))
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
            profesores = new Profesores(id, NombreTextBox.Text, apellidoTextBox.Text, TandaTextBox.Text);
        }



        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            LlenarCamposInstancia();
            if (ProfesoresBLL.Guardar(profesores))
            {
                IDTextBox.Text = profesores.ProfesorId.ToString();
                //MensajeGuardado.Text = "Gardo";
                Limpiar();






            }
        }
    }
}