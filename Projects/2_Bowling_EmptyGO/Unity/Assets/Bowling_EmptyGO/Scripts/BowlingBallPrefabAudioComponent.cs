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
namespace com.rmc.projects.bowling_emptygo
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
	public class BowlingBallPrefabAudioComponent : MonoBehaviour 
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
		private EmptyGOStateComponent _bowlingBallPrefabStateComponent = null;
		
		/// <summary>
		/// The audio source.
		/// </summary>
		private AudioSource _bowlingBallRolling_audiosource = null;
		
		/// <summary>
		/// The _has collided with wood floor_boolean.
		/// </summary>
		private bool _hasCollidedWithWoodFloor_boolean = false;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			
			GameObject emptyGO				 = GameObject.Find ("_EmptyGO");
			_bowlingBallPrefabStateComponent = emptyGO.GetComponent<EmptyGOStateComponent>();
			
			_bowlingBallRolling_audiosource = GetComponent<AudioSource>();
			
			
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			if (_bowlingBallPrefabStateComponent.bowlingBallState == BowlingBallState.PRE_GAME_AIM_MODE) {
				
				//	HANDLE THROW
				if (Input.GetMouseButton (0)) {
					
					//TODO: IF YOU WANT TO PLAY A SOUND UPON 'THROW' DO IT HERE
					
				}
				
				//	RESET
				_hasCollidedWithWoodFloor_boolean = false;
				
			}
	
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
		/// <summary>
		/// Raises the collision enter event.
		/// </summary>
		/// 
		/// NOTE: 	If you don't use collisionInfo in the function, leave out the collision parameter 
		/// 		as this avoids unneccessary calculations. 
		/// 
		/// <param name='collider'>
		/// Collider.
		/// </param>
		void OnCollisionEnter (Collision collision) 
		{
			
			//WHEN THE BALL HITS THE FLOOR, PLAY THE SOUND
			if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("WoodFloorLayer")) {
				
				//PLAY A MAXIMUM OF 1 TIMES
				if (!_hasCollidedWithWoodFloor_boolean) {
					_hasCollidedWithWoodFloor_boolean = true;
					_bowlingBallRolling_audiosource.Play ();
				}
				
			//WHEN THE BALL HITS A PIN, STOP THE ROLLING SOUND
			} else if (collision.collider.gameObject.tag == "BowlingPinPrefabTag") {
				
				if (_bowlingBallRolling_audiosource.isPlaying) {
					//OR DON'T STOP, YOU CAN CHOOSE
					//_bowlingBallRolling_audiosource.Stop();
				}
			}
		}
		
		/// <summary>
		/// Raises the collision stay event.
		/// </summary>
		/// 
		/// NOTE: 	If you don't use collisionInfo in the function, leave out the collision parameter 
		/// 		as this avoids unneccessary calculations. 
		/// 
		void OnCollisionStay () 
		{
			
			
		}
		
		
		/// <summary>
		/// Raises the collision exit event.
		/// </summary>
		/// 
		/// NOTE: 	If you don't use collisionInfo in the function, leave out the collision parameter 
		/// 		as this avoids unneccessary calculations. 
		/// 
		/// <param name='collision'>
		/// Collision.
		/// </param>
		void OnCollisionExit (Collision collision) 
		{
			
			//WHEN THE BALL STOPS HITTING THE FLOOR (AFTER IT STARTED TO HIT THE FLOOR), STOP THE SOUND
			if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("WoodFloorLayer")) {
				
				//I DON'T DO THIS OR THE SOUND WILL STOP ON A BOUNCING ROLL, FYI.
				//BUT YOU MAY NEED TO STOP IN SOME CASES IF YOU LIKE
				//_bowlingBallRolling_audiosource.Stop ();
			}
		}
		
	}
}