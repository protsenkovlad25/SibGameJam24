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

		_gameLabel.localPosition = new Vector3(0, - _gameLabel.localPosition.y - _gameLabel.sizeDelta.y, 0);

		_playButton.localPosition = new Vector3(0, - _playButton.localPosition.y - _playButton.sizeDelta.y, 0);
	}

	private void Start()
	{
		_gameLabel.DOLocalMove(_initialGameLabelPosition, _labelDuration).SetEase(Ease.OutBack).OnComplete(() =>
		{
			_playButton.DOLocalMove(_initialPlayButtonPosition, _buttonDuration).SetEase(Ease.OutBack);
		});
	}
}
