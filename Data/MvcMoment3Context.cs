using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using moment3.Models;

namespace moment3.Data
{
    public class MvcAlbumContext : DbContext
    {
        public MvcAlbumContext(DbContextOptions<MvcAlbumContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
    }
}