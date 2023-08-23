<%@ Page Title="Storage Type" MasterPageFile="~/Site.Master"  Language="C#" AutoEventWireup="true" CodeBehind="StorageType.aspx.cs" Inherits="Bulk_Storage_Solutions.Views.StorageType" %>

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
        
        <asp:Button ID="CreateStorageTypeBtn" runat="server" Height="40px" OnClick="CreateStorageTypeBtn_Click" Text="Add New" class="btn  btn-primary" />
        <br />
        <br />

        <asp:GridView ID="StorageTypeGridView" runat="server" Height="211px" Width="1200px" CssClass="table table-striped table-responsive table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Storage_Type_Desc" HeaderText="Storage Type Description"/>
                <asp:BoundField DataField="Storage_Qty_Available" HeaderText="Units Available"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="editLink" runat="server" Text="Edit" CssClass="btn btn-primary" CommandArgument='<%# Eval("Storage_Type_Id") %>' OnClick="PopupEditModalBtn_Click"></asp:LinkButton>
                        <asp:LinkButton ID="deleteLink" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%# Eval("Storage_Type_Id") %>' OnClick="PopupDeleteModalBtn_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </div>

    <div class="container">
        <div class="modal fade" id="createStorageTypeModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Create New Storage Type</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <label>Storage Type Description</label>
                        <asp:TextBox runat="server" ID="txtStorageTypeDesc" CssClass="form-control" placeholder="Description"/>  
                        <label>Storage Units Available</label>
                        <asp:TextBox runat="server" ID="txtStorageQtyAvailable" CssClass="form-control" placeholder="Units Available"/>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Height="40px" OnClick="AddStorageTypeBtn_Click" Text="Save" class="btn  btn-primary" />
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
                        <h4 class="modal-title">Edit Storage Type</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField runat="server" ID="EditStorageTypeID" />
                        <label>Storage Type Description</label>
                        <asp:TextBox runat="server" ID="txtEditDesc" CssClass="form-control"/>  
                        <label>Storage Units Available</label>
                        <asp:TextBox runat="server" ID="txtEditunitsAvailable" CssClass="form-control"/>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="saveEditBtn" runat="server" Height="40px" OnClick="SaveEditBtn_Click" Text="Save" class="btn  btn-primary" />
                        <asp:Button ID="cancelBtn" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="modal fade" id="deleteStorageTypeModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Delete Storage Type</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField runat="server" ID="DeleteStorageTypeId" />
                        <label>Are you sure you want to delete this contract?</label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDelete" runat="server" Height="40px" OnClick="DeleteBtn_Click" Text="Delete" class="btn  btn-danger" />
                        <asp:Button ID="btnCancelDelete" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
