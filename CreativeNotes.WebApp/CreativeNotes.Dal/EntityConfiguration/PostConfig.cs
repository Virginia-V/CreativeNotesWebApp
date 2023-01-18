using CreativeNotes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreativeNotes.Dal.EntityConfiguration
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(300);
        }
    }
}
