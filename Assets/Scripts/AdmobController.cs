using System;
using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdmobController : MonoBehaviour
{
	private const float TIME_KEEPING = 20f;
	private const float TIME_NEXT = 35f;

	private BannerView bannerView;

	private float deltaTime = 0.0f;
	private float timeDestroy = 0.0f;

	private float timeShow = 10f;

	public void Update ()
	{
		// Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
		// value.
		deltaTime += Time.deltaTime;

		if (deltaTime > timeShow) {
//			Debug.Log ("Show Banner Ads:: how Banner Ads:: how Banner Ads:: how Banner Ads:: how Banner Ads:: " + deltaTime);
			RequestBanner ();

			timeDestroy = deltaTime + TIME_KEEPING;
			timeShow += TIME_NEXT;
		}

		if (deltaTime > timeDestroy) {
			bannerView.Destroy ();
		}

	}

	// Returns an ad request with custom ad targeting.
	private AdRequest CreateAdRequest ()
	{
		return new AdRequest.Builder ()
			.AddTestDevice (AdRequest.TestDeviceSimulator)
			.AddTestDevice ("0123456789ABCDEF0123456789ABCDEF")
			.AddKeyword ("game")
			.SetGender (Gender.Male)
			.SetBirthday (new DateTime (1985, 1, 1))
			.TagForChildDirectedTreatment (false)
			.AddExtra ("color_bg", "9B30FF")
			.Build ();
	}

	public void RequestBanner ()
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
