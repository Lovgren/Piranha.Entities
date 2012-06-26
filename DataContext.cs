using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace Piranha
{
	/// <summary>
	/// The Piranha DbContext
	/// </summary>
	public class DataContext : DbContext
	{
		#region DbSets
		public DbSet<Entities.User> Users { get ; set ; }
		public DbSet<Entities.Group> Groups { get ; set ; }
		public DbSet<Entities.Permission> Permissions { get ; set ; }
		public DbSet<Entities.Param> Params { get ; set ; }
		public DbSet<Entities.PageTemplate> PageTemplates { get ; set ; }
		public DbSet<Entities.PostTemplate> PostTemplates { get ; set ; }
		public DbSet<Entities.Permalink> Permalinks { get ; set ; }
		public DbSet<Entities.Category> Categories { get ; set ; }
		public IQueryable<Entities.Property> Properties { get { return Set<Entities.Property>().Where(p => !p.IsDraft) ; } }
		public IQueryable<Entities.Post> Posts { get { return Set<Entities.Post>().Where(p => !p.IsDraft) ; } }
		#endregion

		/// <summary>
		/// Default constructor. Creates a new db context.
		/// </summary>
		public DataContext() : base("Piranha") {
			((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += 
				new System.Data.Objects.ObjectMaterializedEventHandler(OnEntityLoad) ;
		}

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
			modelBuilder.Configurations.Add(new Entities.Maps.PermalinkMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.CategoryMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PropertyMap()) ;
			modelBuilder.Configurations.Add(new Entities.Maps.PostMap()) ;

			base.OnModelCreating(modelBuilder);
		}

		/// <summary>
		/// Event called when an entity has been loaded.
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">Event arguments</param>
		void OnEntityLoad(object sender, System.Data.Objects.ObjectMaterializedEventArgs e) {
			if (e.Entity is Entities.BaseEntity)
				((Entities.BaseEntity)e.Entity).OnLoad() ;
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
					if (entity.State == EntityState.Added || entity.State == EntityState.Modified) {
						((Entities.BaseEntity)entity.Entity).OnSave(entity.State) ;
						//((Entities.BaseEntity)entity.Entity).OnInvalidate(entity.State) ;
					} else if (entity.State == EntityState.Deleted) {
						((Entities.BaseEntity)entity.Entity).OnDelete() ;
						//((Entities.BaseEntity)entity.Entity).OnInvalidate(entity.State) ;
					}
				}
			}
			return base.SaveChanges();
		}
	}
}
