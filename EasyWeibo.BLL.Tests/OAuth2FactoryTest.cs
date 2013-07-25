// <copyright file="OAuth2FactoryTest.cs">Copyright ©  2013</copyright>
using System;
using System.Collections.Generic;
using EasyWeibo.BLL;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyWeibo.BLL
{
    /// <summary>This class contains parameterized unit tests for OAuth2Factory</summary>
    [PexClass(typeof(OAuth2Factory))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class OAuth2FactoryTest
    {
        /// <summary>Test stub for get_ServerList()</summary>
        [PexMethod]
        public Dictionary<string, OAuth2Base> ServerListGet()
        {
            Dictionary<string, OAuth2Base> result = OAuth2Factory.ServerList;
            return result;
            // TODO: add assertions to method OAuth2FactoryTest.ServerListGet()
        }

        /// <summary>Test stub for get_SessionOAuth()</summary>
        [PexMethod]
        public OAuth2Base SessionOAuthGet()
        {
            OAuth2Base result = OAuth2Factory.SessionOAuth;
            return result;
            // TODO: add assertions to method OAuth2FactoryTest.SessionOAuthGet()
        }

        /// <summary>Test stub for set_SessionOAuth(OAuth2Base)</summary>
        [PexMethod]
        public void SessionOAuthSet(OAuth2Base value)
        {
            OAuth2Factory.SessionOAuth = value;
            // TODO: add assertions to method OAuth2FactoryTest.SessionOAuthSet(OAuth2Base)
        }

        /// <summary>Test stub for get_TaoBaoAuther()</summary>
        [PexMethod]
        public OAuth2Base TaoBaoAutherGet()
        {
            OAuth2Base result = OAuth2Factory.TaoBaoAuther;
            return result;
            // TODO: add assertions to method OAuth2FactoryTest.TaoBaoAutherGet()
        }
    }
}
