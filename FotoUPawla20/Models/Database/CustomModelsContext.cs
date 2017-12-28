using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FotoUPawla20.Models.Database
{
    public class CustomModelsContext : DbContext
    {
        public CustomModelsContext(DbContextOptions<CustomModelsContext> dbContextOptions) : base(options: dbContextOptions)
        {

        }

        public DbSet<KlienciModel> Klienci { get; set; }
        public DbSet<CodliConfiguration> Konfiguracja { get; set; }
        public DbSet<ZdjeciaModel> Zdjecia { get; set; }
    }

    public class KlienciModel
    {
        [Key]
        public int KlienciModelId { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public int Data { get; set; }
        [Required]
        public string Tytul { get; set; }
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public bool Zrealizowano { get; set; }
        public string KodKlienta { get; set; }
        public string AdresZdjec { get; set; }
    }

    public class CodliConfiguration
    {
        [Key]
        public int CodliConfigurationId { get; set; }
        public string ConfName { get; set; }
        public string ConfValue { get; set; }
    }

    public class ZdjeciaModel
    {
        [Key]
        public int ZdjeciaModelId { get; set; }
        public int GaleriaId { get; set; }
        public string Path { get; set; }
    }
}
