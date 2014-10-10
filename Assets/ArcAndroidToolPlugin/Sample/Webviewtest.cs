using UnityEngine;
using System.Collections;

public class Webviewtest : MonoBehaviour {

	public string url;
	ScreenOrientation lastOrit;
	Vector2 scale = new Vector2(1.0f, 1.0f);
	// Use this for initialization
	void Start ()
	{
		lastOrit = Screen.orientation;
	}
	
	// Update is called once per frame
	void Update ()
	{		
		if (lastOrit != Screen.orientation)
		{
			lastOrit = Screen.orientation;
			
			arcAndroidWebView.Instance.SetSizeScale(scale.x, scale.y);
		}
	}

	
	void OnGUI ()
	{
		
		if (GUI.Button(new Rect (0, 100, 100, 100), "Size 0"))
		{
			scale.x = 1;
			scale.y = 1;
			
			arcAndroidWebView.Instance.SetSizeScale(scale.x, scale.y);
			arcAndroidWebView.Instance.ShowURL(url);
		}
		
		
		if (GUI.Button(new Rect (0, 200, 100, 100), "Size 1"))
		{
			scale.x = 0.9f;
			scale.y = 0.9f;
			arcAndroidWebView.Instance.SetSizeScale(scale.x, scale.y);
			arcAndroidWebView.Instance.ShowURL(url);
		}
		
		if (GUI.Button(new Rect (0, 300, 100, 100), "Size 2"))
		{
			scale.x = 0.5f;
			scale.y = 0.5f;
			arcAndroidWebView.Instance.SetSizeScale(scale.x, scale.y);
			arcAndroidWebView.Instance.ShowURL(url);
		}
		
		if (GUI.Button(new Rect (0, 400, 100, 100), "Size 3"))
		{
			scale.x = 2.0f;
			scale.y = 2.0f;
			arcAndroidWebView.Instance.SetSizeScale(scale.x, scale.y);
			arcAndroidWebView.Instance.ShowURL(url);
		}
		
		if (GUI.Button(new Rect (0, 500, 100, 100), "close"))
		{
			arcAndroidWebView.Instance.CloseURL();
		}
	}
}
