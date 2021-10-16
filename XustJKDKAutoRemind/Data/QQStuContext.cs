using Microsoft.EntityFrameworkCore;

namespace XustJKDKAutoRemind.Data
{
    public class QQStuContext : DbContext
    {
        public QQStuContext()
        {
        }

        public QQStuContext(DbContextOptions<QQStuContext> options) : base(options)
        {

        }
        public DbSet<QQStu> QQStus {  get; set; }
    }
}
