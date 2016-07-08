using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainBL.Entities;
using DomainBL.Factories;

namespace DomainUnitTest
{
	/// <summary>
	/// Summary description for OTBREAgencyTest
	/// </summary>
	[TestClass]
	public class LREAgencyTest
	{
		private Property _databaseProperty = null;

		[TestInitialize]
		public void TestInitialize()
		{
			_databaseProperty = new Property { Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "LRE", Name = "The Summit Apartments", Latitude = 32.9697M, Longitude = -96.80322M };
		}

		[TestMethod]
		public void ValidProperty_LREAgencyTest()
		{
			//Arrange
			Property agencyProperty = new Property { Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "LRE", Name = "The Summit Apartments", Latitude = 32.9687M, Longitude = -96.80322M };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsTrue(agencyStrategy.IsMatch(agencyProperty, _databaseProperty));
		}

		[TestMethod]
		public void InValidProperty_LREAgencyTest()
		{
			//Arrange
			Property agencyProperty = new Property { Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "LRE", Name = "The Summit Apartments", Latitude = 30.9697M, Longitude = -96.80322M };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsFalse(agencyStrategy.IsMatch(agencyProperty, _databaseProperty));
		}

		[TestMethod]
		public void InCompleteProperty_LREAgencyTest()
		{
			//Arrange
			Property agencyProperty = new Property { AgencyCode = "LRE", Name = "The Summit Apartments", Latitude = 30.9697M, Longitude = -96.80322M };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsFalse(agencyStrategy.IsMatch(agencyProperty, _databaseProperty));
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void NullProperty_LREAgencyTest()
		{
			//Arrange
			Property agencyProperty = null;

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			agencyStrategy.IsMatch(agencyProperty, _databaseProperty);
		}
	}
}
