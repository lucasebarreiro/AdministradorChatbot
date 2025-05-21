using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdministradorChatBot.Models;

public partial class ChatbotDbContext : DbContext
{
    public ChatbotDbContext()
    {
    }

    public ChatbotDbContext(DbContextOptions<ChatbotDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chatbot> Chatbots { get; set; }

    public virtual DbSet<ChatbotKeyword> ChatbotKeywords { get; set; }

    public virtual DbSet<ChatbotResponse> ChatbotResponses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-JPM48D3\\SQLEXPRESS;Database=ChatbotAdminDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chatbot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chatbots__3214EC07B9364CBD");

            entity.HasOne(d => d.User).WithMany(p => p.Chatbots).HasConstraintName("FK__Chatbots__UserId__4BAC3F29");
        });

        modelBuilder.Entity<ChatbotKeyword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChatbotK__3214EC07C8C84E66");

            entity.HasOne(d => d.Chatbot).WithMany(p => p.ChatbotKeywords).HasConstraintName("FK__ChatbotKe__Chatb__4E88ABD4");
        });

        modelBuilder.Entity<ChatbotResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChatbotR__3214EC072D396CC2");

            entity.HasOne(d => d.Keyword).WithMany(p => p.ChatbotResponses).HasConstraintName("FK__ChatbotRe__Keywo__5165187F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07DF705DF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
