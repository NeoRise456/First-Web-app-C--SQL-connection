using intento4.Logica;
using intento4.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace intento4.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        EstudianteLogica datos = EstudianteLogica.Instancia;
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                }

                if (Request.QueryString["op"]!=null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo usuario";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de usuario";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar usuario";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar usuario";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }

            }
        }



        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Estudiante obj = new Estudiante()
            {
                Codigo = tbcodigo.Text,
                Nombre = tbNombre.Text
            };

            bool respuesta = EstudianteLogica.Instancia.Guardar(obj);
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {

        }
    }
}