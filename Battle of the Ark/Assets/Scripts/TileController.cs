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
		createTiles ();
	}

	// Update is called once per frame
	void Update () {

	}

	void createTiles() {
		tiles = new List<Tile> ();
		/*
		tiles.Add (new Tile ("T1","T2","T4"));
		tiles.Add (new Tile ("T2","T3","T1"));
		tiles.Add (new Tile ("T3","T4","T2"));
		tiles.Add (new Tile ("T4","T1","T3"));
		*/
		/*
		tiles.Add (new Tile ("T1","T2","T6"));
		tiles.Add (new Tile ("T2","T3","T1","T5"));
		tiles.Add (new Tile ("T3","T4","T2"));
		tiles.Add (new Tile ("T4","T5","T3"));
		tiles.Add (new Tile ("T5","T6","T4","T2"));
		tiles.Add (new Tile ("T6","T1","T5"));
		*/

		//1
		tiles.Add (new Tile ("T1","T2","T36"));
		tiles.Add (new Tile ("T2","T3","T1"));
		tiles.Add (new Tile ("T3","T4","T2"));
		tiles.Add (new Tile ("T4","T5","T3"));
		tiles.Add (new Tile ("T5","T6","T4"));

		//2
		tiles.Add (new Tile ("T6","T7","T5","T37"));
		tiles.Add (new Tile ("T7","T8","T6"));
		tiles.Add (new Tile ("T8","T9","T7"));
		tiles.Add (new Tile ("T9","T10","T8"));
		tiles.Add (new Tile ("T10","T11","T9"));

		//3
		tiles.Add (new Tile ("T11","T12","T10"));
		tiles.Add (new Tile ("T12","T13","T11"));
		tiles.Add (new Tile ("T13","T14","T12"));
		tiles.Add (new Tile ("T14","T15","T13"));

		//4
		tiles.Add (new Tile ("T15","T16","T14","T38"));
		tiles.Add (new Tile ("T16","T17","T15"));
		tiles.Add (new Tile ("T17","T18","T16"));
		tiles.Add (new Tile ("T18","T19","T17"));

		//5
		tiles.Add (new Tile ("T19","T20","T18"));
		tiles.Add (new Tile ("T20","T21","T19"));
		tiles.Add (new Tile ("T21","T22","T20"));
		tiles.Add (new Tile ("T22","T23","T21"));
		tiles.Add (new Tile ("T23","T24","T22"));

		//6
		tiles.Add (new Tile ("T24","T25","T23","T39"));
		tiles.Add (new Tile ("T25","T26","T24"));
		tiles.Add (new Tile ("T26","T27","T25"));
		tiles.Add (new Tile ("T27","T28","T26"));
		tiles.Add (new Tile ("T28","T29","T27"));

		//7
		tiles.Add (new Tile ("T29","T30","T28"));
		tiles.Add (new Tile ("T30","T31","T29"));
		tiles.Add (new Tile ("T31","T32","T30"));
		tiles.Add (new Tile ("T32","T33","T31"));

		//8
		tiles.Add (new Tile ("T33","T34","T32","T40"));
		tiles.Add (new Tile ("T34","T35","T33"));
		tiles.Add (new Tile ("T35","T36","T34"));
		tiles.Add (new Tile ("T36","T1","T35"));

		//9
		tiles.Add (new Tile ("T37","T6","T42"));
		tiles.Add (new Tile ("T38","T15","T44"));
		tiles.Add (new Tile ("T39","T24","T46"));
		tiles.Add (new Tile ("T40","T33","T48"));

		//10
		tiles.Add (new Tile ("T41","T42","T48"));
		tiles.Add (new Tile ("T42","T43","T41","T37"));
		tiles.Add (new Tile ("T43","T44","T42"));
		tiles.Add (new Tile ("T44","T45","T43","T38"));
		tiles.Add (new Tile ("T45","T46","T44"));
		tiles.Add (new Tile ("T46","T47","T45","T39"));
		tiles.Add (new Tile ("T47","T48","T46"));
		tiles.Add (new Tile ("T48","T41","T47","T40"));

		Debug.Log ("tile initialized");
	}
}
