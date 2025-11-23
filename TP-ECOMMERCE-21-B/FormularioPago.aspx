<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioPago.aspx.cs" Inherits="TP_ECOMMERCE_21_B.FormularioPago" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalle productos</h1>
    <asp:Label runat="server" ID="labelMessage" />
    <asp:Repeater ID="RepeaterCarrito" runat="server">
        <ItemTemplate>
            <div class="div-contenedor-producto">
                <input type="hidden" name="hfId" class="hfId" value="" />
                <div class="div-img-carrito">
                    <img src="<%# Eval("Imagenes[0].Url") %>" style="max-width:100px; height:auto;" />

                </div>

                <div class="div-producto-info">
                    <p><%# Eval("Nombre") %></p>
                    <p><%# Eval("Descripcion") %></p>
                    <strong>
                        <label>Cantidad:</label>
                    </strong>
                    <p><%# Eval("cantidad")%></p>
                </div>
                
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <hr />  
    <asp:Label ID="lblTotal" runat="server" CssClass="total-pago" />
    <hr />
    <hr />

    <div class="mb-3">
        <label for="rbEnvio">Tipo de envío</label>

        <asp:RadioButtonList ID="rbEnvio" runat="server" CssClass="form-check" AutoPostBack="true" OnSelectedIndexChanged="rbEnvio_SelectedIndexChanged">
            <asp:ListItem Text="Retiro por el local" Value="Retiro" />
            <asp:ListItem Text="Coordinar entrega con el vendedor" Value="Coordinar" />
        </asp:RadioButtonList>


        <asp:Panel ID="panelDireccion" runat="server" Visible="false">
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Dirección del local" ReadOnly="true" Text="Av. Siempreviva 123" />
        </asp:Panel>


        <asp:Panel ID="panelTelefono" runat="server" Visible="false">
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Teléfono de contacto" />
        </asp:Panel>
    </div>
    <hr />
    <hr />


    <!----  <div class="mb-3">
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Placeholder="Apellido" />
    </div>
    <div class="mb-3">
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" TextMode="Email" />
    </div> --->



    <div class="mb-3">
        <label for="rbPago">Método de pago</label>
        <asp:RadioButtonList ID="rbPago" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbPago_SelectedIndexChanged">
            <asp:ListItem Text="Tarjeta de crédito" Value="tarjeta" />
            <asp:ListItem Text="Transferencia bancaria" Value="transferencia" />
            <asp:ListItem Text="MercadoPago" Value="mercadopago" />
        </asp:RadioButtonList>
    </div>

    <asp:Panel ID="panelTarjeta" runat="server" Visible="false">
        <asp:TextBox ID="txtNumeroTarjeta" runat="server" Placeholder="Número de tarjeta" CssClass="form-control" />
        <asp:TextBox ID="txtNombreTitular" runat="server" Placeholder="Nombre del titular" CssClass="form-control" />
        <asp:TextBox ID="txtVencimiento" runat="server" Placeholder="MM/AA" CssClass="form-control" />
        <asp:TextBox ID="txtCVV" runat="server" Placeholder="CVV" CssClass="form-control" />
    </asp:Panel>

    <asp:Panel ID="panelTransferencia" runat="server" Visible="false">
        <p>CBU: 0000003100012345678901</p>
        <p>Alias: SIGNOS.ECOMMERCE</p>
    </asp:Panel>

    <asp:Panel ID="panelMercadoPago" runat="server" Visible="false">
        <p>Serás redirigido a MercadoPago para completar el pago.</p>
    </asp:Panel>



    <div class="mb-3">
        <asp:Button ID="btnConfirmarPago" runat="server" CssClass="btn btn-primary" Text="Confirmar pago" OnClick="btnConfirmarPago_Click" />
    </div>
</asp:Content>

