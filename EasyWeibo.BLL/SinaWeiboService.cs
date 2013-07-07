using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EasyWeibo.BLL
{
	class SinaWeiboService:WeiboServiceBase
	{
		public override void Send(WeiboMessage message)
		{
			
		}

		public override void BatchSend(List<WeiboMessage> msgList)
		{
			throw new NotImplementedException();
		}
	}
}
