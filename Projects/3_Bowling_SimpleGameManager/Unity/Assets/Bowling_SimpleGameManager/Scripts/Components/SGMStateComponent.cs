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
	
	/// <summary>
	/// Event listening mode.
	/// </summary>
	public enum BowlingBallState
	{
		PRE_GAME_AIM_MODE,
		MOVING_GAME_MODE
		
	}

	/// <summary>
	/// Input mode.
	/// NOTE: GAME MAY ACTIVELY TOGGLE BETWEEN THESE AS YOU PLAY
	/// </summary>
	public enum InputMode
	{
		MOUSE_ONLY,
		KEYBOARD_ONLY
	}
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
		
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class SGMStateComponent : MonoBehaviour 
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// The state of the _bowling ball.
		/// 
		/// NOTE: We check this from outside this class for handling input
		/// 
		/// </summary>
		private BowlingBallState _bowlingBallState;
		public BowlingBallState bowlingBallState { 
			get
			{
				return _bowlingBallState;
			}
			set
			{
				_bowlingBallState = value;
				
				//	TURN OFF 'PHYSICS' DURING AIMING
				if (_bowlingBallState == BowlingBallState.PRE_GAME_AIM_MODE) {
					if (bowlingBallPrefab) {
						bowlingBallPrefab.rigidbody.isKinematic = true;
					}
				} else if (_bowlingBallState == BowlingBallState.MOVING_GAME_MODE) {
					if (bowlingBallPrefab) {
						bowlingBallPrefab.rigidbody.isKinematic = false;
					}
				}
				
			}
		}
		
		private InputMode _inputMode;
		public InputMode inputMode { 
			get
			{
				return _inputMode;
			}
			set
			{
				_inputMode = value;
				
			}
		} 
			
			
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The bowling ball prefab.
		/// </summary>
		private GameObject bowlingBallPrefab;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			bowlingBallState = BowlingBallState.PRE_GAME_AIM_MODE;
			inputMode = InputMode.MOUSE_ONLY;
			bowlingBallPrefab = GameObject.FindGameObjectWithTag ("BowlingBallPrefabTag");
			
		}
		
		
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			bowlingBallPrefab = GameObject.FindGameObjectWithTag ("BowlingBallPrefabTag");
			
			if (bowlingBallPrefab) {
				//Debug.Log ("update p: " + bowlingBallPrefab);
				//	TOGGLE BETWEEN KEYBOARD ***OR*** MOUSE MODE
				if (Input.GetKeyDown (KeyCode.LeftArrow) 	||
					Input.GetKeyDown (KeyCode.RightArrow) 	||
					Input.GetKeyDown (KeyCode.UpArrow) 		||
					Input.GetKeyDown (KeyCode.DownArrow) 	||
					Input.GetKeyDown (KeyCode.Space)		) {
					inputMode = InputMode.KEYBOARD_ONLY;
				}
				
				//	TOGGLE BETWEEN KEYBOARD ***OR*** MOUSE MODE
				if (Input.GetAxis("Mouse Y") != 0 ||
					Input.GetAxis("Mouse X") != 0 ||
					Input.GetMouseButton(0)			){
					inputMode = InputMode.MOUSE_ONLY;
				}
					
				
				//WHILE MOVING
				if (_bowlingBallState == BowlingBallState.MOVING_GAME_MODE) {
							
					//	ADD PHYSICS SPIN TO THE LEFT
					bowlingBallPrefab.rigidbody.AddTorque (new Vector3 (0, 0, 1200f * bowlingBallPrefab.rigidbody.mass), ForceMode.Acceleration);	
				}
				
			}
			
		}
		
		// PUBLIC
		/// <summary>
		/// Throws the ball.
		/// </summary>
		public void throwBall ()
		{
			//	STOP AIMING VIA INPUT
			bowlingBallState = BowlingBallState.MOVING_GAME_MODE;
			
			if (bowlingBallPrefab) {
				
				//	START MOVING WITH PHYSICS TOWARD PINS (AND UP IN THE AIR A LITTLE BIT)
				bowlingBallPrefab.rigidbody.AddForce (new Vector3 (0, 100f, 600f * bowlingBallPrefab.rigidbody.mass), ForceMode.Force);
				
				
				//	ADD PHYSICS PUSH TO THE LEFT
				bowlingBallPrefab.rigidbody.AddForce (new Vector3 (-20f * bowlingBallPrefab.rigidbody.mass, 0, 0), ForceMode.Force);
				
				
			}

		}


		/// <summary>
		/// Moves the ball.
		/// 
		/// NOTE: We don't move the z.
		/// 
		/// </summary>
		public void moveBallTo (Vector2 aPosition_vector2)
		{
			if (bowlingBallPrefab != null) {
				bowlingBallPrefab.transform.position = new Vector3 (aPosition_vector2.x, aPosition_vector2.y, bowlingBallPrefab.transform.position.z);
			}
			
		}
		
		/// <summary>
		/// Moves the ball.
		/// 
		/// NOTE: We don't move the z.
		/// 
		/// </summary>
		public void moveBallBy (Vector2 aMoveBy_vector2)
		{
			
			bowlingBallPrefab.transform.position = new Vector3 (
												bowlingBallPrefab.transform.position.x + aMoveBy_vector2.x, 
												bowlingBallPrefab.transform.position.y + aMoveBy_vector2.y, 
												bowlingBallPrefab.transform.position.z);
		}
		
		/// <summary>
		/// Resets the game.
		/// 
		/// NOTE: This works great. In a more mature game, you may need to manually place each item again.
		/// 
		/// </summary>
		public void resetGame ()
		{
			bowlingBallState = BowlingBallState.PRE_GAME_AIM_MODE;
			Application.LoadLevel(Application.loadedLevel);
		}
		
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
