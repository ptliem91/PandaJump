using UnityEngine;
using System.Collections;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookController : MonoBehaviour
{
	//	public Text txtUserId;

	private void Awake ()
	{
		if (!FB.IsInitialized) {
			FB.Init ();
		
		} else {
			FB.ActivateApp ();
		}
	}

	public void LogIn ()
	{
		FB.LogInWithReadPermissions ();
	}

	private void OnLogIn (ILoginResult result)
	{
		if (FB.IsLoggedIn) {
			AccessToken token = AccessToken.CurrentAccessToken;
//			txtUserId.text = token.UserId;

		} else {
			Debug.Log ("Canceled Login");
		}
	}

	public void Share ()
	{
		FB.ShareLink (
			contentTitle: "This is message share",
//			contentURL: new System.Uri ("link google play"),
			contentDescription: "Here is my first game!",
			callback: OnShare);
	}

	private void OnShare (IShareResult result)
	{
		if (result.Cancelled || !string.IsNullOrEmpty (result.Error)) {
//			Debug.Log ("Share error: " + result.Error);
//			txtUserId.text = result.Error;

		} else if (!string.IsNullOrEmpty (result.PostId)) {
//			Debug.Log ("result.PostId: " + result.PostId);
//			txtUserId.text = result.PostId;
		
		} else {
//			Debug.Log ("Share success!");
//			txtUserId.text = "Share success";
		}
	}
}
