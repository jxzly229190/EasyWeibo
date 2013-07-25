// <copyright file="TokenVerificationExceptionTest.cs">Copyright ©  2013</copyright>
using System;
using EasyWeibo.BLL.CustomException;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyWeibo.BLL.CustomException
{
    /// <summary>This class contains parameterized unit tests for TokenVerificationException</summary>
    [PexClass(typeof(TokenVerificationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class TokenVerificationExceptionTest
    {
    }
}
