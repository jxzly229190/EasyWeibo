using System;
using System.Collections.Generic;
using System.Web.SessionState;
using EasyWeibo.Authorize;
using EasyWeibo.Model;
using NetDimension.Weibo;
using EasyWeibo.BLL.CustomException;

namespace EasyWeibo.BLL
{
	public class SinaWeiboService:WeiboServiceBase
	{
		Client sinaClient;
		private string sessionKey;
		public SinaWeiboService(string sessionKey)
		{
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
				OAuth auth;
				auth = new OAuth(sinaAuth2.AppKey, sinaAuth2.AppSercet, sessionKey, null);
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
	}
}
