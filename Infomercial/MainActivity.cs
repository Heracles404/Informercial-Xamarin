using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Infomercial;
using System.Timers;
using System;
using RandomApp;

namespace Informercial
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView text1;
        Button btn, btn2, btnstop;
        ImageView iv;
        Timer timer;
        Random rand;
        Randomizer r;

        int cnt = 0;
        string[] nvidia = { "RTX4000", "RTX40s", "BROADCAST", "METAVERSE", "OMNIVERSE", "OVX", "VR", "WORKSTATIONS", "CLIMATE" };
        string[] amd = { "Radeon", "Gaming", "RX7900", "Rendering", "Performance", "Display", "RX6000_Series", "RX6600" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            btn = FindViewById<Button>(Resource.Id.button1);
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btnstop = FindViewById<Button>(Resource.Id.button3);
            text1 = FindViewById<TextView>(Resource.Id.textView1);
            iv = FindViewById<ImageView>(Resource.Id.imageView1);
            iv.SetImageResource(Resource.Drawable.nva);

            btn.Click += (sender, e) =>
            {
                btn.Enabled = false; // Disable Button1
                btn2.Enabled = false; // Enable Button2
                btnstop.Enabled = true; // Enable Button3

                timer = new Timer();
                timer.Interval = 1500;
                timer.Elapsed += timer_Elapsed;
                timer.Start();
            };

            btn2.Click += (sender, e) =>
            {
                btn2.Enabled = false; // Disable Button2
                btn.Enabled = false; // Enable Button1
                btnstop.Enabled = true; // Enable Button3

                timer = new Timer();
                timer.Interval = 1500;
                timer.Elapsed += elapsed_time;
                timer.Start();
            };

            btnstop.Click += (sender, e) =>
            {
                btn.Enabled = true; // Enable Button1
                btn2.Enabled = true; // Enable Button2
                btnstop.Enabled = false; // Disable Button3

                if (r != null)
                {
                    r.Istap();
                }

                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }
            };

        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            rand = new Random();
            cnt = rand.Next(21);
            text1.Text = nvidia[cnt];
            int resourceId = (int)typeof(Resource.Drawable).GetField(nvidia[cnt]).GetValue(null);
            iv.SetImageDrawable(GetDrawable(resourceId));
            iv.LayoutParameters.Height = 200;
            iv.LayoutParameters.Width = 200;

            throw new NotImplementedException();
        }

        private void elapsed_time(object sender, System.Timers.ElapsedEventArgs e)
        {
            rand = new Random();
            cnt = rand.Next(21);
            text1.Text = amd[cnt];
            int resourceId = (int)typeof(Resource.Drawable).GetField(amd[cnt]).GetValue(null);
            iv.SetImageDrawable(GetDrawable(resourceId));
            iv.LayoutParameters.Height = 200;
            iv.LayoutParameters.Width = 200;

            throw new NotImplementedException();
        }

        public void ClassRandomizer(object sender, EventArgs e)
        {
            r.SetIntervalMode(1000);
            r.PlayRandom();
        }

        public void ClassRandomizerStop(object sender, EventArgs e)
        {
            r.Istap();
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}