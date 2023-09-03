<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="Bulk_Storage_Solutions.Login2" %>


   <authentication mode="Forms">
       <forms DefaultURL="Default.aspx" CargoURL="Cargo.aspx" ClientURL="Client.aspx" ClientStorageAgreementURL="ClientStorageAgreement.aspx" ContractsURL="Contracts.aspx" ReportsURL="Reports.aspx" StorageURL="Storage.aspx" StorageType="StorageType.aspx" name=".ASPXFORMSAUTH" timeout="30" />
   </authentication>
   <authorization>
       <deny users="?"/> <!-- Deny unauthenticated users -->
   </authorization>

                  
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
            <div>
                <h1>Log into your account</h1>
                <br />
                <div class="container">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-4">
                                <asp:TextBox required="true" ID="UserEmail" runat="server" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Email"></asp:TextBox>
                                <p>&nbsp;</p>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="form-group">
                            <div class="col-md-4">
                                <asp:TextBox required="true" ID="UserPassword" runat="server" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Password"></asp:TextBox>
                                <p>&nbsp;</p>
                                <asp:Button ID="btnLogin2" runat="server" OnClick="btnLogin2_Click" Text="Login" class="btn btn-primary"/>
                                <br />
                                <br />
                                <a href="SignUp.aspx" runat="server">Don't have an account yet? Click here to sign up.</a> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>

</asp:Content>

