using Microsoft.EntityFrameworkCore;
using WebAPITemplate.Api.Models;

namespace WebAPITemplate.Api.Data
{
    public class WebAPIContext : DbContext
    {
        public string DbPath { get; }

        public WebAPIContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "WebAPIDB.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}").UseLazyLoadingProxies();

        public DbSet<WebAPIClass> WebAPIClasses { get; set; }
    }
}
