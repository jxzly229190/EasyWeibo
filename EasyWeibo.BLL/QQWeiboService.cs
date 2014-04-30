namespace EasyWeibo.BLL
{
    using System;

    using EasyWeibo.BLL.CustomException;
    using EasyWeibo.DAL;
    using EasyWeibo.Helper;
    using EasyWeibo.Model;

    using NetDimension.Weibo;

    using QWeiboSDK;

    public class QQWeiboService:WeiboServiceBase
    {
        private PlatFormInfoAccessor accessor;

        private QWeiboSDK.Oauthkey2 oauthKey;

        public QQWeiboService(string appKey,string appSecret,string tokenKey,string openId)
        {
            oauthKey = new Oauthkey2(appKey, appSecret);
            oauthKey.tokenKey = tokenKey;
            oauthKey.openId = openId;
            //oauthKey.tokenSecret = accessSecret;
            accessor = new PlatFormInfoAccessor();
        }

        public override void Send(Model.WeiboMessage message)
        {
            try
            {
                var t = new t(oauthKey, "Json");
                var result = t.add(message.Content, "127.0.0.1", "", "");
                if (string.IsNullOrWhiteSpace(result) || Helper.StringParserHelper.GetJosnValue(result, "errcode") != "0")
                {
                    throw new SendWeiboException(Helper.StringParserHelper.GetJosnValue(result, "msg"));
                }

            }
            catch (Exception exception)
            {
                throw new SendWeiboException(exception.Message);
            }
        }

        public override void BatchSend(System.Collections.Generic.List<Model.WeiboMessage> msgList)
        {
            throw new System.NotImplementedException();
        }

        public platforminfo GetPlatformBySessionKey(string key)
        {
            return accessor.GetPlatFormInfoBySessionKey(key);
        }

        public void UpdateQQWeiboInfo(platforminfo info)
        {
            accessor.UpdateEntity(info);
        }

        public platforminfo SavePlatforminfo(OAuth2Base oa, long userId)
        {
            platforminfo platformInfo = new platforminfo();
            var userJson = new user(oauthKey, "json").info();
            if (string.IsNullOrWhiteSpace(userJson)
                || (!string.IsNullOrWhiteSpace(Helper.StringParserHelper.GetJosnValue(userJson, "errcode "))
                    && Helper.StringParserHelper.GetJosnValue(userJson, "errcode ") != "0"))
            {
                throw new ArgumentNullException("获取用户信息失败");
            }

            platformInfo.Nick = Helper.StringParserHelper.GetJosnValue(userJson, "nick");
            platformInfo.PlatformUserId = Helper.StringParserHelper.GetJosnValue(userJson, "name");
            platformInfo.UserId = userId;
            platformInfo.Platform = Helper.Mappings.PlatForm.QQWeiBo.ToString("G"); //新浪微博
            platformInfo.SessionKey = oa.AccessToken;
            platformInfo.AuthDate = DateTime.Now;
            platformInfo.OpenId = (oa as QQWeiboOAuth2).OpenID;
            platformInfo.ExpireDate = oa.ExpireTime;
            platformInfo.Refresh_token = oa.RefreshToken;
            return accessor.AddEntity(platformInfo); //保存
        }

        public override NetDimension.Weibo.TokenResult VerifyAccessToken()
        {
            throw new System.NotImplementedException();
        }

        public override void SavePlatformInfo(platforminfo entity)
        {
            this.accessor.AddOrUpdatePlatFormInfo(entity);
        }
    }
}