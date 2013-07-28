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
						var tbInfo = this.RegisterTaoBaoSession(oa);
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



		internal userinfo RegisterTaoBaoSession(OAuth2Base oa)
		{
			string sessionKey;
			if ((oa as TaoBaoOAuth2).IsUseSandBox)
			{
				sessionKey = "6101925c77e6ac6b8ddaa3606de6fd7d21401fc18e51eb43598702902";
			}
			else
			{
				sessionKey = oa.AccessToken;
			}
			var tbService = new TaobaoService();
			userinfo info = tbService.GetUserInfoBySessionKey(sessionKey);
			if (info == null)
			{
				User user = tbService.GetSellerUserInfo(sessionKey);
				info = tbService.GetUserInfoByTBUserId(user.UserId.ToString());
				if (info == null)
				{
					info = new userinfo();
				}
				info.Nick = user.Nick;
				info.TB_UserId = user.UserId.ToString();
				info.AuthDate = DateTime.Now;
				info.ExpireTime = DateTime.Now.AddDays(1); //Test case, in the real environment, it is not like this.
				info.LastLogin = DateTime.Now;

				info.AccessToken = sessionKey;
				if ((oa as TaoBaoOAuth2).IsUseSandBox)
				{
					info.RefreshToken = sessionKey;

				}
				else
				{
					info.RefreshToken = oa.RefreshToken;
					info.ExpireTime = oa.ExpireTime;
				}
				tbService.SaveUserInfo(info);
			}
			return info;
		}

		
	}

}
