# ArcAndroidToolPlugin for Unity
_Copyright (c) 2014 Arclee

加入了 Android Webview 功能. 只能在 Android 上執行.

# 說明
* 可在 Unity 遊戲中直接插入一個 Andoird WebView.
* 點擊左上的 x 圖示可關閉 WebView.
* 在 WebView 顯示時, 若後方的遊戲的點擊(touch)有效, 使用者要在顯示 WebView 時, 自己要在遊戲中做 MASK 把點擊給擋下來.



# 導入方法
* 安裝 ArcAndroidToolPlugin.unitypackage
* 如果您的專案裡沒有 AndroidManifest.xml :

複製
```bat
  \Assets\Plugins\Android\ArcAndroidToolPlugin\AndroidManifest.xml
```
至
```bat
 \Assets\Plugins\Android\AndroidManifest.xml
```
* 如果您的專案裡已經有自己的 AndroidManifest.xml 就要修改它. (可以參考 \Assets\Plugins\Android\ArcAndroidToolPlugin\AndroidManifest.xml 內的寫法)

(1) 修改 AndroidManifest.xml 加入 permission
```xml
     <uses-permission android:name="android.permission.INTERNET" />
```

例如:
```xml
<?xml version="1.0" encoding="utf-8"?>
<manifest/>
  ...
	<uses-permission android:name="android.permission.INTERNET" />
	
    <application
    ...
    </application>
	
	
</manifest>
```
(2) 修改 AndroidManifest.xml 加入 ForwardNativeEventsToDalvik
```xml
 <meta-data android:name="unityplayer.ForwardNativeEventsToDalvik" android:value="true" />
```
例如:
```xml
<?xml version="1.0" encoding="utf-8"?>
<manifest/>
  ...
    <application
        <activity android:name="com.unity3d.player.UnityPlayerNativeActivity" android:label="@string/app_name">
          ...
          <meta-data android:name="unityplayer.ForwardNativeEventsToDalvik" android:value="true" />
        </activity>
    </application>
	
	
</manifest>
```

# Sample 
請看 Assets\ArcAndroidToolPlugin\Sample\sample.unity
* 一定要先建在 Scene 裡建立一個 GameObject, 加入 arcAndroidWebView.cs 這個 Component.
* 設定顯示大小
```c#
// 大小在 0 ~ 1 之間.
arcAndroidWebView.Instance.SetSizeScale(0.9f, 0.9f);
```
* 顯示網頁
```c#
arcAndroidWebView.Instance.ShowURL("http://forum.gamer.com.tw/B.php?bsn=27111");
```
* 強制關閉
```c#
arcAndroidWebView.Instance.CloseURL();
```
* 正常關閉網頁
按左上角的 x 圖示即可.
* 接收網頁關閉事件
```c#

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
```

