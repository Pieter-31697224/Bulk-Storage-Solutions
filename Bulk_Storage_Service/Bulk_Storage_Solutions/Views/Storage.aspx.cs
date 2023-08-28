using Bulk_Storage_Solutions.DAL.Features.Contracts;
using Bulk_Storage_Solutions.DAL.Features.Storage;
using Bulk_Storage_Solutions.DAL.Features.StorageType;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
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
            
        }

        protected void CreateStorageBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected void AddStorageBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected void EditStorageBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected void SaveEditStorageBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected void PopupDeleteStorageBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected void DeleteStorageBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}