using System;
using EasyWeibo.Helper;
using EasyWeibo.Model;
using Top.Api.Domain;

namespace EasyWeibo.BLL
{
	public class OAuthService
	{
		public OAuth2Model RegisterPlatformSession(OAuth2Base oa,string code)
		{
			if(!string.IsNullOrEmpty(code)&&oa!=null)
			{
			    if(oa.Authorize(code))
			    {
			    	string sessionKey;
					switch (oa.Server)
					{
						case Mappings.PlatForm.TaoBao:
							var tbInfo = RegisterTaoBaoSession(oa);
							return new OAuth2Model() {AccessToken = tbInfo.AccessToken, Nick = tbInfo.Nick, UID = tbInfo.TB_UserId};
						case Mappings.PlatForm.SinaWeiBo:
							platforminfo sinaInfo = new platforminfo();
							
							return new OAuth2Model() {AccessToken = oa.AccessToken,UID = oa.PlatformUId};
							//todo:保存数据进入数据库或者Cache中
						default:
							//todo:保存数据进入数据库或者Cache中
							return new OAuth2Model() {AccessToken = oa.AccessToken,UID = oa.PlatformUId};
					}
			    }
			}
			return null;
		}

		private static userinfo RegisterTaoBaoSession(OAuth2Base oa)
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
			TaobaoService tbService = new TaobaoService();
			userinfo info = tbService.GetUserInfoBySessionKey(sessionKey);
			if (info == null)
			{
				User user = tbService.GetSellerUserInfo(sessionKey);
				info = tbService.GetUserInfoByTBUserId(user.UserId.ToString());
				if (info == null)
				{
					info = new userinfo();
					info.Nick = user.Nick;
					info.TB_UserId = user.UserId.ToString();
					info.AuthDate = DateTime.Now;
				}

				info.AccessToken = sessionKey;
				if ((oa as TaoBaoOAuth2).IsUseSandBox)
				{
					info.RefreshToken = sessionKey;
					info.ExpireTime = DateTime.Now.AddDays(1); //Test case, in the real environment, it is not like this.
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
