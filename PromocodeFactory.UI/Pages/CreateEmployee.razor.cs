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
        public IEmployeeRepository EmployeeRepo { get; set; }

        private async Task Create()
        {
            await EmployeeRepo.CreateAsync(_employee);
            _notification.Show();
        }
    }
}
