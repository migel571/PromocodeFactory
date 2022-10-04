using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Attributes
{
    public class RoleNameAttribute : ValidationAttribute
    {


        public override bool IsValid(object? value)
        {
            if (value is string roleName)
            {
                if (roleName == "Admin" || roleName == "Employee" || roleName == "Partner")    
                    return true;
                else
                    ErrorMessage = "Некорректное имя роли.";
            }
            ErrorMessage = "Роль должна быть текстовым полем и конкретным из списка";
            return false;
        }

    }
}
