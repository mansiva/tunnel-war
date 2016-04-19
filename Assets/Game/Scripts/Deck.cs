using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
	[SerializeField] int _size;

	Card[] _cards;
	List<Unit> _deckUnits;
	List<Unit> _handUnits;

	public Card SelectedCard { get; private set; }

	public IEnumerator Setup ()
	{
		_cards = new Card[_size];

		// First card is prefab
		GameObject slotPrefab = transform.GetChild(0).gameObject;
		_cards[0] = slotPrefab.GetComponentInChildren<Card>();

		// Remove all but first tile
		for (int i = 1; i < transform.childCount; ++i)
			Destroy(transform.GetChild(i).gameObject);

		yield return null;

		// Create tiles in first column
		for (int i = 1; i < _size; ++i)
		{
			_cards[i] = Instantiate<GameObject>(slotPrefab).GetComponentInChildren<Card>();
			_cards[i].transform.parent.SetParent(transform, false);
			_cards[i].transform.name = string.Format("Slot ({0})", i + 1);
		}
 	}

	public void LoadUnits(Unit[] units)
	{
		units.Shuffle<Unit>();

		_handUnits = new List<Unit>();
		for (int i = 0; i < _size; ++i)
		{
			_handUnits.Add(units[i]);
			_cards[i].Set(units[i]);
		}

		_deckUnits = new List<Unit>();
		for (int i = _size; i < units.Length; ++i)
		{
			_deckUnits.Add(units[i]);
		}
	}

	public void SelectCard(Card card)
	{
		if (SelectedCard != null)
		{
			SelectedCard.transform.position -= new Vector3(0, 20);
		}

		SelectedCard = card;
		SelectedCard.transform.position += new Vector3(0, 20);
	}

	public void PlayCard(Card card, Tile tile)
	{
		// Deploy unit
		card.Unit.Deploy(tile);

		// Move unit to back of deck
		_handUnits.Remove(card.Unit);
		_deckUnits.Add(card.Unit);

		// Replace card with first in deck
		card.Set(_deckUnits[0]);
		_deckUnits.RemoveAt(0);
		_handUnits.Add(card.Unit);
	}
}
