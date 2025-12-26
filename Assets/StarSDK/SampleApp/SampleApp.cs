
using UnityEngine;

public class SampleApp : StarApp
{
	public override void StartApp()
	{
		Debug.Log("Hello World!");
	}
	
	
	public override void UpdateApp(){}
	public override void OnMouseLeft(){ Debug.Log("LClick"); }
	public override void OnMouseRight(){ Debug.Log("RClick"); }
}
