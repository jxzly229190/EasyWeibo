// <copyright file="BatchSendEventArgsTest.cs">Copyright ©  2013</copyright>
using System;
using EasyWeibo.BLL;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyWeibo.BLL
{
    /// <summary>This class contains parameterized unit tests for BatchSendEventArgs</summary>
    [PexClass(typeof(BatchSendEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class BatchSendEventArgsTest
    {
    }
}
