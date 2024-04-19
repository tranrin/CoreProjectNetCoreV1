using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyPhuongTienDoNhom2_Domain.Identity;

namespace Persistence
{
    public class QLPT_DbContext : IdentityDbContext<HT_NguoiDung, HT_VaiTro, Guid>
    {
        public QLPT_DbContext(DbContextOptions<QLPT_DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();

                if (tableName != null)
                {
                    if (tableName.Equals("AspNetUsers"))
                    {
                        entityType.SetTableName("HT_NguoiDung");
                    }
                    else if (tableName.Equals("AspNetRoles"))
                    {
                        entityType.SetTableName("HT_VaiTro");
                    }
                    else if (tableName.StartsWith("AspNet"))
                    {
                        entityType.SetTableName(tableName.Replace("AspNet", "HT_"));
                    }
                }

            }
        }
    }
}
