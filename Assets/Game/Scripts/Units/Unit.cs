using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Unit : ScriptableObject
{
	public CardData cardData;

	public int Level { get; set; }

	public abstract void Deploy(Tile tile);
}
