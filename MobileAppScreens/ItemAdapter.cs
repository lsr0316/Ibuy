using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Views;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using static MobileAppScreens.ProductListing;

namespace MobileAppScreens
{
    class ItemAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public ProductListing rProduct;
        private readonly Action<int> OnClick;

        public ItemAdapter(ProductListing productlisting)
        {
            rProduct = productlisting;
        }
        public override int ItemCount
        {
            get { return rProduct.numProduct; }
        }



        //public override int ItemCount
        //{
        //    get { return rProduct.numProduct; }
        //}

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProductViewHolder vh = holder as ProductViewHolder;
            vh.Item.SetImageResource(rProduct[position].pProductID);
            vh.Description.Text = rProduct[position].pDescription;
        }



        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Itemcard, parent, false);
            ProductViewHolder vh = new ProductViewHolder(itemView, OnClick);
            return vh;
        }


    }
}