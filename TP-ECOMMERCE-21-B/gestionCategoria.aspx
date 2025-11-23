<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestionCategoria.aspx.cs" Inherits="TP_ECOMMERCE_21_B.gestionCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Administrá las categorias y marcas del sistema</h3>
    <p>Seleccioná una categoria o marca para modificar.</p>
    <div class="row">
        <div class="col-md-6">
            <h4>Categorías</h4>

            <asp:TextBox ID="txtFiltroCategoria" runat="server" CssClass="form-control mb-2" placeholder="Buscar categoría por nombre" />
            <asp:Button ID="btnFiltrarCategoria" runat="server" Text="Filtrar" CssClass="btn btn-sm btn-secondary mb-3"
                OnClick="btnFiltrarCategoria_Click" />

            <asp:GridView ID="GridViewCategoria" AutoGenerateColumns="false" AutoGenerateSelectButton="true" DataKeyNames="Id" CssClass="table table-bordered" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridViewCategoria_PageIndexChanging" OnSelectedIndexChanged="GridViewCategoria_SelectedIndexChanged" AutoPostBack="true">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                </Columns>
            </asp:GridView>
            <hr />
            <asp:TextBox ID="txtCategoria" runat="server" placeholder="Agregar Categoria"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCategoria" runat="server"
                ControlToValidate="txtCategoria"
                ErrorMessage="⚠️ Ingresá un nombre de categoría."
                Display="Dynamic" CssClass="text-danger" />
        </div>

        <div class="col-md-6">
            <h4>Marcas</h4>
            <asp:TextBox ID="txtFiltroMarca" runat="server" CssClass="form-control mb-2" placeholder="Buscar marca por nombre" />
            <asp:Button ID="btnFiltrarMarca" runat="server" Text="Filtrar" CssClass="btn btn-sm btn-secondary mb-3"
                OnClick="btnFiltrarMarca_Click" />

            <asp:GridView ID="GridViewMarca" AutoGenerateColumns="false" AutoGenerateSelectButton="true" DataKeyNames="Id" CssClass="table table-bordered" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridViewMarca_PageIndexChanging" OnSelectedIndexChanged="GridViewMarca_SelectedIndexChanged" AutoPostBack="true">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                </Columns>
            </asp:GridView>
            <hr />
            <asp:TextBox ID="txtMarca" runat="server" placeholder="Agregar Marca"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMarca" runat="server"
                ControlToValidate="txtMarca"
                ErrorMessage="⚠️ Ingresá un nombre de marca."
                Display="Dynamic" CssClass="text-danger" />
        </div>

    </div>

    <hr />
    <div class="d-flex flex-wrap gap-2 mt-3">
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" CausesValidation="true" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-warning" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />
    </div>


</asp:Content>
