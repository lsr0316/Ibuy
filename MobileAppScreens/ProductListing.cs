using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using static Android.Content.ClipData;
/*
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;*/

namespace MobileAppScreens
{
    public class Product
    {
        public int pProductID{ get; set; }
        public string pDescription { get; set; }

    }
    class ProductListing
    {

        static Product[] listProduct =
        {
            new Product() {pProductID = Resource.Drawable.Ex1 , pDescription ="xyz" },
            new Product() {pProductID = Resource.Drawable.ex2 , pDescription ="abc" },
            new Product() {pProductID = Resource.Drawable.EX3 , pDescription ="123" },

        };

        private Product[] products;
        public ProductListing()
        {
            this.products = listProduct;
        }

        public int numProduct
        {
            get 
            
            {
                return products.Length;
            }
        }

        public Product this[int i]

        { 
            get { return products[i]; } 
        }


      


        public class ProductViewHolder : RecyclerView.ViewHolder
        {
            public ImageView Item { get; set; }
            public TextView Description { get; set; }

            [Obsolete]
            public ProductViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                Item = itemview.FindViewById<ImageView>(Resource.Id.imageView);
                Description = itemview.FindViewById<TextView>(Resource.Id.textView);
                itemview.Click += (sender, e) => listener(Position);
            }

            private void Itemview_Click(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }
        }

    }
}


/*  create the other classes and objects view holder*/