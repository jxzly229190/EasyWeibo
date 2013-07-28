using System;
using EasyWeibo.Helper;
using EasyWeibo.Model;
using Top.Api.Domain;

namespace EasyWeibo.BLL
{
	public class OAuthService
	{
		public userinfo RegisterTaoBaoSession(OAuth2Base oa,string code)
		{
			if(!string.IsNullOrEmpty(code)&&oa!=null)
			{
			    if(oa.Authorize(code))
			    {
			    	string sessionKey;
					if (oa.Server==Mappings.PlatForm.TaoBao)
					{
						var tbInfo = (new TaobaoService()).RegisterTaoBaoSession(oa);
						if (tbInfo != null) return tbInfo;
					}
			    }
			}
			return null;
		}

		public platforminfo RegisterPlatformSession(OAuth2Base oa,string code,long UID)
		{
			if (oa != null && oa.Authorize(code))
			{
				switch (oa.Server)
				{
					case Mappings.PlatForm.SinaWeiBo:
						return this.RegisterSinaWeiboPlatform(oa, UID);
					default:
						return null;
				}
			}
			if(oa==null)
				throw new NullReferenceException("oa 为null");
			throw new Exception("认证失败");
		}


		public platforminfo RegisterSinaWeiboPlatform(OAuth2Base oa, long userId)
		{
			if (oa != null&&!string.IsNullOrEmpty(oa.AccessToken))
			{
				var service = new SinaWeiboService(oa.AccessToken);
				var platformInfo = service.GetPlatformBySessionKey(oa.AccessToken);

				if (platformInfo != null)
				{
					platformInfo.AuthDate = DateTime.Now;
					platformInfo.ExpireDate = oa.ExpireTime;
					platformInfo.Refresh_token = "";
					service.UpdateWeiboInfo(platformInfo);
					return platformInfo;
				}

				return service.SavePlatforminfo(oa, userId);
			}
			else
			{
				throw new NullReferenceException("Auth2SinaWeibo 对象为空");
			}
		}

		
	}

}
