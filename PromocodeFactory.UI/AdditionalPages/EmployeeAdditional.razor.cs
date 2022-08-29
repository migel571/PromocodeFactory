using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.AdditionalPages
{
    public partial class EmployeeAdditional
    {
        [Parameter]
        public EmployeeModel employee { get; set; }
    }
}
