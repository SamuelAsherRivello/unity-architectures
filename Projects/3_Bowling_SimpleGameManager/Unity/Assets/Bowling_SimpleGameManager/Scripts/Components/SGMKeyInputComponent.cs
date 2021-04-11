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
namespace com.rmc.projects.bowling_sgmc
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
	public class SGMKeyInputComponent : MonoBehaviour 
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
		private SGMStateComponent _bowlingBallPrefabStateComponent = null;
		
		
		// PRIVATE STATIC
		private static float _MOVE_BY_AMOUNT_FLOAT = 0.1f;
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_bowlingBallPrefabStateComponent = GetComponent<SGMStateComponent>();
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			if (_bowlingBallPrefabStateComponent.inputMode == InputMode.KEYBOARD_ONLY) {
					
				if (_bowlingBallPrefabStateComponent.bowlingBallState == BowlingBallState.PRE_GAME_AIM_MODE) {
					
					
					//	HANDLE MOVE
					if (Input.GetKeyDown (KeyCode.LeftArrow) ) {
						_bowlingBallPrefabStateComponent.moveBallBy ( new Vector2 (-_MOVE_BY_AMOUNT_FLOAT, 0));
					} else if (Input.GetKeyDown (KeyCode.RightArrow) ) {
						_bowlingBallPrefabStateComponent.moveBallBy ( new Vector2 (_MOVE_BY_AMOUNT_FLOAT, 0));
					}
		
					//	HANDLE MOVE
					if (Input.GetKeyDown (KeyCode.UpArrow) ) {
						_bowlingBallPrefabStateComponent.moveBallBy ( new Vector2 (0, _MOVE_BY_AMOUNT_FLOAT));
					} else if (Input.GetKeyDown (KeyCode.DownArrow) ) {
						_bowlingBallPrefabStateComponent.moveBallBy ( new Vector2 (0, -_MOVE_BY_AMOUNT_FLOAT));
					}
					
					
					// 	HANDLE THROW
					if (Input.GetKeyDown (KeyCode.Space) ) {
						_bowlingBallPrefabStateComponent.throwBall();
					}
						
			
				} else {
					
					//	HANDLE RESET
					if (Input.GetKeyDown (KeyCode.Space) ) {
						_bowlingBallPrefabStateComponent.resetGame();
						
					}
					
				}
				
			} //END IF KEYBOARD MODE
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
	