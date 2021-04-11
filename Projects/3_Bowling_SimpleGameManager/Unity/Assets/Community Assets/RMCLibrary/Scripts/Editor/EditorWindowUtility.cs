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
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.utilities
{
	
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Generics Utility
	/// </summary>
	public class EditorWindowUtility
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
		/// Sets the editor window tab icon.
		/// </summary>
		/// <param name='cachedTitleContent'>
		/// Cached title content.
		/// </param>
		/// <param name='tabIcon_texture2D'>
		/// Tab icon_texture2 d.
		/// </param>
		public static void SetEditorWindowTabIcon (EditorWindow editorWindow, Texture2D tabIcon_texture2D)
		{
	 		
			//TODO, MOVE THIS TO A PROPERTY SO WE DON'T CALL 'GETPROPERTY' MORE THAN NEEDED (JUST ONCE?)
			PropertyInfo cachedTitleContent;
			
			
			
			
	        //if (cachedTitleContent == null) {
	
	            cachedTitleContent = typeof(EditorWindow).GetProperty("cachedTitleContent", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);
	
	        //}
	
	        if (cachedTitleContent != null) {
	
	            GUIContent titleContent = cachedTitleContent.GetValue(editorWindow, null) as GUIContent;
	
	            if (titleContent != null) {
	
	                titleContent.image = tabIcon_texture2D;
	                //titleContent.text = "Super Cool3"; // <= here goes the title of your window
	
	            }
	
	        }
			
		}
		
		/// <summary>
		/// Debugs the log all properties for serialized property.
		/// </summary>
		/// <param name='aSerializedObject'>
		/// A serializedproperty.
		/// </param>
		public static void DebugLogAllPropertiesForSerializedProperty (SerializedObject aSerializedObject)
		{
			Debug.Log ("EditorWindowUtility.DebugLogAllPropertiesForSerializedProperty()");
			var property = aSerializedObject.GetIterator();
			var first = true;
			while(property.NextVisible(first))
			{
			     first = false;
			     Debug.Log("	" + property.name + " = " + property);
			}
		}
		
		
		//*********************************************************************
		//*********************************************************************
		//**	PROJECT WINDOW UTILITIES
		//*********************************************************************
		//*********************************************************************
		
		
		
		/// <summary>
		/// Gets the type of the all project window items subclass of.
		/// </summary>
		/// <returns>
		/// The all project window items subclass of type.
		/// </returns>
		/// <param name='aType'>
		/// A type.
		/// </param>
		public static Object[] GetAllProjectWindowItemsSubclassOfType (System.Type aType)
		{
			Object[] objects_array = Resources.FindObjectsOfTypeAll(aType).Where ( (aItem) => (aItem.GetType().IsSubclassOf (aType) )).ToArray();
			return objects_array;
			
		}
		
		/// <summary>
		/// Gets all project window items interface of.
		/// </summary>
		/// <returns>
		/// The all project window items interface of.
		/// </returns>
		/// <param name='aType'>
		/// A type.
		/// </param>
		public static Object[] GetAllProjectWindowItemsByInterface (System.Type aType)
		{
			System.Type classType = typeof (Object);
			System.Type interfaceType = aType;
			Object[] objects_array = Resources.FindObjectsOfTypeAll(classType).Where ( (aItem) => (aItem.GetType().GetInterface(interfaceType.Name) == (interfaceType) )).ToArray();
			return objects_array;
			
		}
		
		/// <summary>
		/// Gets the type of the all project window items by interface and is subclass of.
		/// </summary>
		/// <returns>
		/// The all project window items by interface and is subclass of type.
		/// </returns>
		/// <param name='aInterfaceType'>
		/// A interface type.
		/// </param>
		/// <param name='aSuperClassType'>
		/// A super class type.
		/// </param>
		public static Object[] GetAllProjectWindowScriptsBySuperClassAndInterface (System.Type aSuperClassType, System.Type aInterfaceType)
		{
			//SEARCH 'ALL' OBJECTS, THEN FILTER DOWN BEFORE RETURNING
			System.Type classType = typeof (UnityEngine.Object);
			Object[] objects_array = Resources.FindObjectsOfTypeAll(classType).Where ( (aItem) => 
				(
				
					aItem.GetType().GetInterface(aInterfaceType.Name) == (aInterfaceType) ) &&
					aItem.GetType().IsSubclassOf(aSuperClassType) == true 
				
				
				).ToArray();
			return objects_array;
			
		}
		
		
		
		//*********************************************************************
		//*********************************************************************
		//**	HIERARCHY WINDOW UTILITIES
		//*********************************************************************
		//*********************************************************************
		public static Object[] GetAllHierarchyScriptsBySuperClassAndInterface (System.Type aSuperClassType, System.Type aInterfaceType)
		{
			
			//DO NOT SHOW A HARMLESS SMALL WARNING IN CONSOLE
			#pragma warning disable 0162
			throw new UnityException();
		    Object[] foundGameObjects_array = GameObject.FindObjectsOfType (typeof (GameObject));
		    
			//
			for (int i=0;i<foundGameObjects_array.Length;i++) {
				Debug.Log ("found_gameobject: " + ((GameObject)foundGameObjects_array[i]).name);
			}
			//
			return foundGameObjects_array;
			#pragma warning restore 0162
		}
		
		
		
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

