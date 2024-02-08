<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="tienda_web.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img {            
            height: 300px;            
            object-fit: contain;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-3 mb-3">Favoritos</h1>

    <div class="row d-flex justify-content-evenly">         

         <asp:Repeater runat="server" ID="repArticulos" >
             <ItemTemplate>
                 <div class="col-xs-6 col-md-4">
                     <div class="card text-center m-2">
                         <img src="<%#Eval("ImagenUrl") %>" onerror="this.src='https://www.mobismea.com/upload/iblock/2a0/2f5hleoupzrnz9o3b8elnbv82hxfh4ld/No%20Product%20Image%20Available.png'" class="img" alt="<%#Eval("Nombre") %> " />
                         <div class="card-body">
                             <h5 class="card-title"><%#Eval("Nombre") %></h5>
                             <p class="card-text text-decoration-underline fw-semibold">$<%# utilidades.UtilidadPrecio.limitarDecimales(Eval("Precio")) %></p>
                             <asp:Button  runat="server" Text="Comprar" CssClass="btn btn-primary" ID="btnComprar" />
                             <asp:Button  runat="server" Text="Ver detalles" CssClass="btn btn-secondary" ID="btnDetalle" CommandArgument='<%# Eval("Id") %>' CommandName="ArticuloId" OnClick="btnDetalle_Click" />
                         </div>
                     </div>
                 </div>
             </ItemTemplate>
         </asp:Repeater>

    </div>
    <hr />
    <div class="d-flex">
        <a href="#" onclick="history.go(-1);" class="btn btn-primary btn-lg ms-auto">Regresar</a>
    </div>

</asp:Content>
