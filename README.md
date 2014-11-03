# ArcAndroidToolPlugin for Unity
_Copyright (c) 2014 Arclee

加入了 Android Webview 功能. 只能在 Android 上執行.
![Alt text](Assets/ArcAndroidToolPlugin/Sample/ScreenShot/Screenshot_2014-10-11-17-23-57.png?raw=true "使用前")
(使用前)

![Alt text](Assets/ArcAndroidToolPlugin/Sample/ScreenShot/Screenshot_2014-10-11-17-24-10.png?raw=true "全畫面網頁")
(全畫面網頁)

![Alt text](Assets/ArcAndroidToolPlugin/Sample/ScreenShot/Screenshot_2014-10-11-17-24-22.png?raw=true "90%大小網頁")
(90%大小網頁)

![Alt text](Assets/ArcAndroidToolPlugin/Sample/ScreenShot/Screenshot_2014-10-11-17-24-44.png?raw=true "自動轉向")
(自動轉向)

![Alt text](Assets/ArcAndroidToolPlugin/Sample/ScreenShot/Screenshot_2014-10-11-17-25-35.png?raw=true "可輸入文字")
(可輸入文字)

# 說明
* 可在 Unity 遊戲中直接插入一個 Andoird WebView.
* 點擊左上的 x 圖示可關閉 WebView.
* 可設定關閉圖示的基本大小.(之後會自動隨機手的解析度調整大小)
* 按手機的 back 鍵可回上一頁.
* 可設定內部網址關鍵字, 若網址包含該關鍵字則會留在 Unity webview 裡, 否則會另外開一個應用程式來瀏覽網址.
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
* 設定顯示縮放大小 (以下的實作可參考 Webviewtest.cs)
```c#
// 大小在 0 ~ 1 之間.
arcAndroidWebView.Instance.SetSizeScale(0.9f, 0.9f);
```
* 設定關閉按鈕的基本大小.(會自動隨機手的解析度調整大小)
```c#
arcAndroidWebView.Instance.SetCloseBtnBaseSize(40.0f);
```
* 可設定內部網址關鍵字, 設定空字串為永遠留在 Unity 裡.
```c#
//例1:http://m.gamer.com.tw/forum/  的網址留在 Unity 裡顯示.
arcAndroidWebView.Instance.SetInteralKeyword("http://m.gamer.com.tw/forum/");
//例2:不論什麼網址, 都留在 Unity 裡顯示.
arcAndroidWebView.Instance.SetInteralKeyword("");
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

![Alt text](Assets/ArcAndroidToolPlugin/Sample/ScreenShot/Screenshot_2014-10-11-17-24-22.png?raw=true "點左上角的 x 關閉")

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

