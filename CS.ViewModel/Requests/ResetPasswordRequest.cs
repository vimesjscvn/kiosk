﻿namespace CS.VM.Requests
{
    public class ResetPasswordRequest
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}