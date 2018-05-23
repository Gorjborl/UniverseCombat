using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class RewardedAd : MonoBehaviour {
    
    RewardBasedVideoAd RewardedVideo;

    // Use this for initialization
    void Start()
    {

        RewardedVideo = RewardBasedVideoAd.Instance;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadVideoAd()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-5506973357467780/4430598242";
#elif UNITY_IOS
        string adUnitId = "INSERT_IOS_AD_UNIT_ID";
#else
        string adUnitId = "Unexpected Platform";
#endif
        if (!RewardedVideo.IsLoaded())
        {
            AdRequest request = new AdRequest.Builder().Build();
            RewardedVideo.LoadAd(request, adUnitId);
        }

        if (RewardedVideo.IsLoaded())
        {
            RewardedVideo.Show();
        }
    }
}
