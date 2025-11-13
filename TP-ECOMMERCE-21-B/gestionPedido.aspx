<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gestionPedido.aspx.cs" Inherits="TP_ECOMMERCE_21_B.gestionPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewPedido" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
        OnRowCommand="GridViewPedido_RowCommand" OnRowDataBound="GridViewPedido_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID Pedido" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            <asp:BoundField DataField="IdUsuario" HeaderText="ID Usuario" />
            <asp:BoundField DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Estado" HeaderText="Estado Actual" />
            <asp:BoundField DataField="MetodoDePago" HeaderText="Método de Pago" />

            <asp:TemplateField HeaderText="Nuevo Estado">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlEstado" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnCambiarEstado" runat="server" Text="Cambiar"
                        CommandName="CambiarEstado" CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-primary btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>