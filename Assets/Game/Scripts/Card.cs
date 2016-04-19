using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public struct CardData
{
	public Sprite image;
	public int cost;
}

public class Card : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[SerializeField] Image _image;
	[SerializeField] Text _cost;

	Vector3 _initialPosition;

	public Unit Unit { get; private set; }

	public void Set(Unit unit)
	{
		Unit = unit;
		_image.sprite = Unit.cardData.image;
		_cost.text = Unit.cardData.cost.ToString();
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		GameContext.Instance.Deck.SelectCard(this);
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		GameContext.Instance.Deck.SelectCard(this);

		_initialPosition = transform.position;

		// TODO: Move to higher transform
	}

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData)
	{
//		transform.position = _initialPosition;
	}
}
