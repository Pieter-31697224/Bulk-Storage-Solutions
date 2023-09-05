<%@ Page Title="Storage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Storage.aspx.cs" Inherits="Bulk_Storage_Solutions.Storage" %>

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
        
        <asp:Button ID="CreateStorageBtn" runat="server" Height="40px" OnClick="CreateStorageBtn_Click" Text="Add New" class="btn  btn-primary" />
        <br />
        <br />

        <asp:GridView ID="StorageGridView" runat="server" Height="211px" Width="1200px" CssClass="table table-striped table-responsive table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Storage_Desc" HeaderText="Description"/>
                <asp:BoundField DataField="Unit_Number" HeaderText="Unit Number"/>
                <asp:BoundField DataField="Status" HeaderText="Status"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="editLink" runat="server" Text="Edit" CssClass="btn btn-primary" CommandArgument='<%# Eval("Storage_Id") %>' OnClick="EditStorageBtn_Click"></asp:LinkButton>
                        <asp:LinkButton ID="deleteLink" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%# Eval("Storage_Id") %>' OnClick="PopupDeleteStorageBtn_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </div>

    <div class="container">
        <div class="modal fade" id="createStorageModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Create New Storage</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <label>Storage Description</label>  
                        <asp:DropDownList runat="server" ID="StorageDropDownList" CssClass="form-control" placeholder="Storage Type" AutoPostBack="false"></asp:DropDownList>
                        <label>Storage Status</label>
                        <asp:DropDownList runat="server" ID="StorageStatusDropDownList" CssClass="form-control" placeholder="Status" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Height="40px" OnClick="AddStorageBtn_Click" Text="Save" class="btn  btn-primary"/>
                        <asp:Button ID="btnClose" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="modal fade" id="editStorageModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Edit Storage</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField runat="server" ID="EditStorageID" />
                        <label>Storage Description</label>
                        <asp:DropDownList runat="server" ID="EditStorageDropDownList" CssClass="form-control" placeholder="Storage Type" AutoPostBack="false"></asp:DropDownList>  
                        <label>Storage Status</label>
                        <asp:DropDownList runat="server" ID="EditStorageStatusDropDownList" CssClass="form-control" placeholder="Storage Type" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="saveEditBtn" runat="server" Height="40px" OnClick="SaveEditStorageBtn_Click" Text="Save" class="btn  btn-primary" />
                        <asp:Button ID="cancelBtn" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="modal fade" id="deleteStorageModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Delete Storage</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField runat="server" ID="DeleteStorageId" />
                        <label>Are you sure you want to delete this storage?</label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDeleteStorage" runat="server" Height="40px" OnClick="DeleteStorageBtn_Click" Text="Delete" class="btn  btn-danger" />
                        <asp:Button ID="btnCancelDelete" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="modal fade" id="errorPopupStorageModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Error</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField runat="server" ID="HiddenField1" />
                        <label>Storage could not be deleted. Storage is assigned in storage agreement</label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button2" runat="server" Height="40px" data-dismiss="modal" Text="Ok" class="btn  btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

