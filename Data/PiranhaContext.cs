using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Piranha.Data
{
	/// <summary>
	/// The Piranha DbContext
	/// </summary>
	public class PiranhaContext : DbContext
	{
		public DbSet<Entities.User> Users { get ; set ; }
		public DbSet<Entities.Group> Groups { get ; set ; }
		public DbSet<Entities.Permission> Permissions { get ; set ; }
		public DbSet<Entities.Param> Params { get ; set ; }
		public DbSet<Entities.PageTemplate> PageTemplates { get ; set ; }
		public DbSet<Entities.PostTemplate> PostTemplates { get ; set ; }
		public DbSet<Entities.PropertyTemplate> PropertyTemplates { get ; set ; }
		public DbSet<Entities.Permalink> Permalinks { get ; set ; }
		public DbSet<Entities.Page> Pages { get ; set ; }
		public DbSet<Entities.Post> Posts { get ; set ; }
		public DbSet<Entities.Region> Regions { get ; set ; }
		public DbSet<Entities.Property> Properties { get ; set ; }
		public DbSet<Entities.Content> Content { get ; set ; }
		public DbSet<Entities.Upload> Uploads { get ; set ; }

		/// <summary>
		/// Default constructor. Creates a new db context.
		/// </summary>
		public PiranhaContext() : base("Piranha") {}

		/// <summary>
		/// Initializes the current model.
		/// </summary>
		/// <param name="modelBuilder">The model builder</param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Configurations.Add(new Entities.Maps.UserMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.GroupMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PermissionMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.ParamMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PageTemplateMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PostTemplateMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PropertyTemplateMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.CategoryMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PermalinkMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PageMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PostMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.RegionMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PropertyMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.ContentMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.UploadMap()) ;

			base.OnModelCreating(modelBuilder);
		}

		/// <summary>
		/// Saves the changes made to the context.
		/// </summary>
		/// <returns>The numbe of changes saved.</returns>
		public override int SaveChanges() {
			foreach (var entity in this.ChangeTracker.Entries()) {
				//
				// Call the correct software trigger.
				//
				if (entity.Entity is Entities.BaseEntity) {
					if (entity.State == EntityState.Added || entity.State == EntityState.Modified)
						((Entities.BaseEntity)entity.Entity).OnSave(entity.State) ;
					else if (entity.State == EntityState.Deleted)
						((Entities.BaseEntity)entity.Entity).OnDelete() ;
				}
			}
			return base.SaveChanges();
		}
	}
}
