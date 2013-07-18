using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWeibo.Model;

namespace EasyWeibo.DAL
{
	public class UserInfoAccessor
	{
		private EasyadsEntities ee;
		public UserInfoAccessor()
		{
			ee = new EasyadsEntities();
		}

		public userinfo GetUserInfoBySessionKey(string sessionKey)
		{
			return ee.userinfo.Where(info => info.AccessToken == sessionKey).FirstOrDefault();
		}

		public void AddOrUpdateUserInfo(userinfo info)
		{
			try
			{
				userinfo existingRecord = ee.userinfo.Where(record => record.TB_UserId == info.TB_UserId).FirstOrDefault();
				if (existingRecord != null)
				{
					info.UserId = existingRecord.UserId;
					existingRecord = info;
				}
				else
				{
					ee.userinfo.AddObject(info);
				}

				ee.SaveChanges();
			}
			catch(Exception ex)
			{
				throw new Exception("Can't save userinfo " + ex.Message);
			}
		}

		public userinfo GetUserInfoByTBUserId(string tbUserId)
		{
			return ee.userinfo.Where(info => info.TB_UserId == tbUserId).FirstOrDefault();
		}
	}
}
