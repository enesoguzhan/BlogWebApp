namespace DataAccessLayer.Mappings
{
    public class InteractionMap : IEntityTypeConfiguration<Interactions>
    {
        public void Configure(EntityTypeBuilder<Interactions> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.InteractionDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            builder.Property(s => s.IPAddress).HasMaxLength(15);
            builder.Property(s => s.InteractionType).IsRequired();

            builder.HasOne(s => s.Blogs).WithMany(s => s.Interactions).HasForeignKey(s => s.BlogId);

            builder.ToTable("Interactions");
        }
    }
}
