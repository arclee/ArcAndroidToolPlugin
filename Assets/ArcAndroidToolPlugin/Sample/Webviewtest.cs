using UnityEngine;
using System.Collections;

public class Webviewtest : MonoBehaviour {

	//要連去的網站..
	public string url;
	public string internalKeyword;
	// Use this for initialization
	void Start ()
	{
	}

	void OnEnable()
	{
		//接收網頁關閉事件..
		arcAndroidWebView.onCloseURLEvent += onCloseURL;
	}

	void OnDisable()
	{
		//移除接收網頁關閉事件..
		arcAndroidWebView.onCloseURLEvent -= onCloseURL;

	}
	
	void onCloseURL()
	{
		//網頁關閉時要要做什麼事, 都寫在這裡...
		Debug.Log("Webviewtest onCloseURL");
	}

	// Update is called once per frame
	void Update ()
	{
	}

	
	void OnGUI ()
	{
		//不同大小的網頁..
		if (GUI.Button(new Rect (0, 100, 100, 100), "Size 0"))
		{
			//設定網站包含關鍵字時, 就留在原webview, 否則另開應用程式.
			arcAndroidWebView.Instance.SetInteralKeyword(internalKeyword);
			//設縮放大小..
			arcAndroidWebView.Instance.SetSizeScale(1.0f, 1.0f);
			//顯示網頁...
			arcAndroidWebView.Instance.ShowURL(url);
		}
		
		
		if (GUI.Button(new Rect (0, 200, 100, 100), "Size 1"))
		{
			arcAndroidWebView.Instance.SetSizeScale(0.9f, 0.9f);
			arcAndroidWebView.Instance.ShowURL(url);
		}
		
		if (GUI.Button(new Rect (0, 300, 100, 100), "Size 2"))
		{
			arcAndroidWebView.Instance.SetSizeScale(0.5f, 0.5f);
			arcAndroidWebView.Instance.ShowURL(url);
		}
		
		if (GUI.Button(new Rect (0, 400, 100, 100), "Size 3"))
		{
			arcAndroidWebView.Instance.SetSizeScale(2.0f, 2.0f);
			arcAndroidWebView.Instance.ShowURL(url);
		}
		
		if (GUI.Button(new Rect (0, 500, 100, 100), "close"))
		{
			//強制關閉...
			arcAndroidWebView.Instance.CloseURL();
		}
	}
}
