//using System;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MobileIAP.Api
{
	public class IAPRequest
	{	
		private Dictionary<string, string> iapSKProducts;
		
		public IAPRequest(){
			this.iapSKProducts = new Dictionary<string, string>();
		}

		public void addProductID(string key, string value){
			this.iapSKProducts.Add(key, value);
		}

		public Dictionary<string, string> IAPSKProducts
		{
			get
			{
				return iapSKProducts;
			}
		}

		public int count
		{
			get
			{
				return iapSKProducts.Count;
			}
		}

	}
}