using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour
{
	[SerializeField] int _width;
	[SerializeField] int _height;

	Tile[,] _tiles;

	IEnumerator Start ()
	{
		_tiles = new Tile[_width, _height];

		// First tile of first column is prefab
		Transform columnPrefab = transform.GetChild(0);
		Transform tilePrefab = columnPrefab.GetChild(0);
		_tiles[0, 0] = tilePrefab.GetComponent<Tile>();

		// Remove all but first tile
		for (int x = 1; x < transform.childCount; ++x)
			Destroy(transform.GetChild(x).gameObject);
		for (int y = 1; y < columnPrefab.childCount; ++y)
			Destroy(columnPrefab.GetChild(y).gameObject);

		yield return null;

		// Create tiles in first column
		for (int y = 1; y < _height; ++y)
		{
			_tiles[0, y] = Instantiate<GameObject>(tilePrefab.gameObject).GetComponent<Tile>();
			_tiles[0, y].transform.SetParent(columnPrefab, false);
			_tiles[0, y].name = string.Format("Tiles ({0})", y + 1);
		}

		// Create columns and get tiles
		for (int x = 1; x < _width; ++x)
		{
			GameObject column = Instantiate<GameObject>(columnPrefab.gameObject);
			column.transform.SetParent(transform, false);
			column.name = string.Format("Column ({0})", x + 1);

			for (int y = 0; y < _height; ++y)
				_tiles[x, y] = column.transform.GetChild(y).GetComponent<Tile>();
		}
	}
}
