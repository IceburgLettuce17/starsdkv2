using UnityEngine;
using System;

#pragma warning disable 0649 // s_urlToOpen should be set in implemented class
//------------------------------------------------------------------------------
//    StarApp - Star Studios SDK App class
//    Easy way to make your app.
//    Contains methods to check when actions are done.
//	  By Akira and John B
//------------------------------------------------------------------------------



public abstract class StarApp : MonoBehaviour
{
	public const int MOUSEBUTTON_LEFT = 0;
	public const int MOUSEBUTTON_RIGHT = 1;
	
	//--------------------------------------//
	//           State Machine				//
	//           By Akira					//
	//--------------------------------------//
	
	// Do not mess with this; this is StarApp default states
	public const int STATE_QUIT = -1;
	public const int STATE_NORMAL = 0;
	public const int STATE_INMENU = 1;
	
	// State variable (it can be any of STATE_ consts)
	public static int s_sappState = STATE_NORMAL;
	
	public static StarAppDescriptor s_descriptor;
	
	public static void SetDescriptorValues(string name, string desc, string provider, string ver, StarApp app)
	{
		s_descriptor.appName = name;
		s_descriptor.appDescription = desc;
		s_descriptor.appProvider = provider;
		s_descriptor.appVersion = ver;
		s_descriptor.appClass = app;
	}
	public void StateMachineInit(int state)
	{
		switch (state)
		{
			case STATE_QUIT:
				Application.Quit();
				break;
			
			
			case STATE_NORMAL:
				break;
				
			case STATE_INMENU:
				break;
		}
	}
	
	public abstract void StateMachine_Custom(int state);
	
	
	private void Start()
	{
		// John B add
		// Akira: this is deprecated, you cannot add abstracts to a go
		//if (gameObject.GetComponent<StarApp>() != null && IsStarAppBase())
		//{
		//	Debug.Log("StarApp should not be added to a GO directly.");
		//}
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
		
		StateMachineInit(s_sappState);
		UpdateApp();
	}
	
	//------------------------------------------------------------------------------
	// Quit the app.
	// When Exit or Quit option is selected (or the app quits for any other reason) you should call this function.
	//------------------------------------------------------------------------------
	static protected void Quit()
	{
		Debug.Log("StarApp.quit");

		s_sappState = STATE_QUIT;
	}

	//------------------------------------------------------------------------------
	// StarApp : Unity misc. wrapper
	// wrapper for some usual unity function, use this instead of the unity ones
	//------------------------------------------------------------------------------
	
	// akira add (for StarApp::UnityWrapper.OpenURL(string))
	
	// Stores the URL that will be opened next OpenURLPredef call
	private static string s_urlToOpen;
	
	// Indicates that an OpenURLPredef call in happening
	private static bool s_urlOpenPending;
	
	//------------------------------------------------------------------------------
	//Performs Application.OpenURL
	//
	//This method wraps calls to OpenURL, incorporating some workarounds for usual OpenURL problems
	//@param url the url to open
	//@return if the opening was successful
	//------------------------------------------------------------------------------
	public static void OpenURL(string url)
	{
		Application.OpenURL(url);
		Debug.Log("openurl called");
	}
	
	private static void OpenURLPredef()
	{
		s_urlOpenPending = false;
		
		if (s_urlToOpen != null)
		{
			Application.OpenURL(s_urlToOpen);
		}
		if (StarSDKConfig.exitAfterOpenUrlPredef)
		{
			Quit();
		}
		
	}
	
	// this is not used
	//private bool IsStarAppBase()
	//{
	//	return this.GetType() == typeof(StarApp);
	//}
	
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