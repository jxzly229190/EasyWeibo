using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWeibo;

namespace IDAL
{
	public class PlatFormInfoAccessor
	{
		private EasyadsEntities ee;
		public PlatFormInfoAccessor()
		{
			ee = new EasyadsEntities();
		}

		public void InsertPlatFormInfo(platforminfo info)
		{
			if (info != null)
			{
				ee.AddToplatforminfo(info);
				ee.SaveChanges();
			}
		}
	}
}
