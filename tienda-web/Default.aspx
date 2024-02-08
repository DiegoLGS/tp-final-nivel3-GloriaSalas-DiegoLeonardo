<%@ Page Title="Home" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tienda_web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img {            
            height: 400px;
            object-fit: contain;
        }

        .card {
            max-height: 544px;
        }

        .favorito {
            position: absolute;
            right: 10px;
            top: 10px;
            font-size: 28px;
            background-color: transparent;
            border: none;
            transition: 0.3s;
        }

        .favorito:hover {
            color: aliceblue;
            transform: scale(1.2);
        }        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <h1 class="mt-3 mb-3">Tienda Web</h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="col-sm-12 col-md-6">
                <div class="mb-3">
                    <asp:Label Text="Buscar por nombre:" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <asp:CheckBox Text="*Filtro avanzado"
                        CssClass="" ID="chkAvanzado" runat="server"
                        AutoPostBack="true"
                        OnCheckedChanged="chkAvanzado_CheckedChanged" />
                </div>
            </div>

    <%if (this.chkAvanzado.Checked)
      {
    %>

            <div class="row">
                <div class ="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                        <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" >
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoria" />
                            <asp:ListItem Text="Precio" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class ="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" ID="lblFiltroAvanzado" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                    </div>
                </div>
                
                <div class="col-3 d-flex align-items-end">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" id="btnBuscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>

    <%}%>

            <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">         

                <asp:Repeater runat="server" ID="repArticulos" OnItemDataBound="repArticulos_ItemDataBound">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card text-center">

                         <%if(utilidades.UtilidadLogin.sesionActiva(Session["usuario"]) && !utilidades.UtilidadLogin.esAdmin(Session["usuario"]))
                           {
                         %>
                                <asp:Button runat="server" CssClass="favorito" ID="btnFavorito" CommandArgument='<%# Eval("Id") %>' CommandName="ArticuloId" OnClick="btnFavorito_Click" />
                         <%}%>

                                <img src="<%#Eval("ImagenUrl") %>" onerror="this.src='https://www.mobismea.com/upload/iblock/2a0/2f5hleoupzrnz9o3b8elnbv82hxfh4ld/No%20Product%20Image%20Available.png'" class="img" alt="<%#Eval("Nombre") %> " />
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text text-decoration-underline fw-semibold">$<%# utilidades.UtilidadPrecio.limitarDecimales(Eval("Precio")) %></p>
                                    <asp:Button  runat="server" Text="Comprar" CssClass="btn btn-primary" ID="btnComprar" />
                                    <asp:Button  runat="server" Text="Detalles" CssClass="btn btn-secondary" ID="btnDetalle" CommandArgument='<%# Eval("Id") %>' CommandName="ArticuloId" OnClick="btnDetalle_Click" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
