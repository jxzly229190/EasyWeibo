using System;
using System.Collections.Generic;
using System.Web.SessionState;
using EasyWeibo.DAL;
using EasyWeibo.Model;
using NetDimension.Weibo;

namespace EasyWeibo.BLL
{
	public class SinaWeiboService:WeiboServiceBase
	{
		Client sinaClient;
		private string sessionKey;
		private PlatFormInfoAccessor accessor;
		public SinaWeiboService(string sessionKey)
		{
			accessor=new PlatFormInfoAccessor();
			this.sessionKey = sessionKey;
			sinaClient = InitializeSinaClient();
		}

		public override void Send(WeiboMessage message)
		{			
			TokenResult tokenResult = VerifyAccessToken(sinaClient);

			try
			{
				if (tokenResult == TokenResult.Success)
				{
					if (message.PicUrl != null)
					{
						var entity = sinaClient.API.Entity.Statuses.UploadUrlText(message.Content + message.Url, message.PicUrl);
					}
					else
					{
						var entity = sinaClient.API.Entity.Statuses.Update(message.Content + message.Url);
					}
				}
				else
				{
					throw new CustomException.TokenVerificationException() { TokenResult = tokenResult, Message = "Token异常" };
				}
			}
			catch (Exception ex)
			{
				throw new CustomException.SendWeiboException() { Message = "发送微薄出错：" + ex.Message };
			}
		}

		private Client InitializeSinaClient()
		{
			if (!string.IsNullOrEmpty(sessionKey))//检查是否存在SessionKey，后续可能还要从数据库去取
			{
				OAuth2Base sinaAuth2 = new SinaWeiboOAuth2();
				OAuth auth = new OAuth(sinaAuth2.AppKey, sinaAuth2.AppSecret, sessionKey, null);
				Client sinaClient = new Client(auth);
				return sinaClient;
			}
			else
			{
				throw new CustomException.NullWeiboSessionKeyException();
			}
		}

		public override TokenResult VerifyAccessToken()
		{
			return VerifyAccessToken(sinaClient);
		}

		public override void SavePlatformInfo(platforminfo entity)
		{
			var accessor=new PlatFormInfoAccessor();
			accessor.AddEntity(entity);
		}

		private TokenResult VerifyAccessToken(Client sinaClient)
		{
			TokenResult tokenResult;
			try
			{
				tokenResult = sinaClient.OAuth.VerifierAccessToken();
			}
			catch (Exception ex)
			{
				throw new CustomException.TokenVerificationException() { Message = "验证SessionKey出现网络异常:" + ex.Message };
			}
			return tokenResult;
		}

		public override void BatchSend(List<WeiboMessage> msgList)
		{
			throw new NotImplementedException();
		}

		public platforminfo GetPlatformBySessionKey(string key)
		{
			return accessor.GetPlatFormInfoBySessionKey(key);
		}

		public void UpdateWeiboInfo(platforminfo info)
		{
			accessor.UpdateEntity(info);
		}

		public platforminfo SavePlatforminfo(OAuth2Base oa, long userId)
		{
			platforminfo platformInfo;
			platformInfo = new platforminfo();
			var user = this.sinaClient.API.Entity.Users.Show(oa.PlatformUId);
			if (user != null)
			{
				platformInfo.Nick = user.Name;
				platformInfo.PlatformUserId = user.ID;
				platformInfo.UserId = userId;
				platformInfo.Platform = (int) Helper.Mappings.PlatForm.SinaWeiBo; //新浪微博
				platformInfo.SessionKey = oa.AccessToken;
				platformInfo.AuthDate = DateTime.Now;
				platformInfo.ExpireDate = oa.ExpireTime;
				platformInfo.Refresh_token = sinaClient.OAuth.RefreshToken;
				return accessor.AddEntity(platformInfo); //保存
			}
			return null;
		}
	}
}
