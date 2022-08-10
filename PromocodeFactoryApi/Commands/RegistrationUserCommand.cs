namespace PromocodeFactoryApi.Commands
{
    public class RegistrationUserCommand
    {
        public string UserName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public string ConfirmPassword { get; set; } 
    }
}
