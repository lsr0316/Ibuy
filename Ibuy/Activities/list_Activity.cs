﻿using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
/*
Error	CS0115	'list_Activity.OnCreate(Bundle)': no suitable method found to override	Ibuy	C:\Users\Owner\Desktop\Ibuy-RayWorkingBranch\Ibuy\Activities\list_Activity.cs	20	Active
*/
using Ibuy.Adapter;

namespace Ibuy.Activities
{
    class list_Activity
    {
        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        PhotoAlbum mPhotoAlbum;
        PhotoAlbumAdapter mAdapter;
        protected override void OnCreate(Bundle savedInstanceState)  //<-- not suitable method for over ride
        {
            base.OnCreate(savedInstanceState);  //<--
            mPhotoAlbum = new PhotoAlbum();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.list);
            mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView); //<--
            mLayoutManager = new LinearLayoutManager(this);                     //<--
            mRecycleView.SetLayoutManager(mLayoutManager);
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);
            mAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(mAdapter);
        }

        private void SetContentView(int list)
        {
            throw new NotImplementedException();
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            throw new NotImplementedException();
        }
    }
}

