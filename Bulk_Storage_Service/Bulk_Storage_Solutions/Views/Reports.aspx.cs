using Bulk_Storage_Solutions.DAL.Features.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using static Bulk_Storage_Solutions.Enums.enums;

namespace Bulk_Storage_Solutions.Views
{
    public partial class Reports : System.Web.UI.Page
    {
        private readonly IReports _report;

        public Reports()
        {
            _report = Global.Resolve<IReports>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindClientChartData(1, string.Empty, string.Empty);
                    FillChartDropDownListForClientChart();

                    FillStorageTypeChartDropDownList();
                    BindStorageTypeChart(1);

                    FillStorageStatusChartDropDownList();
                    BindStorageStatusChart(1);
                }
            }
        }

        protected void ApplyClientChartButton_Click(object sender, EventArgs e)
        {
            BindStorageStatusChart(Convert.ToInt32(StorageStatusDropDownList.SelectedValue));
            BindClientChartData(Convert.ToInt32(ChartTypeDropDownListForClientsChart.SelectedValue), StartDateForClientChart.Text, EndDateForClientChart.Text);
            BindStorageTypeChart(Convert.ToInt32(StorageTypeChartTypeDropDownList.SelectedValue));
        }

        protected void SearchClientReportButton_Click(object sender, EventArgs e)
        {
            BindClientChartData(Convert.ToInt32(ChartTypeDropDownListForClientsChart.SelectedValue), StartDateForClientChart.Text, EndDateForClientChart.Text);
        }

        protected void ApplyStorageTypeChartButton_Click(object sender, EventArgs e)
        {
            BindStorageStatusChart(Convert.ToInt32(StorageStatusDropDownList.SelectedValue));
            BindStorageTypeChart(Convert.ToInt32(StorageTypeChartTypeDropDownList.SelectedValue));
            BindClientChartData(Convert.ToInt32(ChartTypeDropDownListForClientsChart.SelectedValue), StartDateForClientChart.Text, EndDateForClientChart.Text);
        }

        protected void ApplyStorageStatusChartButton_Click(object sender, EventArgs e)
        {
            BindClientChartData(Convert.ToInt32(ChartTypeDropDownListForClientsChart.SelectedValue), StartDateForClientChart.Text, EndDateForClientChart.Text);
            BindStorageTypeChart(Convert.ToInt32(StorageTypeChartTypeDropDownList.SelectedValue));
            BindStorageStatusChart(Convert.ToInt32(StorageStatusDropDownList.SelectedValue));
        }

        public void BindClientChartData(int chartTypeId, string startDate, string endDate)
        {
            try
            {
                var clientList = _report.GetClientsReport(startDate, endDate);

                foreach(var client in clientList)
                {
                    DataPoint datapoint = new DataPoint
                    {
                        AxisLabel = client.Client,
                        YValues = new double[] { client.AgreementCount }
                    };
                    TopTenClientsChart.Series["Series1"].Points.Add(datapoint);
                }

                switch(chartTypeId)
                {
                    case (int)ChartType.Pie:
                        TopTenClientsChart.Series["Series1"].ChartType = SeriesChartType.Pie;
                        break;
                    case (int)ChartType.Doughnut:
                        TopTenClientsChart.Series["Series1"].ChartType = SeriesChartType.Doughnut;
                        break;
                    case (int)ChartType.Column:
                        TopTenClientsChart.Series["Series1"].ChartType = SeriesChartType.Column;
                        break;
                    case (int)ChartType.Line:
                        TopTenClientsChart.Series["Series1"].ChartType = SeriesChartType.Line;
                        break;
                    case (int)ChartType.Bar:
                        TopTenClientsChart.Series["Series1"].ChartType = SeriesChartType.Bar;
                        break;
                    default:
                        TopTenClientsChart.Series["Series1"].ChartType = SeriesChartType.Pie;
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void BindStorageTypeChart(int chartTypeId)
        {
            try
            {
                var storageTypeList = _report.GetMostUsedStorageTypeReport();

                foreach (var storage in storageTypeList)
                {
                    DataPoint datapoint = new DataPoint
                    {
                        AxisLabel = storage.StorageDesc,
                        YValues = new double[] { storage.StorageypeCount }
                    };
                    StorageTypeChart.Series["Series1"].Points.Add(datapoint);
                }

                switch (chartTypeId)
                {
                    case (int)ChartType.Pie:
                        StorageTypeChart.Series["Series1"].ChartType = SeriesChartType.Pie;
                        break;
                    case (int)ChartType.Doughnut:
                        StorageTypeChart.Series["Series1"].ChartType = SeriesChartType.Doughnut;
                        break;
                    case (int)ChartType.Column:
                        StorageTypeChart.Series["Series1"].ChartType = SeriesChartType.Column;
                        break;
                    case (int)ChartType.Line:
                        StorageTypeChart.Series["Series1"].ChartType = SeriesChartType.Line;
                        break;
                    case (int)ChartType.Bar:
                        StorageTypeChart.Series["Series1"].ChartType = SeriesChartType.Bar;
                        break;
                    default:
                        StorageTypeChart.Series["Series1"].ChartType = SeriesChartType.Pie;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void BindStorageStatusChart(int chartTypeId)
        {
            try
            {
                var storageStatusList = _report.GetStorageStatusReport();

                foreach (var storage in storageStatusList)
                {
                    DataPoint datapoint = new DataPoint
                    {
                        AxisLabel = "Active",
                        YValues = new double[] { storage.ActiveCount}
                    };

                    DataPoint datapointNew = new DataPoint
                    {
                        AxisLabel = "Inactive",
                        YValues = new double[] { storage.InactiveCount }
                    };


                    StorageStatusChart.Series["Series1"].Points.Add(datapoint);
                    StorageStatusChart.Series["Series1"].Points.Add(datapointNew);
                }

                switch (chartTypeId)
                {
                    case (int)ChartType.Pie:
                        StorageStatusChart.Series["Series1"].ChartType = SeriesChartType.Pie;
                        break;
                    case (int)ChartType.Doughnut:
                        StorageStatusChart.Series["Series1"].ChartType = SeriesChartType.Doughnut;
                        break;
                    case (int)ChartType.Column:
                        StorageStatusChart.Series["Series1"].ChartType = SeriesChartType.Column;
                        break;
                    case (int)ChartType.Line:
                        StorageStatusChart.Series["Series1"].ChartType = SeriesChartType.Line;
                        break;
                    case (int)ChartType.Bar:
                        StorageStatusChart.Series["Series1"].ChartType = SeriesChartType.Bar;
                        break;
                    default:
                        StorageStatusChart.Series["Series1"].ChartType = SeriesChartType.Pie;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FillChartDropDownListForClientChart()
        {
            ChartType[] values = (ChartType[])Enum.GetValues(typeof(ChartType));

            foreach (ChartType value in values)
            {
                ChartTypeDropDownListForClientsChart.Items.Add(new ListItem(value.ToString(), ((int)value).ToString()));
            }
        }

        public void FillStorageTypeChartDropDownList()
        {
            ChartType[] values = (ChartType[])Enum.GetValues(typeof(ChartType));

            foreach (ChartType value in values)
            {
                StorageTypeChartTypeDropDownList.Items.Add(new ListItem(value.ToString(), ((int)value).ToString()));
            }
        }

        public void FillStorageStatusChartDropDownList()
        {
            ChartType[] values = (ChartType[])Enum.GetValues(typeof(ChartType));

            foreach (ChartType value in values)
            {
                StorageStatusDropDownList.Items.Add(new ListItem(value.ToString(), ((int)value).ToString()));
            }
        }
    }
}