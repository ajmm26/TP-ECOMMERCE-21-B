<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TP_ECOMMERCE_21_B.Catalogo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Signos.</h3>

        <div class="text-end mt-2 me-3">
            <a href="Login.aspx" class="btn btn-outline-dark">
                <i class="bi bi-person-circle"></i>Iniciar sesión
            </a>
        </div>






        <div class="row row-cols-1 row-cols-md-3 g-4">
            <%
                foreach (dominio.Producto item in listaProducto)
                {
            %>
            <div class="col">
                <div class="card h-100">
                    <div id="carousel<%: item.Id %>" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <% 
                                for (int i = 0; i < item.Imagenes.Count; i++)
                                {
                                    var img = item.Imagenes[i];
                            %>
                            <div class="carousel-item <% if (i == 0)
                                { %>active<% } %>">
                                <img src="<%: img.Url %>" class="d-block w-100" alt="Imagen del producto">
                            </div>
                            <% } %>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%: item.Id %>" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Anterior</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carousel<%: item.Id %>" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Siguiente</span>
                        </button>
                    </div>


                    <div class="card-body">
                        <h5 class="card-Nombre"><%:item.Nombre %></h5>
                        <p class="card-descripcion"><%:item.Descripcion %></p>
                        <p class="card-precio"><%:item.PrecioVenta %></p>
                        <p class="card-stock"><%:item.StockActual %></p>
                        <a href='Comprar.aspx?id=<%: item.Id %>' class="btn btn-primary w-100 mt-2">Comprar</a>
                    </div>
                </div>
            </div>

            <% 
                }
            %>
        </div>



        <address>
            <strong>Soporte:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
            
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
        </address>
    </main>
</asp:Content>
