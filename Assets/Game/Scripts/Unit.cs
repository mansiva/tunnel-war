using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Unit : ScriptableObject
{
	public CardData cardData;

	public int Level { get; set; }

	public abstract void Deploy(Tile tile);
}

public class SpellUnit : Unit
{
	public Color color;

	public override void Deploy(Tile tile)
	{
		tile.GetComponent<Image>().color = color;
	}
}