<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestionUsuario.aspx.cs" Inherits="TP_ECOMMERCE_21_B.gestionUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title">Gestión de Usuarios</h2>
        <h3>Administrá los usuarios del sistema</h3>
        <p>Seleccioná un usuario para modificar, eliminar, dar de baja o alta.</p>

        <asp:GridView ID="GridViewUsuario" runat="server" AllowPaging="true" PageSize="10"
            CssClass="table table-bordered"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnSelectedIndexChanged="GridViewUsuario_SelectedIndexChanged"
            OnPageIndexChanging="GridViewUsuario_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Dni" HeaderText="DNI" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="CodigoPostal" HeaderText="Código Postal" />
                <asp:BoundField DataField="RolUsuario" HeaderText="Rol" />
                <asp:BoundField DataField="Estado" HeaderText="Activo" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnSeleccionar" runat="server" CommandName="Select" Text="Seleccionar" Visible='<%# MostrarBotonSeleccionar() %>'/>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-warning" />
        <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click" CssClass="btn btn-outline-secondary" />
        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" CssClass="btn btn-outline-success" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />

        <asp:Label ID="lblMensaje" runat="server" CssClass="text-success" />
    </main>

</asp:Content>
