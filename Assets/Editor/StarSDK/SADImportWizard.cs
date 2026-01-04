using UnityEditor;
using UnityEngine;

public class SADImportWizard : ScriptableWizard
{
	StarAppDescriptor descr;
	
	private void OnEnable()
	{

	}

	private void OnInspectorUpdate()
	{
	    if (Resources.FindObjectsOfTypeAll(typeof(SADViewer)).Length == 0)
	    {
			Close();
	    }
	}

	protected override bool DrawWizardGUI()
	{
	    GUILayout.Label("Welcome to the Star Application Descriptor import wizard." + 
		" This will import a new Descriptor from a script.", EditorStyles.wordWrappedLabel);
	    EditorGUILayout.Separator();
	    return base.DrawWizardGUI();
	}

	private void OnWizardCreate()
	{
	    if (Resources.FindObjectsOfTypeAll(typeof(SADViewer)).Length >= 1)
	    {
			//((SADViewer)Resources.FindObjectsOfTypeAll(typeof(SADViewer))[0]).Import(importCompanyName, importProductName);
	    }
	}
}
