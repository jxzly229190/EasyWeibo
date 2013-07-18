﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using EasyWeibo.Helper;

namespace EasyWeibo.BLL
{
	public abstract class OAuth2Base
	{
		protected WebClient wc = new WebClient();
		public OAuth2Base()
		{
			wc = new WebClient();
			wc.Encoding = Encoding.UTF8;
			wc.Headers.Add("Pragma", "no-cache");
		}
		#region 基础属性
		/// <summary>
		/// 返回的开放ID。
		/// </summary>
		public string openID = string.Empty;
		/// <summary>
		/// 访问的Token
		/// </summary>
		public abstract string AccessToken
		{
			get;
		}

		/// <summary>
		/// 过期时间
		/// </summary>
		public DateTime expiresTime;

		/// <summary>
		/// 第三方账号昵称
		/// </summary>
		public string nickName = string.Empty;

		/// <summary>
		/// 第三方账号头像地址
		/// </summary>
		public string headUrl = string.Empty;
		/// <summary>
		/// 首次请求时返回的Code
		/// </summary>
		/// 
		public string TokenResultJson { protected set; get; }
		public abstract Mappings.PlatForm server
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
				return StringParserHelper.GetConfig(server.ToString() + ".AppKey");
			}
		}
		public virtual string AppSecret
		{
			get
			{
				return StringParserHelper.GetConfig(server.ToString() + ".AppSercet");
			}
		}
		public virtual string CallbackUrl
		{
			get
			{
				return StringParserHelper.GetConfig(server.ToString() + ".CallbackUrl");
			}
		}
		public virtual string BaseUrl
		{
			get 
			{
				return StringParserHelper.GetConfig(server.ToString() + ".BaseUrl");
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
			string result = string.Empty;
			try
			{
				string para = "grant_type=authorization_code&client_id=" + AppKey + "&client_secret=" + AppSecret + "&code=" + code + "&state=" + server;
				para += "&redirect_uri=" + System.Web.HttpUtility.UrlEncode(CallbackUrl) + "&rnd=" + DateTime.Now.Second;
				if (method == "POST")
				{
					if (string.IsNullOrEmpty(wc.Headers["Content-Type"]))
					{
						wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					}
					result = wc.UploadString(TokenUrl, method, para);
				}
				else
				{
					result = wc.DownloadString(TokenUrl + "?" + para);
				}
			}
			catch (Exception err)
			{
				throw err;
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
