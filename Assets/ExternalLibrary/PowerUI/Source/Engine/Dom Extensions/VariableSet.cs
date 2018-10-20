//--------------------------------------//          Dom Framework////        For documentation or //    if you have any issues, visit//         wrench.kulestar.com////    Copyright � 2013 Kulestar Ltd//          www.kulestar.com//--------------------------------------using System;using System.Collections;using System.Collections.Generic;using Json;namespace Dom{		/// <summary>	/// Represents a set of &variables; used for localization.	/// </summary>		public partial class VariableSet{				/// <summary>Converts this set to a JSON array.</summary>		public JSArray ToJson(){						JSArray arr=new JSArray();						foreach(KeyValuePair<string,string> kvp in Map){				string varName=kvp.Key;				string varValue=kvp.Value;				arr[varName]=new JSValue(varValue);			}						return arr;					}			}	}