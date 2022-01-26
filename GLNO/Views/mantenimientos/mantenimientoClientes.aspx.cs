using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GLNO.Controllers;


namespace GLNO.Views.mantenimientos
{
    public partial class mantenimientoClientes : System.Web.UI.Page
    {

        ConsultasController cns = new ConsultasController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                llenartbl(); }
        }

        protected void btnguardarcliente_Click(object sender, EventArgs e)
        {
            if (nombres.Text != "" && apellidos.Text != "" && direccion.Text != "" && edad.Text != "" && dpi.Text != "") {
                string ultimo = cns.obtenerultimo("Clientes", "clienteid");
                /*
                 string sql = "INSERT INTO Clientes(clienteid,nombres,apellidos,direccion,DPI,edad) VALUES( '"+ultimo+"' ,'"+ nombres.Text + "','"+ apellidos.Text + "','"+ direccion.Text + "','"+ dpi.Text  + "','"+ edad.Text + "');";
                 cns.executesql(sql);*/


                cns.procedimientoinsert("PAIcliente", ultimo,nombres, apellidos , direccion, dpi , edad, "Insert");
                nombres.Text = "";
                apellidos.Text = "";
                direccion.Text = "";
                edad.Text = "";
                dpi.Text = "";
                llenartbl();
            }

            else {

                String script = "alert('Ingrese todos los campos'); window.location.href= 'Ex_pendienteAg.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);

            }
        }

        public void llenartbl()
        {

            cns.procedimientomostrar("verclientes", clientesdgv);


        }


        protected void clientesdgv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            clientesdgv.EditIndex = -1;
            llenartbl();
        }

        protected void clientesdgv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
              

                cns.procedimientoinsert("PAIcliente", (clientesdgv.Rows[e.RowIndex].FindControl("idcliente") as Label).Text,
                    (clientesdgv.Rows[e.RowIndex].FindControl("txtapell") as TextBox), (clientesdgv.Rows[e.RowIndex].FindControl("txtnom") as TextBox), 
                    (clientesdgv.Rows[e.RowIndex].FindControl("txtdir") as TextBox),
                    (clientesdgv.Rows[e.RowIndex].FindControl("txtdpi") as TextBox),
                    (clientesdgv.Rows[e.RowIndex].FindControl("txtedad") as TextBox),
                    "Update");


                clientesdgv.EditIndex = -1;
                llenartbl();
                lblSuccessMessage1.Text = "Registro modificado exitosamente";
                lblErrorMessage1.Text = "";


            }
            catch (Exception ex)
            {
                lblSuccessMessage1.Text = "";
                lblErrorMessage1.Text = ex.Message;
            }

        }

        protected void clientesdgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
               

                cns.procedimientoinsert("PAIcliente", clientesdgv.DataKeys[e.RowIndex].Value.ToString(), null, null, null, null, null,"Delete");

                llenartbl();
                lblSuccessMessage1.Text = "Registro eliminado exitosamente";
                lblErrorMessage1.Text = "";

            }
            catch (Exception ex)
            {
                lblSuccessMessage1.Text = "";
                lblErrorMessage1.Text = ex.Message;
            }
        }

        protected void clientesdgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            clientesdgv.PageIndex = e.NewPageIndex;
            llenartbl();
        }

        protected void clientesdgv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            clientesdgv.EditIndex = e.NewEditIndex;
            llenartbl();
        }
    }
}