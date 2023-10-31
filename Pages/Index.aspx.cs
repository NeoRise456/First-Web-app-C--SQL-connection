using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using intento4.Logica;
using System.Data.SQLite;

namespace intento4.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        //la conexion sql esta en estudiantes logica
        readonly SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        void CargarTabla()
        {


            SQLiteCommand cmd = new SQLiteCommand("select ID_usuario,Codigo,Nombre from Estudiantes", con);
            //cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandType = CommandType.Text;
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvusuarios.DataSource = dt;
            gvusuarios.DataBind();
            con.Close();


        }

        void Search_tabla(string comando) {
            SQLiteCommand cmd = new SQLiteCommand(comando, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvsearch.DataSource = dt;
            gvsearch.DataBind();
            con.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=C");
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;

            Response.Redirect("~/Pages/CRUD.aspx?id="+id+"&op=R");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;

            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;

            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=D");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string comando = "select ID_usuario,Codigo,Nombre from Estudiantes where Codigo = " + tbuscador.Text;
            Search_tabla(comando);
        }
    }
}