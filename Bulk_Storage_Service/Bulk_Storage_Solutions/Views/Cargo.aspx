<%@ Page Title="Cargo" MasterPageFile="~/Site.Master"  Language="C#" AutoEventWireup="True" CodeBehind="Cargo.aspx.cs" Inherits="Bulk_Storage_Solutions.Cargo" %>

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
    
    <asp:Button ID="CreateCargoBtn" runat="server" Height="40px" OnClick="CreateCargoBtn_Click" Text="Add New" class="btn  btn-primary" />
    <br />
    <br />

    <asp:GridView ID="CargoGridView" runat="server" Height="211px" Width="1200px" CssClass="table table-striped table-responsive table-bordered" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Cargo_Desc" HeaderText="Description"/>
            <asp:BoundField DataField="Cargo_Qty" HeaderText="Quantity"/>
            <asp:BoundField DataField="Cargo_Weight" HeaderText="Weight"/>
            <asp:BoundField DataField="Cargo_Long" HeaderText="Longitude"/>
            <asp:BoundField DataField="Cargo_Lat" HeaderText="Latitude"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="editLink" runat="server" Text="Edit" CssClass="btn btn-primary" CommandArgument='<%# Eval("Cargo_Id") %>' OnClick="EditCargoBtn_Click"></asp:LinkButton>
                    <asp:LinkButton ID="deleteLink" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%# Eval("Cargo_Id") %>' OnClick="PopupDeleteCargoBtn_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
</div>

<div class="container">
    <div class="modal fade" id="createCargoModal" role="dialog">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Create New Cargo</h4>
                    <button type="button"class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <label>Cargo Description</label>
                    <asp:TextBox runat="server" ID="txtCargoDesc" CssClass="form-control" placeholder="Description"/>  
                    <label>Cargo Qty</label>
                    <asp:TextBox runat="server" ID="txtCargoQty" CssClass="form-control" placeholder="Quantity"/>
                    <label>Cargo Weight</label>
                    <asp:TextBox ID="txtCargoWeight" runat="server" CssClass="form-control" placeholder="Weight"/>
                    <label>Cargo Long</label>
                    <asp:TextBox ID="txtCargoLong" runat="server" CssClass="form-control" placeholder="Longitude"/>
                    <label>Cargo Lat</label>
                    <asp:TextBox ID="txtCargoLat" runat="server" CssClass="form-control" placeholder="Latitude"/>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSave" runat="server" Height="40px" OnClick="AddCargoBtn_Click" Text="Save" class="btn  btn-primary"/>
                    <asp:Button ID="btnClose" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                </div>
            </div>
        </div>
    </div>
</div>

<div class="container">
    <div class="modal fade" id="editCargoModal" role="dialog">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Edit Cargo</h4>
                    <button type="button"class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField runat="server" ID="EditCargoID" />
                    <label>Cargo Description</label>
                    <asp:TextBox runat="server" ID="txtEditDesc" CssClass="form-control" placeholder="Description"/>  
                    <label>Cargo Qty</label>
                    <asp:TextBox runat="server" ID="txtEditQty" CssClass="form-control" placeholder="Quantity"/>
                    <label>Cargo Weight</label>
                    <asp:TextBox ID="txtEditWeight" runat="server" CssClass="form-control" placeholder="Weight"/>
                    <label>Cargo Long</label>
                    <asp:TextBox ID="txtEditLong" runat="server" CssClass="form-control" placeholder="Long"/>
                    <label>Cargo Lat</label>
                    <asp:TextBox ID="txtEditLat" runat="server" CssClass="form-control" placeholder="Lat"/>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="saveEditBtn" runat="server" Height="40px" OnClick="SaveEditCargoBtn_Click" Text="Save" class="btn  btn-primary" />
                    <asp:Button ID="cancelBtn" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                </div>
            </div>
        </div>
    </div>
</div>

<div class="container">
    <div class="modal fade" id="deleteCargoModal" role="dialog">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Delete Cargo</h4>
                    <button type="button"class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField runat="server" ID="DeleteCargoId" />
                    <label>Are you sure you want to delete this Cargo?</label>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnDeleteCargo" runat="server" Height="40px" OnClick="DeleteCargoBtn_Click" Text="Delete" class="btn  btn-danger" />
                    <asp:Button ID="btnCancelDelete" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                </div>
            </div>
        </div>
    </div>
</div>

<div class="container">
        <div class="modal fade" id="errorPopupCargoModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Error</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField runat="server" ID="HiddenField1" />
                        <label>Cargo could not be deleted. Cargo is assigned in storage agreement</label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button2" runat="server" Height="40px" data-dismiss="modal" Text="Ok" class="btn  btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
