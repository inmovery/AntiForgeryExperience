namespace AntiForgeryExperience.Persistence.Configurations;

public class BookEntityConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> entity)
    {
        entity.HasKey(properties => properties.Id);

        entity.Property(properties => properties.Title)
	        .IsRequired()
	        .HasColumnName("title")
	        .HasColumnType("text");

        entity.Property(properties => properties.Author)
            .IsRequired()
            .HasColumnName("author")
            .HasColumnType("text");

        entity.Property(properties => properties.Publisher)
            .IsRequired()
            .HasColumnName("publisher")
            .HasColumnType("text");

        entity.Property(properties => properties.PagesQuantity)
            .IsRequired()
            .HasColumnName("pages_quantity")
            .HasColumnType("int");

        entity.Property(properties => properties.Country)
            .IsRequired()
            .HasColumnName("country")
            .HasColumnType("text");

        entity.Property(properties => properties.PagesQuantity)
            .IsRequired()
            .HasColumnName("pages_quantity")
            .HasColumnType("int");

        entity.Property(properties => properties.ReleaseDate)
            .IsRequired()
            .HasColumnName("release_date")
            .HasColumnType("date");

        entity.ToTable("books");
    }
}