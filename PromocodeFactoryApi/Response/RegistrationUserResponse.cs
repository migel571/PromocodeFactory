﻿namespace PromocodeFactory.Api.Response
{
    public class RegistrationUserResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
