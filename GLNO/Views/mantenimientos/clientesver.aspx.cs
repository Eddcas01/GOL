using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GLNO.Controllers;

namespace GLNO.Views.mantenimientos
{
    public partial class clientesver : System.Web.UI.Page
    {
        ConsultasController cns = new ConsultasController();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenartbl();
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