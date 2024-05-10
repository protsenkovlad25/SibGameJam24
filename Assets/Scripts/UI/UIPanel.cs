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
	private float				_showDuration			= 1f;
	[SerializeField]
	private RectTransform       _text;
	[SerializeField]
	private float               _textShowDuration		= 0.5f;
	[SerializeField]
	private UIButton            _okButton;
	[SerializeField]
	private float				_buttonShowDuration		= 0.25f;

	private LevelCanvas			_levelCanvas;
	protected LevelSceneLoader  _levelSceneLoader;

	public void Initialize(LevelCanvas levelCanvas, LevelSceneLoader levelSceneLoader)
	{
		_levelCanvas = levelCanvas;
		_levelSceneLoader = levelSceneLoader;
	}

	protected virtual void Awake()
	{
		_body.anchoredPosition = Vector2.zero;
		_body.sizeDelta = Vector2.zero;
		_okButton.transform.localScale = Vector2.zero;
		_text.localScale = Vector2.zero;
		_view.localScale = Vector3.zero;
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
		_view.transform.DOScale(Vector3.one, _showDuration).SetEase(Ease.OutBack).OnComplete(() =>
		{
			_text.DOScale(Vector3.one, _textShowDuration).SetEase(Ease.OutBack).OnComplete(() =>
			{
				_okButton.transform.DOScale(Vector3.one, _buttonShowDuration).SetEase(Ease.OutBack);
			});
		});
	}

	public virtual void Hide()
	{
		_levelCanvas.HideBackground();
		_view.transform.DOScale(Vector3.zero, _showDuration).SetEase(Ease.InBack).OnComplete(() =>
		{
			_view.gameObject.SetActive(false);
			OnHideComplete();
		});
	}

	protected virtual void OnHideComplete()
	{
		
	}
}
