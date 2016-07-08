using DomainBL.Entities;
using DomainBL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainBL.Implementation.Strategies
{
	public class LREStrategy : IPropertyMatcher
	{
		private readonly ILogger _logger;
		private const int MAX_DISTANCE_BUFFER = 200;

		public LREStrategy()
		{
			_logger = new Logger(); //Ideally inject from config file
		}

		public bool IsMatch(Property agencyProperty, Property databaseProperty)
		{
			if (agencyProperty.isValid())
			{
				if (Distance(agencyProperty.Latitude, agencyProperty.Longitude, databaseProperty.Latitude, databaseProperty.Longitude) <= MAX_DISTANCE_BUFFER)
				{
					return (databaseProperty.Equals(agencyProperty)) ? true : false;
				}
				else
				{
					return false;
				}
			}
			else
			{
				_logger.LogError("Invalid Property");
				return false;
			}
		}

		private double Distance(decimal Latitude1, decimal Longitude1, decimal Latitude2, decimal Longitude2)
		{
			var lat = (Math.PI / 180) * ((double)Latitude2 - (double)Latitude1);
			var lng = (Math.PI / 180) * ((double)Longitude2 - (double)Longitude1);
			var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
										Math.Cos((Math.PI / 180) * (double)Latitude1) * Math.Cos((Math.PI / 180) * (double)Latitude2) *
										Math.Sin(lng / 2) * Math.Sin(lng / 2);
			var dist = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
			//var distInMeters = 6371 * dist
			var distInMeters = (double)Math.Round(1000 * (6371 * dist), 0);
			return distInMeters;
		}
	}
}
