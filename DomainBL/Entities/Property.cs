using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainBL.Entities
{
	public class Property
	{
		public string Address { get; set; }
		public string AgencyCode { get; set; }
		public string Name { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }

		public bool isValid()
		{
			foreach (var prop in this.GetType().GetProperties())
			{
				switch (prop.PropertyType.Name)
				{
					case "String":
						if ((string)prop.GetValue(this, null) == null)
						{
							return false;
						}
						break;
					case "Decimal":
						if ((decimal)prop.GetValue(this, null) == 0)
						{
							return false;
						}
						break;
				}
			}
			return true;
		}

		public override bool Equals(object compareObject)
		{
			var originalObject = this;
			foreach (var item in originalObject.GetType().GetProperties())
			{
				if (item.Name != "Latitude" && item.Name != "Longitude")
				{
					if (!item.GetValue(originalObject, null).Equals(compareObject.GetType().GetProperty(item.Name).GetValue(compareObject, null)))
						return false;
				}
			}
			return true;
		}
	}
}
