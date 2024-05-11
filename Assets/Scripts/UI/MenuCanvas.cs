using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
	[SerializeField] 
	private RectTransform	_gameLabel;
	[SerializeField]
	private float			_labelDuration	= 1f;
	[SerializeField] 
	private RectTransform	_playButton;
	[SerializeField]
	private float           _buttonDuration	= 1f;

	private Vector3			_initialGameLabelPosition;
	private Vector3			_initialPlayButtonPosition;

	private void Awake()
	{
		_initialGameLabelPosition = _gameLabel.localPosition;
		_initialPlayButtonPosition = _playButton.localPosition;

		_gameLabel.localPosition = new Vector3(0, 800, 0);

		_playButton.localPosition = new Vector3(0, -800, 0);
	}

	private void Start()
	{
		Sequence s = DOTween.Sequence();
		s.Append(_gameLabel.DOLocalMove(_initialGameLabelPosition, _labelDuration).SetEase(Ease.OutBack));
		s.Insert(.8f, _playButton.DOLocalMove(_initialPlayButtonPosition, _buttonDuration).SetEase(Ease.OutBack));
	}
}
