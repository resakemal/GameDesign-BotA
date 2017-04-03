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
		l = false;
	}

	// Update is called once per frame
	void Update () {
		tileset = (List<Tile>) tileControl.tiles;
		if (Input.GetKeyDown (KeyCode.X))
			initPlayer();
		if (Input.GetKeyDown (KeyCode.C))
			movePlayer (1);
		/*
		if (Input.GetKeyDown (KeyCode.J)) {
			l = true;
			Debug.Log ("left selected");
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			l = false;
			Debug.Log ("right selected");
		}
		*/
	}

	void initPlayer() {
		pos = new Tile (tileset[0]);
		laspos = new Tile (tileset [0]);
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
			if (ncopy.Remove (laspos.tileID) == false) { //remove previous tile from list
				Debug.Log ("teleport");
				StartCoroutine ("chooseDirection",ncopy);
			} else if (ncopy.Count > 1) { //if list has > 1 element, it's an intersection
				Debug.Log ("intersection");
				StartCoroutine ("chooseDirection",ncopy);
			} else { //list has 1 element; move player to next tile
				laspos = pos;
				pos = tileset.Find (t => t.tileID == ncopy [0]);
			}
			Debug.Log ("end " + pos.tileID);
			nextTileObj = GameObject.Find (pos.tileID);
			this.transform.position = nextTileObj.transform.position;
			this.transform.Translate (0, 2f, 0);
			i++;
		}
		Debug.Log ("movement done");
	}

	IEnumerator chooseDirection(List<string> branch) {
		Debug.Log ("count: " + branch.Count);
		yield return StartCoroutine ("waitInput");
		Debug.Log ("input received");
		if (l) {
			Debug.Log ("forward");
			laspos = pos;
			pos = tileset.Find (t => t.tileID == branch [0]);
		} else {
			Debug.Log ("shortcut");
			laspos = pos;
			pos = tileset.Find (t => t.tileID == branch [1]);
		}
		GameObject nextTileObj = GameObject.Find (pos.tileID);
		this.transform.position = nextTileObj.transform.position;
		this.transform.Translate (0, 2f, 0);
	}

	IEnumerator waitInput() {
		//bool wait = true;
		Debug.Log ("choose j/k");
		while (true) {
			if (Input.GetKeyDown (KeyCode.J)) {
				l = true;
				yield break;
			}
			if (Input.GetKeyDown (KeyCode.K)) {
				l = false;
				yield break;
			}	
			yield return null;
		}
	}
}
