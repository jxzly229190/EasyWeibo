// <copyright file="TaoBaoOAuth2Test.cs">Copyright ©  2013</copyright>
using System;
using EasyWeibo.BLL;
using EasyWeibo.Helper;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyWeibo.BLL
{
    /// <summary>This class contains parameterized unit tests for TaoBaoOAuth2</summary>
    [PexClass(typeof(TaoBaoOAuth2))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class TaoBaoOAuth2Test
    {
        /// <summary>Test stub for get_AccessToken()</summary>
        [PexMethod]
        public string AccessTokenGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            string result = target.AccessToken;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.AccessTokenGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_AppKey()</summary>
        [PexMethod]
        public string AppKeyGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            string result = target.AppKey;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.AppKeyGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_AppSecret()</summary>
        [PexMethod]
        public string AppSecretGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            string result = target.AppSecret;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.AppSecretGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_BaseUrl()</summary>
        [PexMethod]
        public string BaseUrlGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            string result = target.BaseUrl;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.BaseUrlGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public TaoBaoOAuth2 Constructor()
        {
            TaoBaoOAuth2 target = new TaoBaoOAuth2();
            return target;
            // TODO: add assertions to method TaoBaoOAuth2Test.Constructor()
        }

        /// <summary>Test stub for get_ExpireTime()</summary>
        [PexMethod]
        public DateTime ExpireTimeGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            DateTime result = target.ExpireTime;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.ExpireTimeGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_ImgUrl()</summary>
        [PexMethod]
        public string ImgUrlGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            string result = target.ImgUrl;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.ImgUrlGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_IsUseSandBox()</summary>
        [PexMethod]
        public bool IsUseSandBoxGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            bool result = target.IsUseSandBox;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.IsUseSandBoxGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_OAuthUrl()</summary>
        [PexMethod]
        public string OAuthUrlGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            string result = target.OAuthUrl;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.OAuthUrlGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_PlatformUId()</summary>
        [PexMethod]
        public string PlatformUIdGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            string result = target.PlatformUId;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.PlatformUIdGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_RefreshToken()</summary>
        [PexMethod]
        public string RefreshTokenGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            string result = target.RefreshToken;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.RefreshTokenGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_Server()</summary>
        [PexMethod]
        public Mappings.PlatForm ServerGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            Mappings.PlatForm result = target.Server;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.ServerGet(TaoBaoOAuth2)
        }

        /// <summary>Test stub for get_TokenUrl()</summary>
        [PexMethod]
        public string TokenUrlGet([PexAssumeUnderTest]TaoBaoOAuth2 target)
        {
            string result = target.TokenUrl;
            return result;
            // TODO: add assertions to method TaoBaoOAuth2Test.TokenUrlGet(TaoBaoOAuth2)
        }
    }
}
