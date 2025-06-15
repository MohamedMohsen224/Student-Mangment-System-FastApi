using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Models;

namespace TrialDay.Repo.Config
{
    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Teacher)
                .HasMaxLength(50);

            builder.Property(c => c.Decription)
                .HasMaxLength(100);

            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Class)
                .HasForeignKey(e => e.ClassId);

        }
    }
}
