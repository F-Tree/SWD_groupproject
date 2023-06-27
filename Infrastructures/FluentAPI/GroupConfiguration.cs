using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructures.FluentAPI
{
    public class GroupConfiguration : IEntityTypeConfiguration<GroupChatEntity>
    {
        public void Configure(EntityTypeBuilder<GroupChatEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.GroupName).HasMaxLength(30);
            builder.Property(x => x.GroupDescription).HasMaxLength(40);
        }
    }
}
