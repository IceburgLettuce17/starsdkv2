
using UnityEngine;

public class SampleApp : StarApp
{
	// Old sample app
	/*public override void StartApp()
	{
		Debug.Log("Hello World!");
	}
	
	
	public override void UpdateApp(){}
	public override void OnMouseLeft(){ Debug.Log("LClick"); }
	public override void OnMouseRight(){ Debug.Log("RClick"); }*/
	
	public const int STATE_DEMO = 0;
	public static int s_appState = STATE_DEMO;
	
	public override void StartApp()
	{
		Debug.Log("StartApp");
		StarApp.SetDescriptorValues("Sample StarSDK App",
		"StarSDK Test App",
		"Star Studios",
		"1.0.0",
		this);
	}
	
	public override void UpdateApp()
	{
		StateMachine_Custom(s_appState);
	}
	
	public override void StateMachine_Custom(int state)
	{
		if (state > StarApp.STATE_QUIT)
		{
			switch (state)
			{
				case STATE_DEMO:
					Debug.Log("Hello");
					break;
					
				default:
					Debug.Log("State " + state + " is not a valid state."); break;
			}
		}
	}
	
	public override void OnMouseLeft(){}
	public override void OnMouseRight(){}
}
