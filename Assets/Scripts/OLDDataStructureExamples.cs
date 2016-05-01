using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OLDDataStructureExamples : MonoBehaviour {

	public List<string> names;
	public Dictionary<KeyCode, string> characterDictionary;
	public Queue<string> inline;
	public Stack<string> cards;

	// Use this for initialization
	void Start () {

//		names = new List<string>();

		Debug.Log("Length of names: " + names.Count);
		names.Insert(1, "Ewing");

		names.Add("Matt");

		names.Remove("Matt");
		names.RemoveAt(0);

		Debug.Log("List element 1: " + names[1]);

		foreach(string name in names){
			Debug.Log("name: " + name);
		}
			
		names.Clear();

		characterDictionary = new Dictionary<KeyCode, string>();

		characterDictionary.Add(KeyCode.A, "Alice");
		characterDictionary.Add(KeyCode.B, "Bomberman");
		characterDictionary.Add(KeyCode.C, "Clank");
		characterDictionary.Add(KeyCode.D, "Diddy Kong");

//		characterDictionary.Clear();
//		characterDictionary.ContainsKey(KeyCode.A);
//		characterDictionary.ContainsValue("Mike");

		inline = new Queue<string>();

		inline.Enqueue("Matt");
		inline.Enqueue("Missy");
		inline.Enqueue("Eli");


		Debug.Log("first in line: " + inline.Peek());
		Debug.Log("first in line: " + inline.Dequeue());
		Debug.Log("first in line: " + inline.Dequeue());

		cards = new Stack<string>();

		cards.Push("Ace");
		cards.Push("King");
		cards.Push("Queen");
		cards.Push("Jack");

//		cards.Peek();
		Debug.Log("card: " + cards.Pop());
	}
	
	// Update is called once per frame
	void Update () {
		foreach(KeyCode button in characterDictionary.Keys){
			if(Input.GetKeyDown(button)){
				Debug.Log("Character Name: " + characterDictionary[button]);
			}
		}
	}
}
