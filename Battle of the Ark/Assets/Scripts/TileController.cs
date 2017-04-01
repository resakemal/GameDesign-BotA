using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tile {
	public string tileID;
	public List<string> neighbor;

	//tile constructor
	public Tile(string ID, string n1, string n2) {
		tileID = ID;
		List<string> nlist = new List<string> ();
		nlist.Add (n1);
		nlist.Add (n2);
		neighbor = nlist;
	}

	//intersection tile constructor
	public Tile(string ID, string n1, string n2, string n3) {
		tileID = ID;
		List<string> nlist = new List<string> ();
		nlist.Add (n1);
		nlist.Add (n2);
		nlist.Add (n3);
		neighbor = nlist;
	}

	//copy contstructor
	public Tile(Tile t) {
		tileID = t.tileID;
		neighbor = t.neighbor;
	}
}

public class TileController : MonoBehaviour {
	public List<Tile> tiles;
	// Use this for initialization
	void Start () {
		tiles = new List<Tile> ();
		/*
		tiles.Add (new Tile ("T1","T2","T4"));
		tiles.Add (new Tile ("T2","T3","T1"));
		tiles.Add (new Tile ("T3","T4","T2"));
		tiles.Add (new Tile ("T4","T1","T3"));
		*/
		tiles.Add (new Tile ("T1","T2","T6"));
		tiles.Add (new Tile ("T2","T3","T1","T5"));
		tiles.Add (new Tile ("T3","T4","T2"));
		tiles.Add (new Tile ("T4","T5","T3"));
		tiles.Add (new Tile ("T5","T6","T4","T2"));
		tiles.Add (new Tile ("T6","T1","T5"));

		Debug.Log ("tile initialized");
	}

	// Update is called once per frame
	void Update () {

	}
}
