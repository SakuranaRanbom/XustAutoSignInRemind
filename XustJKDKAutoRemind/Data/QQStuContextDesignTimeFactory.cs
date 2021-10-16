using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace XustJKDKAutoRemind.Data
{
    public class QQStuContextDesignTimeFactory : IDesignTimeDbContextFactory<QQStuContext>
    {
        public QQStuContext CreateDbContext(string[] args)
        {
            
            var builder = new DbContextOptionsBuilder<QQStuContext>();
            builder.UseSqlite("Data Source=QQStu.db");

            return new QQStuContext(builder.Options);
        }
    }
}
