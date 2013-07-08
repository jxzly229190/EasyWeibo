using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using EasyWeibo.Authorize;
using NetDimension.Weibo;

namespace EasyWeibo.BLL
{
	public class SinaWeiboService:WeiboServiceBase
	{
		OAuth2Base sinaAuth2 =new SinaWeiboOAuth2();
		OAuth auth;
		public override void Send(WeiboMessage message)
		{
			HttpSessionState session = Helper.ContextHelper.CurrentSession;
			if (session["sessionKey"] != null)//检查是否存在SessionKey，后续可能还要从数据库去取
			{
				auth=new OAuth(sinaAuth2.AppKey,sinaAuth2.AppSercet,session["sessionKey"].ToString(),null);
				Client sinaClient = new Client(auth);
				TokenResult tokenResult;

				try
				{
					tokenResult = sinaClient.OAuth.VerifierAccessToken();
				}
				catch (Exception ex)
				{
					throw new CustomException.TokenVerificationException() { Message = "验证SessionKey出现网络异常:"+ex.Message };
				}

				try
				{
					if (tokenResult == TokenResult.Success)
					{
						if (message.PicUrl != null)
						{
							var entity = sinaClient.API.Entity.Statuses.UploadUrlText(message.Content + message.Url, message.PicUrl);
						}
					}
					else
					{
						throw new CustomException.TokenVerificationException() { TokenResult = tokenResult, Message = "Token异常" };
					}
				}
				catch(Exception ex)
				{
					throw new CustomException.SendWeiboException() { Message ="发送微薄出错：" + ex.Message };
				}
			}
		}

		public override void BatchSend(List<WeiboMessage> msgList)
		{
			throw new NotImplementedException();
		}

		private void Authorize()
		{

		}
	}
}
