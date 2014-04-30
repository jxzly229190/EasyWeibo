using System;
using EasyWeibo.Helper;
using EasyWeibo.Model;
using Top.Api.Domain;

namespace EasyWeibo.BLL
{
    using System.Linq;
    using System.Linq.Expressions;

    using EasyWeibo.DAL;

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
                    case Mappings.PlatForm.QQ:
				        return this.RegisterQQWeiboPlatform(oa, UID);
					default:
						return null;
				}
			}
			if(oa==null)
				throw new NullReferenceException("oa 为null");
			throw new Exception("认证失败");
		}

        public platforminfo RegisterQQWeiboPlatform(OAuth2Base oa, long userId)
        {
            if (oa != null && !string.IsNullOrEmpty(oa.AccessToken))
            {
                var qqOa = oa as QQWeiboOAuth2;
                var service = new QQWeiboService(oa.AppKey, oa.AppSecret, oa.AccessToken, qqOa.OpenID);
                var platformInfo = service.GetPlatformBySessionKey(oa.AccessToken);

                if (platformInfo != null)
                {
                    platformInfo.AuthDate = DateTime.Now;
                    platformInfo.ExpireDate = oa.ExpireTime;
                    platformInfo.Refresh_token = "";
                    platformInfo.OpenId = qqOa.OpenID;
                    platformInfo.Platform = Mappings.PlatForm.QQWeiBo.ToString("G");
                    service.UpdateQQWeiboInfo(platformInfo);
                    return platformInfo;
                }

                return service.SavePlatforminfo(oa, userId);
            }
            else
            {
                throw new NullReferenceException("Auth2QQWeibo 对象为空");
            }
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
                    platformInfo.Platform = Mappings.PlatForm.SinaWeiBo.ToString("G");
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

	    public platforminfo GetPlatforminfoByUserID(int userId)
	    {
	        return new PlatFormInfoAccessor().GetEntities(e => e.UserId == userId).FirstOrDefault(p => p.UserId == userId);
	    }

        public platforminfo QueryPlatforminfo(Expression<Func<platforminfo, bool>> selector)
        {
            return new PlatFormInfoAccessor().GetEntities(selector).FirstOrDefault();
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
