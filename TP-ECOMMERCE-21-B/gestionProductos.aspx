<%@ Page Title="Alta Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestionProductos.aspx.cs" Inherits="TP_ECOMMERCE_21_B.gestionProductos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your application description page.</h3>
        <p>Use this area to provide additional information.</p>

        <asp:GridView ID="GridViewProductos" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridViewProductos_PageIndexChanging"
            CssClass="table table-bordered"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnSelectedIndexChanged="GridViewProductos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                <asp:TemplateField HeaderText="Id Marca">
                    <ItemTemplate>
                        <%# Eval("IdMarca.Id") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Id Categoria">
                    <ItemTemplate>
                        <%# Eval("IdCategoria.Id") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="PrecioCompra" HeaderText="Precio Compra" />
                <asp:BoundField DataField="PorcentajeGanancia" HeaderText="Ganancia (%)" />
                <asp:BoundField DataField="PrecioVenta" HeaderText="Precio Venta" />
                <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
                <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mínimo" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>


        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click" CssClass="btn btn-warning" />
        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" CssClass="btn btn-outline-success" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />


    </main>
</asp:Content>
