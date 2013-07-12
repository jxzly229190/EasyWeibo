using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWeibo.Helper
{
	public class Mappings
	{
		/// <summary>
		/// 提供授权的服务商
		/// </summary>
		public enum PlatForm
		{
			/// <summary>
			/// 
			/// </summary>
			None = 0,
			/// <summary>
			/// 新浪微博
			/// </summary>
			SinaWeiBo,
			/// <summary>
			/// 腾讯QQ
			/// </summary>
			QQ,
			/// <summary>
			/// 淘宝网
			/// </summary>
			TaoBao,
			/// <summary>
			/// 人人网（未支持）
			/// </summary>
			RenRen,
			/// <summary>
			/// 腾讯微博（未支持）
			/// </summary>
			QQWeiBo,
			/// <summary>
			/// 开心网（未支持）
			/// </summary>
			KaiXin,
			/// <summary>
			/// 飞信（未支持）
			/// </summary>
			FeiXin,
		}
	}
}
