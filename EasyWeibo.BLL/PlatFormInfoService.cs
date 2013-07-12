using System.Collections.Generic;
using EasyWeibo.DAL;
using EasyWeibo.Helper;
using EasyWeibo.Model;

namespace EasyWeibo.BLL
{
	public class PlatFormInfoService
	{
		private PlatFormInfoAccessor platformAccessor;
		public PlatFormInfoService()
		{
			platformAccessor = new PlatFormInfoAccessor();
		}

		public List<platforminfo> GetPlatFormInfoByNickName(string nickName)
		{
			return platformAccessor.GetPlatFormInfoByNickName(nickName);
		}

		public platforminfo GetPlatFormInfoByNickNameAndPlatFormId(string nickName, Mappings.PlatForm platformId)
		{
			return platformAccessor.GetPlatFormInfoByNickNameAndPlatFormId(nickName, (int)platformId);
		}

		public void SavePlatFormInfo(platforminfo info)
		{
			platformAccessor.SavePlatFormInfo(info);
		}
	}
}
