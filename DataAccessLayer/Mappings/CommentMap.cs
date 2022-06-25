namespace DataAccessLayer.Mappings
{
    internal class CommentMap : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.CommentDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            builder.Property(s => s.Email).HasMaxLength(100);
            builder.Property(s => s.Commenter).HasMaxLength(100);
            builder.Property(s => s.Status).HasDefaultValue(false);

            builder.HasOne(s => s.Blogs).WithMany(s => s.Comments).HasForeignKey(s => s.BlogId);

            builder.ToTable("Comments");
        }
    }
}
