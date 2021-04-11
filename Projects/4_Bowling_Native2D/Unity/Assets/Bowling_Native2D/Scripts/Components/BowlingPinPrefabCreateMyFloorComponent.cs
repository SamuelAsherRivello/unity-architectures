/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furnished to do so, subject to
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
using System.Collections;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.bowling_native2d
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class BowlingPinPrefabCreateMyFloorComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		public static int totalPinFloorsCreated_int;
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		/// <summary>
		/// Awake this instance.
		/// </summary>
		void Awake ()
		{
			//GRACEFULLY HANDLE AN APPLICATION RESTART
			if (totalPinFloorsCreated_int != 0) {
				totalPinFloorsCreated_int = 0;
			}
		}


		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			//INCREMENT
			totalPinFloorsCreated_int 		= totalPinFloorsCreated_int + 1;
			string newPinLayerName_string 	= "BowlingPinLayer" + totalPinFloorsCreated_int;
			string newFloorLayerName_string = "BowlingFloorLayer" + totalPinFloorsCreated_int;


			//
			GameObject bowlingPinDynamicFloorPrefab = GameObject.Instantiate( Resources.LoadAssetAtPath("Assets/Bowling_Native2D/Prefabs/BowlingPinDynamicFloorPrefab.prefab", typeof(GameObject)) ) as GameObject;
			bowlingPinDynamicFloorPrefab.transform.parent = GameObject.Find ("_DynamicGameObjects").transform;
			
			//MOVE
			bowlingPinDynamicFloorPrefab.transform.position = new Vector2 (transform.position.x, transform.position.y - 0.9f);


			/*
			 *  PHYSICS
			 * 
			 *	SOLUTION: DYNAMICALLY GIVE LAYERS (IN PHYSICS2D SETTINGS PANEL THEY'RE SET TO UNIQUELY COLLIDE)
			 * 
			 *  BENEFITS: WORKS 100%
			 * 
			 *  DRAWBACKS: CONSUMES ALMOST ALL AVAILABLE LAYERS. ON A LARGER PROJECT THIS WOULD BE A PROBLEM
			 * 
			 *  WORKAROUND: WELL THIS *IS* THE WORKAROUND BECAUSE THE FOLLOWING DOESN'T EXIST
			 * 
			 * 		//EXISTS
			 * 		Physics.IgnoreCollision (collider1, collider2D);
			 * 
			 * 		//DOES NOT YET TO EXIST (BUT SHOULD TO SOLVE THIS WHOLE SOLUTION)
			 * 		Physics2D.IgnoreCollision (collider1, collider2D);
			 * 
			*/
			gameObject.layer 					= LayerMask.NameToLayer (newPinLayerName_string);
			bowlingPinDynamicFloorPrefab.layer 	= LayerMask.NameToLayer (newFloorLayerName_string);

		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{



		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		
		
	}
}
