using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class TextNode : GenericNode {

	[Input] public int PreviousNode;
	
	
	[Output(dynamicPortList = true)] public string[] NextNode;
	public string key;


	public override string GetString(){
		return "TextNode/" + key + "/" + NextNode;
	}
}