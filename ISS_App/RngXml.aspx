<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RngXml.aspx.cs" Inherits="ISS_App.RngXml" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container center">

        <h2 class="title">Xml Rng Validation

        </h2>
    </div>



    <div class="container basketBorders borders">
        <div class="row basketMargins">


            <div class="col-sm">
                <div class="row">


                    <div class="topText col-auto">
                        <asp:TextBox runat="server" ID="TbName" CssClass="smalli" placeholder="Unesite Ime" ValidationGroup="Add" />
                        <asp:TextBox runat="server" ID="TbSurname" CssClass="smalli" placeholder="Unesite Prezime" ValidationGroup="Add" />
                        <asp:TextBox runat="server" ID="TbGender" CssClass="smalli" placeholder="Unesite Spol" ValidationGroup="Add" />
                        <asp:TextBox runat="server" ID="TbUrl" CssClass="smalli" placeholder="Unesite Url Slike" ValidationGroup="Add" />
                        <asp:Label ID="LblInfo" runat="server" />
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1"
                            runat="server"
                            ValidationGroup="Add"
                            ErrorMessage="Name-No numbers"
                            ControlToValidate="TbName"
                            ValidationExpression="^[a-z]*$"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator2"
                            runat="server"
                            ValidationGroup="Add"
                            ErrorMessage="Surname-No numbers"
                            ControlToValidate="TbSurname"
                            ValidationExpression="^[a-z]*$"></asp:RegularExpressionValidator>
                          <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator3"
                            runat="server"
                            ValidationGroup="Add"
                            ErrorMessage="Url-Valid URL needed"
                            ControlToValidate="TbUrl"
                            ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)"></asp:RegularExpressionValidator>
                     
                    </div>
                </div>
            </div>




            <div class="col-auto-sm horizontalCenter marginLeftBasket ">
            </div>


            <div class="col-auto-sm horizontalCenter ">

                <asp:Button ID="BtnInsertXSD" Text="Send" CssClass="basketP" runat="server" ValidationGroup="Add" OnClick="BtnInsertXSD_Click" />

            </div>



        </div>
    </div>
</asp:Content>
