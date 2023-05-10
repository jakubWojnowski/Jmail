using Jmail.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jmail.Infrastructure.Persistance;

public class JmailDbContext : IdentityDbContext
{
    public JmailDbContext(DbContextOptions<JmailDbContext> options) : base(options)
    {
      
    }

    
    public DbSet<Message> Messages { get; set; }
    public DbSet<Folder> Folders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /*//Message
        modelBuilder.Entity<Message>().Property(m => m.Title).IsRequired();
        modelBuilder.Entity<Message>().Property(m => m.ReciptientEmail).IsRequired();
        //Folder
        modelBuilder.Entity<Folder>().Property(f => f.Name).IsRequired();*/
     
    }
}