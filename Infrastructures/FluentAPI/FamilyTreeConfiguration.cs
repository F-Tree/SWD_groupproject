
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.FluentValidation
{
    public class FamilyTreeConfiguration : IEntityTypeConfiguration<FamilyTree>
    {
        public void Configure(EntityTypeBuilder<FamilyTree> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
