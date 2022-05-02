using Microsoft.EntityFrameworkCore;

public class DbTrovaLeDifferenze : DbContext
	{
		public DbSet<DomandaImmagine> DomandeImmagine { get; set; }
		public DbSet<Differenza> Differenze { get; set; }
		public DbTrovaLeDifferenze (DbContextOptions<DbTrovaLeDifferenze> options)
			: base(options)
		{
		}
	}
