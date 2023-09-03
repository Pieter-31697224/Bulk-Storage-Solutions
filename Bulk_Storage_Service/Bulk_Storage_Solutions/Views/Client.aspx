<%@ Page Title="Clients" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="Bulk_Storage_Solutions.Views.Client" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<br />
 
        <br />
        <div class="container">
            <div class="row">
                <div class="form-group">
                    <div class="col-xs-3">
                        <asp:TextBox ID="SearchText" runat="server" Width="800px" CssClass="form-control" placeHolder="Search"></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <asp:Button ID="SearchButton" runat="server" Height="31px" OnClick="SearchButton_Click" Text="Search" class="btn  btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        
        <asp:Button ID="CreateClientBtn" runat="server" Height="40px" OnClick="CreateClientBtn_Click" Text="Add New" class="btn  btn-primary" />
        <br />
        <br />

        <asp:GridView ID="ClientGridView" runat="server" Height="211px" Width="1200px" CssClass="table table-striped table-responsive table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Client_Id" HeaderText="Client ID"/>
                <asp:BoundField DataField="Client_Name" HeaderText="Client Name"/>
                <asp:BoundField DataField="Client_Surname" HeaderText="Client Surname"/>
                <asp:BoundField DataField="Client_Status" HeaderText="Client Status"/>
                <asp:BoundField DataField="Client_Email" HeaderText="Client Email"/>
                 <asp:BoundField DataField="Client_Contact_Number" HeaderText="Client Contact"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="editLink" runat="server" Text="Edit" CssClass="btn btn-primary" CommandArgument='<%# Eval("Client_Id") %>' OnClick="EditClientBtn_Click"></asp:LinkButton>
                        <asp:LinkButton ID="deleteLink" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%# Eval("Client_Id") %>' OnClick="PopupDeleteClientBtn_Click"></asp:LinkButton>
               
     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    

    <div class="container">
        <div class="modal fade" id="createClientModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Create New Contract</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">  
                        
                        <label>Client Name</label>
                        <asp:TextBox ID="ClientName" runat="server" CssClass="form-control" placeholder="Client Name"></asp:TextBox>
                        <label>Client Surname</label>
                        <asp:TextBox ID="ClientSurname" runat="server" CssClass="form-control" placeholder="Client Surname"></asp:TextBox>
                        <label>Client Status</label>
                        <asp:DropDownList runat="server" ID="ClientStatusDropDownList" CssClass="form-control" placeholder="Status" AutoPostBack="false"></asp:DropDownList>
                         <label>Client Email</label>
                        <asp:TextBox runat="server" ID="ClientEmail" CssClass="form-control" placeholder="Client Email"/>
                         <label>Client Contact</label>
                        <asp:TextBox runat="server" ID="ClientContact" CssClass="form-control" placeholder="Client Contact"/>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Height="40px" OnClick="AddClientBtn_Click" Text="Save" class="btn  btn-primary" />
                        <asp:Button ID="btnClose" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="modal fade" id="editClientModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Edit Client</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField runat="server" ID="EditClientID" />
                        <label>Client Status</label>
                        <asp:DropDownList runat="server" ID="EditClientStatusDropDownList" CssClass="form-control" placeholder="Status" AutoPostBack="false"></asp:DropDownList>
                        <label>Client Name</label>
                        <asp:TextBox ID="EditClientName" runat="server" CssClass="form-control"></asp:TextBox>
                        <label>Client Surname</label>
                        <asp:TextBox ID="EditClientSurname" runat="server" CssClass="form-control" ></asp:TextBox>
                         <label>Client Email</label>
                        <asp:TextBox ID="EditClientEmail" runat="server" CssClass="form-control" ></asp:TextBox>
                         <label>Client Contact</label>
                        <asp:TextBox ID="EditClientContact" runat="server" CssClass="form-control" ></asp:TextBox>


                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="saveEditBtn" runat="server" Height="40px" OnClick="SaveEditClientBtn_Click" Text="Save" class="btn  btn-primary" />
                        <asp:Button ID="cancelBtn" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="modal fade" id="deleteClientModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Delete Client</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField runat="server" ID="DeleteClientId" />
                        <label>Are you sure you want to delete this Client?</label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDeleteClient" runat="server" Height="40px" OnClick="DeleteClientBtn_Click" Text="Delete" class="btn  btn-danger" />
                        <asp:Button ID="btnCancelDelete" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
