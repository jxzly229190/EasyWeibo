// <copyright file="OAuthServiceTest.cs">Copyright ©  2013</copyright>
using System;
using EasyWeibo.BLL;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyWeibo.BLL
{
    /// <summary>This class contains parameterized unit tests for OAuthService</summary>
    [PexClass(typeof(OAuthService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class OAuthServiceTest
    {
        /// <summary>Test stub for RegisterPlatformSession(OAuth2Base, String)</summary>
        [PexMethod]
        public void RegisterPlatformSession(
            [PexAssumeUnderTest]OAuthService target,
            OAuth2Base oa,
            string code
        )
        {
            target.RegisterPlatformSession(oa, code);
            // TODO: add assertions to method OAuthServiceTest.RegisterPlatformSession(OAuthService, OAuth2Base, String)
        }
    }
}
