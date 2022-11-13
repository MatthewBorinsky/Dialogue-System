using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

// Matthew Borinsky 251093967
// This file creates an empty dialogue tree to be filled using xNode

[CreateAssetMenu]
public class DialogueTree : NodeGraph { 
	public TextNode currentNode;
}