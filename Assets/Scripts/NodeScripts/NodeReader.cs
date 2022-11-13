using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class NodeReader : MonoBehaviour
{
    public DialogueTree tree;
    Coroutine _parser;
    public Text character;
    public Text content;

    void Start(){
        foreach (GenericNode nodes in tree.nodes){
            if (nodes.GetString() == "root"){
                tree.currentNode = nodes;
                break;
            }
        }
        _parser = StartCoroutine(ReadNode());
    }

    IEnumerator ReadNode(){
        GenericNode node = tree.currentNode;
        string text = node.GetString();
        string[] textArray = text.Split('/');

        if (textArray[0] == "root"){
            NextNode("exit");
        }

        if (textArray[0] == "TextNode"){
            character.text = textArray[1];
            content.text = textArray[2];
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            NextNode("exit");
        }
    }

    public void NextNode(string neededPort){
        if (_parser != null){
            StopCoroutine(_parser);
            _parser = null;
        }

        foreach(NodePort port in tree.currentNode.Ports){
            if (port.fieldName == neededPort){
                tree.currentNode = port.Connection.node as GenericNode;
                break;
            }
        }
        _parser = StartCoroutine(ReadNode());
    }
}
