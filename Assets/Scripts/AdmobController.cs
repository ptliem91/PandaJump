using System;
using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdmobController : MonoBehaviour
{
	private const float TIME_KEEPING = 25f;
	//25f
	private const float TIME_NEXT = 60f;
	//90f

	private BannerView bannerView;
	private InterstitialAd interstitial;

	private float timeDestroy = TIME_KEEPING;
	private float timeShow = 0.0f;
	private float timeNextShow = 20f;
	//30f

	public void Update ()
	{
//		print (Time.realtimeSinceStartup);
		timeShow = Time.realtimeSinceStartup;

		if (timeShow > timeNextShow) {
//			Debug.Log ("Show Banner Ads:: how Banner Ads:: how Banner Ads:: how Banner Ads:: how Banner Ads:: " + timeShow);
			RequestBanner ();

			timeDestroy = timeShow + TIME_KEEPING;
			timeNextShow = timeShow + TIME_NEXT;

//			Debug.Log ("timeDestroytimeDestroytimeDestroy:::" + timeDestroy);
//			Debug.Log ("timeNextShowtimeNextShowtimeNextShow:::" + timeNextShow);
		}

		if (timeShow > timeDestroy) {
//			Debug.Log ("timeDestroy=========>" + timeDestroy);
			this.bannerView.Destroy ();
			timeDestroy = 9999999f;
		}

	}

	// Returns an ad request with custom ad targeting.
	private AdRequest CreateAdRequest ()
	{
		return new AdRequest.Builder ()
			.AddTestDevice (AdRequest.TestDeviceSimulator)
			.AddTestDevice ("715B8ED480FE68F53C865C5CD0BC9605")
//			.AddTestDevice ("A2568EFD855BF5841BFF07096C5F87D5")
			.AddExtra ("color_bg", "9B30FF")
			.Build ();
	}

	private void RequestBanner ()
	{
		
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-5682292900657385/2908571350";
		#elif UNITY_IPHONE
		string adUnitId = "unused";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		this.bannerView = new BannerView (adUnitId, AdSize.SmartBanner, AdPosition.Top);

		// Register for ad events.
		this.bannerView.OnAdLoaded += this.HandleAdLoaded;
		this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
		this.bannerView.OnAdLoaded += this.HandleAdOpened;
		this.bannerView.OnAdClosed += this.HandleAdClosed;
		this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

		// Load a banner ad.
		this.bannerView.LoadAd (this.CreateAdRequest ());
	}

	private void RequestInterstitial ()
	{
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-5682292900657385/9370247352";
		#elif UNITY_IPHONE
		string adUnitId = "unused";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		this.interstitial = new InterstitialAd (adUnitId);

		// Register for ad events.
		this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
		this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
		this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
		this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
		this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

		// Load an interstitial ad.
		this.interstitial.LoadAd (this.CreateAdRequest ());
	}

	private void ShowInterstitial ()
	{
		if (this.interstitial.IsLoaded ()) {
			this.interstitial.Show ();
		} else {
			MonoBehaviour.print ("Interstitial is not ready yet");
		}
	}

	#region Banner callback handlers

	public void HandleAdLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdLoaded event received");
	}

	public void HandleAdFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print ("HandleFailedToReceiveAd event received with message: " + args.Message);
	}

	public void HandleAdOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdOpened event received");
	}

	public void HandleAdClosed (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdClosed event received");
	}

	public void HandleAdLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdLeftApplication event received");
	}

	#endregion

	#region Interstitial callback handlers

	public void HandleInterstitialLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialLoaded event received");
	}

	public void HandleInterstitialFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print (
			"HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}

	public void HandleInterstitialOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialOpened event received");
	}

	public void HandleInterstitialClosed (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialClosed event received");
	}

	public void HandleInterstitialLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialLeftApplication event received");
	}

	#endregion

	#region Native express ad callback handlers

	public void HandleNativeExpressAdLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleNativeExpressAdAdLoaded event received");
	}

	public void HandleNativeExpresseAdFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print (
			"HandleNativeExpressAdFailedToReceiveAd event received with message: " + args.Message);
	}

	public void HandleNativeExpressAdOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleNativeExpressAdAdOpened event received");
	}

	public void HandleNativeExpressAdClosed (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleNativeExpressAdAdClosed event received");
	}

	public void HandleNativeExpressAdLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleNativeExpressAdAdLeftApplication event received");
	}

	#endregion

	#region RewardBasedVideo callback handlers

	public void HandleRewardBasedVideoLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoLoaded event received");
	}

	public void HandleRewardBasedVideoFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print (
			"HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
	}

	public void HandleRewardBasedVideoOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoClosed event received");
	}

	public void HandleRewardBasedVideoRewarded (object sender, Reward args)
	{
		string type = args.Type;
		double amount = args.Amount;
		MonoBehaviour.print (
			"HandleRewardBasedVideoRewarded event received for " + amount.ToString () + " " + type);
	}

	public void HandleRewardBasedVideoLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoLeftApplication event received");
	}

	#endregion
}
