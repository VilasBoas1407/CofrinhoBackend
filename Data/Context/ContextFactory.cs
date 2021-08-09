using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<CofrinhoContext>
    {
        public CofrinhoContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=127.0.0.1;Database=DB_COFRINHO;User Id=sa;Password=123456;";
            var optionsBuilder = new DbContextOptionsBuilder<CofrinhoContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new CofrinhoContext(optionsBuilder.Options);
        }
    }
}
