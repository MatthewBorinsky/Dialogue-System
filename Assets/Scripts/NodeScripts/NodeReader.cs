using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;
using TMPro;

// Matthew Borinsky 251093967
// This is the class which changes to different nodes. It relys on the
// keys used by the localization files. It will just change the textboxes
// to the keys associated and the localization tool fills in the text.

public class NodeReader : MonoBehaviour
{
    public DialogueTree tree;  // The dialogue tree
    public GameObject prompt;  // The textbox with the question prompts
    public GameObject[] responses; // The responses for the prompt

    // Finds the root node and sets the keys accordingly.
    void Start(){
        foreach (TextNode nodes in tree.nodes){
            if (nodes.isRoot){
                tree.currentNode = nodes;
                SetNode();
                break;
            }
        }
    }

    // Sets the keys in each textbox to the ones associated with the
    // current node. The localization system then fills in the text.
    public void SetNode(){
        TextNode node = tree.currentNode;

        string promptKey = node.GetString();
        string[] choices = node.GetNext();

        prompt.GetComponent<Key>().key = promptKey;  // Sets the prompt key

        foreach (GameObject buttons in responses){  // Resets the buttons
            buttons.SetActive(false);
        }

        int enumerator = 0;
        foreach (string options in choices){  // Sets the choices keys
            GameObject thisButton = responses[enumerator];
            thisButton.SetActive(true);  // Turns on needed buttons
            Key keyToChange = thisButton.GetComponentInChildren(typeof(Key)) as Key;
            keyToChange.key = options;
            enumerator++;
        }
    }

    // Finds the new current node based on the button/choice selected
    public void NextNode(int nodePort){
        foreach(NodePort port in tree.currentNode.Ports){
            if ("NextNode " + nodePort == port.fieldName){
                tree.currentNode = port.Connection.node as TextNode;
                SetNode();
                break;
            }
        }
    }

    // Function to exit the game
    public void Exit(){
        Application.Quit();
    }
}
