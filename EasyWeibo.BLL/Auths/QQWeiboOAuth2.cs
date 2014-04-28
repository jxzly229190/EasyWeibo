namespace EasyWeibo.BLL
{
    using System;

    using EasyWeibo.Helper;

    public class QQWeiboOAuth2:OAuth2Base
    {

        public override string PlatformUId
        {
            get { return Helper.StringParserHelper.QueryString(TokenResultJson, "name"); }
        }

        public override string AccessToken
        {
            get { return Helper.StringParserHelper.QueryString(this.TokenResultJson, "access_token"); }
        }

        public string OpenID
        {
            get { return Helper.StringParserHelper.QueryString(this.TokenResultJson, "openid"); }
        }

        public string Nick
        {
            get { return Helper.StringParserHelper.QueryString(this.TokenResultJson, "nick"); }
        }

        public string Name
        {
            get
            {
                return Helper.StringParserHelper.QueryString(this.TokenResultJson, "name");
            }
        }

        public override string RefreshToken
        {
            get { return Helper.StringParserHelper.QueryString(this.TokenResultJson, "refresh_token"); }
        }

        public override System.DateTime ExpireTime
        {
            get { return DateTime.Now.AddMilliseconds(Int32.Parse(Helper.StringParserHelper.QueryString(this.TokenResultJson, "expires_in"))); }
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