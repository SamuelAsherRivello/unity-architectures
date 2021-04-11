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
namespace com.rmc.projects.bowling_game_no_manager
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
	public class BowlingBallPrefabMouseInputComponent : MonoBehaviour 
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _bowling ball prefab state component.
		/// </summary>
		private BowlingBallPrefabStateComponent _bowlingBallPrefabStateComponent = null;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_bowlingBallPrefabStateComponent = GetComponent<BowlingBallPrefabStateComponent>();
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			if (_bowlingBallPrefabStateComponent.inputMode == InputMode.MOUSE_ONLY) {
					
				if (_bowlingBallPrefabStateComponent.bowlingBallState == BowlingBallState.PRE_GAME_AIM_MODE) {
					
					
					
					//	HANDLE MOVE
					//	NOTE: IF YOUR MOUSE 'HITS' THE InvisibleMouseDetectionCubeLayer GAMEOBJECT THEN ITS A LEGAL POSITION
					//	NOTE: THE "BowlingBallPrefab" HAS A LAYER OF "Ignore Raycast", WHICH WE REQUIRE
					//
					RaycastHit raycastHit;
					if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity)) {
						
						if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer ("InvisibleMouseDetectionCubeLayer")) {
							_bowlingBallPrefabStateComponent.moveBallTo (new Vector2 (raycastHit.point.x, raycastHit.point.y));
						}
					} 
					
					
					//	HANDLE THROW
					if (Input.GetMouseButton (0)) {
						_bowlingBallPrefabStateComponent.throwBall();
					}
					
		
				} else {
					
					//	HANDLE RESET
					if (Input.GetMouseButtonDown (0)) {
						_bowlingBallPrefabStateComponent.resetGame();
						
					}
					
				}
				
			} //END IF MOUSEMODE
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