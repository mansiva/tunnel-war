using UnityEngine;
using UnityEngine.UI;

public class SpellUnit : Unit
{
	public Color color;

	public override void Deploy(Tile tile)
	{
		tile.GetComponent<Image>().color = color;
	}
}
