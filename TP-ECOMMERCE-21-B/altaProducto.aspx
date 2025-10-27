<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="altaProducto.aspx.cs" Inherits="TP_ECOMMERCE_21_B.altaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Alta producto   </h1>
    <div class="mb-3">
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Placeholder="Codigo" />
    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
    </div>
    <div class="mb-3">
       <asp:DropDownList ID="ddlMarcas" runat="server" DataTextField="Nombre" DataValueField="Id" CssClass="form-control" />

    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Descripcion" />
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
        <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-control" Placeholder="Stock Minimo" />
    </div>
    <div>   
         <asp:CheckBox ID="CheckBoxEstado" runat="server" Text="&nbsp;&nbsp;Activo" />
    </div>
    <div>   
        <asp:Button ID="Aceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click" CssClass="btn btn-success" />
    </div>
   
    

</asp:Content>
