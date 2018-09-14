using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Image Image1;
	public Image Image2;

	public bool IsUIDisplayed;

	public Color color;

	public float FadeDuration;

	public bool IsImageFadding;

	

	// Update is called once per frame
	//HACK::PROTO
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (IsImageFadding)
			{
				Image1.CrossFadeAlpha(1, 5.0f, false);
				IsImageFadding = false;
			}
			else if (!IsImageFadding)
			{
				Image1.CrossFadeAlpha(0, 5.0f, false);
				IsImageFadding = true;
			}
			
		}

	}
}
