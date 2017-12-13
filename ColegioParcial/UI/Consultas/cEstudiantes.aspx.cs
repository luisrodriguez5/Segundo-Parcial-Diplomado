using AsiginaturaBLL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ColegioParcial.UI.Consultas
{
    public partial class cEstudiantes : System.Web.UI.Page
    {
        public static List<Estudiantes> Lista { get; set; }
        public Estudiantes estudiantes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LlenarGriw();

            }

        }
        private void LlenarGriw()
        {
            EstudiantesConsulta.DataSource = Lista;
            EstudiantesConsulta.DataBind();
        }

        private void Filtrar()
        {
            if (FiltrarDropDownList.SelectedIndex == 0)
            {
                Lista = EstudiantesBLL.GetListAll();
            }
            else if (FiltrarDropDownList.SelectedIndex != 0)
            {
                if (FiltrarDropDownList.SelectedIndex == 2)
                {
                    Lista = EstudiantesBLL.GetList(p => p.Nombre == FiltrarTextBox.Text);
                }

                if (FiltrarDropDownList.SelectedIndex == 4)
                {
                    DateTime FechaDesde = Convert.ToDateTime(FechaDesdeTextBox.Text);
                    DateTime FechaHasta = Convert.ToDateTime(FechaHastaTextBox.Text);
                    Lista = EstudiantesBLL.GetList(p => p.FechaIngreso >= FechaDesde.Date && p.FechaIngreso <= FechaHasta.Date);
                }

                if (FiltrarDropDownList.SelectedIndex == 1)
                {
                    int id = Utilidades.TOINT(FiltrarTextBox.Text);
                    Lista = EstudiantesBLL.GetList(p => p.EstudianteId == id);
                }
            }
            LlenarGriw();

        }


        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Filtrar();

        }

        protected void EstudiantesConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void EstudiantesConsulta_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {


        }

        protected void EstudiantesConsulta_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EstudiantesConsulta.EditIndex = e.NewEditIndex;
            LlenarGriw();
        }

        protected void EstudiantesConsulta_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow gvRow = (GridViewRow)EstudiantesConsulta.Rows[e.RowIndex];
            Label lblId = (Label)gvRow.FindControl("EstudianteId");
            int id = Convert.ToInt32(lblId.Text.Trim());
            string Nombre = ((TextBox)gvRow.Cells[2].Controls[0]).Text;
            string Apellido = ((TextBox)gvRow.Cells[3].Controls[0]).Text;
            string Email = ((TextBox)gvRow.Cells[4].Controls[0]).Text;

            using (ColegioDb context = new ColegioDb())
            {
                var db = context.Estudiante.Where(a => a.EstudianteId.Equals(id)).FirstOrDefault();
                if (db != null)
                {
                    db.Nombre = Nombre;
                    db.Apellido = Apellido;
                    db.Email = Email;
                }
                context.SaveChanges();
                EstudiantesConsulta.EditIndex = -1;
                LlenarGriw();
           }
        }

        protected void EstudiantesConsulta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)EstudiantesConsulta.Rows[e.RowIndex];
            Label lblId = (Label)gvRow.FindControl("EstudianteId");
            int id = Convert.ToInt32(lblId.Text.Trim());

            using (ColegioDb Context = new ColegioDb())
            {
                var db = Context.Estudiante.Where(a => a.EstudianteId.Equals(id)).FirstOrDefault();
                if(db != null)
                {
                    Context.Estudiante.Remove(db);
                    Context.SaveChanges();
                    LlenarGriw();
                }
            }
        }
    }
}