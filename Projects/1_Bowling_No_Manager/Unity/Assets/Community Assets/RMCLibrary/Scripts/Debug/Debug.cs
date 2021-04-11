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
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngineInternal;
using System.Diagnostics;
     

//--------------------------------------
//  Class
//--------------------------------------

//NOTE				RENAME AS 'Debug' if you want one-line debugs in the console
//NOTE				RENAME AS 'Debug2' if you want to click an error and go to the actual issue and NOT to this class
public static class Debug2
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
		
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	///<summary>
	///	Determines if debugging occurs
	///</summary>
	public static bool isDebugBuild = true;
	
	///<summary>
	///	Extra lines added to every Debug.Log() console output.
	//    ********
	//    ********
	//    ******** The purpose of this class is to reduce console output to ONE line each. Solely for readabilities sake.
	//    ********
	//    ********
	///</summary>
	private static string hr = "\n\n-------------------------------------------------------------------------------";
      
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	// PUBLIC
	
	// PUBLIC STATIC
	
	//*************************************************************************
	//  THESE METHODS EXIST JUST TO MAKE THE TRACES IN THE CONSOLE WINDOW HAVE EXACTLY ONE LINE (NOT 2 LIKE DEFAULT BEHAVIOR), PURELY COSMETIC
	//*************************************************************************
	public static void Log (object message)
	{
		if (isDebugBuild)
			UnityEngine.Debug.Log (message + hr);
		//UnityEngine.Debug.Log (message.ToString ());
	}
	
	public static void Log (object message, UnityEngine.Object context)
	{
		if (isDebugBuild)
			UnityEngine.Debug.Log (message, context);
		//UnityEngine.Debug.Log (message.ToString (), context);
	}
       
	public static void LogError (object message)
	{
		if (isDebugBuild)
			UnityEngine.Debug.LogError (message);
		//UnityEngine.Debug.LogError (message.ToString ());
	}
     
	public static void LogError (object message, UnityEngine.Object context)
	{
		if (isDebugBuild)
			UnityEngine.Debug.LogError (message, context);
		//UnityEngine.Debug.LogError (message.ToString (), context);
	}
     
	public static void LogWarning (object message)
	{
		if (isDebugBuild)
			UnityEngine.Debug.LogWarning (message.ToString ());
	}
     
	public static void LogWarning (object message, UnityEngine.Object context)
	{
		if (isDebugBuild)
			UnityEngine.Debug.LogWarning (message.ToString (), context);
	}
	
	
	//*************************************************************************
	//  MORE CUSTOM DEBUGGING
	//*************************************************************************
	/// <summary>
	/// Logs the stack trace.
	/// </summary>
	public static void LogStackTrace ()
	{
		//Debug.Log (	_GetMethodStackTrace("LogStackTrace()\n[CLICK TO EXPAND]")	);			
	}
	
	/// <summary>
	/// _s the get method stack trace.
	/// </summary>
	/// <returns>
	/// The get method stack trace.
	/// </returns>
	/// <param name='aMessage_string'>
	/// A message_string.
	/// </param>
	private static string _GetMethodStackTrace (string aMessage_string)
	{
		StackTrace stackTrace = new StackTrace();
		StackFrame[] stackFrames = stackTrace.GetFrames();
		string output_string = "";
		output_string += aMessage_string;
		string spaces_string = "  ";
		StackFrame stackFrame;
		for (int count_int = 2 ; count_int < stackFrames.Length; count_int ++ ) {
			
			stackFrame = stackFrames[count_int];
			output_string += "\n" + (spaces_string + stackFrame.GetMethod());
			spaces_string += "  ";
		}
		return output_string;			
	}
	
	
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------

}
