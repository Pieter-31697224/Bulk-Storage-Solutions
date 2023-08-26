<%@ Page Title="ClientStorageAgreement" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientStorageAgreement.aspx.cs" Inherits="Bulk_Storage_Solutions.ClientStorageAgreement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        
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
        
        <asp:Button ID="CreateClientStorageAgreementBtn" runat="server" Height="40px" OnClick="CreateCSABtn_Click" Text="Add New" class="btn  btn-primary" />
        <br />
        <br />

        <asp:GridView ID="CSAGridView" runat="server" Height="211px" Width="1200px" CssClass="table table-striped table-responsive table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Client" HeaderText="Client"/>
                <asp:BoundField DataField="Cargo" HeaderText="Cargo"/>
                <asp:BoundField DataField="Storage" HeaderText="Storage"/>
                <asp:BoundField DataField="Contracts" HeaderText="Contract"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="deleteLink" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%# Eval("CSA_Id") %>' OnClick="PopupDeleteCSABtn_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </div>

    <div class="container">
        <div class="modal fade" id="createCSAModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Create New Client Storage Agreement</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <label>Client</label>
                        <asp:DropDownList runat="server" ID="clientDropDownList" CssClass="form-control" placeholder="Clients" AutoPostBack="false"></asp:DropDownList>  
                        <label>Cargo</label>
                        <asp:DropDownList runat="server" ID="cargoDropDownList" CssClass="form-control" placeholder="Cargo" AutoPostBack="false"></asp:DropDownList>
                        <label>Storage</label>
                        <asp:DropDownList runat="server" ID="storageDropDownList" CssClass="form-control" placeholder="Storage" AutoPostBack="false"></asp:DropDownList>
                        <label>Contract</label>
                        <asp:DropDownList runat="server" ID="contractDropDownList" CssClass="form-control" placeholder="Contracts" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Height="40px" OnClick="AddCSABtn_Click" Text="Save" class="btn  btn-primary"/>
                        <asp:Button ID="btnClose" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="modal fade" id="deleteCSAModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Delete Client Storage Agreement</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField runat="server" ID="DeleteCSAId" />
                        <label>Are you sure you want to delete this Client Storage Agreement?</label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDeleteContract" runat="server" Height="40px" OnClick="DeleteCSABtn_Click" Text="Delete" class="btn  btn-danger" />
                        <asp:Button ID="btnCancelDelete" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
