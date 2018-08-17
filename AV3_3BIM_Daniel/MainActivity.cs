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

        private AlarmManager manager;

        private Intent i;
        private PendingIntent pi;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            c = this;

            i = new Intent(this, typeof(AlarmBroadcast));
            pi = PendingIntent.GetBroadcast(this, 0, i, 0); ;

            manager = (AlarmManager)GetSystemService(AlarmService);

            Button buttonDelayAlarm = FindViewById<Button>(Resource.Id.buttonDelayAlarm);

            buttonDelayAlarm.Click += OnButtonDelayAlarmClicked;

            SetAlarm();
        }

        private void OnButtonDelayAlarmClicked(object sender, System.EventArgs e)
        {
            Toast toast = Toast.MakeText(c, "+10 seconds", ToastLength.Short);

            manager.SetExact(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + 10000, pi);
            toast.Show();
            
        }

        private void SetAlarm()
        {
            Toast toast = Toast.MakeText(c, "15 seconds", ToastLength.Short);

            manager.SetExact(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + 15000, pi);
            toast.Show();
        }

        public static void CloseThis()
        {
            if(c != null)
            {
                c.Finish();
            }
        }
    }
}

