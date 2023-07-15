using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.FluentAPI
{
	public class MessageConfiguration : IEntityTypeConfiguration<Message>
	{
		public void Configure(EntityTypeBuilder<Message> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
			builder.Property(x => x.Content);
			builder.HasOne(x => x.Group).WithMany(g => g.Messages).HasForeignKey(x => x.GroupId);
		}
	}
}
