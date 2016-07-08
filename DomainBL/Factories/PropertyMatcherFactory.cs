using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainBL.Interface;
using DomainBL.Implementation;
using DomainBL.Entities;

namespace DomainBL.Factories
{
	public class PropertyMatcherFactory
	{
		private static IPropertyMatcher propertyMatcher = null;
		private static ILogger _logger = new Logger(); //Ideally inject from config file;

		public static IPropertyMatcher GetPropertyMatcherAgencyStrategy(Property agencyProperty)
		{
			try
			{
				propertyMatcher = Activator.CreateInstance(Type.GetType("DomainBL.Implementation.Strategies." + agencyProperty.AgencyCode + "Strategy")) as IPropertyMatcher;
			}
			catch (Exception ex)
			{
				_logger.LogError("Invali Agency Code");
			}
			//
			return propertyMatcher;
		}
	}
}
