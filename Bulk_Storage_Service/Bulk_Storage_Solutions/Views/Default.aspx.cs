using Bulk_Storage_Solutions.DAL.Features.Contracts;
using System;
using System.Web.UI;

namespace Bulk_Storage_Solutions
{
    public partial class _Default : Page
    {
        private readonly IContracts _contracts;

        public _Default()
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
    }
}