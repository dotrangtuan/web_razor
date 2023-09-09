using Microsoft.EntityFrameworkCore;
using razorweb.models;

public class MyBlogContext : DbContext {
    public DbSet<Article>? articles {get;set;}

    private const string connectionString = @"
        Data Source=.;
        Initial Catalog=myblog;
        Integrated Security=true;
        Encrypt=False
";

    protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(connectionString);
        
    }

}

