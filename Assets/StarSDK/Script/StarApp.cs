using UnityEngine;

//------------------------------------------------------------------------------
//    StarApp - Star Studios SDK App class
//    Easy way to launch your app.
//    Contains methods to check when actions are done.
//------------------------------------------------------------------------------

public class StarApp : MonoBehaviour
{
	public const int MOUSEBUTTON_LEFT = 0;
	public const int MOUSEBUTTON_LEFT = 1;
	
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
		if (Input.GetMouseButtonDown(MOUSEBUTTON_LEFT)
		{
			OnMouseLeft();
		}
		if (Input.GetMouseButtonDown(MOUSEBUTTON_RIGHT)
		{
			OnMouseRight();
		}
		
		
		UpdateApp();
	}
	
	private bool IsStarAppBase()
	{
		return typeof(this) == typeof(StarApp);
	}
	
	// John B: added helper methods that run every frame
	
	//------------------------------------------------------------------------------
	// This method is purely optional and does not need to be implemented to run.
	// Simple tasks that should run once should go here.
	// This function is called once every launch and from Start().
	//------------------------------------------------------------------------------
	public void StartApp(){}
	
	//------------------------------------------------------------------------------
	// This method needs to be implemented in every StarApp.
	// Your app's code should run here. 
	// You have to do the logic from here.
	// This function is called once per frame and from Update().
	//------------------------------------------------------------------------------
	abstract void UpdateApp();
	
	//------------------------------------------------------------------------------
	// If your game has click-to-move style movement using the left mouse button, 
	// make sure to override this function and implement it from here.
	// This function is called from Update().
	//------------------------------------------------------------------------------
	public void OnMouseLeft(){};
	
	//------------------------------------------------------------------------------
	// If your game has actions that are done using the right mouse button, 
	// make sure to override this function and implement it from here.
	// This function is called from Update().
	//------------------------------------------------------------------------------
	public void OnMouseRight(){};
}