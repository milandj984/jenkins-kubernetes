using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserApp.Models;

public class User
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }

	internal static void BuildModel(EntityTypeBuilder<User> entity)
	{
		entity.ToTable("Users");

		entity.Property(e => e.Name)
			.IsRequired()
			.HasColumnName("name");

		entity.Property(e => e.LastName)
			.IsRequired()
			.HasColumnName("last_name");
	}
}