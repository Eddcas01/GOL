using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using GLNO.Conexion;

namespace GLNO.Controllers
{
    public class ConsultasController
    {
        Conexiona conexiongeneral = new Conexiona();
        public void executesql(string sql)
        {

            using (SqlConnection sqlCon = new SqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sql, sqlCon);
                    SqlDataReader reader = command.ExecuteReader();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

            }


        }

        public void procedimientomostrar(string procedimiento, GridView dg)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedimiento;
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
            
                    da.Fill(dt);

                    dg.DataSource = dt;
                    dg.DataBind();

                    
                 

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

            }


        }

        public void procedimientoinsert(string procedimiento, string ultimo = "",TextBox t1 = null, TextBox t2 = null, TextBox t3 = null, TextBox t4 = null, TextBox t5 = null, string statement = "", GridView dg = null)
        {

            using (SqlConnection sqlCon = new SqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    if (statement != "Select" && statement != "Delete") {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = procedimiento;
                        cmd.Parameters.Add("@clienteid", SqlDbType.Int).Value = ultimo;
                        cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = t1.Text;
                        cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = t2.Text;
                        cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = t3.Text;
                        cmd.Parameters.Add("@DPI", SqlDbType.VarChar).Value = t4.Text;
                        cmd.Parameters.Add("@edad", SqlDbType.Int).Value = t5.Text;
                        cmd.Parameters.Add("@StatementType", SqlDbType.VarChar).Value = statement;
                        cmd.Connection = sqlCon;
                        sqlCon.Open();
                        cmd.ExecuteNonQuery(); }
                    if(statement == "Delete") {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = procedimiento;
                        cmd.Parameters.Add("@clienteid", SqlDbType.Int).Value = ultimo;
                        cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value ="f";
                        cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = "f";
                        cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = "f";
                        cmd.Parameters.Add("@DPI", SqlDbType.VarChar).Value = "f";
                        cmd.Parameters.Add("@edad", SqlDbType.Int).Value = "1";
                        cmd.Parameters.Add("@StatementType", SqlDbType.VarChar).Value = statement;
                        cmd.Connection = sqlCon;
                        sqlCon.Open();
                        cmd.ExecuteNonQuery();
                    }
              

                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

            }


        }

        public string obtenerultimo(string tabla, string campo)
        {
            String camporesultante = "";
            using (SqlConnection sqlCon = new SqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(" + campo + ")+1 FROM " + tabla + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
                    SqlCommand command = new SqlCommand(sql, sqlCon);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                    //Console.WriteLine("El resultado es: " + camporesultante);
                    if (String.IsNullOrEmpty(camporesultante))
                        camporesultante = "1";
                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }


        }

        public DataTable llenardgvfamilia(string colab, string lt)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {

                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand("SELECT `ColaboradorFamiliaID`,`ColaboradorFamiliaNombre`,`ColaboradorFamiliaOcupacion`,`ColaboradorFamiliaComentario`, DATE_FORMAT(ColaboradorFamiliaFecNacimient, '%Y-%m-%d') as ColaboradorFamiliaFecNacimient FROM `EP_ColaboradorFamilia` WHERE LoteID = '" + lt + "' AND `ColaboradorID`= '" + colab + "'", sqlCon);
                    SqlDataAdapter ds = new SqlDataAdapter();
                    ds.SelectCommand = command;
                    ds.Fill(dt);


                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }

                return dt;
            }
        }
        public void llenadocombo(string sql, DropDownList drp, string textfield, string valuecode, string valorcero)
        {
            using (SqlConnection sqlCon = new SqlConnection(conexiongeneral.cadenadeconexiongeneral()))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = sql;
                    SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "usuarios");
                    drp.DataSource = ds;
                    drp.DataTextField = textfield;
                    drp.DataValueField = valuecode;
                    drp.DataBind();
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[" + valorcero + "]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

    }
}