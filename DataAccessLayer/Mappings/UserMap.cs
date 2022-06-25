namespace DataAccessLayer.Mappings
{
    public class UserMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NameSurname).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Summary).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Explanation).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.AvatarImages);

            // İlişkilendirme.
            builder.HasMany(s => s.Blogs).WithOne(s => s.Users).HasForeignKey(s => s.UsersId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Users"); // Tablo Adı
        }
    }
}
