using DomainBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainBL.Interface
{
	public interface IPropertyMatcher
	{
		bool IsMatch(Property agencyProperty, Property databaseProperty);
	}
}
