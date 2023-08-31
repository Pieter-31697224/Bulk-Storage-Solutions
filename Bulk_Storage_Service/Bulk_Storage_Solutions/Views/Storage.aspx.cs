using Bulk_Storage_Solutions.DAL.Features.Contracts;
using Bulk_Storage_Solutions.DAL.Features.Storage;
using Bulk_Storage_Solutions.DAL.Features.StorageType;
using Bulk_Storage_Solutions.Models.DTO;
using Bulk_Storage_Solutions.Models.Persistent;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            try
            {
                StorageGridView.DataSource = _storage.GetAllStorage();
                StorageGridView.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
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
            
        }

        protected void EditStorageBtn_Click(object sender, EventArgs e)
        {
            int storageId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            var storage = _storage.GetStorageById(storageId);
            EditStorageID.Value = storageId.ToString();
            
            txtEditDesc.Text=storage.storageDescription.ToString();
            txtEditStatus.Text=storage.storageStatus.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "editStorageModal", "$('#editStorageModal').modal('show');", true);
        }

        protected void SaveEditStorageBtn_Click(object sender, EventArgs e)
        {
            
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
    }
}