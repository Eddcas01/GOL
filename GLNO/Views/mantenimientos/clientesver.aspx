<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientesver.aspx.cs" Inherits="GLNO.Views.mantenimientos.clientesver" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <div class="row" style="margin-top:10%">


            <div class="col-lg-12 ">
                <div class="table-responsive">
                  
                    <%-- Aqui gridview --%>
               <div class="row">
        
    <div class="col-md-12" style="overflow-x: auto;" >
      
          <asp:GridView ID="clientesdgv" CssClass="table table-striped" style="width: 100%;text-align:center" runat="server"  DataKeyNames="clienteid" HeaderStyle-BackColor="#404040" HeaderStyle-ForeColor="Black"
    AutoGenerateColumns="False" BorderStyle="Solid" ShowHeaderWhenEmpty="true"  AllowPaging="true" PageSize="10" OnPageIndexChanging="clientesdgv_PageIndexChanging" OnRowEditing="clientesdgv_RowEditing"
            
                OnRowCancelingEdit="clientesdgv_RowCancelingEdit"
                OnRowUpdating="clientesdgv_RowUpdating" OnRowDeleting="clientesdgv_RowDeleting">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="ID" Visible="false" >
                           <ItemTemplate>
                           <asp:Label ID="idcliente"  Width="150px" Text='<%# Eval("clienteid") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="No">
                           <ItemTemplate>
                           <asp:Label ID="nofam"  Width="30px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                       


                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="NOMBRES">
                           <ItemTemplate>
                           <asp:Label ID="lblnombre"  Width="100%" Text='<%# Eval("nombres") %>' runat="server" />
                        </ItemTemplate>
                                <EditItemTemplate>
                            <asp:TextBox ID="txtnom" TextMode="SingleLine" Text='<%# Eval("nombres") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="APELLIDOS">
                           <ItemTemplate>
                           <asp:Label ID="lblapell"  Width="100%" Text='<%# Eval("apellidos") %>' runat="server" />
                        </ItemTemplate>
                                <EditItemTemplate>
                            <asp:TextBox ID="txtapell" TextMode="SingleLine" Text='<%# Eval("apellidos") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="DIRECCION">
                           <ItemTemplate>
                           <asp:Label ID="lbldir"  Width="100%" Text='<%# Eval("direccion") %>' runat="server" />
                        </ItemTemplate>
                                <EditItemTemplate>
                            <asp:TextBox ID="txtdir" TextMode="SingleLine" Text='<%# Eval("direccion") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="DPI">
                           <ItemTemplate>
                           <asp:Label ID="lbldpi"  Width="100%" Text='<%# Eval("DPI") %>' runat="server" />
                        </ItemTemplate>
                                <EditItemTemplate>
                            <asp:TextBox ID="txtdpi" MaxLength="13" TextMode="Number" Text='<%# Eval("DPI") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño" HeaderText="EDAD">
                           <ItemTemplate>
                           <asp:Label ID="lbledad"  Width="100%" Text='<%# Eval("edad") %>' runat="server" />
                        </ItemTemplate>
                                <EditItemTemplate>
                            <asp:TextBox ID="txtedad" MaxLength="2" TextMode="Number" Text='<%# Eval("edad") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                              <asp:TemplateField HeaderText="Opciones">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../../Imagenes/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="../../Imagenes/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="../../Imagenes/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="../../Imagenes/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                   
                    </asp:TemplateField>

                   

                     </Columns>
        <HeaderStyle  Width="300px" ForeColor="White"></HeaderStyle>
        </asp:GridView>
          <br />
            <asp:Label ID="lblSuccessMessage1" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage1" Text="" runat="server" ForeColor="Red" />
        </div>    
    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
