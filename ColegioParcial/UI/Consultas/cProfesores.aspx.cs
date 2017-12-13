using BLL;
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
    public partial class cProfesores : System.Web.UI.Page
    {
        public static List<Profesores> Lista { get; set; }
        public Profesores profesores { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LlenarGriw()
        {
            ProfesoresConsulta.DataSource = Lista;
            ProfesoresConsulta.DataBind();
        }

        private void Filtrar()
        {
            if (FiltrarDropDownList.SelectedIndex == 0)
            {
                Lista = ProfesoresBLL.GetListAll();
            }
            else if (FiltrarDropDownList.SelectedIndex != 0)
            {
                if (FiltrarDropDownList.SelectedIndex == 2)
                {
                    Lista = ProfesoresBLL.GetList(p => p.Nombre == FiltrarTextBox.Text);
                }



                if (FiltrarDropDownList.SelectedIndex == 1)
                {
                    int id = Utilidades.TOINT(FiltrarTextBox.Text);
                    Lista = ProfesoresBLL.GetList(p => p.ProfesorId == id);
                }
            }
            LlenarGriw();

        }

        protected void ProfesoresConsulta_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void ProfesoresConsulta_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)ProfesoresConsulta.Rows[e.RowIndex];
            Label Label1 = (Label)gvRow.FindControl("ProfesorId");
            int id = Convert.ToInt32(Label1.Text.Trim());
            string Nombre = ((TextBox)gvRow.Cells[2].Controls[0]).Text;
            string Apellido = ((TextBox)gvRow.Cells[3].Controls[0]).Text;
            string Tanda = ((TextBox)gvRow.Cells[4].Controls[0]).Text;



            using (ColegioDb context = new ColegioDb())
            {
                var db = context.Profesore.Where(a => a.ProfesorId.Equals(id)).FirstOrDefault();
                if (db != null)
                {
                    db.Nombre = Nombre;
                    db.Tanda = Tanda;
                    db.Apellido = Apellido;

                }
                context.SaveChanges();
                ProfesoresConsulta.EditIndex = -1;
                LlenarGriw();
                Filtrar();

            }
        }

        protected void ProfesoresConsulta_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ProfesoresConsulta.EditIndex = e.NewEditIndex;
            LlenarGriw();
        }

        protected void ProfesoresConsulta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)ProfesoresConsulta.Rows[e.RowIndex];
            Label lblId = (Label)gvRow.FindControl("ProfesorId");
            int id = Convert.ToInt32(lblId.Text.Trim());

            using (ColegioDb Context = new ColegioDb())
            {
                var db = Context.Profesore.Where(a => a.ProfesorId.Equals(id)).FirstOrDefault();
                if (db != null)
                {
                    Context.Profesore.Remove(db);
                    Context.SaveChanges();
                    LlenarGriw();
                }
            }

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Filtrar();
        }
    }
}