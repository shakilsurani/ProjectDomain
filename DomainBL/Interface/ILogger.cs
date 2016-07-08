using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainBL.Interface
{
	public interface ILogger
	{
		void LogError(string error);
	}
}
