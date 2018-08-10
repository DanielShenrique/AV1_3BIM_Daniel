using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace AV3_3BIM_Daniel
{
    [Activity(Label = "AV3_3BIM_Daniel", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private static Activity c;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            c = this;

            Button buttonDelayAlarm = FindViewById<Button>(Resource.Id.buttonDelayAlarm);

            buttonDelayAlarm.Click += OnButtonDelayAlarmClicked;

            SetAlarm();
        }

        private void OnButtonDelayAlarmClicked(object sender, System.EventArgs e)
        {
        
        AlarmManager manager = (AlarmManager)GetSystemService(Android.Content.Context.AlarmService);
        Intent i2;
        PendingIntent pi2;

        i2 = new Intent(this, typeof(AlarmBroadcast));
        pi2 = PendingIntent.GetBroadcast(this, 0, i2, 0);

        manager.SetExact(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + 10000, pi2);
        


        }

        private void SetAlarm()
        {
            AlarmManager manager = (AlarmManager)GetSystemService(Android.Content.Context.AlarmService);
            Intent i;
            PendingIntent pi;

            i = new Intent(this, typeof(AlarmBroadcast));
            pi = PendingIntent.GetBroadcast(this, 0, i, 0);

            manager.SetExact(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + 15000, pi);
        }

        public static void CloseThis()
        {
            c.Finish();
        }
    }
}

