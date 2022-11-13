using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

// Matthew Borinsky 251093967
// This is the node structure for each dialogue section

public class TextNode : Node {

	[Input] public int PreviousNode;

	public bool isRoot = false;
	
	
	[Output(dynamicPortList = true)] public string[] NextNode;
	public string key;

	// Returns the current key
	public string GetString(){
		return key;
	}

	// Returns all next nodes that could be selected as an array
	public string[] GetNext(){
		return NextNode;
	}
}