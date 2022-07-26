<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AlbumApi.aspx.cs"  Async="true" Inherits="ISS_App.AlbumApi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
            <div class="container center">

        <h2 class="title">

           RestAPi

        </h2>
    </div>


      <div class="container borders">
        <div class="row">
            
            <div class="col center">

              
                  <asp:TextBox runat="server" ID="TbAlbum" CssClass="form-control-sm" placeholder="Unesite ime Albuma" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                runat="server" ControlToValidate="TbAlbum"
                                ErrorMessage="Field cannot be empty" ForeColor="DarkRed" ValidationGroup="AddAlbum">
                            </asp:RequiredFieldValidator>
                 

            </div>

            <div class="col">
                     <asp:DropDownList
                            runat="server"
                            ID="DdlALbum"
                            CssClass="form-control-sm"
                            />
            
            </div>   
            <div class="col">

              <asp:Button ID="BtnAlbum" Text="AddAlbum" CssClass="btn btn-light" runat="server" ValidationGroup="AddAlbum" OnClick="BtnAlbum_Click" />

            </div>

                       <div class="col">

              <asp:Button ID="BtnDelete" Text="DeleteAlbum" CssClass="btn btn-light" runat="server"  OnClick="BtnDelete_Click"/>

            </div>

        </div>
    </div>


        
    <div class="container basketBorders borders">
        <div class="row basketMargins">


          <div class="col-sm">
                <div class="row">
                
                  
                    <div class="topText col-auto">
                        <asp:TextBox runat="server" ID="TbName" CssClass="smalli" placeholder="Unesite Ime" />
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                runat="server" ControlToValidate="TbName"
                                ErrorMessage="Field cannot be empty" ForeColor="DarkRed" ValidationGroup="AddGroup">
   
                            </asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="TbSurname" CssClass="smalli" placeholder="Unesite Prezime" />
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                runat="server" ControlToValidate="TbSurname"
                                ErrorMessage="Field cannot be empty" ForeColor="DarkRed" ValidationGroup="AddGroup">
   
                            </asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="UrlAddUser" CssClass="smalli" placeholder="Unesite Url Slike" />
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                runat="server" ControlToValidate="UrlAddUser"
                                ErrorMessage="Field cannot be empty" ForeColor="DarkRed" ValidationGroup="AddGroup">
   
                            </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>




        <div class="col-auto-sm horizontalCenter marginLeftBasket ">

        </div>


        <div class="col-auto-sm horizontalCenter ">

              <asp:Button ID="BtnInsertIntoALbum" Text="Insert" CssClass="basketP" runat="server" ValidationGroup="AddGroup" OnClick="BtnInsertIntoALbum_Click"/>
           
           </div>



        </div>
    </div>



    
      <div class="container borders">
        <div class="row">
            
            <div class="col center">

              
                 <asp:Button ID="BtnInsert" Text="Insert All from Database" CssClass="btn btn-light" runat="server" OnClick="BtnInsert_Click"/>
                  

            </div>

            <div class="col">

                 <asp:Button ID="BtnTrain" Text="Train Album" CssClass="btn btn-light" runat="server"  OnClick="BtnTrain_Click"/>
         

            </div>   
            <div class="col">

              <asp:Button ID="BtnView" Text="View Album" CssClass="btn btn-light" runat="server"  OnClick="BtnView_Click"/>

            </div>

        </div>
    </div>


          <div class="container borders">
        <div class="row">
            
            <div class="col center">

              
                <asp:TextBox runat="server" ID="TbUrl" CssClass="form-control-sm" placeholder="Unesite Validan Url" />
             
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                runat="server" ControlToValidate="TbUrl"
                                ErrorMessage="Field cannot be empty" ForeColor="DarkRed" ValidationGroup="Recog_Group">
   
                            </asp:RequiredFieldValidator>
                  

            </div>

            <div class="col">

                <asp:Button ID="BtnRecog" Text="Recognize Person" CssClass="btn btn-light" runat="server" ValidationGroup="Recog_Group" OnClick="BtnRecog_Click"/>

            </div>

        </div>
    </div>



       <div class="container borders ">
       
            
    
            <div class="col">

             <asp:Label ID="LblInfo" runat="server" />
                
            </div>


    </div>


</asp:Content>
