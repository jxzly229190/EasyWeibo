namespace EasyWeibo.App.Common
{
    using System.Configuration;

    public class CommonParas
    {
        public static string TaobaoURL
        {
            get
            {
                var url = ConfigurationManager.AppSettings["TaoBao.BaseUrl"];
                if (string.IsNullOrWhiteSpace(url))
                {
                    throw new ConfigurationErrorsException("TaoBao.BaseUrl 配置为空");
                }

                return url;
            }
        }
    }
}