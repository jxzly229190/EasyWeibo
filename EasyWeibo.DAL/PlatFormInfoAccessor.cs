using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWeibo.Model;
using EasyWeibo.Helper;

namespace EasyWeibo.DAL
{
	public class PlatFormInfoAccessor
	{
		private EasyadsEntities ee;
		public PlatFormInfoAccessor()
		{
			ee = new EasyadsEntities();
		}

		public List<platforminfo> GetPlatFormInfoByNickName(string nickName)
		{
			return ee.platforminfo.Where(info => info.Nick == nickName).ToList();
		}

		public platforminfo GetPlatFormInfoByNickNameAndPlatFormId(string nickName, int platformId)
		{
			return ee.platforminfo.Where(info => info.Nick == nickName && info.Platform == platformId).FirstOrDefault();
		}

		public void AddOrUpdatePlatFormInfo(platforminfo info)
		{
			try
			{
				platforminfo existingRecord = ee.platforminfo.Where(record => record.SessionKey == info.SessionKey && record.UserId == info.UserId).FirstOrDefault();
				if (existingRecord != null)
				{
					info.ID = existingRecord.ID;
					existingRecord = info;
				}
				else
				{
					ee.platforminfo.AddObject(info);
				}
				ee.SaveChanges();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed to save platformInfo" + ex.Message);
			}
		}

		public platforminfo GetUserInfoBySessionKey(string sessionKey)
		{
			return ee.platforminfo.Where(info => info.SessionKey == sessionKey).FirstOrDefault();
		}
	}
}
