using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using EasyWeibo.Helper;

namespace EasyWeibo.BLL
{
	public abstract class OAuth2Base
	{
		protected WebClient Wc;
		public OAuth2Base()
		{
			Wc = new WebClient();
			Wc.Encoding = Encoding.UTF8;
			Wc.Headers.Add("Pragma", "no-cache");
		}
		#region 基础属性

		/// <summary>
		/// 返回的开放UserID。
		/// </summary>
		public abstract string PlatformUId { get; }

		/// <summary>
		/// 访问的Token
		/// </summary>
		public abstract string AccessToken
		{
			get;
		}
		
		/// <summary>
		/// 获取Refresh Token(新浪微博暂时还不支持）
		/// </summary>
		public abstract string RefreshToken { get; } 

		/// <summary>
		/// 过期时间（目前还不支持）
		/// </summary>
		public DateTime ExpiresTime;

		/*
		/// <summary>
		/// 第三方账号头像地址（目前不支持）
		/// </summary>
		///public string HeadUrl = string.Empty;
		/// <summary>
		/// 首次请求时返回的Code
		/// </summary>
		/// 
		*/

		/// <summary>
		/// 获取Token结果的Json格式数据
		/// </summary>
		public string TokenResultJson { protected set; get; }
		public abstract Mappings.PlatForm Server
		{
			get;
		}
		#endregion

		#region 非公开的请求路径和Logo图片地址。

		public abstract string OAuthUrl
		{
			get;
		}
		public abstract string TokenUrl
		{
			get;
		}
		public abstract string ImgUrl
		{
			get;
		}
		#endregion

		#region WebConfig对应的配置【AppKey、AppSercet、CallbackUrl】
		public virtual string AppKey
		{
			get
			{
				return StringParserHelper.GetConfig(Server.ToString() + ".AppKey");
			}
		}
		public virtual string AppSecret
		{
			get
			{
				return StringParserHelper.GetConfig(Server.ToString() + ".AppSercet");
			}
		}
		public virtual string CallbackUrl
		{
			get
			{
				return StringParserHelper.GetConfig(Server.ToString() + ".CallbackUrl");
			}
		}
		public virtual string BaseUrl
		{
			get 
			{
				return StringParserHelper.GetConfig(Server.ToString() + ".BaseUrl");
			}
		}
		#endregion

		#region 基础方法

		/// <summary>
		/// 获得Token
		/// </summary>
		/// <returns></returns>
		protected string GetToken(string method,string code)
		{
			string result;
			try
			{
				string para = "grant_type=authorization_code&client_id=" + AppKey + "&client_secret=" + AppSecret + "&code=" + code + "&state=" + Server;
				para += "&redirect_uri=" + System.Web.HttpUtility.UrlEncode(CallbackUrl) + "&rnd=" + DateTime.Now.Second;
				if (method == "POST")
				{
					if (string.IsNullOrEmpty(Wc.Headers["Content-Type"]))
					{
						Wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					}
					result = Wc.UploadString(TokenUrl, method, para);
				}
				else
				{
					result = Wc.DownloadString(TokenUrl + "?" + para);
				}
			}
			catch (Exception err)
			{
				throw;
			}
			return result;
		}
		/// <summary>
		/// 获取是否通过授权。
		/// </summary>
		public bool Authorize(string code)
		{
			if (!string.IsNullOrEmpty(code))
			{
				this.TokenResultJson = GetToken("POST", code);//一次性返回数据。
				return true;
			}
			return false;
		}

		/// <param name="bindAccount">返回绑定的账号（若未绑定返回空）</param>
		
		#endregion

		#region 关联绑定账号

		/// <summary>
		/// 读取已经绑定的账号
		/// </summary>
		/// <returns></returns>
		public string GetBindAccount()
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// 添加绑定账号
		/// </summary>
		/// <param name="bindAccount"></param>
		/// <returns></returns>
		public bool SetBindAccount(string bindAccount)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
	
}
