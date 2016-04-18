using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public struct CardData
{
	public Sprite image;
	public int cost;
}

public class Card : MonoBehaviour
{
	[SerializeField] Image _image;
	[SerializeField] Text _cost;

	public Unit Unit { get; private set; }

	public void Set(Unit unit)
	{
		Unit = unit;
		_image.sprite = Unit.cardData.image;
		_cost.text = Unit.cardData.cost.ToString();
	}
}
