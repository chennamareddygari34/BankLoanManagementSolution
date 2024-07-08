using BankLoanManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.Contexts
{
    public class BankLoanDbContext : DbContext
    {
        public BankLoanDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }
        public DbSet<User> users { get; set; }
    }
}
