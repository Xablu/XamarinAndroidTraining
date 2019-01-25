using System;
using System.Collections.Generic;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MvxSample.Core.Models;

namespace MvxSample.Droid.TemplateSelectors
{
    public class CitiesTemplateSelector : IMvxTemplateSelector
    {
        public int ItemTemplateId { get; set; }

        public int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }

        public int GetItemViewType(object forItemObject)
        {
            var city = (City)forItemObject;
            return city.IsCapital ? Resource.Layout.item_capital : Resource.Layout.item_city;
        }
    }
}
