using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCanvas : MonoBehaviour
{
	[SerializeField]
	private Image			_background;

	[SerializeField]
	private float           _duration   = 1f;

	private bool            _isBackgroundShowed;

	public void ShowBackground()
	{
		if (!_isBackgroundShowed)
		{
			_isBackgroundShowed = true;

			_background.DOFade(0.5f, _duration);
		}
	}

	public void HideBackground()
	{
		if (_isBackgroundShowed)
		{
			_isBackgroundShowed = false;

			_background.DOFade(0f, _duration);
		}
	}
}
