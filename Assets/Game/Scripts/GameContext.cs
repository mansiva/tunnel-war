using UnityEngine;
using System.Collections;

public class GameContext : MonoBehaviour
{
	public static GameContext Instance;

	void Awake()
	{
		Instance = this;
	}

	[SerializeField] Inventory _inventory;
	[SerializeField] Board _board;
	[SerializeField] Deck _deck;

	public Inventory Inventory { get { return _inventory; } }
	public Board Board { get { return _board; } }
	public Deck Deck { get { return _deck; } }

	IEnumerator Start ()
	{
		Inventory.Load();

		yield return StartCoroutine(Board.Setup());
		yield return StartCoroutine(Deck.Setup());

		Deck.LoadUnits(Inventory.units);
	}
}
