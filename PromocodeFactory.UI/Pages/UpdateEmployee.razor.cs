using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class UpdateEmployee
    {
        private EmployeeModel _employee;
        private SuccessNotification _notification;
        [Parameter]
        public string EmployeeId { get; set; }
        [Inject]
        IEmployeeRepository _employeeRepo { get; set; }

        protected  async override Task OnInitializedAsync()
        {
            _employee = await _employeeRepo.GetAsync(Guid.Parse(EmployeeId));
        }
        private async Task Update()
        {
            await _employeeRepo.UpdateAsync(_employee);
            _notification.Show();
        }
    }
}
