using Bulk_Storage_Solutions.DAL.Features.Contracts;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Bulk_Storage_Solutions.Enums.enums;

namespace Bulk_Storage_Solutions
{
    public partial class Contracts : Page
    {
        private readonly IContracts _contracts;

        public Contracts()
        {
            _contracts = Global.Resolve<IContracts>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                try
                {
                    ContractsGridView.DataSource = _contracts.GetAllRowsFromContracts();
                    ContractsGridView.DataBind();

                    if(!IsPostBack)
                    {
                        FillContractStatusDropDownList();
                        FillContractStatusDropDownListForEdit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                ContractsGridView.DataSource = _contracts.SearchForContract(SearchText.Text);
                ContractsGridView.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void CreateContractBtn_Click(object sender, EventArgs e)
        {
            string script = "$('#createContractModal').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void AddContractBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ContractDTO contract = new ContractDTO
                {
                    ContractDescription = txtContractDesc.Text,
                    ContractStatus = ContractStatusDropDownList.SelectedItem.Text,
                    StartDate = DateTime.TryParse(startDateCal.Text, out DateTime resultStartDate) ? DateTime.Parse(startDateCal.Text) : DateTime.MinValue, 
                    EndDate = DateTime.TryParse(endDateCal.Text, out DateTime resultEndDate) ? DateTime.Parse(endDateCal.Text) : DateTime.MinValue
                };

                if(contract.StartDate == DateTime.MinValue)
                {
                    contract.StartDate = null;
                }

                if (contract.EndDate == DateTime.MinValue)
                {
                    contract.EndDate = null;
                }

                _contracts.CreateNewContract(contract);

                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void EditContractBtn_Click(object sender, EventArgs e) 
        {
            int contractId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            var contract = _contracts.GetContractById(contractId);
            EditContractID.Value = contractId.ToString();

            txtEditDesc.Text = contract.ContractDescription;
            txtEditStartDate.Text = contract.StartDate.HasValue ? contract.StartDate.Value.ToString("yyyy-MM-dd") : null;
            txtEditEndDate.Text = contract.EndDate.HasValue ? contract.EndDate.Value.ToString("yyyy-MM-dd") : null;

            ScriptManager.RegisterStartupScript(this, GetType(), "editContractModal", "$('#editContractModal').modal('show');", true);
        }

        protected void SaveEditContractBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int contractId = Convert.ToInt32(EditContractID.Value);

                ContractDTO contract = new ContractDTO
                {
                    ContractId = contractId,
                    ContractDescription = txtEditDesc.Text,
                    ContractStatus = EditContractStatusDropDownList.SelectedItem.Text,
                    StartDate = DateTime.TryParse(txtEditStartDate.Text, out DateTime resultStartDate) ? DateTime.Parse(txtEditStartDate.Text) : DateTime.MinValue,
                    EndDate = DateTime.TryParse(txtEditEndDate.Text, out DateTime resultEndDate) ? DateTime.Parse(txtEditEndDate.Text) : DateTime.MinValue
                };

                if (contract.StartDate == DateTime.MinValue)
                {
                    contract.StartDate = null;
                }

                if (contract.EndDate == DateTime.MinValue)
                {
                    contract.EndDate = null;
                }

                _contracts.UpdateContract(contract);

                Page_Load(sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected void PopupDeleteContractBtn_Click(object sender, EventArgs e)
        {
            int contractId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DeleteContractId.Value = contractId.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "deleteContractModal", "$('#deleteContractModal').modal('show');", true);
        }

        protected void DeleteContractBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int contractId = Convert.ToInt32(DeleteContractId.Value);
                _contracts.DeleteContract(contractId);

                Page_Load(sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FillContractStatusDropDownList()
        {
            Status[] statusValues = (Status[])Enum.GetValues(typeof(Status));

            foreach (Status status in statusValues)
            {
                ContractStatusDropDownList.Items.Add(new ListItem(status.ToString(), ((int)status).ToString()));
            }
        }

        public void FillContractStatusDropDownListForEdit()
        {
            Status[] statusValues = (Status[])Enum.GetValues(typeof(Status));

            foreach (Status status in statusValues)
            {
                EditContractStatusDropDownList.Items.Add(new ListItem(status.ToString(), ((int)status).ToString()));
            }
        }
    }
}