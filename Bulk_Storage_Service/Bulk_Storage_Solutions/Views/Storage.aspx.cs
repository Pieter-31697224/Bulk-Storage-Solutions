using Bulk_Storage_Solutions.DAL.Features.Storage;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Bulk_Storage_Solutions.Enums.enums;

namespace Bulk_Storage_Solutions
{
    public partial class Storage : Page
    {
        
        private readonly IStorage _storage;

        public Storage()
        {
            _storage = Global.Resolve<IStorage>();
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
                    StorageGridView.DataSource = _storage.GetAllStorage();
                    StorageGridView.DataBind();

                    if (!IsPostBack)
                    {
                        FillStorageTypeDropDownList();
                        FillStorageTypeDropDownListForEdit();
                        FillStorageStatusDropDownList();
                        FillStorageStatusDropDownListForEdit();
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
                StorageGridView.DataSource = _storage.SearchForStorage(SearchText.Text);
                StorageGridView.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void CreateStorageBtn_Click(object sender, EventArgs e)
        {
            string script = "$('#createStorageModal').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void AddStorageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StorageDTO storage = new StorageDTO
                {
                    storageTypeId = Convert.ToInt32(StorageDropDownList.SelectedValue),
                    storageStatus = StorageStatusDropDownList.SelectedItem.Text.ToString()
                };

                _storage.CreateStorage(storage);

                Page_Load(sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void EditStorageBtn_Click(object sender, EventArgs e)
        {
            int storageId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            var storage = _storage.GetStorageById(storageId);
            EditStorageID.Value = storageId.ToString();
            
            ScriptManager.RegisterStartupScript(this, GetType(), "editStorageModal", "$('#editStorageModal').modal('show');", true);
        }

        protected void SaveEditStorageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StorageDTO storage = new StorageDTO
                {
                    storageStatus = EditStorageStatusDropDownList.SelectedItem.Text,
                    storageTypeId = Convert.ToInt32(EditStorageDropDownList.SelectedValue),
                    storageId = Convert.ToInt32(EditStorageID.Value)
                };

                _storage.UpdateStorage(storage);

                Page_Load(sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void PopupDeleteStorageBtn_Click(object sender, EventArgs e)
        {
            int storageId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DeleteStorageId.Value = storageId.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "deleteStorageModal", "$('#deleteStorageModal').modal('show');", true);
        }

        protected void DeleteStorageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int storageId = Convert.ToInt32(DeleteStorageId.Value);
                _storage.DeleteStorage(storageId);

                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FillStorageTypeDropDownList()
        {
            StorageDropDownList.DataSource = _storage.GetAllStorageTypesForDropDownList();
            StorageDropDownList.DataTextField = "StorageTypeDesc";
            StorageDropDownList.DataValueField = "StorageTypeId";
            StorageDropDownList.DataBind();
        }

        public void FillStorageTypeDropDownListForEdit()
        {
            EditStorageDropDownList.DataSource = _storage.GetAllStorageTypesForDropDownList();
            EditStorageDropDownList.DataTextField = "StorageTypeDesc";
            EditStorageDropDownList.DataValueField = "StorageTypeId";
            EditStorageDropDownList.DataBind();
        }

        public void FillStorageStatusDropDownList()
        {
            Status[] statusValues = (Status[])Enum.GetValues(typeof(Status));

            foreach (Status status in statusValues)
            {
                StorageStatusDropDownList.Items.Add(new ListItem(status.ToString(), ((int)status).ToString()));
            }
        }

        public void FillStorageStatusDropDownListForEdit()
        {
            Status[] statusValues = (Status[])Enum.GetValues(typeof(Status));

            foreach (Status status in statusValues)
            {
                EditStorageStatusDropDownList.Items.Add(new ListItem(status.ToString(), ((int)status).ToString()));
            }
        }
    }
}