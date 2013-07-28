using System;
using System.Data;
using System.Linq;
using EasyWeibo.Model;

namespace EasyWeibo.DAL.Base
{ 
	public class AccessorBase<T> where T: class, new()
	{
		protected EasyadsEntities DbOperator;

		/// <summary>
		/// 构建对象
		/// </summary>
		public AccessorBase()
		{
			 DbOperator= new EasyadsEntities();
		}

		/// <summary>
		/// 根据表达式获取多个实体
		/// </summary>
		/// <param name="whereLambda"></param>
		/// <returns></returns>
		public IQueryable<T> GetEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
		{
			return DbOperator.CreateObjectSet<T>().Where(whereLambda);
		}

		/// <summary>
		/// 从数据库移除对象
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public int RemoveEntity(T model)
		{
			DbOperator.CreateObjectSet<T>().Attach(model);
			DbOperator.ObjectStateManager.ChangeObjectState(model, EntityState.Deleted);
			return DbOperator.SaveChanges();
		}

		/// <summary>
		/// 根据表达式批量移除对象
		/// </summary>
		/// <param name="whereLambda"></param>
		/// <returns></returns>
		public int RemoveEntitiesByExpress(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
		{
			var temp = DbOperator.CreateObjectSet<T>().Where(whereLambda);
			foreach (var entity in temp)
			{
				DbOperator.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
			}
			return DbOperator.SaveChanges();
		}

		/// <summary>
		/// 添加一个对象到数据库
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public T AddEntity(T entity)
		{
			DbOperator.CreateObjectSet<T>().AddObject(entity);
			DbOperator.SaveChanges();
			return entity;
		}

		/// <summary>
		/// 更新对象到数据库
		/// </summary>
		/// <param name="entity"></param>
		public void UpdateEntity(T entity)
		{
			try
			{
				DbOperator.CreateObjectSet<T>().Attach(entity);
			}
			catch (InvalidOperationException exception)
			{
				//实体已经附加，忽略此异常继续执行。
			}
			DbOperator.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
			DbOperator.SaveChanges();
		}
	}
}
