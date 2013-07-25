// <copyright file="OAuth2BaseTest.cs">Copyright ©  2013</copyright>
using System;
using EasyWeibo.BLL;
using EasyWeibo.Helper;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyWeibo.BLL
{
    /// <summary>This class contains parameterized unit tests for OAuth2Base</summary>
    [PexClass(typeof(OAuth2Base))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class OAuth2BaseTest
    {
        /// <summary>Test stub for get_AccessToken()</summary>
        [PexMethod]
        public string AccessTokenGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.AccessToken;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.AccessTokenGet(OAuth2Base)
        }

        /// <summary>Test stub for get_AppKey()</summary>
        [PexMethod]
        public string AppKeyGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.AppKey;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.AppKeyGet(OAuth2Base)
        }

        /// <summary>Test stub for get_AppSecret()</summary>
        [PexMethod]
        public string AppSecretGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.AppSecret;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.AppSecretGet(OAuth2Base)
        }

        /// <summary>Test stub for Authorize(String)</summary>
        [PexMethod]
        public bool Authorize([PexAssumeNotNull]OAuth2Base target, string code)
        {
            bool result = target.Authorize(code);
            return result;
            // TODO: add assertions to method OAuth2BaseTest.Authorize(OAuth2Base, String)
        }

        /// <summary>Test stub for get_BaseUrl()</summary>
        [PexMethod]
        public string BaseUrlGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.BaseUrl;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.BaseUrlGet(OAuth2Base)
        }

        /// <summary>Test stub for get_CallbackUrl()</summary>
        [PexMethod]
        public string CallbackUrlGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.CallbackUrl;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.CallbackUrlGet(OAuth2Base)
        }

        /// <summary>Test stub for get_ExpireTime()</summary>
        [PexMethod]
        public DateTime ExpireTimeGet([PexAssumeNotNull]OAuth2Base target)
        {
            DateTime result = target.ExpireTime;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.ExpireTimeGet(OAuth2Base)
        }

        /// <summary>Test stub for GetBindAccount()</summary>
        [PexMethod]
        public string GetBindAccount([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.GetBindAccount();
            return result;
            // TODO: add assertions to method OAuth2BaseTest.GetBindAccount(OAuth2Base)
        }

        /// <summary>Test stub for get_ImgUrl()</summary>
        [PexMethod]
        public string ImgUrlGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.ImgUrl;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.ImgUrlGet(OAuth2Base)
        }

        /// <summary>Test stub for get_OAuthUrl()</summary>
        [PexMethod]
        public string OAuthUrlGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.OAuthUrl;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.OAuthUrlGet(OAuth2Base)
        }

        /// <summary>Test stub for get_PlatformUId()</summary>
        [PexMethod]
        public string PlatformUIdGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.PlatformUId;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.PlatformUIdGet(OAuth2Base)
        }

        /// <summary>Test stub for get_RefreshToken()</summary>
        [PexMethod]
        public string RefreshTokenGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.RefreshToken;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.RefreshTokenGet(OAuth2Base)
        }

        /// <summary>Test stub for get_Server()</summary>
        [PexMethod]
        public Mappings.PlatForm ServerGet([PexAssumeNotNull]OAuth2Base target)
        {
            Mappings.PlatForm result = target.Server;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.ServerGet(OAuth2Base)
        }

        /// <summary>Test stub for SetBindAccount(String)</summary>
        [PexMethod]
        public bool SetBindAccount([PexAssumeNotNull]OAuth2Base target, string bindAccount)
        {
            bool result = target.SetBindAccount(bindAccount);
            return result;
            // TODO: add assertions to method OAuth2BaseTest.SetBindAccount(OAuth2Base, String)
        }

        /// <summary>Test stub for get_TokenUrl()</summary>
        [PexMethod]
        public string TokenUrlGet([PexAssumeNotNull]OAuth2Base target)
        {
            string result = target.TokenUrl;
            return result;
            // TODO: add assertions to method OAuth2BaseTest.TokenUrlGet(OAuth2Base)
        }
    }
}
