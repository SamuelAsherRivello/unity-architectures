/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furn
 * 
 * ished to do so, subject to
 * the following conditions:                                            
 *                                                                      
 * The above copyright notice and this permission notice shall be       
 * included in all copies or substantial portions of the Software.      
 *                                                                      
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.                                      
 */
// Marks the right margin of code *******************************************************************

//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using UnityEditor;
using System.IO;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.utilities
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Scriptable object utility.
	/// </summary>
	public class ScriptableObjectUtility
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
	
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		/// <summary>
		//	This makes it easy to create, name and place unique new ScriptableObject asset files.
		/// </summary>
		public static void CreateAsset<T> () where T : ScriptableObject
		{
			T asset = ScriptableObject.CreateInstance<T> ();
	 
			string path = AssetDatabase.GetAssetPath (Selection.activeObject);
			if (path == "") 
			{
				path = "Assets";
			} 
			else if (Path.GetExtension (path) != "") 
			{
				path = path.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
			}
	 
			string uniquePath_string = path + "/" + typeof(T).Name + ".asset";
			Debug.Log ("u: " + uniquePath_string);
			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (uniquePath_string);
	 
			AssetDatabase.CreateAsset (asset, assetPathAndName);
	 
			AssetDatabase.SaveAssets ();
			EditorUtility.FocusProjectWindow ();
			Selection.activeObject = asset;
		}
		
		/// <summary>
		/// Creates the asset from project selection.
		/// </summary>
		//DISABLE MENU [MenuItem("Assets/Create/MOM/Create ScriptableObject From Selected")]
		public static void CreateAssetFromProjectSelection ()
		{
			string selectedScriptPath_string;
			string selectedScriptName_string;
			ScriptableObject scriptableObject;
			string desiredScriptableObject_path;
			
			//
			if (ScriptableObjectUtility.hasValidProjectSelection()) {
				
				//	FIND SELECTED
				selectedScriptName_string = Selection.activeObject.name;
				selectedScriptPath_string = AssetDatabase.GetAssetPath (Selection.activeObject);
				desiredScriptableObject_path = selectedScriptPath_string.Replace (".cs",".asset");
				
				//	CREATE NEW OBJECT
				scriptableObject = ScriptableObject.CreateInstance (selectedScriptName_string);
				desiredScriptableObject_path = AssetDatabase.GenerateUniqueAssetPath (desiredScriptableObject_path);
				AssetDatabase.CreateAsset (scriptableObject, desiredScriptableObject_path);
		 
				//	STORE ASSET
				AssetDatabase.SaveAssets ();
				EditorUtility.FocusProjectWindow ();
				Selection.activeObject = scriptableObject;
				
			} else {
				Debug.Log ("Show ERROR Window: Must select ScriptableObject");	
			}
		}
		
		
		/// <summary>
		/// Hases the valid project selection.
		/// </summary>
		/// <returns>
		/// The valid project selection.
		/// </returns>
		public static bool hasValidProjectSelection ()
		{
			//TODO, CHECK THAT IT EXTENDS 'scriptableObject'
			if (Selection.activeObject != null) {
				return true;	
			} else {
				return false;
			}
			
			
		}
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		
		
	}
}

