using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EasyWeibo.Model;

namespace EasyWeibo.DAL.Base
{ 
	public abstract class AccessorBase<T> where T: class, new()
	{
		protected EasyadsEntities dbOperator = new EasyadsEntities();

		/// <summary>
		/// 根据表达式获取多个实体
		/// </summary>
		/// <param name="whereLambda"></param>
		/// <returns></returns>
		public IQueryable<T> GetEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
		{
			return Queryable.Where(this.dbOperator.CreateObjectSet<T>(), whereLambda);
		}

		/// <summary>
		/// 从数据库移除对象
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public int RemoveEntity(T model)
		{
			dbOperator.CreateObjectSet<T>().Attach(model);
			dbOperator.ObjectStateManager.ChangeObjectState(model, EntityState.Deleted);
			return dbOperator.SaveChanges();
		}

		/// <summary>
		/// 根据表达式批量移除对象
		/// </summary>
		/// <param name="whereLambda"></param>
		/// <returns></returns>
		public int RemoveEntitiesByExpress(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
		{
			var temp = dbOperator.CreateObjectSet<T>().Where(whereLambda);
			foreach (var entity in temp)
			{
				dbOperator.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
			}
			return dbOperator.SaveChanges();
		}

	}
}
