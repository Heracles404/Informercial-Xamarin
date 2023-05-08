using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;


namespace RandomApp
{
    internal class Randomizer
    {
        private int speed;
        private Timer timer;
        private Random rand;
        private int cnt;
        private string[] arr;
        TextView tv;
        public Randomizer(TextView tv_main, string[] arr_main)
        {
            tv = tv_main;
            arr = arr_main;
            timer = new Timer();
        }
        public void SetIntervalMode(int n)
        {
            speed = n;
        }

        public void PlayRandom()
        {
            timer.Interval = speed;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            rand = new Random();
            cnt = rand.Next(arr.Length);
            tv.Text = arr[cnt];

            throw new NotImplementedException();
        }

        public void Istap()
        {
            timer.Stop();
        }

    }
}