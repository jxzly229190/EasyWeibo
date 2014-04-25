namespace EasyWeibo.BLL
{
    using System;

    using EasyWeibo.DAL;
    using EasyWeibo.Model;

    using NetDimension.Weibo;

    public class QQWeiboService:WeiboServiceBase
    {
        private PlatFormInfoAccessor accessor;

        public QQWeiboService()
        {
            accessor = new PlatFormInfoAccessor();
        }

        public override void Send(Model.WeiboMessage message)
        {
            throw new System.NotImplementedException();
        }

        public override void BatchSend(System.Collections.Generic.List<Model.WeiboMessage> msgList)
        {
            throw new System.NotImplementedException();
        }

        public platforminfo GetPlatformBySessionKey(string key)
        {
            return accessor.GetPlatFormInfoBySessionKey(key);
        }

        public void UpdateWeiboInfo(platforminfo info)
        {
            accessor.UpdateEntity(info);
        }

        public platforminfo SavePlatforminfo(OAuth2Base oa, long userId)
        {
            platforminfo platformInfo;
            platformInfo = new platforminfo();
            var user = this.sinaClient.API.Entity.Users.Show(oa.PlatformUId);
            if (user != null)
            {
                platformInfo.Nick = user.Name;
                platformInfo.PlatformUserId = user.ID;
                platformInfo.UserId = userId;
                platformInfo.Platform = Helper.Mappings.PlatForm.SinaWeiBo.ToString("G"); //新浪微博
                platformInfo.SessionKey = oa.AccessToken;
                platformInfo.AuthDate = DateTime.Now;
                platformInfo.ExpireDate = oa.ExpireTime;
                platformInfo.Refresh_token = sinaClient.OAuth.RefreshToken;
                return accessor.AddEntity(platformInfo); //保存
            }
            return null;
        }

        public override NetDimension.Weibo.TokenResult VerifyAccessToken()
        {
            throw new System.NotImplementedException();
        }

        public override void SavePlatformInfo(Model.platforminfo entity)
        {
            throw new System.NotImplementedException();
        }
    }
}