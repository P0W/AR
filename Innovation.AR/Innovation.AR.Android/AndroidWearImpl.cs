
using Android.App;
using Android.Content;
using Android.OS;
using Innovation.AR.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidWearImpl))]
namespace Innovation.AR.Droid
{
    public class AndroidWearImpl : IAndroidWear
    {

        static public FormsAppCompatActivity currentActivity;
        static public NotificationManager notifyManager;


        public void ProcessRxData(int airdropPhase)
        {
            int _ap = airdropPhase;

            if (_ap == 3)
            {
                ARModel.GetInstance.AirdropPhase = 3;
                var valuesForActivity = new Bundle();
                valuesForActivity.Equals("message");
                string groupkey = "group_key";
                var intent = new Intent(currentActivity, typeof(MainActivity));
                intent.PutExtras(valuesForActivity);
                var pendingIntent = PendingIntent.GetActivity(currentActivity, 0, intent, PendingIntentFlags.OneShot);
                var builder = new Notification.Builder(currentActivity)
                    .SetAutoCancel(true)
                    .SetContentIntent(pendingIntent)
                    .SetContentTitle("Welcome to CHADCS")
                    //.SetSmallIcon(Resource.Drawable.greeen)
                    //.SetLargeIcon(Resource.Drawable.red)
                    .SetContentText("AirDrop Light is Green")  //message is the one recieved from the notification
                    .SetGroup(groupkey)    //creates groups
                    .SetShowWhen(true)
                    .SetLocalOnly(false)
                    .SetVisibility(NotificationVisibility.Public)
                    .SetPriority((int)NotificationPriority.High);
                //                .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate);

                //intent for voice input or text selection 
                var wear_intent = new Intent(Intent.ActionView);
                var wear_pending_intent = PendingIntent.GetActivity(currentActivity, 0, wear_intent, 0);



                // Create the reply action and add the remote input
                var action = new Notification.Action.Builder(Resource.Drawable.icon, "Ok Light", wear_pending_intent)
                .Build();

                //add it to the notification builder
                Notification notification = builder.Extend(new Notification.WearableExtender()).Build();

                int notification_id = 1;
                if (notification_id < 9)
                {
                    notification_id += 1;
                }
                else
                {
                    notification_id = 0;
                }

                //var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
                notifyManager.Notify(notification_id + 2, notification);
            }
            else if (_ap == 2)
            {
                //ARModel.GetInstance.AirdropPhase = 3;
                var valuesForActivity = new Bundle();
                valuesForActivity.Equals("message");
                string groupkey = "group_key";
                var intent = new Intent(currentActivity, typeof(MainActivity));
                intent.PutExtras(valuesForActivity);
                var pendingIntent = PendingIntent.GetActivity(currentActivity, 0, intent, PendingIntentFlags.OneShot);
                var builder = new Notification.Builder(currentActivity)
                    .SetAutoCancel(true)
                    .SetContentIntent(pendingIntent)
                    .SetContentTitle("Welcome to CHADCS")
                    //.SetSmallIcon(Resource.Drawable.yellow)
                    //.SetLargeIcon(Resource.Drawable.red)
                    .SetContentText("AirDrop Light is Yellow")  //message is the one recieved from the notification
                    .SetGroup(groupkey)    //creates groups
                    .SetShowWhen(true)
                    .SetLocalOnly(false)
                    .SetVisibility(NotificationVisibility.Public)
                    .SetPriority((int)NotificationPriority.High);
                //                .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate);

                //intent for voice input or text selection 
                var wear_intent = new Intent(Intent.ActionView);
                var wear_pending_intent = PendingIntent.GetActivity(currentActivity, 0, wear_intent, 0);



                // Create the reply action and add the remote input
                var action = new Notification.Action.Builder(Resource.Drawable.icon, "Ok Light", wear_pending_intent)
                .Build();

                //add it to the notification builder
                Notification notification = builder.Extend(new Notification.WearableExtender()).Build();

                int notification_id = 1;
                if (notification_id < 9)
                {
                    notification_id += 1;
                }
                else
                {
                    notification_id = 0;
                }

                //var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
                notifyManager.Notify(notification_id + 2, notification);
            }

            else if (_ap == 1)
            {
                //ARModel.GetInstance.AirdropPhase = 3;
                var valuesForActivity = new Bundle();
                valuesForActivity.Equals("message");
                string groupkey = "group_key";
                var intent = new Intent(currentActivity, typeof(MainActivity));
                intent.PutExtras(valuesForActivity);
                var pendingIntent = PendingIntent.GetActivity(currentActivity, 0, intent, PendingIntentFlags.OneShot);
                var builder = new Notification.Builder(currentActivity)
                    .SetAutoCancel(true)
                    .SetContentIntent(pendingIntent)
                    .SetContentTitle("Welcome to CHADCS")
                    //.SetSmallIcon(Resource.Drawable.red)
                    //.SetLargeIcon(Resource.Drawable.red)
                    .SetContentText("AirDrop Light is Red")  //message is the one recieved from the notification
                    .SetGroup(groupkey)    //creates groups
                    .SetShowWhen(true)
                    .SetLocalOnly(false)
                    .SetVisibility(NotificationVisibility.Public)
                    .SetPriority((int)NotificationPriority.High);
                //                .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate);

                //intent for voice input or text selection 
                var wear_intent = new Intent(Intent.ActionView);
                var wear_pending_intent = PendingIntent.GetActivity(currentActivity, 0, wear_intent, 0);



                // Create the reply action and add the remote input
                var action = new Notification.Action.Builder(Resource.Drawable.icon, "Ok Light", wear_pending_intent)
                .Build();

                //add it to the notification builder
                Notification notification = builder.Extend(new Notification.WearableExtender()).Build();

                int notification_id = 1;
                if (notification_id < 9)
                {
                    notification_id += 1;
                }
                else
                {
                    notification_id = 0;
                }

                //var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
                notifyManager.Notify(notification_id + 2, notification);
            }
        }

    }
}