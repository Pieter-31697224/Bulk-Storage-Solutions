using Bulk_Storage_Solutions.DAL.Features.Cargo;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulk_Storage_Solutions
{
    public partial class Cargo : Page
    {
        private readonly ICargo _cargo;

        public Cargo()
        {
            _cargo = Global.Resolve<ICargo>();
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
                    CargoGridView.DataSource = _cargo.GetAllRowsFromCargo();
                    CargoGridView.DataBind();
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
                CargoGridView.DataSource = _cargo.SearchForCargo(SearchText.Text);
                CargoGridView.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void CreateCargoBtn_Click(object sender, EventArgs e)
        {
            string script = "$('#createCargoModal').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void AddCargoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CargoDTO cargo = new CargoDTO
                {
                    CargoDesc = txtCargoDesc.Text.ToString(),
                    CargoQty = Convert.ToInt32(txtCargoQty.Text),
                    CargoWeight = Convert.ToDouble(txtCargoWeight.Text),
                    CargoLong = Convert.ToDouble(txtCargoLong.Text),
                    CargoLat = Convert.ToDouble(txtCargoLat.Text)
                };

                _cargo.CreateNewCargo(cargo);

                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void EditCargoBtn_Click(object sender, EventArgs e)
        {
            int cargoId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            var cargo = _cargo.GetCargoById(cargoId);
            EditCargoID.Value = cargoId.ToString();

            txtEditDesc.Text = cargo.CargoDesc;
            txtEditWeight.Text = cargo.CargoWeight.ToString();
            txtEditLong.Text = cargo.CargoLong.ToString();
            txtEditLat.Text = cargo.CargoLat.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "editCargoModal", "$('#editCargoModal').modal('show');", true);
        }

        protected void SaveEditCargoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int cargoId = Convert.ToInt32(EditCargoID.Value);

                CargoDTO cargo = new CargoDTO
                {
                    CargoId = cargoId,
                    CargoDesc = txtEditDesc.Text,
                    CargoQty = Convert.ToInt32(txtEditQty.Text),
                    CargoWeight= Convert.ToDouble(txtEditWeight.Text),
                    CargoLong = Convert.ToDouble(txtEditLong.Text),
                    CargoLat = Convert.ToDouble(txtEditLat.Text)
                };

                

                _cargo.UpdateCargo(cargo);

                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected void PopupDeleteCargoBtn_Click(object sender, EventArgs e)
        {
            int cargoId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DeleteCargoId.Value = cargoId.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "deleteCargoModal", "$('#deleteCargoModal').modal('show');", true);
        }

        protected void DeleteCargoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int cargoId = Convert.ToInt32(DeleteCargoId.Value);
                _cargo.DeleteCargo(cargoId);

                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "errorPopupCargoModal", "$('#errorPopupCargoModal').modal('show');", true);
                Console.WriteLine(ex?.ToString());;
            }
        }
    }
}