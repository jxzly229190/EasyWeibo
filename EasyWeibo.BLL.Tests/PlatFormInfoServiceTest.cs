// <copyright file="PlatFormInfoServiceTest.cs">Copyright ©  2013</copyright>
using System;
using System.Collections.Generic;
using EasyWeibo.BLL;
using EasyWeibo.Helper;
using EasyWeibo.Model;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyWeibo.BLL
{
    /// <summary>This class contains parameterized unit tests for PlatFormInfoService</summary>
    [PexClass(typeof(PlatFormInfoService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class PlatFormInfoServiceTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public PlatFormInfoService Constructor()
        {
            PlatFormInfoService target = new PlatFormInfoService();
            return target;
            // TODO: add assertions to method PlatFormInfoServiceTest.Constructor()
        }

        /// <summary>Test stub for GetPlatFormInfoByNickName(String)</summary>
        [PexMethod]
        public List<platforminfo> GetPlatFormInfoByNickName([PexAssumeUnderTest]PlatFormInfoService target, string nickName)
        {
            List<platforminfo> result = target.GetPlatFormInfoByNickName(nickName);
            return result;
            // TODO: add assertions to method PlatFormInfoServiceTest.GetPlatFormInfoByNickName(PlatFormInfoService, String)
        }

        /// <summary>Test stub for GetPlatFormInfoByNickNameAndPlatFormId(String, PlatForm)</summary>
        [PexMethod]
        public platforminfo GetPlatFormInfoByNickNameAndPlatFormId(
            [PexAssumeUnderTest]PlatFormInfoService target,
            string nickName,
            Mappings.PlatForm platformId
        )
        {
            platforminfo result
               = target.GetPlatFormInfoByNickNameAndPlatFormId(nickName, platformId);
            return result;
            // TODO: add assertions to method PlatFormInfoServiceTest.GetPlatFormInfoByNickNameAndPlatFormId(PlatFormInfoService, String, PlatForm)
        }

        /// <summary>Test stub for SavePlatFormInfo(platforminfo)</summary>
        [PexMethod]
        public void SavePlatFormInfo(
            [PexAssumeUnderTest]PlatFormInfoService target,
            platforminfo info
        )
        {
            target.SavePlatFormInfo(info);
            // TODO: add assertions to method PlatFormInfoServiceTest.SavePlatFormInfo(PlatFormInfoService, platforminfo)
        }
    }
}
