﻿namespace BankLoanManagement.Utilities
{
    public class InvalidUserName:Exception
    
         {
        string message = "";
        public InvalidUserName()
        {
            message = "invalid username";
        }
        public override string Message => message;
    }
}
