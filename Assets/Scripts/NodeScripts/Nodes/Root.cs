using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class Root : GenericNode {

	[Output] public int NextNode;

	public override string GetString(){
		return "root";
	}
}