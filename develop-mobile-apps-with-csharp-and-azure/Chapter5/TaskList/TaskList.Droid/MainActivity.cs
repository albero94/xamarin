﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using TaskList.Abstractions;
using TaskList.Droid.Services;
using Xamarin.Forms;

namespace TaskList.Droid
{
    [Activity(Label = "TaskList.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            global::Xamarin.Forms.Forms.Init(this, bundle);

            ((DroidPlatformProvider)DependencyService.Get<IPlatformProvider>()).Init(this);

            string param = this.Intent.GetStringExtra("param");
            LoadApplication(new App(loadParameter: param));
        }
    }
}

