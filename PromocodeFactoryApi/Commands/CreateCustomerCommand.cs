﻿using System.ComponentModel.DataAnnotations;

namespace PromocodeFactoryApi.Commands
{
    public class CreateCustomerCommand
    {
       
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

        public List<Guid> PreferenceIds { get; set; }
        public List<Guid> PromoCodeIds { get; set; }

    }
}
