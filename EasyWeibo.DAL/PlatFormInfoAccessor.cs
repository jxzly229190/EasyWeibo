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

		public void InsertPlatFormInfo(platforminfo info)
		{
			if (info != null)
			{
				ee.AddToplatforminfo(info);
				ee.SaveChanges();
			}
		}

		public List<platforminfo> GetPlatFormInfoByNickName(string nickName)
		{
			return ee.platforminfo.Where(info => info.Nick == nickName).ToList();
		}

		public platforminfo GetPlatFormInfoByNickNameAndPlatFormId(string nickName, int platformId)
		{
			return ee.platforminfo.Where(info => info.Nick == nickName && info.Platform == platformId).FirstOrDefault();
		}

		public void SavePlatFormInfo(platforminfo info)
		{
			try
			{
				ee.platforminfo.AddObject(info);
				ee.SaveChanges();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed to save platformInfo" + ex.Message);
			}
		}
	}
}
