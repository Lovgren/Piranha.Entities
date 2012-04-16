using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Piranha.Repository
{
	/// <summary>
	/// Abstract base repository for all base entities.
	/// </summary>
	/// <typeparam name="T">The entity type</typeparam>
	public abstract class BaseRepository<T> : IDisposable where T : Entities.BaseEntity<T>
	{
		/// <summary>
		/// Gets the entity identifies by the given id.
		/// </summary>
		/// <param name="id">The entity id</param>
		/// <returns>A single entity</returns>
		public virtual T GetSingle(Guid id) {
			using (var db = new Data.PiranhaContext()) {
				return db.Set<T>().Where(t => t.Id == id).Single() ;
			}
		}

		/// <summary>
		/// Gets the first entity matching the given criterias.
		/// </summary>
		/// <param name="where">Where expression</param>
		/// <returns>A single entity</returns>
		public virtual T First(Expression<Func<T, bool>> where) {
			return Query(where).First() ;
		}

		/// <summary>
		/// Gets the first entity matching the given criterias.
		/// </summary>
		/// <typeparam name="TKey">The order by key</typeparam>
		/// <param name="where">Where expression</param>
		/// <param name="order">Order by expression</param>
		/// <returns>A single entity</returns>
		public virtual T First<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order) {
			return Query(where).OrderBy(order).First() ;
		}

		/// <summary>
		/// Gets the entities matching the given criterias.
		/// </summary>
		/// <param name="where">Optional where expression</param>
		/// <returns>A list of entities</returns>
		public virtual List<T> Get(Expression<Func<T, bool>> where = null) {
			return Query(where).ToList() ;
		}

		/// <summary>
		/// Gets the entities ordered.
		/// </summary>
		/// <typeparam name="TKey">The order by key</typeparam>
		/// <param name="order">Order by expression</param>
		/// <returns>A list of entities</returns>
		public virtual List<T> GetOrdered<TKey>(Expression<Func<T, TKey>> order) {
			return Query().OrderBy(order).ToList() ;
		}

		/// <summary>
		/// Gets the entities matching the given criterias ordered.
		/// </summary>
		/// <typeparam name="TKey">The order by key</typeparam>
		/// <param name="where">Where expression</param>
		/// <param name="order">Order by expression</param>
		/// <returns>A list of entities</returns>
		public virtual List<T> GetOrdered<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order) {
			return Query(where).OrderBy(order).ToList() ;
		}

		/// <summary>
		/// Disposes the repository
		/// </summary>
		public virtual void Dispose() {}

		#region Protected methods
		/// <summary>
		/// Gets the entities matching the given criterias.
		/// </summary>
		/// <param name="where">Optional where expression</param>
		/// <returns>A list of entities</returns>
		protected virtual IQueryable<T> Query(Expression<Func<T, bool>> where = null) {
			using (var db = new Data.PiranhaContext()) {
				if (where == null)
					return db.Set<T>() ;
				else return db.Set<T>().Where(where) ;
			}
		}
		#endregion
	}
}
