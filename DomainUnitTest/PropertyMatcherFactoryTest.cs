using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainBL.Entities;
using DomainBL.Factories;
using DomainBL.Implementation.Strategies;

namespace DomainUnitTest
{
	/// <summary>
	/// Summary description for OTBREAgencyTest
	/// </summary>
	[TestClass]
	public class PropertyMatcherFactoryTest
	{
		[TestMethod]
		public void InValidAgency_PropertyMatcherFactoryTest()
		{
			//Arrange
			Property agencyProperty = new Property { Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "CRE123", Name = "Apartments Summit The", Latitude = 10, Longitude = 10 };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsNull(agencyStrategy);
		}

		[TestMethod]
		public void NullProperty_PropertyMatcherFactoryTest()
		{
			//Arrange
			Property agencyProperty = null;

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsNull(agencyStrategy);
		}

		[TestMethod]
		public void OTBRE_ValidAgency_PropertyMatcherFactoryTest()
		{
			//Arrange
			Property agencyProperty = new Property { Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "OTBRE", Name = "Apartments Summit The", Latitude = 10, Longitude = 10 };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsInstanceOfType(agencyStrategy, typeof(OTBREStrategy));
		}

		[TestMethod]
		public void LRE_ValidAgency_PropertyMatcherFactoryTest()
		{
			//Arrange
			Property agencyProperty = new Property { Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "LRE", Name = "Apartments Summit The", Latitude = 10, Longitude = 10 };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsInstanceOfType(agencyStrategy, typeof(LREStrategy));
		}

		[TestMethod]
		public void CRE_ValidAgency_PropertyMatcherFactoryTest()
		{
			//Arrange
			Property agencyProperty = new Property { Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "CRE", Name = "Apartments Summit The", Latitude = 10, Longitude = 10 };

			//Act
			var agencyStrategy = PropertyMatcherFactory.GetPropertyMatcherAgencyStrategy(agencyProperty);

			//Assert
			Assert.IsInstanceOfType(agencyStrategy, typeof(CREStrategy));
		}
	}
}
