<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioPago.aspx.cs" Inherits="TP_ECOMMERCE_21_B.FormularioPago" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalle productos</h1>

    
    <div class="mb-3">
        <label for="rbEnvio">Tipo de envío</label>
        <asp:RadioButtonList ID="rbEnvio" runat="server" CssClass="form-check">
            <asp:ListItem Text="Retiro por el local" Value="Retiro" />
            <asp:ListItem Text="Cordinar entrega con el vendedor" Value="Coordinar" />
        </asp:RadioButtonList>
    </div>

   
    <div class="mb-3">
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Placeholder="Apellido" />
    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" TextMode="Email" />
    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Teléfono" />
    </div>

   
    <div class="mb-3">
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Dirección de entrega" />
    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" Placeholder="Código Postal" />
    </div>

   
    <div class="mb-3">
        <label for="rbPago">Método de pago</label>
        <asp:RadioButtonList ID="rbPago" runat="server" CssClass="form-check">
            <asp:ListItem Text="Tarjeta de crédito" Value="tarjeta" />
            <asp:ListItem Text="Transferencia bancaria" Value="transferencia" />
            <asp:ListItem Text="Pago en efectivo" Value="efectivo" />
        </asp:RadioButtonList>
    </div>

    
    <div class="mb-3">
        <asp:Button ID="btnConfirmarPago" runat="server" CssClass="btn btn-primary" Text="Confirmar pago" OnClick="btnConfirmarPago_Click"  />
    </div>
</asp:Content>

