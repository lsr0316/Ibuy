using Android.Support.V7.Widget;
using Android.Views;
using Ibuy.Activities;
using System;
using static Ibuy.Activities.PhotoAlbum;


namespace Ibuy.Adapter
{
    class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        private PhotoAlbum mPhotoAlbum;
        public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
        {
            mPhotoAlbum = photoAlbum;
        }
        public override int ItemCount
        {
            get { return mPhotoAlbum.numPhoto; }
        }

        internal PhotoAlbum MPhotoAlbum { get => mPhotoAlbum; set => mPhotoAlbum = value; }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            PhotoViewHolder vh = holder as PhotoViewHolder;
            vh.Image.SetImageResource(mPhotoAlbum[position].mPhotoID);
            vh.Caption.Text = mPhotoAlbum[position].mCaption;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.photocard, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}
