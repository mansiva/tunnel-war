using UnityEditor;
using UnityEngine;
using System.Collections;

public class ScriptableObjectCreator
{
	[MenuItem("Assets/Create/Scriptable Object/From Script", true, 80)]
	private static bool ValidateCreateNewObject()
	{
		MonoScript script = Selection.activeObject as MonoScript;
		if(null == script){ return false; }
		System.Type type = script.GetClass();

		if(!type.IsAbstract && typeof(ScriptableObject).IsAssignableFrom(type)){
			return true;
		}

		return false;
	}

	[MenuItem("Assets/Create/Scriptable Object/From Script", false, 80)]
	private static void CreateNewObject()
	{
		MonoScript script = Selection.activeObject as MonoScript;
		CreateAndSaveNewScriptableObjectAsset (script.GetClass());
	}

	public static void CreateAndSaveNewScriptableObjectAsset<T>() where T: ScriptableObject
	{
		CreateAndSaveNewScriptableObjectAsset(typeof(T)); 
	}

	public static void CreateAndSaveNewScriptableObjectAsset<T>(string path) where T: ScriptableObject
	{
		CreateAndSaveNewScriptableObjectAsset(typeof(T), path); 
	}

	public static void CreateAndSaveNewScriptableObjectAsset(System.Type type)
	{
		string assetPath = EditorUtility.SaveFilePanelInProject(
			string.Format ("New '{0}' Instance", type.Name), 
			string.Format ("New{0}", type.Name), 
			"asset", 
			string.Format ("Create a new instance of '{0}'", type.Name));

		CreateAndSaveNewScriptableObjectAsset (type, assetPath);
	}

	public static void CreateAndSaveNewScriptableObjectAsset(System.Type type, string path)
	{
		if(!string.IsNullOrEmpty (path))
		{
			// Create the new scriptable object
			ScriptableObject newObj = ScriptableObject.CreateInstance (type);
			AssetDatabase.CreateAsset (newObj, path);
			AssetDatabase.SaveAssets ();
			AssetDatabase.ImportAsset (path);
			Selection.activeObject = newObj;
		}
		else
		{
			throw new UnityException ("Could not create asset because path was invalid");
		}
	}
}
