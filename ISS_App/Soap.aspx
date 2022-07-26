<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Soap.aspx.cs" Inherits="ISS_App.Soap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


            <div class="container center">

        <h2 class="title">

           Soap

        </h2>
    </div>


      <div class="container borders">
        <div class="row">
            
            <div class="col center">

              
                 <asp:TextBox runat="server" ID="TbID" CssClass="form-control-sm" placeholder="Unesite ID" />
                   <asp:Label ID="LblInfo" runat="server" />

            </div>

            <div class="col">

              <asp:Button ID="SoapApi" Text="Find" CssClass="btn btn-light" runat="server" ValidationGroup="AddGroup" OnClick="SoapApi_Click"/>

            </div>   
            <div class="col">

              <asp:Button ID="IsValid" Text="Is Valid" CssClass="btn btn-light" runat="server" ValidationGroup="AddGroup" OnClick="IsValid_Click"/>

            </div>

        </div>
    </div>



</asp:Content>
