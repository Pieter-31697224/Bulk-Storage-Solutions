using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bulk_Storage_Solutions.DAL.Features.IClients;
using Bulk_Storage_Solutions.Models.DTO;
using static Bulk_Storage_Solutions.Enums.enums;

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
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                try
                {
                    ClientGridView.DataSource = _clients.GetAllRowsFromClients();
                    ClientGridView.DataBind();

                    if(!IsPostBack)
                    {
                        FillClientStatusDropDownList();
                        FillClientStatusDropDownListForEdit();
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
                    ClientStatus = ClientStatusDropDownList.SelectedItem.Text,
                    ClientEmail = ClientEmail.Text,
                    ClientContact = ClientContact.Text

                };

                _clients.CreateNewClient(client);

                Page_Load(sender, e);
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

            EditClientID.Value = clientId.ToString();
            EditClientName.Text = client.ClientName;
            EditClientSurname.Text = client.ClientSurname;
            EditClientStatusDropDownList.SelectedItem.Text = client.ClientStatus;
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
                ClientName = EditClientName.Text,
                ClientSurname = EditClientSurname.Text,
                ClientStatus = EditClientStatusDropDownList.SelectedItem.Text,
                ClientContact = EditClientContact.Text,
                ClientEmail = EditClientEmail.Text,

            };
            _clients.UpdateClient(client);

            Page_Load(sender, e);
        }

        protected void PopupDeleteClientBtn_Click(object sender, EventArgs e)
        {
            int clientId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DeleteClientId.Value = clientId.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "deleteClientModal", "$('#deleteClientModal').modal('show');", true);
        }

        protected void DeleteClientBtn_Click(object sender, EventArgs e)
        {
            int clientId = Convert.ToInt32(DeleteClientId.Value);
            _clients.DeleteClient(clientId);

            Page_Load(sender, e);
        }

        public void FillClientStatusDropDownList()
        {
            Status[] statusValues = (Status[])Enum.GetValues(typeof(Status));

            foreach (Status status in statusValues)
            {
                ClientStatusDropDownList.Items.Add(new ListItem(status.ToString(), ((int)status).ToString()));
            }
        }

        public void FillClientStatusDropDownListForEdit()
        {
            Status[] statusValues = (Status[])Enum.GetValues(typeof(Status));

            foreach (Status status in statusValues)
            {
                EditClientStatusDropDownList.Items.Add(new ListItem(status.ToString(), ((int)status).ToString()));
            }
        }

    }
}