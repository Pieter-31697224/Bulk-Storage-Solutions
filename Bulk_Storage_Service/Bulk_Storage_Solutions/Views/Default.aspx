<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bulk_Storage_Solutions._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        
        <br />
        <div class="container">
            <div class="row">
                <div class="form-group">
                    <div class="col-xs-3">
                        <asp:TextBox ID="SearchText" runat="server" Width="800px" CssClass="form-control" placeHolder="Search by Contract ID"></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <asp:Button ID="SearchButton" runat="server" Height="31px" OnClick="SearchButton_Click" Text="Search" class="btn  btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        
        <asp:Button ID="CreateContractBtn" runat="server" Height="40px" OnClick="CreateContractBtn_Click" Text="Add New" class="btn  btn-primary" />
        <br />
        <br />

        <asp:GridView ID="ContractsGridView" runat="server" Height="211px" Width="1223px" class="table">
        </asp:GridView>
        
    </div>

    <div class="container">
        <div class="modal fade" id="createContractModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Create New Contract</h4>
                        <button type="button"class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <label>Contract Description</label>
                        <asp:TextBox runat="server" ID="txtContractDesc" CssClass="form-control" placeholder="Description"/>  
                        <label>Contract Status</label>
                        <asp:TextBox runat="server" ID="txtContractStatus" CssClass="form-control" placeholder="Status"/>
                        <label>Contract Start Date</label>
                        <asp:TextBox ID="startDateCal" runat="server" CssClass="form-control" placeholder="Statr Date" type="date"></asp:TextBox>
                        <label>Contract End Date</label>
                        <asp:TextBox ID="endDateCal" runat="server" CssClass="form-control" placeholder="End Date" type="date"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Height="40px" OnClick="AddContractBtn_Click" Text="Save" class="btn  btn-primary" />
                        <asp:Button ID="btnClose" runat="server" Height="40px" data-dismiss="modal" Text="Cancel" class="btn  btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
