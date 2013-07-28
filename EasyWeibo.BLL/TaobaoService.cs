using System;
using System.Collections.Generic;
using EasyWeibo.DAL;
using EasyWeibo.Helper;
using EasyWeibo.Model;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;

namespace EasyWeibo.BLL
{
	public class TaobaoService
	{
		private TaoBaoOAuth2 authModel;
		private UserInfoAccessor uiAccessor;
		public TaobaoService()
		{
			authModel = new TaoBaoOAuth2();
			uiAccessor = new UserInfoAccessor();
		}

		public User GetSellerUserInfo(string sessionKey)
		{
			ITopClient client = new DefaultTopClient(authModel.BaseUrl, authModel.AppKey, authModel.AppSecret);
			UserSellerGetRequest req = new UserSellerGetRequest();
			req.Fields = "user_id,nick,sex";
			UserSellerGetResponse response = client.Execute(req, sessionKey);
			return response.User;
		}

		public userinfo GetUserInfoBySessionKey(string sessionKey)
		{
			return uiAccessor.GetUserInfoBySessionKey(sessionKey);
		}

		public userinfo GetUserInfoByTBUserId(string tbUserId)
		{
			return uiAccessor.GetUserInfoByTBUserId(tbUserId);
		}
		public void SaveUserInfo(userinfo userInfo)
		{
			uiAccessor.AddOrUpdateUserInfo(userInfo);
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
			userinfo info = this.GetUserInfoBySessionKey(sessionKey);
			if (info == null)
			{
				User user = this.GetSellerUserInfo(sessionKey);
				info = this.GetUserInfoByTBUserId(user.UserId.ToString());
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
				this.SaveUserInfo(info);
			}
			return info;
		}
	}
}
