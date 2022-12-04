using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSex : MonoBehaviour
{
	public Button button;
	public static string sexSelected = null;

	void Start()
	{
		button.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		sexSelected = button.GetComponentInChildren<Text>().text.ToLower();
	}
}

