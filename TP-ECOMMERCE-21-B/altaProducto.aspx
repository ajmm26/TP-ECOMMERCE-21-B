<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="altaProducto.aspx.cs" Inherits="TP_ECOMMERCE_21_B.altaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblTitulo" runat="server" CssClass="h2 text-center mb-4" />

    <div class="row">
        <!-- Columna izquierda -->
        <div class="col-md-6">
            <div class="mb-3">
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Placeholder="Código" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
            </div>

            <asp:UpdatePanel ID="updListas" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-control" />
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>

            <div class="mb-3">
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Descripción" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtPrecioCompra" runat="server" CssClass="form-control" Placeholder="Precio Compra" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtPorcentajeGanancia" runat="server" CssClass="form-control" ReadOnly="true" />

            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtPrecioVenta" runat="server" CssClass="form-control" Placeholder="Precio Venta" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtStockActual" runat="server" CssClass="form-control" Placeholder="Stock Actual" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-control" Placeholder="Stock Mínimo" />
            </div>
            <div class="mb-3">
                <asp:CheckBox ID="CheckBoxEstado" runat="server" Checked="true" Enabled="false" Text="&nbsp;&nbsp;Activo" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger" />


                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click" CssClass="btn btn-success" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
            </div>
        </div>

        <!-- Columna derecha -->
        <div class="col-md-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <asp:Label ID="lblErrorImagen" runat="server" CssClass="text-danger mb-2" />
                    </div>
                    <div class="mb-3 d-flex">


                        <asp:TextBox ID="txtUrlImagen" runat="server" AutoPostBack="false" CssClass="form-control me-2" placeholder="Url" />
                        <asp:Button ID="btnVistaPrevia" runat="server" Text="Vista previa" CssClass="btn btn-info me-2" OnClick="btnVistaPrevia_Click" />
                        <asp:Button ID="btnCargar" runat="server" Text="Cargar Imagen" CssClass="btn btn-success" OnClick="btnCargar_Click" />
                    </div>


                    <div class="mb-3">
                        <asp:Image ID="imgPreview" runat="server" Width="200px" Height="200px" CssClass="img-thumbnail" />
                        <asp:Repeater ID="rptImagenes" runat="server" OnItemCommand="rptImagenes_ItemCommand">
                            <ItemTemplate>
                                <div class="d-inline-block text-center me-2">
                                   <img src='<%# Eval("Url") %>' class="img-thumbnail" width="100" onerror="this.onerror=null;this.src='/img/placeholder.jpg';" />


                                    <asp:Button ID="btnModificarImagen" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Url") %>' Visible='<%# Session["modificarId"] != null %>' CssClass="btn btn-sm btn-danger mt-1" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>


                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
