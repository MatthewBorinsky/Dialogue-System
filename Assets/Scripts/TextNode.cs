using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class TextNode : GenericNode {

	[Input] public int PreviousNode;
	[Output] public int NextNode;
	public string character;
	public string text;


	public override string GetString(){
		return "TextNode/" + character + "/" + text;
	}
}