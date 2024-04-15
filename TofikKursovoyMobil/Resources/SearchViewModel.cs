using System;
using System.Collections.ObjectModel;
using TofikKursovoyModels.ClassesCombine;

namespace TofikKursovoyMobil.Resources
{
	public class SearchViewModel
	{
		public List<DiscountCombiner> combiner { get; set;}
		public SearchViewModel(List<DiscountCombiner> c)
		{
			combiner = c;
		}

	}
}

