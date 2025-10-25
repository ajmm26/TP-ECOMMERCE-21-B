<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_ECOMMERCE_21_B.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <asp:MultiView ID="mvLoginRegistro" runat="server" ActiveViewIndex="0">

                   
                    <asp:View ID="vwLogin" runat="server">
                        <h2 class="text-center mb-4">Iniciar sesión</h2>
                        <div class="card p-4 shadow-sm">
                            <div class="mb-3">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" />
                            </div>
                            <div class="mb-3">
                                <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Contraseña" />
                            </div>
                            <div class="d-grid">
                                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-dark" OnClick="btnLogin_Click" />
                            </div>
                            <div class="mt-3 text-center">
                                ¿No tenés cuenta?
                                <asp:LinkButton ID="btnMostrarRegistro" runat="server" CssClass="link-primary" OnClick="btnMostrarRegistro_Click">Registrate acá</asp:LinkButton>
                            </div>
                            <div class="mt-3 text-center">
                                <asp:Label ID="lblErrorLogin" runat="server" ForeColor="Red" />
                            </div>
                        </div>
                    </asp:View>

                   
                    <asp:View ID="vwRegistro" runat="server">
                        <h2 class="text-center mb-4">Registrarse</h2>
                        <div class="card p-4 shadow-sm">
                            <div class="mb-3">
                                <asp:TextBox ID="txtNuevoEmail" runat="server" CssClass="form-control" Placeholder="Email" />
                            </div>
                            <div class="mb-3">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" />
                            </div>
                            <div class="mb-3">
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Placeholder="Apellido" />
                            </div>
                            <div class="mb-3">
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Direccion" />
                            </div>
                            <div class="mb-3">
                                <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" Placeholder="Localidad" />
                            </div>
                            <div class="mb-3">
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Telefono" />
                            </div>
                            <div class="mb-3">
                                <asp:TextBox ID="txtNuevaClave" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Contraseña" />
                            </div>
                            <div class="d-grid">
                                <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" CssClass="btn btn-success" OnClick="btnRegistro_Click" />
                            </div>
                            <div class="mt-3 text-center">
                                ¿Ya tenés cuenta?
                                <asp:LinkButton ID="btnMostrarLogin" runat="server" CssClass="link-primary" OnClick="btnMostrarLogin_Click">Volver al login</asp:LinkButton>
                            </div>
                            <div class="mt-3 text-center">
                                <asp:Label ID="lblErrorRegistro" runat="server" ForeColor="Red" />
                            </div>
                        </div>
                    </asp:View>

                </asp:MultiView>
            </div>
        </div>
    </main>
</asp:Content>


