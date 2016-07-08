using DomainBL.Entities;
using DomainBL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainBL.Implementation.Strategies
{
	public class CREStrategy : IPropertyMatcher
	{
		private readonly ILogger _logger;
		public CREStrategy()
		{
			_logger = new Logger(); //Ideally inject from config file
		}

		public bool IsMatch(Property agencyProperty, Property databaseProperty)
		{
			if (agencyProperty.isValid())
			{
				agencyProperty.Name = StandardizeBackwardValue(agencyProperty.Name);
				return (databaseProperty.Equals(agencyProperty)) ? true : false;
			}
			else
			{
				_logger.LogError("Invalid Property");
				return false;
			}
		}

		private string StandardizeBackwardValue(string rawString)
		{
			return string.Join(" ", rawString.Split(' ').Reverse());
		}
	}
}
