using Microsoft.EntityFrameworkCore;

namespace AdministradorChatBot.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Models.Chatbot> Chatbots { get; set; }
    public DbSet<Models.PreguntaRespuesta> PreguntasRespuestas { get; set; }
    public DbSet<Models.Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Chatbot>()
            .HasMany(c => c.PreguntasRespuestas)
            .WithOne(p => p.Chatbot)
            .HasForeignKey(p => p.ChatbotId);

        modelBuilder.Entity<Models.Usuario>()
            .HasMany(u => u.Chatbots)
            .WithOne(c => c.Usuario)
            .HasForeignKey(c => c.UsuarioId);
    }
}

