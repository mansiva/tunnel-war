using UnityEngine;
using System.Collections.Generic;

public class Board : MonoBehaviour
{
	[SerializeField] int width;
	[SerializeField] int height;

	Tile[,] _tiles;

	void Start ()
	{
		_tiles = new Tile[width, height];

		Transform tunnelPrefab = transform.GetChild(0);
		Transform tilePrefab = tunnelPrefab.GetChild(0);

		_tiles[0
		for (int i = 1; i < height; ++i)
		{
			GameObject tile = Instantiate<GameObject>(tilePrefab.gameObject);
			tile.transform.SetParent(tunnelPrefab);
		}

		for (int i = 1; i < width; ++i)
		{
			GameObject tunnel = Instantiate<GameObject>(tunnelPrefab.gameObject);
			tunnel.transform.SetParent(transform);
		}
	}
}
