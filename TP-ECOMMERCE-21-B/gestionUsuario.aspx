<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestionUsuario.aspx.cs" Inherits="TP_ECOMMERCE_21_B.gestionUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewUsuario" CssClass="table table-bordered" runat="server"></asp:GridView>
    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" />
    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-primary" Text="Modificar" OnClick="btnModificar_Click" />
    <asp:Button ID="btnAlta" runat="server" CssClass="btn btn-outline-secondary" Text="Alta" OnClick="btnAlta_Click" />
    <asp:Button ID="btnBaja" runat="server" CssClass="btn btn-warning" Text="Baja" OnClick="btnBaja_Click" />
    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn" Text="Cancelar" OnClick="btnCancelar_Click" />

   

</asp:Content>
