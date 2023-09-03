using Bulk_Storage_Solutions.DAL.Features.ClientStorageAgreement;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulk_Storage_Solutions
{
    public partial class ClientStorageAgreement : Page
    {
        private readonly IClientStorageAgreement _clientStorageAgreement;

        public ClientStorageAgreement()
        {
            _clientStorageAgreement = Global.Resolve<IClientStorageAgreement>();
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
                    CSAGridView.DataSource = _clientStorageAgreement.GetAllClientStorageAgreements();
                    CSAGridView.DataBind();

                    if (!IsPostBack)
                    {
                        FillClientDropDownList();
                        FillCargoDropDownList();
                        FillContractDropDownList();
                        FillStorageDropDownList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void SearchButton_Click(object Sender, EventArgs e)
        {
            try
            {
                CSAGridView.DataSource = _clientStorageAgreement.SearchForClientStorageAgreement(SearchText.Text);
                CSAGridView.DataBind();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void CreateCSABtn_Click(object Sender, EventArgs e)
        {
            string script = "$('#createCSAModal').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void PopupDeleteCSABtn_Click(object Sender, EventArgs e)
        {
            int clientStorageAgreementId = Convert.ToInt32((Sender as LinkButton).CommandArgument);
            DeleteCSAId.Value = clientStorageAgreementId.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "deleteCSAModal", "$('#deleteCSAModal').modal('show');", true);
        }

        protected void AddCSABtn_Click(object Sender, EventArgs e)
        {
            try
            {
                ClientStorageAgreementDTO clientAgreement = new ClientStorageAgreementDTO
                {
                    CargoId = Convert.ToInt32(cargoDropDownList.SelectedValue),
                    ClientId = Convert.ToInt32(clientDropDownList.SelectedValue),
                    ContractId = Convert.ToInt32(contractDropDownList.SelectedValue),
                    StorageId = Convert.ToInt32(storageDropDownList.SelectedValue)
                };

                _clientStorageAgreement.CreateClientStorageAgreement(clientAgreement);

                Page_Load(Sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void DeleteCSABtn_Click(object Sender, EventArgs e)
        {
            try
            {
                int clientStorageAgreementId = Convert.ToInt32(DeleteCSAId.Value);
                _clientStorageAgreement.DeleteClientStorageAgreement(clientStorageAgreementId);

                Page_Load(Sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FillClientDropDownList()
        {
            clientDropDownList.DataSource = _clientStorageAgreement.GetAllClientsForDropDownList();
            clientDropDownList.DataTextField = "ClientName";
            clientDropDownList.DataValueField = "ClientId";
            clientDropDownList.DataBind();
        }

        public void FillCargoDropDownList()
        {
            cargoDropDownList.DataSource = _clientStorageAgreement.GetAllCargoForDropDownList();
            cargoDropDownList.DataTextField = "CargoDesc";
            cargoDropDownList.DataValueField = "CargoId";
            cargoDropDownList.DataBind();
        }

        public void FillContractDropDownList()
        {
            contractDropDownList.DataSource = _clientStorageAgreement.GetAllContractsForDropDownList();
            contractDropDownList.DataTextField = "ContractDesc";
            contractDropDownList.DataValueField = "ContractId";
            contractDropDownList.DataBind();
        }

        public void FillStorageDropDownList()
        {
            storageDropDownList.DataSource = _clientStorageAgreement.GetAllStorageForDropDownList();
            storageDropDownList.DataTextField = "StorageUnitNumber";
            storageDropDownList.DataValueField = "StorageId";
            storageDropDownList.DataBind();
        }
    }
}