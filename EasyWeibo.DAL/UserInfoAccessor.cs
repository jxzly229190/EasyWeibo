using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWeibo.Model;
using EasyWeibo.DAL.Base;

namespace EasyWeibo.DAL
{
	public class UserInfoAccessor: AccessorBase<userinfo>
	{
		public userinfo GetUserInfoBySessionKey(string sessionKey)
		{
			return this.GetEntities(info => info.AccessToken == sessionKey).FirstOrDefault();
		}

		public void AddOrUpdateUserInfo(userinfo user)
		{
			try
			{
				var existedRecord = GetEntities(record => record.TB_UserId == user.TB_UserId).FirstOrDefault();
				
				if (existedRecord != null)
				{
					user.UserId = existedRecord.UserId;
					existedRecord = user;
					this.UpdateTBUserInfo(existedRecord);
				}
				else
				{
					this.AddTBUserInfo(user);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Can't save userinfo " + ex.Message);
			}
		}

		public userinfo GetUserInfoByTBUserId(string tbUserId)
		{
			return GetEntities(info => info.TB_UserId == tbUserId).FirstOrDefault();
		}

		public userinfo AddTBUserInfo(userinfo tbUserInfo)
		{
			return this.AddEntity(tbUserInfo);
		}

		public void UpdateTBUserInfo(userinfo tbUserInfo)
		{
			this.UpdateEntity(tbUserInfo);
		}
	}
}
