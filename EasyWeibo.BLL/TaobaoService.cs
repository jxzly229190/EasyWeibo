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
	}
}
