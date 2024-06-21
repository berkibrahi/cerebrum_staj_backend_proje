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
	public class UserConfig : IEntityTypeConfiguration<User>
	{
		
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(u => u.UserId);
                builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
              
                builder.Property(u => u.Position).HasMaxLength(100);

            
            Randomizer.Seed = new Random(8675309);
            var userFaker = new Faker<User>("tr")
                    .RuleFor(u => u.UserId, f => f.IndexFaker + 1)
                    .RuleFor(u => u.Name, f => f.Name.FullName())
                    
                    .RuleFor(u => u.Position, f => f.Name.JobTitle());

                var users = userFaker.Generate(10);
                builder.HasData(users);
            }
        }
	}

