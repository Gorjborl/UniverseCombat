using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Request Ads
        BannerRequest();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BannerRequest()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-5506973357467780/9763532588";
#elif UNITY_IOS
        string adUnitId = "INSERT_IOS_AD_UNIT_ID";
#else
        string adUnitId = "Unexpected Platform";
#endif
        //banner 320x50 at bottom
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        //AdRequest
        AdRequest request = new AdRequest.Builder().Build();
        //Load Banner
        bannerView.LoadAd(request);
    }
}
