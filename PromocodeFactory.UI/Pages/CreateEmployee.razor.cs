using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class CreateEmployee
    {
        private CreateEmployeeModel _employee = new CreateEmployeeModel();
        private SuccessNotification _notification;
        [Inject]
        IEmployeeRepository _employeeRepo { get; set; }

        private async Task Create()
        {
            await _employeeRepo.CreateAsync(_employee);
            _notification.Show();
        }
    }
}
