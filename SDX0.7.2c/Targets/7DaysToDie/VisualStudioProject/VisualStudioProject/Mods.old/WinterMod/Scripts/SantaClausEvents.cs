using UnityEngine;
using System.Collections;

public class SantaClausEvents : MonoBehaviour
{
	//triggered from Mechanim Events in Animation
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnDropSack ()
	{
		//Sack is being handled in SantaClausConfig in Santaclaus namespace. Get reference and trigger DropSack function
		//print ("Mechanim Event:Santa Claus Sackdrop animation called SackDrop function.");
		var m_ObjWithDropScript = GameObject.FindObjectOfType (typeof(SantaClausConfig)) as SantaClausConfig;
		m_ObjWithDropScript.DropSack ();


	}
}
