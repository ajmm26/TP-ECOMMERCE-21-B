<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_ECOMMERCE_21_B.Default" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/default.css") %>" rel="stylesheet" />
</asp:Content>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Signos.</h3>

        <div class="div-buscadores">
    <div class="divs-contentBuscador" id="div-marca">
        <p>Marca:</p>
        <asp:DropDownList runat="server" CssClass="select-category" id="marcaSelect"/>
    </div>

    <div class="divs-contentBuscador" id="div-category">
        <p>Categoria:</p>
        <asp:DropDownList runat="server" CssClass="select-category" id="categoriaSelect"/>
    </div>

    <div class="divs-contentBuscador buscador-right">
        <asp:TextBox ID="txtFiltro" runat="server" CssClass="mb-2" Style="width: 300px;"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
    </div>
</div>


        <div class="mb-3 carousel slide carousel-fixed-height bg-dark"
            id="carouselExampleControlsNoTouching"
            data-bs-touch="false"
            data-bs-ride="carousel"
            data-bs-interval="2000">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcS-16UNOVHe5nIZWa7zLh-ex6terwMLo5nz58LivszmFGL-38kQENQi49HzUOnsRcieNGQ4gL-e0z0CKl7mDYIGtyVs5zivW1MUFfH5R4E"
                        style="background-color: black; display: block; margin: 0 auto; max-height: 300px; object-fit: contain;" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="https://www.megatone.net/images/Articulos/zoom2x/253/MKT0579LTA-1.jpg"
                        style="background-color: black; display: block; margin: 0 auto; max-height: 300px; object-fit: contain;" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="https://www.megatone.net/images/Articulos/zoom2x/200/03/MKT0114DIN_3.jpg"
                        style="background-color: black; display: block; margin: 0 auto; max-height: 300px; object-fit: contain;" alt="...">
                </div>
            </div>
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
