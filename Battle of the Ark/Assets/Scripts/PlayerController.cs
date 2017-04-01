using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public TileController tileControl;
	private List<Tile> tileset;
	private Tile pos;
	private Tile laspos;
	private bool teleport;
	private bool l;
	// Use this for initialization
	void Start () {
		teleport = false;
		l = true;
	}

	// Update is called once per frame
	void Update () {
		tileset = (List<Tile>) tileControl.tiles;
		if (Input.GetKeyDown (KeyCode.X))
			initPlayer();
		if (Input.GetKeyDown (KeyCode.C))
			movePlayer (1);
		if (Input.GetKeyDown (KeyCode.J)) {
			l = true;
			Debug.Log ("left selected");
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			l = false;
			Debug.Log ("right selected");
		}
	}

	void initPlayer() {
		pos = new Tile (tileset[0]);
		laspos = new Tile (tileset [tileset.Count - 1]);
		Debug.Log ("player initialized");
	}

	void teleportPlayer (string tile) {

	}

	void movePlayer (int steps) {
		int i = 1;
		GameObject nextTileObj;
		while (i <= steps) { //loop as much as number of steps
			Debug.Log ("start " + pos.tileID);
			List<string> ncopy = new List<string> (pos.neighbor); //copy neighbor from current tile
			ncopy.Remove (laspos.tileID); //remove previous tile from list
			if (ncopy.Count > 1) { //if list has > 1 element, it's an intersection
				chooseDirection(ncopy);
			} else { //list has 1 element; move player to next tile
				laspos = pos;
				pos = tileset.Find (t => t.tileID == ncopy [0]);
			}
			Debug.Log ("end " + pos.tileID);
			nextTileObj = GameObject.Find (pos.tileID);
			this.transform.position = nextTileObj.transform.position;
			this.transform.Translate (0, 5f, 0);
			i++;
		}
		Debug.Log ("movement done");
	}

	void chooseDirection(List<string> branch) {
		Debug.Log ("count: " + branch.Count);
		if (l) {
			Debug.Log ("forward");
			laspos = pos;
			pos = tileset.Find (t => t.tileID == branch [0]);
		} else {
			Debug.Log ("shortcut");
			laspos = pos;
			pos = tileset.Find (t => t.tileID == branch [1]);
		}
	}
}
