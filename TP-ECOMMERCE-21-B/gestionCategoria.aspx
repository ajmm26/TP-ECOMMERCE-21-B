<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestionCategoria.aspx.cs" Inherits="TP_ECOMMERCE_21_B.gestionCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Administrá las categorias y marcas del sistema</h3>
    <p>Seleccioná una categoria o marca para modificar.</p>
    <div class="row">
        <div class="col-md-6">
            <h4>Categorías</h4>
            <asp:GridView ID="GridViewCategoria" AutoGenerateSelectButton="true" DataKeyNames="Id" CssClass="table table-bordered" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridViewCategoria_PageIndexChanging"></asp:GridView>
            <hr />
            <asp:TextBox ID="txtCategoria" runat="server" placeholder="Agregar Categoria"></asp:TextBox>
        </div>

        <div class="col-md-6">
            <h4>Marcas</h4>
            <asp:GridView ID="GridViewMarca" AutoGenerateSelectButton="true" DataKeyNames="Id" CssClass="table table-bordered" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridViewMarca_PageIndexChanging"></asp:GridView>
            <hr />
            <asp:TextBox ID="txtMarca" runat="server" placeholder="Agregar Marca"></asp:TextBox>
        </div>

    </div>

    <hr />

    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />
</asp:Content>
