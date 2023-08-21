﻿using Bulk_Storage_Solutions.DAL.Features.Contracts;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Web.UI;

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
                ContractsGridView.DataSource = _contracts.GetContractById(int.Parse(SearchText.Text));
                ContractsGridView.DataBind();
            }
            catch(Exception ex)
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
    }
}