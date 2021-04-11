//C# Unity event manager that uses strings in a hashtable over delegates and events in order to
//allow use of events without knowing where and when they're declared/defined.
//by Billy Fletcher of Rubix Studios
using UnityEngine;
using System.Collections;
using com.rmc.events;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;
 

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.events
{
	
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	/// <summary>
	/// Event delegate.
	/// </summary>
	public delegate void EventDelegate (IEvent iEvent);
	
	
	/// <summary>
	/// Event listening mode.
	/// </summary>
	public enum EventDispatcherAddMode
	{
		DEFAULT,
		SINGLE_SHOT
		
	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
		
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class EventDispatcher
	{

		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The mom_serialized object.
		/// </summary>
	    private Hashtable _eventListenerDatas_hashtable = new Hashtable();
	 
		/// <summary>
		/// The _target_object.
		/// </summary>
		private object _target_object;
		
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		///<summary>
		///	 Constructor
		///</summary>
		public EventDispatcher (object aTarget_object )
		{
			//
			_target_object = aTarget_object;
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		//~EventDispatcher ( )
		//{
		//	Debug.Log ("EventDispatcher.deconstructor()");
			
		//}
		
		
		/// <summary>
		/// Adds the event listener.
		/// </summary>
		/// <returns>
		/// The event listener.
		/// </returns>
		/// <param name='aEventName_string'>
		/// If set to <c>true</c> a event name_string.
		/// </param>
		/// <param name='aEventDelegate'>
		/// If set to <c>true</c> a event delegate.
		/// </param>
	    public bool addEventListener(string aEventName_string, EventDelegate aEventDelegate)
	    {
			return addEventListener (aEventName_string, aEventDelegate, EventDispatcherAddMode.DEFAULT);	
		}
			
		/// <summary>
		/// Adds the event listener.
		/// </summary>
		/// <returns>
		/// The event listener.
		/// </returns>
		/// <param name='aEventDelegate'>
		/// If set to <c>true</c> a event delegate.
		/// </param>
		/// <param name='aEventName_string'>
		/// If set to <c>true</c> a event name_string.
		/// </param>
	    public bool addEventListener( EventDelegate aEventDelegate, string aEventName_string)
	    {
			return addEventListener (aEventName_string, aEventDelegate, EventDispatcherAddMode.DEFAULT);	
		}
			
		
		/// <summary>
		/// Adds the event listener.
		/// </summary>
		/// <returns>
		/// The event listener.
		/// </returns>
		/// <param name='aEventName_string'>
		/// If set to <c>true</c> a event type_string.
		/// </param>
		/// <param name='aEventDelegate'>
		/// If set to <c>true</c> a event delegate.
		/// </param>
		/// <param name='aEventDispatcherAddMode'>
		/// If set to <c>true</c> event listening mode.
		/// </param>
	    public bool addEventListener(string aEventName_string, EventDelegate aEventDelegate, EventDispatcherAddMode aEventDispatcherAddMode)
	    {
			//
			bool wasSuccessful_boolean = false;
			
			//
			object aIEventListener = _getArgumentsCallee(aEventDelegate);			
			
			//
	        if (aIEventListener != null && aEventName_string != null) {
				
				//	OUTER
				string keyForOuterHashTable_string = _getKeyForOuterHashTable (aEventName_string);
		        if (!_eventListenerDatas_hashtable.ContainsKey(keyForOuterHashTable_string) ) {
		            _eventListenerDatas_hashtable.Add(keyForOuterHashTable_string, new Hashtable());
				}
		 
				//	INNER
		        Hashtable inner_hashtable = _eventListenerDatas_hashtable[keyForOuterHashTable_string] as Hashtable;
				EventListenerData eventListenerData = new EventListenerData (aIEventListener, aEventName_string, aEventDelegate, aEventDispatcherAddMode);
				//
				string keyForInnerHashTable_string = _getKeyForInnerHashTable (eventListenerData);
		        if (inner_hashtable.Contains(keyForInnerHashTable_string)) {
					
					//THIS SHOULD *NEVER* HAPPEN - REMOVE AFTER TESTED WELL
		            Debug.Log("TODO (FIX THIS): Event Manager: Listener: " + keyForInnerHashTable_string + " is already in list for event: " + keyForOuterHashTable_string);

				} else {
		 
					//	ADD
		        	inner_hashtable.Add(keyForInnerHashTable_string, eventListenerData);
					wasSuccessful_boolean = true;
					//Debug.Log ("	ADDED AT: " + keyForInnerHashTable_string + " = " +  eventListenerData);
				}
				
			}
	        return wasSuccessful_boolean;
	    }
		
		
	    /// <summary>
	    /// Hases the event listener.
	    /// </summary>
	    /// <returns>
	    /// The event listener.
	    /// </returns>
	    /// <param name='aIEventListener'>
	    /// If set to <c>true</c> a I event listener.
	    /// </param>
	    /// <param name='aEventName_string'>
	    /// If set to <c>true</c> a event name_string.
	    /// </param>
	    /// <param name='aEventDelegate'>
	    /// If set to <c>true</c> a event delegate.
	    /// </param>
	    public bool hasEventListener(string aEventName_string, EventDelegate aEventDelegate)
	    {
			//
			bool hasEventListener_boolean = false;
			
			//
			object aIEventListener = _getArgumentsCallee(aEventDelegate);			
			
			//	OUTER
			string keyForOuterHashTable_string = _getKeyForOuterHashTable (aEventName_string);
	        if (_eventListenerDatas_hashtable.ContainsKey(keyForOuterHashTable_string)) {
	        
				//	INNER
				Hashtable inner_hashtable = _eventListenerDatas_hashtable[keyForOuterHashTable_string] as Hashtable;
				string keyForInnerHashTable_string = _getKeyForInnerHashTable (new EventListenerData (aIEventListener, aEventName_string, aEventDelegate, EventDispatcherAddMode.DEFAULT));
				//
				if (inner_hashtable.Contains(keyForInnerHashTable_string)) {
		            hasEventListener_boolean = true;
				}
			}
	 
	        return hasEventListener_boolean;
	    }
		
	    /// <summary>
	    /// Removes the event listener.
	    /// </summary>
	    /// <returns>
	    /// The event listener.
	    /// </returns>
	    /// <param name='aIEventListener'>
	    /// If set to <c>true</c> a I event listener.
	    /// </param>
	    /// <param name='aEventName_string'>
	    /// If set to <c>true</c> a event name_string.
	    /// </param>
	    /// <param name='aEventDelegate'>
	    /// If set to <c>true</c> a event delegate.
	    /// </param>
	    public bool removeEventListener(string aEventName_string, EventDelegate aEventDelegate)
	    {
			//
			bool wasSuccessful_boolean = false;
			
			//
			if (hasEventListener (aEventName_string, aEventDelegate)) {
				//	OUTER
				string keyForOuterHashTable_string = _getKeyForOuterHashTable (aEventName_string);
				Hashtable inner_hashtable = _eventListenerDatas_hashtable[keyForOuterHashTable_string] as Hashtable;
				//
				object aIEventListener = _getArgumentsCallee(aEventDelegate);	
				//  INNER
				string keyForInnerHashTable_string = _getKeyForInnerHashTable (new EventListenerData (aIEventListener, aEventName_string, aEventDelegate, EventDispatcherAddMode.DEFAULT));
				inner_hashtable.Remove(keyForInnerHashTable_string);
	        	wasSuccessful_boolean = true;
			} 
			
			return wasSuccessful_boolean;
			
	    }
		
		/// <summary>
		/// Removes all event listeners.
		/// </summary>
		/// <returns>
		/// The all event listeners.
		/// </returns>
	    public bool removeAllEventListeners()
	    {
			//
			bool wasSuccessful_boolean = false;
			
			//TODO, IS IT A MEMORY LEAK TO JUST RE-CREATE THE TABLE? ARE THE INNER HASHTABLES LEAKING?
			_eventListenerDatas_hashtable = new Hashtable();
			
			return wasSuccessful_boolean;
	    }
		
	 
	    /// <summary>
	    /// Dispatchs the event.
	    /// </summary>
	    /// <returns>
	    /// The event.
	    /// </returns>
	    /// <param name='aIEvent'>
	    /// If set to <c>true</c> a I event.
	    /// </param>
	    public bool dispatchEvent(IEvent aIEvent)
	    {
			
			//
			bool wasSuccessful_boolean = false;
			
			//
			_doAddTargetValueToIEvent (aIEvent);
			
			//	OUTER
	        string keyForOuterHashTable_string = _getKeyForOuterHashTable (aIEvent.type);
			int dispatchedCount_int = 0;
	        if (_eventListenerDatas_hashtable.ContainsKey(keyForOuterHashTable_string)) {
	 
				//	INNER
				Hashtable inner_hashtable = _eventListenerDatas_hashtable[keyForOuterHashTable_string] as Hashtable;
				IEnumerator innerHashTable_ienumerator = inner_hashtable.GetEnumerator();
				DictionaryEntry dictionaryEntry;
				EventListenerData eventListenerData;
				ArrayList toBeRemoved_arraylist = new ArrayList ();
				//
		        while (innerHashTable_ienumerator.MoveNext()) {
					
					dictionaryEntry = (DictionaryEntry)innerHashTable_ienumerator.Current;
					eventListenerData = dictionaryEntry.Value as EventListenerData;
					
					//***DO THE DISPATCH***
					//Debug.Log ("DISPATCH : ");
					//Debug.Log ("	n    : " + eventListenerData.eventName );
					//Debug.Log ("	from : " + aIEvent.target );
					//Debug.Log ("	to   : " + eventListenerData.eventListener );
					//Debug.Log ("	del  : " + eventListenerData.eventDelegate + " " + (eventListenerData.eventDelegate as System.Delegate).Method.DeclaringType.Name + " " + (eventListenerData.eventDelegate as System.Delegate).Method.Name.ToString());
					eventListenerData.eventDelegate (aIEvent);
					
					
					//TODO - THIS IS PROBABLY FUNCTIONAL BUT NOT OPTIMIZED, MY APPROACH TO HOW/WHY SINGLE SHOTS ARE REMOVED
					//REMOVE IF ONESHOT
					if (eventListenerData.eventListeningMode == EventDispatcherAddMode.SINGLE_SHOT) {
						
						toBeRemoved_arraylist.Add (eventListenerData);
					}
					
					
					//MARK SUCCESS, BUT ALSO CONTINUE LOOPING TOO
					wasSuccessful_boolean = true;
					dispatchedCount_int++;
		        }
				
				
				//CLEANUP ANY ONE-SHOT, SINGLE-USE 
				EventListenerData toBeRemoved_eventlistenerdata;
				for (int count_int = toBeRemoved_arraylist.Count -1; count_int >= 0; count_int --) {
					toBeRemoved_eventlistenerdata = toBeRemoved_arraylist[count_int] as EventListenerData;
					removeEventListener (toBeRemoved_eventlistenerdata.eventName, toBeRemoved_eventlistenerdata.eventDelegate);
				}
	 
	        	
			}
			
			
			return wasSuccessful_boolean;
	    }
		
		/// <summary>
		/// _dos the add target value to I event.
		/// </summary>
		/// <param name='aIEvent'>
		/// A I event.
		/// </param>
		/// <exception cref='System.NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void _doAddTargetValueToIEvent (IEvent aIEvent)
		{
			aIEvent.target = _target_object;
		}

		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	    public void OnApplicationQuit()
	    {
			//TODO, DO THIS CLEANUP HERE, OR OBLIGATE API-USER TO DO IT??
	        _eventListenerDatas_hashtable.Clear();
	    }
		
		
		private string _getKeyForOuterHashTable (string aEventName_string)
		{
			//SIMPLY USING THE EVENT NAME - METHOD USED HERE, IN CASE I WANT TO TWEAK THIS MORE...
			return aEventName_string;
		}
		
		private string _getKeyForInnerHashTable (EventListenerData aEventListenerData)
		{
			//VERY UNIQUE - NICE!
			return aEventListenerData.eventListener.GetType().FullName + "_" + aEventListenerData.eventListener.GetType().GUID + "_" + aEventListenerData.eventName + "_" + (aEventListenerData.eventDelegate as System.Delegate).Method.Name.ToString();
		
		}

		public object _getArgumentsCallee (EventDelegate aEventDelegate)
		{
			return (aEventDelegate as System.Delegate).Target;
		}
	}
}