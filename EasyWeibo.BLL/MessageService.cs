namespace EasyWeibo.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EasyWeibo.DAL.Base;
    using EasyWeibo.Model;

    public class MessageService
    {
        private AccessorBase<message> accessor;

        public MessageService()
        {
            accessor=new AccessorBase<message>();
        }

        public List<message> GetMessages(int pageIndex, int pageSize, int userID)
        {
            var query = accessor.GetEntities(m => m.UserId == userID && m.State == 0);
            var query1 = query.OrderBy(u => u.ID);
            var query2 = query1.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query2.ToList();
        }

        public message Add(message message)
        {
            return accessor.AddEntity(message);
        }

        public void Update(message message)
        {
            accessor.UpdateEntity(message);
        }

        public void Remove(System.Linq.Expressions.Expression<Func<message, bool>> whereLambda)
        {
            accessor.RemoveEntitiesByExpress(whereLambda);
        }

        public message Single(int id)
        {
            return accessor.GetEntities(u => u.ID == id).FirstOrDefault();
        }
    }
}