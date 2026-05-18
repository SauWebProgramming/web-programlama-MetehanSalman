using Microsoft.EntityFrameworkCore;
using SecondHandSales.Data;

namespace SecondHandSales.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<T> _dbSet;

		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public T GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}

		public void Delete(int id)
		{
			var entity = _dbSet.Find(id);
			if (entity != null)
			{
				_dbSet.Remove(entity);
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}