using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tile {
	public string tileID;
	public bool intersection;
	public List<string> branch;

	public Tile(string ID) {
		tileID = ID;
		intersection = false;
		branch = null;
	}

	public Tile(string ID, List<string> branchlist) {
		tileID = ID;
		intersection = true;
		branch = branchlist;
	}

	public bool Equals(Tile t1, Tile t2) {
		if (t1.tileID == t2.tileID) {
			if (t1.intersection == t2.intersection)
				return true;
			else
				return false;
		} else
			return false;
	}
}

public class TileController : MonoBehaviour {
	public LinkedList<Tile> tiles;
	// Use this for initialization
	void Start () {
		Tile t1 = new Tile ("T1");
		Tile t2 = new Tile ("T2");
		Tile t3 = new Tile ("T3");
		Tile t4 = new Tile ("T4");
		tiles.AddLast (t1);
		tiles.AddLast (t2);
		tiles.AddLast (t3);
		tiles.AddLast (t4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
