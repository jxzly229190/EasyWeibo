namespace EasyWeibo.BLL
{
    using System;

    using EasyWeibo.Helper;

    public class QQWeiboOAuth2:OAuth2Base
    {

        public override string PlatformUId
        {
            get { return Helper.StringParserHelper.GetJosnValue(TokenResultJson, "name"); }
        }

        public override string AccessToken
        {
            get { return Helper.StringParserHelper.GetJosnValue(this.TokenResultJson, "access_token"); }
        }

        public override string RefreshToken
        {
            get { return Helper.StringParserHelper.GetJosnValue(this.TokenResultJson, "refresh_token");}
        }

        public override System.DateTime ExpireTime
        {
            get { return DateTime.Now.AddMilliseconds(Int32.Parse(Helper.StringParserHelper.GetJosnValue(this.TokenResultJson, "expires_in"))); }
        }

        public override Helper.Mappings.PlatForm Server
        {
            get { return Mappings.PlatForm.QQ; }
        }

        public override string OAuthUrl
        {
            get
            {
                return
                    string.Format(
                        "https://open.t.qq.com/cgi-bin/oauth2/authorize?client_id={0}&response_type=code&redirect_uri={1}&state={2}",
                        this.AppKey,
                        this.CallbackUrl,
                        this.Server);
            }
        }

        public override string TokenUrl
        {
            get { return "https://open.t.qq.com/cgi-bin/oauth2/access_token"; }
        }

        public override string ImgUrl
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}