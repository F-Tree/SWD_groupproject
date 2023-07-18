using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.FluentAPI
{
	public class TreeRelationshipConfiguration : IEntityTypeConfiguration<TreeRelationship>
	{
		public void Configure(EntityTypeBuilder<TreeRelationship> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.RelationshipName);
			builder.HasOne(x=>x.FirstPerson).WithMany(p=>p.TreeRelationshipOne).HasForeignKey(x=>x.FirstPersonId).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.SecondPerson).WithMany(p => p.TreeRelationshipTwo).HasForeignKey(x => x.SecondPersonId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
