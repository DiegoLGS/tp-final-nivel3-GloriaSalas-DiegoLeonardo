<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="tienda_web.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img-fluid {
            max-height: 450px;
        }
    </style>
    <script>        
        function mostrarImagen(input) {
            if (input.files && input.files[0]) {
                const reader = new FileReader();
                reader.onload = function (e) {
                    document.getElementById('ContentPlaceHolder1_imgAvatar').src = e.target.result;
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-4">
        <div class="col-12 col-md-6">
            <div class="mb-3 text-center">
                <asp:Image ID="imgAvatar" ImageUrl="https://www.pngitem.com/pimgs/m/146-1468479_my-profile-icon-blank-profile-picture-circle-hd.png" 
                    runat="server" CssClass="img-fluid" />
            </div>           
            <div class="mb-3">
                <label for="txtImagen" class="form-label fw-semibold">Imagen de perfil:</label>
                <input runat="server" type="file" ID="txtImagen" class="form-control" onchange="mostrarImagen(this)" />
            </div>                                       
        </div>

        <div class="col-12 col-md-6">                   
            <div class="mb-3">
                <label for="txtNombre" class="form-label fw-semibold">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50" />
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label fw-semibold">Apellido:</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" MaxLength="50" />
            </div>                        
            <div class="mb-3">
                <label for="txtEmail" class="form-label fw-semibold">Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" MaxLength="100" />
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label fw-semibold">Password:</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" MaxLength="20" />
            </div>
        </div>
                
    </div>
                 
    <div class="col">
        <asp:Label runat="server" Text="" ID="lblAviso" CssClass="text-danger" />
    </div>

    <div class="col-12 text-center ps-2">            
        <asp:Button Text="Actualizar" ID="btnActualizar" CssClass="btn btn-primary m-4 btn-lg" OnClick="btnActualizar_Click" runat="server" />   
        <a href="Default.aspx" class="btn btn-outline-danger m-4 btn-lg">Cancelar</a>
    </div>
</asp:Content>
