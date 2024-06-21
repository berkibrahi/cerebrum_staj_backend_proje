using Bogus;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
	public class PostConfig : IEntityTypeConfiguration<Post>
	{
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.PostId);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(2000);
            builder.HasOne(p => p.User)
                   .WithMany(u => u.Posts)
                   .HasForeignKey(p => p.UserId);

            // Seed data using Bogus
            Randomizer.Seed = new Random(8675309);
            var postFaker = new Faker<Post>("tr")
                .RuleFor(p => p.PostId, f => f.IndexFaker + 1)
                .RuleFor(p => p.Title, f => f.Lorem.Sentence())
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                .RuleFor(p => p.UserId, f => f.Random.Number(1, 10)); // assuming there are 10 users

            var posts = postFaker.Generate(50);
            builder.HasData(posts);
        }

    }
}
