using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvHelper
{
	public interface IEnvConstHelper
	{
		string BaseUrl { get; }
		string AuthorizeUrl { get; }
		string AppKey { get; }
		string AppSecret { get; }
	}
}
