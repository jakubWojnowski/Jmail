using Jmail.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jmail.Infrastructure.Persistance;

public class JmailDbContext : IdentityDbContext
{
    public JmailDbContext(DbContextOptions<JmailDbContext> options) : base(options)
    {
        
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Folder> Folders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Account
        modelBuilder.Entity<Account>().Property(ac => ac.Email).IsRequired();
        //Message
        modelBuilder.Entity<Message>().Property(m => m.SenderEmail).IsRequired();
        modelBuilder.Entity<Message>().Property(m => m.SenderEmail).IsRequired();
        modelBuilder.Entity<Message>().Property(m => m.Title).IsRequired();
        //Folder
        modelBuilder.Entity<Folder>().Property(f => f.Name).IsRequired();
    }
}