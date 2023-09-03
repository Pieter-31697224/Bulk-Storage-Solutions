<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="Bulk_Storage_Solutions.Login1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1>WELCOME TO BULK STORAGE SOLUTIONS!</h1>
        <br />
        <div class="container">
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4">
                        <h4 class="text-uppercase mb-0">Already have an account?</h4>
                        <p>Login to get started!</p>
                        <p>&nbsp;</p>
                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" class="btn btn-primary"/>
                    </div>
                    <div class="col-md-4">
                        <h4 class=" text-uppercase mb-0">Don't have an account yet?</h4>
                        <p>Sign up so we can get you going!</p>
                        <p>&nbsp;</p>
                        <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click" Text="Sign Up" class="btn btn-primary"/>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>

                           
</asp:Content>
