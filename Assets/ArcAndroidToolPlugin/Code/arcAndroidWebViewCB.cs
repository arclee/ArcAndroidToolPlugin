using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class arcAndroidWebViewCB : AndroidJavaProxy {
	
	public static Action onCloseURLEvent;

	public arcAndroidWebViewCB():base("com.arc.arcandroidtool.ArcAndroidWebViewCallBack")
	{
		
	}
	
	// Called before playing an ad.
	public void onCloseURL()
	{
		Debug.Log("onCloseURL");
		
		if (onCloseURLEvent != null)
		{
			onCloseURLEvent();
		}
	}

}
