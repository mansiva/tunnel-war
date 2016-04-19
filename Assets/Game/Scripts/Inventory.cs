using UnityEngine;
using System.Collections;

[System.Serializable]
public class Inventory
{
	public Unit[] units;

	public void Load()
	{
		units = Resources.LoadAll<Unit>("Units");
		for (int i = 0; i < units.Length; ++i)
		{
			units[i].Level = PlayerPrefs.GetInt(units[i].name + "_Level", 0);
		}

		// TODO: Have separate list for battle deck
	}
}
