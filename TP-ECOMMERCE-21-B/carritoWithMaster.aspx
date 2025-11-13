 <%@ Import Namespace="dominio" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="carritoWithMaster.aspx.cs" Inherits="TP_ECOMMERCE_21_B.carritoWithMaster" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
<link href="<%= ResolveUrl("~/Content/carrito.css") %>" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnVolverCatalogo" runat="server" Text="Volver al catálogo" CssClass="btn btn-secondary" OnClick="btnVolverCatalogo_Click" />



    <asp:Label runat="server" ID="textcart"/>
    <% 
        List<Producto> products = (List<Producto>)Session["items"]; 
    %>

    <% if (products != null && products.Count == 0) { %>    
        <asp:Label runat="server" ID="Label1" Text="No tiene productos en el carrito"/>
    <% } else if (products != null && products.Count > 0) { %>
        <%int index = 0; %>
         <%foreach (Producto product in products) {%>
        <div class="div-contenedor-producto" id="<%=index%>">
            <input type="hidden" name="hfId" class="hfId" value="<%= index %>" />
            <div class="div-img-carrito">
                <img src="<%=product.Imagenes[0].Url %>">
            </div>

            <div class="div-producto-info">
                <p><%= product.Nombre %></p>
                <p><%= product.Descripcion %></p>
                <strong><label>Cantidad: </label></strong><p><%=product.cantidad.ToString()%></p>
            </div>
            <div class="div-button-eliminar">

 <asp:ImageButton 
                runat="server" 
                ID="btnDelete"
                ImageUrl="~/img/trash.jpg" 
         CommandName="EliminarProducto" 
     Cssclass="imagebtDelete"
     OnCommand="Click_btnDelete"
          />  
        
            </div>
        </div>
    <%index++; %>
    <%} %>
    <asp:Button runat="server" Cssclass="buttonAddCart" role="button" Text="Iniciar Compra"></asp:Button>
    <% } %>
    <script src="<%= ResolveUrl("~/Scripts/WebForms/carrito.js") %>"></script>
</asp:Content>