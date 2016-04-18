using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
	[SerializeField] int _size;

	Card[] _cards;
	List<Unit> _deckUnits;
	List<Unit> _handUnits;

	IEnumerator Start ()
	{
		_cards = new Card[_size];

		// First card is prefab
		_cards[0] = transform.GetChild(0).GetComponent<Card>();

		// Remove all but first tile
		for (int i = 1; i < transform.childCount; ++i)
			Destroy(transform.GetChild(i).gameObject);

		yield return null;

		// Create tiles in first column
		for (int i = 1; i < _size; ++i)
		{
			_cards[i] = Instantiate<GameObject>(_cards[0].gameObject).GetComponent<Card>();
			_cards[i].transform.SetParent(transform, false);
			_cards[i].name = string.Format("Card ({0})", i + 1);
		}
 	}

	public void LoadDeck(Unit[] units)
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
