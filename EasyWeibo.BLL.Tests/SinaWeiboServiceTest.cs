// <copyright file="SinaWeiboServiceTest.cs">Copyright ©  2013</copyright>
using System;
using System.Collections.Generic;
using EasyWeibo.BLL;
using EasyWeibo.Model;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetDimension.Weibo;

namespace EasyWeibo.BLL
{
    /// <summary>This class contains parameterized unit tests for SinaWeiboService</summary>
    [PexClass(typeof(SinaWeiboService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SinaWeiboServiceTest
    {
        /// <summary>Test stub for BatchSend(List`1&lt;WeiboMessage&gt;)</summary>
        [PexMethod]
        public void BatchSend(
            [PexAssumeUnderTest]SinaWeiboService target,
            List<WeiboMessage> msgList
        )
        {
            target.BatchSend(msgList);
            // TODO: add assertions to method SinaWeiboServiceTest.BatchSend(SinaWeiboService, List`1<WeiboMessage>)
        }

        /// <summary>Test stub for .ctor(String)</summary>
        [PexMethod]
        public SinaWeiboService Constructor(string sessionKey)
        {
            SinaWeiboService target = new SinaWeiboService(sessionKey);
            return target;
            // TODO: add assertions to method SinaWeiboServiceTest.Constructor(String)
        }

        /// <summary>Test stub for Send(WeiboMessage)</summary>
        [PexMethod]
        public void Send(
            [PexAssumeUnderTest]SinaWeiboService target,
            WeiboMessage message
        )
        {
            target.Send(message);
            // TODO: add assertions to method SinaWeiboServiceTest.Send(SinaWeiboService, WeiboMessage)
        }

        /// <summary>Test stub for VerifyAccessToken()</summary>
        [PexMethod]
        public TokenResult VerifyAccessToken([PexAssumeUnderTest]SinaWeiboService target)
        {
            TokenResult result = target.VerifyAccessToken();
            return result;
            // TODO: add assertions to method SinaWeiboServiceTest.VerifyAccessToken(SinaWeiboService)
        }
    }
}
