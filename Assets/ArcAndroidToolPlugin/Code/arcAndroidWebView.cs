using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class arcAndroidWebView : MonoBehaviour {
	
	static public arcAndroidWebView Instance;
	private static bool isAdInital = false;

	private static AndroidJavaObject Jo = null;
	static public arcAndroidWebViewCB webViewCB = null;

	//關閉的事件 call back 都加至這裡..
	public static Action onCloseURLEvent;

	//自動轉向...
	ScreenOrientation lastOrit;
	Vector2 scale = new Vector2(1.0f, 1.0f);

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
		lastOrit = Screen.orientation;
	}
	
	void OnEnable()
	{
		arcAndroidWebViewCB.onCloseURLEvent += onCloseURL;
	}
	
	void OnDisable()
	{
		arcAndroidWebViewCB.onCloseURLEvent -= onCloseURL;
		
	}
	
	void onCloseURL()
	{
		Debug.Log("arcAndroidWebView onCloseURL");
		if (onCloseURLEvent != null)
		{
			onCloseURLEvent();
		}

	}

	void Inital()
	{
		if (!isAdInital)
		{
#if UNITY_ANDROID
		
			AndroidJavaClass player = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" );
			AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
			Jo = new AndroidJavaObject("com.arc.arcandroidtool.ArcAndroidWebViewWrapper", activity);
			if (Jo != null)
			{
				webViewCB = new arcAndroidWebViewCB();
				Jo.Call("SetListenerCB", webViewCB);

				isAdInital = true;
			}
#endif
		}
	}

	public void ShowURL(string url)
	{
#if UNITY_ANDROID
		if (Jo != null)
		{		
			Jo.Call("ShowURL", url);
		}
#endif
	}

	public void CloseURL()
	{
#if UNITY_ANDROID
		if (Jo != null)
		{		
			Jo.Call("CloseURL");
		}
#endif
	}

	public void SetSizeScale(float x, float y)
	{
#if UNITY_ANDROID
		if (Jo != null)
		{	
			scale.x = x;
			scale.y = y;
			Jo.Call("SetSizeScale", x, y);
		}
#endif
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (lastOrit != Screen.orientation)
		{
			lastOrit = Screen.orientation;
			
			SetSizeScale(scale.x, scale.y);
		}
	}
}
