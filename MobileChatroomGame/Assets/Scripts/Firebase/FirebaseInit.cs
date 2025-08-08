using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Analytics;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseInit : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnFirebaseInitialized = new UnityEvent();

    void Start()
    {
        FirebaseApp.CheckAndDixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Excpetion != null)
            {
                debug.LogError($"Failed to initializeFirebase{task.Exception}");
                return;
            }
            OnFirebaseInitialized.Invoke();
        });

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
    }

}
