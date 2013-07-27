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
			switch (oa.Server)
			{
				case Mappings.PlatForm.SinaWeiBo:
					var service = new SinaWeiboService(oa.AccessToken);
					return service.RegisterPlatform(oa, UID);
				default:
					return null;
			}
		}
		
	}

}
