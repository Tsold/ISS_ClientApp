<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ISS_App.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container middle" data-aos="fade-up">

        <div class="row justify-content-center" data-aos="fade-up" data-aos-delay="150">
            <div class="col-xl-6 col-lg-8">
                <h1>
                    <a href="Default.aspx">
                        <img src="Assets/Img/Server2.png" class="Picture1" alt=""></a>  </h1>
            </div>
        </div>

        <div class="row mt-5 justify-content-center" data-aos="zoom-in" data-aos-delay="250">
            <div class="col-sm">
                <div class="icon-box">
                    <i class="fas fa-database"></i>
                        <h3><a href="XsdXml.aspx">XSD</a></h3>
                </div>
            </div>
            <div class="col-sm">
                <div class="icon-box">
                    <i class="fas fa-database"></i>
                    <h3><a href="RngXml.aspx">RNG</a></h3>
                </div>
            </div>
            <div class="col-sm">
                <div class="icon-box">
                    <i class="fas fa-database"></i>
                    <h3><a href="Soap.aspx">SOAP</a></h3>
                </div>
            </div>



            <div class="col-sm">
                <div class="icon-box">
                    <i class="fas fa-cloud"></i>
                    <h3><a href="Weather.aspx">Weather</a></h3>
                </div>
            </div>

            <div class="col-sm">
                <div class="icon-box">
                    <i class="fas fa-bed"></i>
                    
                       <h3><a href="AlbumApi.aspx">RestApi</a></h3>
                    
                </div>
            </div>



        </div>

       

    </div>
</asp:Content>
