
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.DAL.Features.IClients;
using Bulk_Storage_Solutions.Models.DTO;


namespace Bulk_Storage_Solutions.Views
{
    public partial class Client : Page
    {

        private readonly IClient _clients;
        public Client()
        {
            _clients = Global.Resolve<IClient>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ClientGridView.DataSource = _clients.GetAllRowsFromClients();
                ClientGridView.DataBind();
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
                ClientGridView.DataSource = _clients.SearchForClient(SearchText.Text);
                ClientGridView.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void CreateClientBtn_Click(object sender, EventArgs e)
        {
            string script = "$('#createClientModal').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void AddClientBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ClientDTO client = new ClientDTO
                {
                    
                    ClientName = ClientName.Text,
                    ClientSurname = ClientSurname.Text,
                    ClientStatus = txtClientStatus.Text,
                    ClientEmail = ClientEmail.Text,
                    ClientContact = ClientContact.Text

                };




                _clients.CreateNewClient(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void EditClientBtn_Click(object sender, EventArgs e)
        {
            int clientId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            var client = _clients.GetClientById(clientId);
            

           ;
            EditClientName.Text = client.ClientName;
            EditClientSurname.Text = client.ClientSurname;
            txtEditClientStatus.Text = client.ClientStatus;
            EditClientContact.Text = client.ClientContact.ToString();
            EditClientEmail.Text = client.ClientEmail;




            ScriptManager.RegisterStartupScript(this, GetType(), "editClientModal", "$('#editClientModal').modal('show');", true);
        }

        protected void SaveEditClientBtn_Click(object sender, EventArgs e)
        {
            int clientId = Convert.ToInt32(EditClientID.Value);

            ClientDTO client = new ClientDTO
            {
                ClientId = clientId,
                ClientName = ClientName.Text,
                ClientSurname = ClientSurname.Text,
                ClientStatus = txtClientStatus.Text,
                ClientContact = ClientContact.Text,
                ClientEmail = ClientEmail.Text,

            };
            _clients.UpdateClient(client);
        }

        protected void PopupDeleteClientBtn_Click(object sender, EventArgs e)
        {
            int clientId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DeleteClientId.Value = clientId.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "deleteContractModal", "$('#deleteContractModal').modal('show');", true);
        }

        protected void DeleteClientBtn_Click(object sender, EventArgs e)
        {
            int clientId = Convert.ToInt32(DeleteClientId.Value);
            _clients.DeleteClient(clientId);


        }

    }
}