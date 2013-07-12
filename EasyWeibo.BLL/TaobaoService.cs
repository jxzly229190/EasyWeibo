using System.Collections.Generic;
using EasyWeibo.DAL;
using EasyWeibo.Helper;
using EasyWeibo.Model;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;

namespace EasyWeibo.BLL
{
	public class TaobaoService
	{
		private TaoBaoOAuth2 authModel;
		private IEnvConstHelper envHelper;

		public TaobaoService()
		{
			authModel = new TaoBaoOAuth2();
			if (authModel.IsUseSandBox)
			{ 
				envHelper = new SandboxEnvConstHelper();
			}
			else
			{
				envHelper = new FormalEnvConstHelper();
			}
		}

		public User GetSellerUserInfo(string sessionKey)
		{
			ITopClient client = new DefaultTopClient(envHelper.BaseUrl, envHelper.AppKey, envHelper.AppSecret);
			UserSellerGetRequest req = new UserSellerGetRequest();
			req.Fields = "user_id,nick,sex,seller_credit,type,has_more_pic,item_img_num,item_img_size,prop_img_num,prop_img_size,auto_repost,promoted_type,status,alipay_bind,consumer_protection,avatar,liangpin,sign_food_seller_promise,has_shop,is_lightning_consignment,has_sub_stock,is_golden_seller,vip_info,magazine_subscribe,vertical_market,online_gaming";
			UserSellerGetResponse response = client.Execute(req, sessionKey);
			if (response.User != null)
				return response.User;
			else
				return new User();
		}

		
	}
}
