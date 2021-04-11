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
	public class BowlingPinPrefabAudioComponent : MonoBehaviour 
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		/// <summary>
		/// The audio source.
		/// </summary>
		private AudioSource _bowlingPinHit_audiosource = null;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			
			_bowlingPinHit_audiosource = GetComponent<AudioSource>();
			
			//BEND PITCH FROM 0.7 TO 1.1 TO VARY THE SOUNDS
			_bowlingPinHit_audiosource.pitch = .7f + (float)Random.Range (1, 4)/10;


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
		/// <summary>
		/// Raises the collision enter2 d event.
		/// </summary>
		/// <param name="collision2D">Collision2 d.</param>
		void OnCollisionEnter2D (Collision2D collision2D) 
		{

			//WHEN THE PIN HITS BALL/PIN, PLAY THE SOUND
			// NOTE: I DON'T PLAY SOUND FOR HITTING THE FLOOR, BUT YOU CAN IF YOU WANT
			if (collision2D.collider.tag == "BowlingBallPrefabTag") {
				_bowlingPinHit_audiosource.Play ();
			}
		}
		
		/// <summary>
		/// Raises the trigger2 d event.
		/// </summary>
		/// <param name="collision2D">Collision.</param>
		void OnTrigger2D (Collision2D collision2D) 
		{
			//DO NOTHING 'DURING' THIS

		}
		
		/// <summary>
		/// Raises the collision stay2 d event.
		/// </summary>
		/// <param name="collision2D">Collision.</param>
		void OnCollisionStay2D (Collision2D collision2D) 
		{
			//DO NOTHING 'DURING' THIS
		}
		
		/// <summary>
		/// Raises the collision exit2 d event.
		/// </summary>
		/// <param name="collision2D">Collision.</param>
		void OnCollisionExit2D (Collision2D collision2D) 
		{

			//DO NOTHING 'DURING' THIS
		}
		
	}
	
}