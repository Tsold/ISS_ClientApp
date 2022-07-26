<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Weather.aspx.cs" Inherits="ISS_App.Weather" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="container center">

        <h2 class="title">

            Weather

        </h2>
    </div>

    <div class="container borders">
        <div class="row">
            
            <div class="col center">

              
                 <asp:TextBox runat="server" ID="TbCity" CssClass="form-control-sm" placeholder="Unesite Grad" />
                   <asp:Label ID="LblInfo" runat="server" />

            </div>

            <div class="col">

              <asp:Button ID="Temp" Text="Temperatura" CssClass="btn btn-light" runat="server" ValidationGroup="AddGroup" OnClick="Temp_Click"/>

            </div>

        </div>
    </div>





</asp:Content>
