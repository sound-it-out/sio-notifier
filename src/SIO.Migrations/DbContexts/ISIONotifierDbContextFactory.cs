namespace SIO.Migrations.DbContexts
{
    public interface ISIONotifierDbContextFactory
    {
        SIONotifierDbContext Create();
    }
}
