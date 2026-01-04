
using UnityEngine;
using UnityEditor;
public class SADViewer : EditorWindow
{
	private bool showAdd;
	
	private const int VIEW = 0;
	
	public StarAppDescriptor currentDescriptor;
	
	[MenuItem("StarSDK/AppDescriptor Viewer")]
	private static void Init()
	{
		SADViewer editor = (SADViewer)GetWindow(typeof(SADViewer), false, "AppDescriptor Viewer");

		Vector2 minSize = editor.minSize;
		minSize.x = 230;
		editor.minSize = minSize;
    }
	
	private void OnGUI()
	{
		EditorGUILayout.Space();

		DrawViewerTop();
		
		DrawViewMenu();
	}
	
	private void DrawViewerTop()
	{
        GUILayout.Toolbar(VIEW, new string[] { "View Descriptors"});
	}
	
	private void DrawViewMenu()
	{
		 if (GUILayout.Button("Import"))
		 {
			 //SADImportWizard wizard = ScriptableWizard.DisplayWizard<SADImportWizard>("Import a descriptor", "Import");
			 GUILayout.Label("Please select a script of type " + "StarAppDescriptor.");
			 
		 }
	}
}