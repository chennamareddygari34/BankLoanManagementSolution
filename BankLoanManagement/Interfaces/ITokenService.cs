﻿namespace BankLoanManagement.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string username);
    }
}
