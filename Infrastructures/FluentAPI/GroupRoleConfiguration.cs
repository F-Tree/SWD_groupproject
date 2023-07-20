using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.FluentAPI
{
	public class GroupRoleConfiguration : IEntityTypeConfiguration<GroupRole>
	{
		public void Configure(EntityTypeBuilder<GroupRole> builder)
		{
			builder.HasData(new GroupRole
			{
				GroupRoleId = 1,
				GroupRoleName= nameof(GroupRoleEnum.FamilyAdmin),
			},
			new GroupRole
			{
				GroupRoleId = 2,
				GroupRoleName= nameof(GroupRoleEnum.FamilyMember),
			}
			);
		}
	}
}
