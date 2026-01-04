
using UnityEngine;
using UnityEditor;
public class SADViewer : EditorWindow
{
	[MenuItem("StarSDK/AppDescriptor Viewer")]
	private static void Init()
	{
       SADViewer editor = (SADViewer)GetWindow(typeof(SADViewer), false, "AppDescriptor Viewer");

		// Require the editor window to be at least 300 pixels wide
		Vector2 minSize = editor.minSize;
		minSize.x = 230;
		editor.minSize = minSize;
    }
}