<%@ Page Title="Reports" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" Debug="true" CodeBehind="Reports.aspx.cs" Inherits="Bulk_Storage_Solutions.Views.Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
     <h2><%: Title %> </h2>

    <div>
        <div class="card" style="border: 1px solid #ddd; border-radius: 5px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); margin-bottom: 20px; background-color: #fff;">
            <div class="card-body" style="padding: 20px;">
                <h3 class="text-center">Top Ten Active Clients</h3>
            </div>
        </div>
    </div>

    <div>
        <div class="card" style="border: 1px solid #ddd; border-radius: 5px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); margin-bottom: 20px; background-color: #fff;">
            <div class="card-body" style="padding: 20px;">
                <div class="container">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-xs-2">  
                                <asp:DropDownList runat="server" ID="ChartTypeDropDownListForClientsChart" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                            </div>
                            <div class="col-xs-2">
                                <asp:Button ID="ClientApplyButton" runat="server" Height="31px" OnClick="ApplyClientChartButton_Click" Text="Apply" class="btn  btn-primary" />
                            </div>
                            <div class="col-xs-2">
                                <asp:TextBox ID="StartDateForClientChart" runat="server" CssClass="form-control" placeholder="Start Date" type="date"></asp:TextBox>
                            </div>
                            <div class="col-xs-2">
                                <asp:TextBox ID="EndDateForClientChart" runat="server" CssClass="form-control" placeholder="Start Date" type="date"></asp:TextBox>
                            </div>
                            <div class="col-xs-2">
                                <asp:Button ID="ClientReportSearch" runat="server" Height="31px" OnClick="SearchClientReportButton_Click" Text="Search" class="btn  btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Chart ID="TopTenClientsChart" runat="server" Width="1050px">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            </div>
        </div>
    </div>

    <div>
        <div class="card" style="border: 1px solid #ddd; border-radius: 5px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); margin-bottom: 20px; background-color: #fff;">
            <div class="card-body" style="padding: 20px;">
                <h3 class="text-center">Most Popular Storage Types</h3>
            </div>
        </div>
    </div>

    <div>
        <div class="card" style="border: 1px solid #ddd; border-radius: 5px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); margin-bottom: 20px; background-color: #fff;">
            <div class="card-body" style="padding: 20px;">
                <div class="container">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-xs-2">  
                                <asp:DropDownList runat="server" ID="StorageTypeChartTypeDropDownList" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                            </div>
                            <div class="col-xs-2">
                                <asp:Button ID="ApplyStorageTypeChart" runat="server" Height="31px" OnClick="ApplyStorageTypeChartButton_Click" Text="Apply" class="btn  btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Chart ID="StorageTypeChart" runat="server" Width="1050px">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            </div>
        </div>
    </div>

    <div>
        <div class="card" style="border: 1px solid #ddd; border-radius: 5px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); margin-bottom: 20px; background-color: #fff;">
            <div class="card-body" style="padding: 20px;">
                <h3 class="text-center">Storage Status Report</h3>
            </div>
        </div>
    </div>

    <div>
        <div class="card" style="border: 1px solid #ddd; border-radius: 5px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); margin-bottom: 20px; background-color: #fff;">
            <div class="card-body" style="padding: 20px;">
                <div class="container">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-xs-2">  
                                <asp:DropDownList runat="server" ID="StorageStatusDropDownList" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                            </div>
                            <div class="col-xs-2">
                                <asp:Button ID="ApplyStorageStatusChartType" runat="server" Height="31px" OnClick="ApplyStorageStatusChartButton_Click" Text="Apply" class="btn  btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Chart ID="StorageStatusChart" runat="server" Width="1050px">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            </div>
        </div>
    </div>
</asp:Content>
