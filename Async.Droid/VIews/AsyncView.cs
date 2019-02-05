using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AsyncProgram.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace Async.Droid.Views
{
    [Activity(Label = "AsyncProgram", MainLauncher = true)]
    class AsyncView : MvxActivity<AsyncViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AsyncView);
        }
    }
}