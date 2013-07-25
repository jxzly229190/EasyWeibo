// <copyright file="WeiboServiceBaseTest.cs">Copyright ©  2013</copyright>
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
    /// <summary>This class contains parameterized unit tests for WeiboServiceBase</summary>
    [PexClass(typeof(WeiboServiceBase))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class WeiboServiceBaseTest
    {
        /// <summary>Test stub for BatchSend(List`1&lt;WeiboMessage&gt;)</summary>
        [PexMethod]
        public void BatchSend(
            [PexAssumeNotNull]WeiboServiceBase target,
            List<WeiboMessage> msgList
        )
        {
            target.BatchSend(msgList);
            // TODO: add assertions to method WeiboServiceBaseTest.BatchSend(WeiboServiceBase, List`1<WeiboMessage>)
        }

        /// <summary>Test stub for Send(WeiboMessage)</summary>
        [PexMethod]
        public void Send([PexAssumeNotNull]WeiboServiceBase target, WeiboMessage message)
        {
            target.Send(message);
            // TODO: add assertions to method WeiboServiceBaseTest.Send(WeiboServiceBase, WeiboMessage)
        }

        /// <summary>Test stub for VerifyAccessToken()</summary>
        [PexMethod]
        public TokenResult VerifyAccessToken([PexAssumeNotNull]WeiboServiceBase target)
        {
            TokenResult result = target.VerifyAccessToken();
            return result;
            // TODO: add assertions to method WeiboServiceBaseTest.VerifyAccessToken(WeiboServiceBase)
        }
    }
}
