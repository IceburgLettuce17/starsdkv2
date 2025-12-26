#define EXIT_ON_OPENURLPREDEF // StarSDKConfig.exitAfterOpenUrlPredef
// For configs we are using ifdefs until a StarSDKConfig class is done
using UnityEngine;
using System;


#pragma warning disable 0649 // s_urlToOpen should be set in implemented class
//------------------------------------------------------------------------------
//    StarApp - Star Studios SDK App class
//    Easy way to launch your app.
//    Contains methods to check when actions are done.
//	  By Akira and John B
//------------------------------------------------------------------------------



public abstract class StarApp : MonoBehaviour
{
	public const int MOUSEBUTTON_LEFT = 0;
	public const int MOUSEBUTTON_RIGHT = 1;
	
	private void Start()
	{
		// John B add
		if (gameObject.GetComponent<StarApp>() != null && IsStarAppBase())
		{
			Debug.Log("StarApp should not be added to a GO directly.");
		}
		StartApp();
	}
	
	private void Update()
	{
		// checker for mouse funcs
		if (Input.GetMouseButtonDown(MOUSEBUTTON_LEFT))
		{
			OnMouseLeft();
		}
		if (Input.GetMouseButtonDown(MOUSEBUTTON_RIGHT))
		{
			OnMouseRight();
		}
		
		// akira add
		if (s_urlOpenPending)
		{
			OpenURLPredef();
		}
		UpdateApp();
	}
	
	// akira add (for StarApp::UnityWrapper.OpenURL(string))
	
	// Stores the URL that will be opened next OpenURLPredef call
	private static string s_urlToOpen;
	
	// Indicates that an OpenURLPredef call in happening
	private static bool s_urlOpenPending;
	
	
	//------------------------------------------------------------------------------
	//Request to quit the app.
	//When Exit or Quit option is selected (or the app quits for any other reason) you should call this function.
	//------------------------------------------------------------------------------
	static protected void Quit()
	{
		Debug.Log("StarApp.quit");

		Application.Quit();
	}

	//------------------------------------------------------------------------------
	// StarApp : Unity misc. wrapper
	// wrapper for some usual unity function, use this instead of the unity ones
	//------------------------------------------------------------------------------
	
	//------------------------------------------------------------------------------
	//Performs Application.OpenURL
	//
	//This method wraps calls to OpenURL, incorporating some workarounds for usual OpenURL problems
	//@param url the url to open
	//@return if the opening was successful
	//------------------------------------------------------------------------------
	public void OpenURL(string url)
	{
		try
		{
			Application.OpenURL(url);
		}
		catch (Exception except)
		{
			Debug.Log("OpenURL Failed with url " + url + " with exception " + except.ToString());
		}
	}
	
	private static void OpenURLPredef()
	{
		s_urlOpenPending = false;
		
		if (s_urlToOpen != null)
		{
			try
			{
				Application.OpenURL(s_urlToOpen);
			}
			catch (Exception){}
		}
		#if EXIT_ON_OPENURLPREDEF
			Quit();
		#endif
	}
	
	private bool IsStarAppBase()
	{
		return this.GetType() == typeof(StarApp);
	}
	
	// John B: added helper methods that run every frame
	
	//------------------------------------------------------------------------------
	// his method needs to be implemented in every StarApp.
	// Simple tasks that should run once should go here.
	// This function is called once every launch and from Start().
	//------------------------------------------------------------------------------
	public abstract void StartApp();
	
	//------------------------------------------------------------------------------
	// This method needs to be implemented in every StarApp.
	// Your app's code should run here. 
	// You have to do the logic from here.
	// This function is called once per frame and from Update().
	//------------------------------------------------------------------------------
	public abstract void UpdateApp();
	
	//------------------------------------------------------------------------------
	// If your game has click-to-move style movement using the left mouse button, 
	// make sure to override this function and implement it from here.
	// This function is called from Update().
	//------------------------------------------------------------------------------
	public abstract void OnMouseLeft();
	
	//------------------------------------------------------------------------------
	// If your game has actions that are done using the right mouse button, 
	// make sure to override this function and implement it from here.
	// This function is called from Update().
	//------------------------------------------------------------------------------
	public abstract void OnMouseRight();
}