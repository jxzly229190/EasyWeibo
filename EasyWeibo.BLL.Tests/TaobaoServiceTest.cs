// <copyright file="TaobaoServiceTest.cs">Copyright ©  2013</copyright>
using System;
using EasyWeibo.BLL;
using EasyWeibo.Model;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top.Api.Domain;

namespace EasyWeibo.BLL
{
    /// <summary>This class contains parameterized unit tests for TaobaoService</summary>
    [PexClass(typeof(TaobaoService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class TaobaoServiceTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public TaobaoService Constructor()
        {
            TaobaoService target = new TaobaoService();
            return target;
            // TODO: add assertions to method TaobaoServiceTest.Constructor()
        }

        /// <summary>Test stub for GetSellerUserInfo(String)</summary>
        [PexMethod]
        public User GetSellerUserInfo([PexAssumeUnderTest]TaobaoService target, string sessionKey)
        {
            User result = target.GetSellerUserInfo(sessionKey);
            return result;
            // TODO: add assertions to method TaobaoServiceTest.GetSellerUserInfo(TaobaoService, String)
        }

        /// <summary>Test stub for GetUserInfoBySessionKey(String)</summary>
        [PexMethod]
        public userinfo GetUserInfoBySessionKey([PexAssumeUnderTest]TaobaoService target, string sessionKey)
        {
            userinfo result = target.GetUserInfoBySessionKey(sessionKey);
            return result;
            // TODO: add assertions to method TaobaoServiceTest.GetUserInfoBySessionKey(TaobaoService, String)
        }

        /// <summary>Test stub for GetUserInfoByTBUserId(String)</summary>
        [PexMethod]
        public userinfo GetUserInfoByTBUserId([PexAssumeUnderTest]TaobaoService target, string tbUserId)
        {
            userinfo result = target.GetUserInfoByTBUserId(tbUserId);
            return result;
            // TODO: add assertions to method TaobaoServiceTest.GetUserInfoByTBUserId(TaobaoService, String)
        }

        /// <summary>Test stub for SaveUserInfo(userinfo)</summary>
        [PexMethod]
        public void SaveUserInfo([PexAssumeUnderTest]TaobaoService target, userinfo userInfo)
        {
            target.SaveUserInfo(userInfo);
            // TODO: add assertions to method TaobaoServiceTest.SaveUserInfo(TaobaoService, userinfo)
        }
    }
}
