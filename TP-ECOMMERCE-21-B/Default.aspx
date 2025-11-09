<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_ECOMMERCE_21_B.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Signos.</h3>

        <div class="text-end mt-2 me-3">
            <asp:LinkButton ID="btnLogin" runat="server" CssClass="btn btn-outline-dark mb-3" PostBackUrl="Login.aspx">
              <i class="bi bi-person-circle"></i>
                
                <asp:Label ID="lblLoginTexto" runat="server" Text="Iniciar sesión" />
            </asp:LinkButton>
            

            <a href="carritoWithMaster.aspx" class="btn btn-outline-dark me-2 mb-3">
                <i class="bi bi-cart"></i>Carrito
            </a>

             <asp:Button ID="btnLogout" runat="server" Text="Cerrar sesión" CssClass="btn btn-outline-danger ms-2" OnClick="btnLogout_Click" />
        </div>

        <div>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="mb-2" Style="width: 500px;"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
        </div>


        <div class="mb-3 carousel slide carousel-fixed-height bg-dark" id="carouselExampleControlsNoTouching" data-bs-touch="false">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="https://img.joomcdn.net/5614e867d137a0dae93a61d2076d9bd638957a95_400_400.jpeg" style="background-color: black; display: block; margin: 0 auto; max-height: 300px; object-fit: contain;" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="https://img.joomcdn.net/5614e867d137a0dae93a61d2076d9bd638957a95_400_400.jpeg" style="background-color: black; display: block; margin: 0 auto; max-height: 300px; object-fit: contain;" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="https://img.joomcdn.net/5614e867d137a0dae93a61d2076d9bd638957a95_400_400.jpeg" style="background-color: black; display: block; margin: 0 auto; max-height: 300px; object-fit: contain;" alt="...">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControlsNoTouching" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControlsNoTouching" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>

        </div>











        <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            <asp:Repeater ID="RepeaterProducto" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <div id="carousel<%# Eval("Id") %>" class="carousel slide" data-bs-ride="carousel" aria-label="Imágenes del producto">
                                <div class="carousel-inner">
                                    <asp:Repeater ID="RepeaterImagenes" runat="server" DataSource='<%# Eval("Imagenes") %>'>
                                        <ItemTemplate>
                                            <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                                <img src='<%# Eval("Url") %>' class="d-block w-100 img-fluid" style="max-height: 300px; object-fit: cover;" alt="Imagen del producto" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Anterior</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Siguiente</span>
                                </button>
                            </div>

                            <div class="card-body">
                                <h5 class="card-Nombre"><%# Eval("Nombre") %></h5>
                                <p class="card-Descripcion"><%# Eval("Descripcion") %></p>
                                <p class="card-Precio"><%# string.Format("${0:N2}", Eval("PrecioVenta")) %></p>
                                <p class="card-StockActual">Stock disponible: <%# Eval("StockActual") %></p>

                                <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="btn btn-outline-secondary w-100 mb-2"
                                    CommandArgument='<%# Eval("Id") %>' CommandName="AgregarCarrito" OnCommand="btnCarrito_Command" />

                                <asp:Button ID="btnComprar" runat="server" Text="Comprar ahora" CssClass="btn btn-primary w-100"
                                    CommandArgument='<%# Eval("Id") %>' CommandName="ComprarAhora" OnCommand="btnComprar_Command" />

                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>





    </main>
</asp:Content>
