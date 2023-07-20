using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.FluentAPI
{
	public class UserInGroupConfiguration : IEntityTypeConfiguration<UserInGroup>
	{
		public void Configure(EntityTypeBuilder<UserInGroup> builder)
		{
			builder.HasKey(x =>x.Id);
			builder.HasOne(x => x.User).WithMany(u => u.UserInGroups).HasForeignKey(x => x.UserId);
			builder.HasOne(x => x.FamilyGroup).WithMany(g => g.UserInGroups).HasForeignKey(x => x.GroupId);
			builder.HasOne(x => x.GroupRole).WithMany(role => role.UserInGroups).HasForeignKey(x => x.GroupRoleId);
		}
	}
}
