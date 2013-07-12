using System;
using System.Collections.Generic;
using EasyWeibo.Helper;

namespace EasyWeibo.BLL
{
	public class OAuth2Factory
	{		
		/// <summary>
		/// 读取或设置当前Session存档的授权类型。 (注销用户时可以将此值置为Null)
		/// </summary>
		public static OAuth2Base SessionOAuth
		{
			get
			{
				if (System.Web.HttpContext.Current.Session != null)
				{
					object o = System.Web.HttpContext.Current.Session["OAuth2"];
					if (o != null)
					{
						return o as OAuth2Base;
					}
				}
				return null;
			}
			set
			{
				System.Web.HttpContext.Current.Session["OAuth2"] = value;
			}
		}
		static Dictionary<string, OAuth2Base> _ServerList;
		/// <summary>
		/// 获取所有的类型（新开发的OAuth2需要到这里注册添加一下）
		/// </summary>
		public static Dictionary<string, OAuth2Base> ServerList
		{
			get
			{
				if (_ServerList == null)
				{
					_ServerList = new Dictionary<string, OAuth2Base>(StringComparer.OrdinalIgnoreCase);
					_ServerList.Add(Mappings.PlatForm.SinaWeiBo.ToString(), new SinaWeiboOAuth2());//新浪微博
					//_ServerList.Add(OAuthServer.QQ.ToString(), new QQOAuth());//QQ微博
					_ServerList.Add(Mappings.PlatForm.TaoBao.ToString(), new TaoBaoOAuth2());//淘宝
				}
				return _ServerList;
			}
		}

		static OAuth2Base _oAuth2Object;
		public static OAuth2Base TaoBaoAuther
		{
			get
			{
				if (_oAuth2Object == null)
				{
					_oAuth2Object = new TaoBaoOAuth2();
				}
				return _oAuth2Object;
			}
		}
	}
}
