<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bulk_Storage_Solutions.Views.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Login</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-4">
                    <h2 class="mb-4">Login</h2>
                    <div class="form-group">
                        <label for="Username">Username or Email</label>
                        <asp:TextBox runat="server" ID="Username" CssClass="form-control" required="true" />
                    </div>
                    <div class="form-group">
                        <label for="Password">Password</label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" required="true" />
                    </div>
                    <asp:Button runat="server" ID="LoginButton" Text="Login" CssClass="btn btn-primary" OnClick="LoginButton_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
