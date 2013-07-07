using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWeibo.Authorize;
using Top.Api.Domain;

namespace EasyWeibo.BLL
{
	class OAuthService
	{

		public User RegisterNewClient(OAuth2Base oa,string code)
		{
			//if(!string.IsNullOrEmpty(code)&&oa!=null)
			//{
			//    if(oa.Authorize(code))
			//    {
			//        switch (oa.server)
			//        {
			//            case OAuthServer.TaoBao:
			//                return 
			//        }
			//    }
			//}

			return new User();
		}


	}

}
