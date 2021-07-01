using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ClassSQL;

namespace WebPruebaAccesoSQL
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClassAccesoSQL db = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cn = System.Configuration.ConfigurationManager.ConnectionStrings["BDTIENDA"].ConnectionString;
            if (IsPostBack == false)
            {
                db = new ClassAccesoSQL(cn);
                Session["db"] = db;
            }
            else
            {
                db = (ClassAccesoSQL)Session["db"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection temp = null;
            string msg = "";
            temp = db.AbrirConexion(ref msg);


            if (temp!=null)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "1", "msgbox('Correcto', '" + msg + "', 'success')", true);
            }
            else
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "6", "msgbox('Error', `" + msg + "`, 'error')", true);
            }
            //TextBox1.Text = msg;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataReader caja = null;
            SqlConnection con = null;
            string msg = "";

            con = db.AbrirConexion(ref msg);
            //TextBox1.Text = msg;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "4", "msgbox(`Correcto`, `" + msg + "`, `success`)", true);
            caja = db.ConsultarReader("Select * from EMPLEADO", con, ref msg);
            if (caja!=null)
            {
                // la consulta es correcta
                Page.ClientScript.RegisterStartupScript(this.GetType(), "2", "msgbox(`Correcto`, `" + msg + "`, `success`)", true);
                ListBox1.Items.Clear();
                while (caja.Read())
                {
                    ListBox1.Items.Add(caja[0] + "  " + caja["NOMBRE"]);
                }

            }
            else
            {
                //TextBox1.Text = msg;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "332", "msgbox(`Incorrecto`, `" + msg + "`, `error`)", true);
            }
            con.Close();
            con.Dispose();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataSet contenedor = null;
            SqlConnection cnab = null;
            string m = "";

            cnab = db.AbrirConexion(ref m);
            if (cnab != null)
            {
                contenedor = db.ConsultaDS("select * from EMPLEADO", cnab, ref m);
                cnab.Close();
                cnab.Dispose();
                if (contenedor != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "set", "msgbox(`Correcto`, `" + m + "`, `success`)", true);
                    GridView1.DataSource = contenedor.Tables[0];
                    GridView1.DataBind();
                    Session["Tabla1"] = contenedor;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "errorSet", "msgbox(`Incorrecto`, `" + m + "`, `error`)", true);
                }
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataSet t = Session["Tabla1"] as DataSet;
            ListBox1.Items.Clear();
            ListBox1.Items.Add("Datos recuperados del dataTable 0");
            DataRow registro = null;
            for (int w = t.Tables[0].Rows.Count - 1; w >= 0; w--)
            {
                registro = t.Tables[0].Rows[w];
                ListBox1.Items.Add(registro[1] + " -- " + registro[0]);

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlParameter first = new SqlParameter("id", SqlDbType.Int);
            SqlParameter second = new SqlParameter("nombre", SqlDbType.NVarChar, 50);

            first.Value = TextBox2.Text;
            second.Value = TextBox3.Text;

            string sentencia = "INSERT INTO empleado VALUES(@id, @nombre)";
            SqlConnection conexion = null;
            string mensaje = "";
            Boolean resp = false;

            conexion = db.AbrirConexion(ref mensaje);
            //resp = db.ModificaBDInsegura(sentencia, conexion, ref mensaje);
            resp = db.InsertaEmpleadoConParametros(sentencia, conexion, ref mensaje, first, second);
            //resp = db.ModificiaParametrosUnPocoMasSegura(sentencia, conexion, ref mensaje, );

            if (resp)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "insertButton5", "msgbox(`Correcto`, `" + mensaje + "`, `success`)", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "errorButton5", "msgbox(`Error`, `" + mensaje + "`, `error`)", true);
            }


        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            SqlParameter[] parametros = new SqlParameter[4];

            parametros[0] = new SqlParameter("idprod", SqlDbType.Int);
            parametros[0].Value = txtIdProd.Text;
            parametros[0].Direction = ParameterDirection.Input;


            parametros[1] = new SqlParameter 
            { 
                ParameterName = "descri", 
                SqlDbType = SqlDbType.NVarChar, 
                Size = 50,
                Direction = ParameterDirection.Input, 
                Value = txtDescripcion.Text 
            };
            parametros[2] = new SqlParameter 
            { 
                ParameterName = "cate", 
                SqlDbType = SqlDbType.NVarChar, 
                Size = 15,
                Direction = ParameterDirection.Input, 
                Value = txtCategoria.Text 
            };

            parametros[3] = new SqlParameter 
            { 
                ParameterName = "precio", 
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input, 
                Value = txtPrecio.Text 
            };

            string sentencia = "INSERT INTO productos VALUES(@idprod, @descri, @cate, @precio)";
            SqlConnection conexion = null;
            string mensaje = "";
            Boolean resp = false;

            conexion = db.AbrirConexion(ref mensaje);
            resp = db.ModificiaParametrosUnPocoMasSegura(sentencia, conexion, ref mensaje, parametros);

            if (resp)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "insertButton5", "msgbox(`Correcto`, `" + mensaje + "`, `success`)", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "errorButton5", "msgbox(`Error`, `" + mensaje + "`, `error`)", true);
            }
        }
    }
}