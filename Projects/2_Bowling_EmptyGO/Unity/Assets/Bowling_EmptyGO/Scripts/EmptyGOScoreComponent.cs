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
	public class EmptyGOScoreComponent : MonoBehaviour 
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
		/// The _score_guitext.
		/// </summary>
		private GUIText _score_guitext = null;
		
		/// <summary>
		/// The _bowling pin prefabs_gameobject.
		/// </summary>
		private GameObject[] _bowlingPinPrefabs_gameobject = null;
		
		/// <summary>
		/// The _total pins knocked over count_int.
		/// </summary>
		private int _totalPinsKnockedOverCount_int = 0;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			//
			_bowlingBallPrefabStateComponent 	= GetComponent<EmptyGOStateComponent>();
			GameObject scoreGUIText_gameobject	= GameObject.Find ("ScoreGUIText");
			_score_guitext = scoreGUIText_gameobject.GetComponent<GUIText>();
			
			//
			_bowlingPinPrefabs_gameobject = GameObject.FindGameObjectsWithTag ("BowlingPinPrefabTag");
			
		}
	
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			_score_guitext.text  = "PINS HIT: " + _getPinsHit() + "\n\nINSTRUCTIONS:\n" + _getInstructions();
		
		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _gets the pins hit.
		/// </summary>
		/// <returns>
		/// The pins hit.
		/// </returns>
		private string _getPinsHit ()
		{
			
			if (_bowlingBallPrefabStateComponent.bowlingBallState == BowlingBallState.PRE_GAME_AIM_MODE) {
				_totalPinsKnockedOverCount_int = 0;
			} else {
				
				
				//OPTIMIZATION: CALCULATE ONLY IF SOME PINS ARE NOT KNOCKED DOWN
				if (_totalPinsKnockedOverCount_int < _bowlingPinPrefabs_gameobject.Length) {
					
					//RECALCULATE
					_totalPinsKnockedOverCount_int = 0;
					foreach (GameObject bowlingPinPrefab in _bowlingPinPrefabs_gameobject) {
						
						//THROUGH TRIAL AND ERROR I FOUND A GOOD DETECTION FOR IF A PIN IS 'KNOCKED OVER'
						//
						//	METHOD: KNOCKED OVER IF ANGLE IS NOT '90' BETWEEN A PIN AND THE 'WORLD'
						int angle_int = (int) Quaternion.Angle (bowlingPinPrefab.transform.rotation, Quaternion.identity);
						bool knockedOver_boolean = !(angle_int == 90);
						
						//
						if (knockedOver_boolean) {
							_totalPinsKnockedOverCount_int++;
						}
							
						
					}
				}
			}
			
	
			
			//
			string pinsHit_string = _totalPinsKnockedOverCount_int + "/" + _bowlingPinPrefabs_gameobject.Length;
			return pinsHit_string;
		}
		
		/// <summary>
		/// _gets the instructions.
		/// </summary>
		/// <returns>
		/// The instructions.
		/// </returns>
		private string _getInstructions ()
		{
			string instructions_string;
			
			if (_bowlingBallPrefabStateComponent.bowlingBallState == BowlingBallState.PRE_GAME_AIM_MODE) {
				instructions_string = "1. Use Mouse/Arrow Keys to aim \n2. Use MouseButton/Spacebar to throw.";
			} else {
				instructions_string = "3. Use MouseButton/Spacebar to reset.";
			}
			
			return instructions_string;
			
		}
		
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
