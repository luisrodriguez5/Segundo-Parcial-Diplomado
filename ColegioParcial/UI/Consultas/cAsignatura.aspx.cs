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
    public partial class cAsignatura : System.Web.UI.Page
    {
        public static List<Asignaturas> Lista { get; set; }
        public Asignaturas asignaturas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LlenarGriw();

            }

        }
        private void LlenarGriw()
        {
            AsignaturasConsulta.DataSource = Lista;
            AsignaturasConsulta.DataBind();
        }


        private void Filtrar()
        {
            if (FiltrarDropDownList.SelectedIndex == 0)
            {
                Lista = AsignatusraBLL.GetListAll();
            }
            else if (FiltrarDropDownList.SelectedIndex != 0)
            {
                if (FiltrarDropDownList.SelectedIndex == 2)
                {
                    Lista = AsignatusraBLL.GetList(p => p.Nombre == FiltrarTextBox.Text);
                }



                if (FiltrarDropDownList.SelectedIndex == 1)
                {
                    int id = Utilidades.TOINT(FiltrarTextBox.Text);
                    Lista = AsignatusraBLL.GetList(p => p.AsignaturaId == id);
                }
            }
            LlenarGriw();

        }


        protected void AsignaturasConsulta_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AsignaturasConsulta.EditIndex = e.NewEditIndex;
            LlenarGriw();
        }

        protected void AsignaturasConsulta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)AsignaturasConsulta.Rows[e.RowIndex];
            Label lblId = (Label)gvRow.FindControl("AsignaturaId");
            int id = Convert.ToInt32(lblId.Text.Trim());

            using (ColegioDb Context = new ColegioDb())
            {
                var db = Context.Asignatura.Where(a => a.AsignaturaId.Equals(id)).FirstOrDefault();
                if (db != null)
                {
                    Context.Asignatura.Remove(db);
                    Context.SaveChanges();
                    LlenarGriw();
                }
            }

        }

        protected void AsignaturasConsulta_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)AsignaturasConsulta.Rows[e.RowIndex];
            Label Label1 = (Label)gvRow.FindControl("AsignaturaId");
            int id = Convert.ToInt32(Label1.Text.Trim());
            string Nombre = ((TextBox)gvRow.Cells[2].Controls[0]).Text;
            string Seccion = ((TextBox)gvRow.Cells[3].Controls[0]).Text;


            using (ColegioDb context = new ColegioDb())
            {
                var db = context.Asignatura.Where(a => a.AsignaturaId.Equals(id)).FirstOrDefault();
                if (db != null)
                {
                    db.Nombre = Nombre;
                    db.Seccion = Utilidades.TOINT(Seccion);

                }
                context.SaveChanges();
                AsignaturasConsulta.EditIndex = -1;
                LlenarGriw();
                Filtrar();

            }
           
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        protected void AsignaturasConsulta_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            AsignaturasConsulta.EditIndex = -1;
            LlenarGriw();
        }

        protected void AsignaturasConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}