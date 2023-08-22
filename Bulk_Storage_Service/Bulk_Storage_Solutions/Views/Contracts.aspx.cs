﻿using Bulk_Storage_Solutions.DAL.Features.Contracts;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            try
            {
                ContractsGridView.DataSource = _contracts.GetAllRowsFromContracts();
                ContractsGridView.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                    ContractStatus = txtContractStatus.Text,
                    StartDate = DateTime.Parse(startDateCal.Text),
                    EndDate = DateTime.Parse(endDateCal.Text)
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
            txtEditStatus.Text = contract.ContractStatus;
            txtEditStartDate.Text = contract.StartDate.HasValue ? contract.StartDate.Value.ToString("yyyy-MM-dd") : null;
            txtEditEndDate.Text = contract.EndDate.HasValue ? contract.EndDate.Value.ToString("yyyy-MM-dd") : null;

            ScriptManager.RegisterStartupScript(this, GetType(), "editContractModal", "$('#editContractModal').modal('show');", true);
        }

        protected void SaveEditContractBtn_Click(object sender, EventArgs e)
        {
            int contractId = Convert.ToInt32(EditContractID.Value);

            ContractDTO contract = new ContractDTO
            {
                ContractId = contractId,
                ContractDescription = txtEditDesc.Text,
                ContractStatus = txtEditStatus.Text,
                StartDate = DateTime.Parse(txtEditStartDate.Text),
                EndDate = DateTime.Parse(txtEditEndDate.Text)
            };

            _contracts.UpdateContract(contract);
        }

        protected void PopupDeleteContractBtn_Click(object sender, EventArgs e)
        {
            int contractId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DeleteContractId.Value = contractId.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "deleteContractModal", "$('#deleteContractModal').modal('show');", true);
        }

        protected void DeleteContractBtn_Click(object sender, EventArgs e)
        {
            int contractId = Convert.ToInt32(DeleteContractId.Value);
            _contracts.DeleteContract(contractId);
        }
    }
}