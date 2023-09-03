<%@ Page Title="Sign up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Bulk_Storage_Solutions.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1>Sign up for a new account</h1>
        <br />
        <div class="container">
            <div class="row">
                <div class="form-group">
                    <div class="col-md-4">
                        <asp:TextBox required="true" ID="UserName" runat="server" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Name"></asp:TextBox>
                        <p>&nbsp;</p>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <div class="col-md-4">
                        <asp:TextBox required="true" ID="UserSurname" runat="server" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Surname"></asp:TextBox>
                        <p>&nbsp;</p>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <div class="col-md-4">
                        <asp:TextBox required="true" ID="UserEmailSignUp" runat="server" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Email"></asp:TextBox>
                        <p>&nbsp;</p>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <div class="col-md-4">
                        <asp:TextBox required="true" ID="UserPasswordSignUp" runat="server" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Password"></asp:TextBox>
                        <p>&nbsp;</p>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <div class="col-md-4">
                        <asp:TextBox required="true" ID="PasswordConfirm" runat="server" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Confirm Password"></asp:TextBox>
                        <p>&nbsp;</p>
                        <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click" Text="Sign Up" class="btn btn-primary"/>
                        <br />
                        <br />
                         <a href="Login2.aspx" runat="server">Already have an account? Click here to login to your account.</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
