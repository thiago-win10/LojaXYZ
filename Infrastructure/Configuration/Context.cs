using LojaXYZ.Infrastructure.Mapping;
using LojaXYZ.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LojaXYZ.Infrastructure.Configuration
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {  
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carrinho> Carrinhos  { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ClienteEndereco> ClienteEnderecos  { get; set; }
        public DbSet<ItemCarrinho> ItemCarrinhos { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);

            //Entity Configuration
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CarrinhoMap());
            modelBuilder.ApplyConfiguration(new ItemCarrinhoMap());
            modelBuilder.ApplyConfiguration(new ClienteEnderecoMap());

        }

        public string ObterStringConexao()
        {
            string conn = "Data Source=DESKTOP-H6JQJL4;Initial Catalog=LojaXYZ;Integrated Security=True";
            return conn;
        }

    }
}

   


