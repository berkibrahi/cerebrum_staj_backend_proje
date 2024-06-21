using Bogus;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config
{
    public class CommentConfig:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.CommentId);
            builder.Property(c => c.Content).IsRequired().HasMaxLength(1000);
            builder.HasOne(c => c.Post)
                   .WithMany(p => p.Comments)
                   .HasForeignKey(c => c.PostId);

            // Seed data using Bogus
            Randomizer.Seed = new Random(8675309);
            var commentFaker = new Faker<Comment>("tr")
                .RuleFor(c => c.CommentId, f => f.IndexFaker + 1)
                .RuleFor(c => c.Content, f => f.Lorem.Sentence())
                .RuleFor(c => c.PostId, f => f.Random.Number(1, 50)); // assuming there are 50 posts

            var comments = commentFaker.Generate(100);
            builder.HasData(comments);
        }
    }

}
