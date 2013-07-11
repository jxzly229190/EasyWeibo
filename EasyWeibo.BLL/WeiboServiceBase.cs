using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetDimension.Weibo;

namespace EasyWeibo.BLL
{
	/// <summary>
	/// 发送微薄服务
	/// </summary>
	public abstract class WeiboServiceBase
	{
		/// <summary>
		/// 微薄开始发送事件
		/// </summary>
		public EventHandler OnSendStart;
		/// <summary>
		/// 微薄发送结束事件
		/// </summary>
		public EventHandler<BatchSendEventArgs> OnSendFinished;
		/// <summary>
		/// 发送单条微薄
		/// </summary>
		/// <param name="message">微薄内容</param>
		public abstract void Send(WeiboMessage message);
		/// <summary>
		/// 批量发送微薄
		/// </summary>
		/// <param name="msgList">微薄内容列表</param>
		public abstract void BatchSend(List<WeiboMessage> msgList);

		/// <summary>
		/// 验证微薄SesssionKey(即Access token)的有效性
		/// </summary>
		/// <returns></returns>
		public abstract TokenResult VerifyAccessToken();
	}

	/// <summary>
	/// 批量发送微薄事件参数
	/// </summary>
	public class BatchSendEventArgs : EventArgs
	{
		/// <summary>
		/// 微薄总数量
		/// </summary>
		public int TotalCount { get; internal set; }

		/// <summary>
		/// 成功发送数量
		/// </summary>
		public int SuccessCount { get; internal set; }
	}
}
