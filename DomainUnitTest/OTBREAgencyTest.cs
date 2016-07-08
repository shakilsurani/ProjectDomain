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
	public class OTBREAgencyTest
	{
		private Property _databaseProperty = null;

		[TestInitialize]
		public void TestInitialize()
		{
			_databaseProperty = new Property { Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "OTBRE", Name = "Super High Apartments, Sydney", Latitude = 10, Longitude = 10 };
		}

		[TestMethod]
		public void ValidProperty_OTBREAgencyTest()
		{
			//Arrange
			Property agencyProperty = new Property { Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "OTBRE", Name = "*Super*-High! APARTMENTS (Sydney)", Latitude = 10, Longitude = 10 };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsTrue(agencyStrategy.IsMatch(agencyProperty, _databaseProperty));
		}

		[TestMethod]
		public void InValidProperty_OTBREAgencyTest()
		{
			//Arrange
			Property agencyProperty = new Property { Address = "32 Sir John-Young Crescent", AgencyCode = "OTBRE", Name = "*Super*-High! APARTMENTS (Sydney)", Latitude = 10, Longitude = 10 };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsFalse(agencyStrategy.IsMatch(agencyProperty, _databaseProperty));
		}

		[TestMethod]
		public void InCompleteProperty_OTBREAgencyTest()
		{
			//Arrange
			Property agencyProperty = new Property { AgencyCode = "OTBRE", Name = "*Super*-High! APARTMENTS (Sydney)", Latitude = 10, Longitude = 10 };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsFalse(agencyStrategy.IsMatch(agencyProperty, _databaseProperty));
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void NullProperty_OTBREAgencyTest()
		{
			//Arrange
			Property agencyProperty = null;

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);
			agencyStrategy.IsMatch(agencyProperty, _databaseProperty);
		}
	}
}
