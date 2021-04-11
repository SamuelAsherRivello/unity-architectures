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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.events
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Test event.
	/// </summary>
	public class EventListenerData
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		/// <summary>
		/// The _event listener.
		/// </summary>
		private object _eventListener;
		public object eventListener 
		{ 
			get
			{
				return _eventListener;
			}
			set
			{
				_eventListener = value;
				
			}
		}
		
		/// <summary>
		/// The _event name_string.
		/// </summary>
		private string _eventName_string;
		public string eventName 
		{ 
			get
			{
				return _eventName_string;
			}
			set
			{
				_eventName_string = value;
				
			}
		}
		
		
		
		/// <summary>
		/// The _event delegate.
		/// </summary>
		private EventDelegate _eventDelegate;
		public EventDelegate eventDelegate 
		{ 
			get
			{
				return _eventDelegate;
			}
			set
			{
				_eventDelegate = value;
				
			}
		}
		
		private EventDispatcherAddMode _eventListeningMode;
		public EventDispatcherAddMode eventListeningMode 
		{ 
			get
			{
				return _eventListeningMode;
			}
			set
			{
				_eventListeningMode = value;
				
			}
		}
		
		
		
		// PUBLIC
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		///<summary>
		///	 Constructor
		///</summary>
		public EventListenerData (object aEventListener, string aEventName_string, EventDelegate aEventDelegate, EventDispatcherAddMode aEventListeningMode )
		{
			_eventListener 		= aEventListener;
			_eventName_string 	= aEventName_string;
			_eventDelegate		= aEventDelegate;
			_eventListeningMode	= aEventListeningMode;
			
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		//~EventListenerData ( )
		//{
			//Debug.Log ("EventListenerData.deconstructor()");
			
		//}
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		

	}
}

