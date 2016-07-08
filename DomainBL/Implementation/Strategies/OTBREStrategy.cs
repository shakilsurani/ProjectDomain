using DomainBL.Entities;
using DomainBL.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomainBL.Implementation.Strategies
{
	public class OTBREStrategy : IPropertyMatcher
	{
		private const char SPACE_CHAR = ' ';
		private const string NSW_STATE = "NSW";
		private const string SYDNEY_CITY = "Sydney";
		private readonly ILogger _logger;

		public OTBREStrategy()
		{
			_logger = new Logger(); //Ideally inject from config file
		}

		public bool IsMatch(Property agencyProperty, Property databaseProperty)
		{
			if (agencyProperty.isValid())
			{
				agencyProperty.Name = StandardizePunctuation(agencyProperty.Name);
				agencyProperty.Address = StandardizePunctuation(agencyProperty.Address);
				//
				return (databaseProperty.Equals(agencyProperty)) ? true : false;
			}
			else
			{
				_logger.LogError("Invalid Property");
				return false;
			}
		}

		private string StandardizePunctuation(string rawString)
		{
			var standardizeValue = string.Empty;
			//
			rawString = Regex.Replace(rawString, @"[^\w\s]", " ");
			TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
			//
			var lstStrings = rawString.Split(SPACE_CHAR).ToList();
			//
			foreach (var itemString in lstStrings)
			{
				if (!string.IsNullOrWhiteSpace(itemString))
				{
					var itemStringWithCase = (itemString == NSW_STATE) ? textInfo.ToUpper(itemString) : textInfo.ToTitleCase(itemString.ToLower());
					standardizeValue += (itemStringWithCase == SYDNEY_CITY) ? ", " + itemStringWithCase : " " + itemStringWithCase;
				}
			}
			//
			return standardizeValue.Trim();
		}
	}
}
