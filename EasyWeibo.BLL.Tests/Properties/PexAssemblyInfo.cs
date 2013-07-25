// <copyright file="PexAssemblyInfo.cs">Copyright ©  2013</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Moles;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("EasyWeibo.BLL")]
[assembly: PexInstrumentAssembly("EasyWeibo.DAL")]
[assembly: PexInstrumentAssembly("TopSdk")]
[assembly: PexInstrumentAssembly("System.Web")]
[assembly: PexInstrumentAssembly("EasyWeibo.Model")]
[assembly: PexInstrumentAssembly("NetDimension.Weibo")]
[assembly: PexInstrumentAssembly("EasyWeibo.Helper")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "EasyWeibo.DAL")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "TopSdk")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "EasyWeibo.Model")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "NetDimension.Weibo")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "EasyWeibo.Helper")]

// Microsoft.Pex.Framework.Moles
[assembly: PexAssumeContractEnsuresFailureAtBehavedSurface]
[assembly: PexChooseAsBehavedCurrentBehavior]

