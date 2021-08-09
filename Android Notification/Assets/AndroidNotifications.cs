using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class AndroidNotifications : MonoBehaviour {

    void Start () {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel () {
            Id = "example_channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic Notifications",

        };

        AndroidNotificationCenter.RegisterNotificationChannel (notificationChannel);

        AndroidNotification notification = new AndroidNotification ();
        notification.Title = "Title1";
        notification.Text = "Title2";
        notification.SmallIcon = "icon_1";
        notification.LargeIcon = "icon_2";
        notification.ShowTimestamp = true;
        notification.FireTime = System.DateTime.Now.AddSeconds (20);

        var identifier =
            AndroidNotificationCenter.SendNotification (notification, "example_channel_id");

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus (identifier) == NotificationStatus.Scheduled) {
            AndroidNotificationCenter.CancelAllNotifications ();
            AndroidNotificationCenter.SendNotification (notification, "example_channel_id");

        }
    }

}