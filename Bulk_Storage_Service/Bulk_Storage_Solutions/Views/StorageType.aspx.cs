using Bulk_Storage_Solutions.DAL.Features.StorageType;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulk_Storage_Solutions.Views
{
    public partial class StorageType : Page
    {
        private readonly IStorageType _storageType;

        public StorageType()
        {
            _storageType = Global.Resolve<IStorageType>();
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
                    StorageTypeGridView.DataSource = _storageType.GetAllStorageTypes();
                    StorageTypeGridView.DataBind();
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
                StorageTypeGridView.DataSource = _storageType.SearchStorageType(SearchText.Text);
                StorageTypeGridView.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void CreateStorageTypeBtn_Click(object sender, EventArgs e)
        {
            string script = "$('#createStorageTypeModal').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void PopupEditModalBtn_Click(object sender, EventArgs e)
        {
            int storageTypeId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            var storageType = _storageType.GetStorageTypeById(storageTypeId);
            EditStorageTypeID.Value = storageTypeId.ToString();

            txtEditDesc.Text = storageType.StorageTypeDesc;
            txtEditunitsAvailable.Text = storageType.StorageTypeQtyAvailable.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "editStorageModal", "$('#editStorageModal').modal('show');", true);
        }

        protected void PopupDeleteModalBtn_Click(object sender, EventArgs e)
        {
            int storageTypeId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DeleteStorageTypeId.Value = storageTypeId.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "deleteStorageTypeModal", "$('#deleteStorageTypeModal').modal('show');", true);
        }

        protected void AddStorageTypeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StorageTypeDTO storageType = new StorageTypeDTO
                {
                    StorageTypeDesc = txtStorageTypeDesc.Text,
                    StorageTypeQtyAvailable = Convert.ToInt32(txtStorageQtyAvailable.Text)
                };

                _storageType.CreateStorageType(storageType);

                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void SaveEditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int storageTypeId = Convert.ToInt32(EditStorageTypeID.Value);

                StorageTypeDTO storageType = new StorageTypeDTO
                {
                    StorageTypeId= storageTypeId,
                    StorageTypeDesc = txtEditDesc.Text,
                    StorageTypeQtyAvailable = Convert.ToInt32(txtEditunitsAvailable.Text)
                };

                _storageType.UpdateStorageType(storageType);

                Page_Load(sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int storageTypeId = Convert.ToInt32(DeleteStorageTypeId.Value);
                _storageType.DeleteStorageType(storageTypeId);

                Page_Load(sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}