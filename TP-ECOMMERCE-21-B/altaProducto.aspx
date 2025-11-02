<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="altaProducto.aspx.cs" Inherits="TP_ECOMMERCE_21_B.altaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>PRODUCTOS   </h1>
    <div class="row">
        <!-- Columna izquierda -->
        <div class="col-md-6">
            <div class="mb-3">
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Placeholder="Código" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
            </div>
            <div class="mb-3">
                <asp:DropDownList ID="ddlMarcas" runat="server" DataTextField="Nombre" DataValueField="Id" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Descripción" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtPrecioCompra" runat="server" CssClass="form-control" Placeholder="Precio Compra" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtPorcentajeGanancia" runat="server" CssClass="form-control" Placeholder="Porcentaje Ganancia" />
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


                <asp:Button ID="Aceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click" CssClass="btn btn-success" />
            </div>
        </div>

        <!-- Columna derecha -->
        <div class="col-md-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:TextBox ID="txtUrlImagen" runat="server" AutoPostBack="true" OnTextChanged="actualizarPreview" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtUrlImagen1" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="actualizarPreview" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtUrlImagen2" runat="server" CssClass="form-control"  AutoPostBack="true" OnTextChanged="actualizarPreview" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtUrlImagen3" runat="server" CssClass="form-control"  AutoPostBack="true" OnTextChanged="actualizarPreview" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtUrlImagen4" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="actualizarPreview" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtUrlImagen5" runat="server" CssClass="form-control"  AutoPostBack="true" OnTextChanged="actualizarPreview" />
                    </div>

                   
                    <div class="mb-3">
                        <asp:Image ID="imgPreview" runat="server" Width="200px" Height="200px" CssClass="img-thumbnail" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>






</asp:Content>
