using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPanel : MonoBehaviour
{
	[SerializeField]
	private RectTransform	_view;
	[SerializeField]
	private Button			_okButton;
	[SerializeField]
	private float			_duration	= 1f;

	private void Awake()
	{
		_view.gameObject.SetActive(false);
		_view.transform.position = Vector3.zero;
	}

	private void OnEnable()
	{
		_okButton.onClick.AddListener(Hide);
	}

	private void OnDisable()
	{
		_okButton.onClick.RemoveListener(Hide);
	}

	public virtual void Show()
	{
		_view.gameObject.SetActive(true);
		_view.transform.DOScale(Vector3.one, _duration).SetEase(Ease.OutBack);
	}

	public virtual void Hide()
	{
		_view.transform.DOScale(Vector3.zero, _duration).SetEase(Ease.InBack).OnComplete(() => _view.gameObject.SetActive(false));
	}
}
