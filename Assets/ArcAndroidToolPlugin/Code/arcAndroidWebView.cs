using UnityEngine;
using System.Collections;

public class arcAndroidWebView : MonoBehaviour {
	
	static public arcAndroidWebView Instance;
	private static bool isAdInital = false;
	private static AndroidJavaObject Jo = null;
	
	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}
	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
		Inital();
	}

	void Inital()
	{
		if (!isAdInital)
		{
#if UNITY_ANDROID
			AndroidJavaClass player = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" );
			AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
			Jo = new AndroidJavaObject("com.arc.arcandroidtool.ArcAndroidWebView", activity);
			if (Jo != null)
			{
				isAdInital = true;
			}
#endif
		}
	}

	public void ShowURL(string url)
	{
		if (Jo != null)
		{		
			Jo.Call("ShowURL", url);
		}
	}

	public void CloseURL()
	{
		if (Jo != null)
		{		
			Jo.Call("CloseURL");
		}
	}

	public void SetSizeScale(float x, float y)
	{
		if (Jo != null)
		{	
			Jo.Call("SetSizeScale", x, y);
		}
	}
}
