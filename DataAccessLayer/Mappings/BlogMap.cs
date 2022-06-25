namespace DataAccessLayer.Mappings
{
    public class BlogMap : IEntityTypeConfiguration<Blogs>
    {
        public void Configure(EntityTypeBuilder<Blogs> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Name).HasMaxLength(150).IsRequired();
            builder.Property(s => s.Explanation).IsRequired();
            builder.Property(s => s.PublishDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            builder.Property(s => s.Status).HasDefaultValue(false);

            // İlişkilendirme.
            builder.HasOne(s => s.Users).WithMany(s => s.Blogs).HasForeignKey(s => s.UsersId);
            builder.HasMany(s => s.Comments).WithOne(s => s.Blogs).HasForeignKey(s => s.BlogId);
            builder.HasMany(s => s.Interactions).WithOne(s => s.Blogs).HasForeignKey(s => s.BlogId);

            builder.ToTable("Blogs");
        }
    }
}
