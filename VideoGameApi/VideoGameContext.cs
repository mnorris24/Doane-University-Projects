using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace VideoGameApi.Models
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGame> TodoItems { get; set; } = null!;
    }
}
