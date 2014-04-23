using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWeibo.Model;
using EasyWeibo.Helper;
using EasyWeibo.DAL.Base;

namespace EasyWeibo.DAL
{
	public class PlatFormInfoAccessor:AccessorBase<platforminfo>
	{

		public List<platforminfo> GetPlatFormInfoByNickName(string nickName)
		{
			return GetEntities(info => info.Nick == nickName).ToList();
		}

		public platforminfo GetPlatFormInfoByNickNameAndPlatFormId(string nickName, string platformId)
		{
			return GetEntities(info => info.Nick == nickName && info.Platform == platformId).FirstOrDefault();
		}

		public platforminfo GetPlatFormInfoBySessionKey(string sessionKey)
		{
			return GetEntities(info => info.SessionKey == sessionKey).FirstOrDefault();
		}

		public platforminfo AddPlatFormInfo(platforminfo info)
		{
			try
			{
				return AddEntity(info);
			}
			catch(Exception ex)
			{
				throw new Exception("Can`t add platforminfo " + ex.Message);
			}
		}

		public void AddOrUpdatePlatFormInfo(platforminfo info)
		{
			try
			{
				platforminfo existingRecord = GetEntities(record => record.SessionKey == info.SessionKey && record.UserId == info.UserId).FirstOrDefault();
				if (existingRecord != null)
				{
					UpdateEntity(existingRecord);
				}
				else
				{
					AddEntity(info);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed to save platformInfo" + ex.Message);
			}
		}
	}
}
