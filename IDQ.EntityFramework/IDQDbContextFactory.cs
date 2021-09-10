using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IDQ.EntityFramework
{
    public class IDQDbContextFactory : IDesignTimeDbContextFactory<IDQDbContext>
    {
        public IDQDbContext CreateDbContext(string[] args = null)
        {
            DbContextOptionsBuilder<IDQDbContext> options = new();
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IDQ";
            _ = Directory.CreateDirectory(dirPath);

            _ = options.UseSqlite("Data Source=" + dirPath + "\\UltraDatabase.db");
            _ = options.UseLazyLoadingProxies();

            new IDQDbContext(options.Options).Database.Migrate();
            IDQDbContext _context = new IDQDbContext(options.Options);

            return _context;
        }
    }
}
