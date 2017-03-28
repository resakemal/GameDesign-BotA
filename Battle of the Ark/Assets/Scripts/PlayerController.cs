using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public TileController tileControl;
	private LinkedList<Tile> btiles;
	private Tile pos;
	private Tile laspos;
	private bool teleport;
	// Use this for initialization
	void Start () {
		btiles = tileControl.tiles;
		teleport = false;
		pos = new Tile("T1");
		laspos = new Tile("T1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void teleportPlayer (string tile) {
		
	}

	void movePlayer (int steps) {
		bool dir = false;
		LinkedListNode<Tile> curTile = btiles.Find (pos);
		if (pos.tileID == laspos.tileID || teleport) {
			dir = chooseDirection (curTile);
			steps--;
		} else {
			if (Equals(curTile.Previous.Value,laspos))
				dir = true;
			else
				dir = false;
		}
		GameObject nextTileObj;
		int i = 1;
		while (i <= steps) {
			if (curTile.Value.intersection)
				dir = chooseDirection (curTile);
			else {
				laspos = curTile.Value;
				if (dir)
					curTile = curTile.Next;
				else
					curTile = curTile.Previous;
				pos = curTile.Value;
				nextTileObj = GameObject.Find (curTile.Value.tileID);
				this.transform.position = nextTileObj.transform.position;
			}
			i++;
		}
	}

	bool chooseDirection(LinkedListNode<Tile> current) {
		bool direction = false;
		List<string> choice = current.Value.branch;
		laspos = current.Value;
		//show option to player
		if (Input.GetKeyDown ("j")) {
			foreach (Tile t in btiles) {
				if (t.tileID == choice [0]) {
					current = btiles.Find (t);
					direction = false;
				}
			}
		} else if (Input.GetKeyDown ("k")) {
			foreach (Tile t in btiles) {
				if (t.tileID == choice [1]) {
					current = btiles.Find (t);
					direction = true;
				}
			}
		}
		pos = current.Value;
		return direction;
	}
}
