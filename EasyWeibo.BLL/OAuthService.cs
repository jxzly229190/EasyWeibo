using EasyWeibo.Helper;
namespace EasyWeibo.BLL
{
	public class OAuthService
	{
		public void RegisterPlatformSession(OAuth2Base oa,string code)
		{
			if(!string.IsNullOrEmpty(code)&&oa!=null)
			{
			    if(oa.Authorize(code))
			    {
					switch (oa.server)
					{
						case Mappings.PlatForm.SinaWeiBo:
							//todo:保存数据进入数据库或者Cache中
							break;
						default:
							//todo:保存数据进入数据库或者Cache中
							break;
					}
			    }
			}
		}
	}

}
