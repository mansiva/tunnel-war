using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Tile : MonoBehaviour, IPointerClickHandler, IDropHandler
{
	public Deck Deck { get { return GameContext.Instance.Deck; } }

	public void OnPointerClick (PointerEventData eventData)
	{
		if (Deck.SelectedCard != null)
			Deck.PlayCard(Deck.SelectedCard, this);
	}

	public void OnDrop (PointerEventData eventData)
	{
//		Card card = eventData.pointerDrag.GetComponent<Card>();
		if (Deck.SelectedCard != null)
			Deck.PlayCard(Deck.SelectedCard, this);
	}

}
