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
    public partial class rAsignaturas : System.Web.UI.Page
    {
        public Asignaturas asignaturas = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {

            NombreTextBox.Text = "";
            SesionTextBox.Text = "";

        }
        private void LlenarCampos()
        {
            IDTextBox.Text = asignaturas.AsignaturaId.ToString();
            NombreTextBox.Text = asignaturas.Nombre;
            SesionTextBox.Text = asignaturas.Seccion.ToString();


        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                interruptor = false;
            }
            if (string.IsNullOrEmpty(SesionTextBox.Text))
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
            asignaturas = new Asignaturas(id, NombreTextBox.Text, Utilidades.TOINT(SesionTextBox.Text));
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            LlenarCamposInstancia();
            if (AsignatusraBLL.Guardar(asignaturas))
            {
                IDTextBox.Text = asignaturas.AsignaturaId.ToString();
                //MensajeGuardado.Text = "Gardo";
                Limpiar();






            }
        }
    }
}