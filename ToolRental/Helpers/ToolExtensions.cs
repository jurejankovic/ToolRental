using System.Globalization;
using ToolRental.Models;
using ToolRental.ViewModels;

namespace ToolRental.Helpers
{
    public static class ToolExtensions
    {
        public static ToolViewModel ToViewModel(this Tool tool)
        {
            return new ToolViewModel
            {
                Id = tool.Id.ToString(),
                Name = tool.Name,
                Description = tool.Description,
                PricePerHour = tool.PricePerHour.ToString()
            };
        }

        public static Tool ToModel(this ToolViewModel viewModel)
        {
            if (int.TryParse(viewModel.Id, out int id) &&
                decimal.TryParse(viewModel.PricePerHour, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal pricePerHour))
            {
                return new Tool
                {
                    Id = id,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    PricePerHour = pricePerHour
                };
            }
            else
            {
                throw new InvalidOperationException("ViewModel has invalid Id or PricePerHour");
            }
        }
    }
}
