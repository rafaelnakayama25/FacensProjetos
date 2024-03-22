using IOTWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace IOTWebAPI.Data;

public class DataContext : DbContext
{
    
    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    {
        
    }
    //Construtor da classe DataContext, "DbContextOptions<DataContext>" está instanciando as opções de config. do contexto do banco de dados.
    //Construtor de DataContext repassa essas opções para o construtor da classe base DbContext.


    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSaving();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
    //Sobrescreve o método SaveChanges da classe DbContext para executar alguma lógica personalizada antes de salvar as alterações no banco de dados.
    

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    //Sobrescreve o método SaveChangesAsync da classe base DbContext para executar alguma lógica personalizada antes de salvar as alterações no banco de dados de forma assíncrona.


    private void OnBeforeSaving()
    {
        var entries = ChangeTracker.Entries();
        var utcNow = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            if (entry.Entity is Gateway gateway)
            {
                if (entry.State == EntityState.Added)
                {
                    gateway.CreatedAt = utcNow;
                    gateway.UpdatedAt = utcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false; // Não altera o valor original de CreatedAt
                    gateway.UpdatedAt = utcNow;
                }
            }
        }
    }
    //É um método privado que vai conter a lógica personalizada que será executada antes de salvar as alterações no banco de dados.
    //Ele atualiza as propriedades CreateAt e UpdateAt do objeto Gateway conforme necessário, dependendo do estado da entidade no contexto.

    public DbSet<Gateway> Gateways { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
}   //Vai dizer para o Context o que todas as nossas entidades são
    //Vai settar todas as entidades no banco de dados através do Dbcontext 