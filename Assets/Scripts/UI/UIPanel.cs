using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
	[SerializeField]
	private RectTransform		_body;
	[SerializeField]
	private RectTransform		_view;
	[SerializeField]
	private UIButton			_okButton;
	[SerializeField]
	private float				_duration	= 1f;

	private LevelCanvas			_levelCanvas;
	protected LevelSceneLoader  _levelSceneLoader;

	public void Initialize(LevelCanvas levelCanvas, LevelSceneLoader levelSceneLoader)
	{
		_levelCanvas = levelCanvas;
		_levelSceneLoader = levelSceneLoader;
	}

	private void Awake()
	{
		_body.anchoredPosition = Vector2.zero;
		_body.sizeDelta = Vector2.zero;
		_view.transform.localScale = Vector3.zero;
		_view.gameObject.SetActive(false);
	}

	private void OnEnable()
	{
		_okButton.ClickEvent += Hide;
	}

	private void OnDisable()
	{
		_okButton.ClickEvent += Hide;
	}

	public virtual void Show()
	{
		_levelCanvas.ShowBackground();
		_view.gameObject.SetActive(true);
		_view.transform.DOScale(Vector3.one, _duration).SetEase(Ease.OutBack);
	}

	public virtual void Hide()
	{
		_levelCanvas.HideBackground();
		_view.transform.DOScale(Vector3.zero, _duration).SetEase(Ease.InBack).OnComplete(() =>
		{
			_view.gameObject.SetActive(false);
			OnHideComplete();
		});
	}

	protected virtual void OnHideComplete()
	{
		
	}
}
