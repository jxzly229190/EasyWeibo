// <copyright file="SinaWeiboOAuth2Test.cs">Copyright ? 2013</copyright>
using System;
using EasyWeibo.BLL;
using EasyWeibo.Helper;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyWeibo.BLL
{
    /// <summary>This class contains parameterized unit tests for SinaWeiboOAuth2</summary>
    [PexClass(typeof(SinaWeiboOAuth2))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SinaWeiboOAuth2Test
    {
        /// <summary>Test stub for get_AccessToken()</summary>
        [PexMethod]
        public string AccessTokenGet([PexAssumeUnderTest]SinaWeiboOAuth2 target)
        {
            string result = target.AccessToken;
            return result;
            // TODO: add assertions to method SinaWeiboOAuth2Test.AccessTokenGet(SinaWeiboOAuth2)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public SinaWeiboOAuth2 Constructor()
        {
            SinaWeiboOAuth2 target = new SinaWeiboOAuth2();
            return target;
            // TODO: add assertions to method SinaWeiboOAuth2Test.Constructor()
        }

        /// <summary>Test stub for get_ExpireTime()</summary>
        [PexMethod]
        public DateTime ExpireTimeGet([PexAssumeUnderTest]SinaWeiboOAuth2 target)
        {
            DateTime result = target.ExpireTime;
            return result;
            // TODO: add assertions to method SinaWeiboOAuth2Test.ExpireTimeGet(SinaWeiboOAuth2)
        }

        /// <summary>Test stub for get_ImgUrl()</summary>
        [PexMethod]
        public string ImgUrlGet([PexAssumeUnderTest]SinaWeiboOAuth2 target)
        {
            string result = target.ImgUrl;
            return result;
            // TODO: add assertions to method SinaWeiboOAuth2Test.ImgUrlGet(SinaWeiboOAuth2)
        }

        /// <summary>Test stub for get_OAuthUrl()</summary>
        [PexMethod]
        public string OAuthUrlGet([PexAssumeUnderTest]SinaWeiboOAuth2 target)
        {
            string result = target.OAuthUrl;
            return result;
            // TODO: add assertions to method SinaWeiboOAuth2Test.OAuthUrlGet(SinaWeiboOAuth2)
        }

        /// <summary>Test stub for get_PlatformUId()</summary>
        [PexMethod]
        public string PlatformUIdGet([PexAssumeUnderTest]SinaWeiboOAuth2 target)
        {
            string result = target.PlatformUId;
            return result;
            // TODO: add assertions to method SinaWeiboOAuth2Test.PlatformUIdGet(SinaWeiboOAuth2)
        }

        /// <summary>Test stub for get_RefreshToken()</summary>
        [PexMethod]
        public string RefreshTokenGet([PexAssumeUnderTest]SinaWeiboOAuth2 target)
        {
            string result = target.RefreshToken;
            return result;
            // TODO: add assertions to method SinaWeiboOAuth2Test.RefreshTokenGet(SinaWeiboOAuth2)
        }

        /// <summary>Test stub for get_Server()</summary>
        [PexMethod]
        public Mappings.PlatForm ServerGet([PexAssumeUnderTest]SinaWeiboOAuth2 target)
        {
            Mappings.PlatForm result = target.Server;
            return result;
            // TODO: add assertions to method SinaWeiboOAuth2Test.ServerGet(SinaWeiboOAuth2)
        }

        /// <summary>Test stub for get_TokenUrl()</summary>
        [PexMethod]
        public string TokenUrlGet([PexAssumeUnderTest]SinaWeiboOAuth2 target)
        {
            string result = target.TokenUrl;
            return result;
            // TODO: add assertions to method SinaWeiboOAuth2Test.TokenUrlGet(SinaWeiboOAuth2)
        }
    }
}
