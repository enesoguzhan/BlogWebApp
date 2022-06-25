using DataAccessLayer.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class BlogContext : DbContext
    {
        // DBSet => Ekle,sili Güncelle,Listele İşlemlerimizi sağlayan abstract

        public DbSet<Users> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<Blogs> Blogs { get; set; }

        //Veri bağlantımızı yöneten bir metetdur. Bu metot polymorphism yöntemini kullanılarak base sınıf metot alt sınıfta değiştirilerek kullanılır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        //Hangi sınıfların tablo yapılarındaki propertyleri yöneteceğini belitrriğimiz metot. Bu metot polymorphism yöntemini kullanılarak base sınıf metot alt sınıfta değiştirilerek kullanılır.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new InteractionMap());
        }
    }


}
