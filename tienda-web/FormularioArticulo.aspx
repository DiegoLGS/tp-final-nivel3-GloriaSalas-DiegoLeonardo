<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="tienda_web.FormularioArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #ContentPlaceHolder1_txtDescripcion {
            resize: none;
        }

        .img-fluid {
            max-height: 450px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="row mt-4">
                <div class="col-12 col-md-6">
                    <div class="mb-3">
                        <label for="txtCodigo" class="form-label fw-semibold">Código</label>
                        <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" MaxLength="50" />
                    </div>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label fw-semibold">Nombre:</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50" />
                    </div>
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label fw-semibold">Descripción:</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" Rows="2" MaxLength="150" />
                    </div>                          
                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label fw-semibold">Marca:</label>
                        <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-labe fw-semibold">Categoria:</label>
                        <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>                
                    <div class="mb-3">
                        <label for="txtId" class="form-label fw-semibold">ID:</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" Text="-" />
                    </div>
                </div>
        
                <div class="col-12 col-md-6">
                    <div class="mb-3">
                        <label for="txtPrecio" class="form-label fw-semibold">Precio: </label>
                        <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                    </div>                      
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label fw-semibold">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" MaxLength="1000" />
                    </div>
                    <div class="mb-3 text-center">
                        <asp:Image onerror="this.src='https://www.mobismea.com/upload/iblock/2a0/2f5hleoupzrnz9o3b8elnbv82hxfh4ld/No%20Product%20Image%20Available.png'"
                            runat="server" ID="imgArticulo" CssClass="img-fluid" />                            
                    </div>           
                </div>
            </div>
                     
            <div class="col">
                <asp:Label runat="server" Text="" ID="lblAviso" CssClass="text-danger" />
            </div>

            <div class="col-12 text-center ps-2">            
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary m-4 btn-lg" OnClick="btnAceptar_Click" runat="server" />   
                <a href="AdministrarArticulos.aspx" class="btn btn-outline-danger m-4 btn-lg">Cancelar</a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

