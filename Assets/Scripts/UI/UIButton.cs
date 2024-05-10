using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIButton : MonoBehaviour
{
	[SerializeField]
	private Button			_button;
	[SerializeField]
	private RectTransform	_body;

	[SerializeField]
	private float			_duration   = 0.25f;

	private bool			_isCooldown;
	private Coroutine		_cooldownCoroutine;

	public event Action		ClickEvent;

	private void OnEnable()
	{
		_button.onClick.AddListener(PlayImpact);
	}

	private void OnDisable()
	{
		if (_cooldownCoroutine != null)
		{
			StopCoroutine(_cooldownCoroutine);
		}

		_isCooldown = false;

		_button.onClick.RemoveListener(PlayImpact);
	}

	private void PlayImpact()
	{
		if (_button == null) return;
		if (_isCooldown || !gameObject.activeInHierarchy)
		{
			return;
		}

		_body.DOScale(_body.localScale * 0.9f, _duration).SetEase(Ease.InCirc).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
		{
			ClickEvent?.Invoke();
		}); ;
		_cooldownCoroutine = StartCoroutine(StartCooldown(_duration * 2));
	}

	private IEnumerator StartCooldown(float time)
	{
		_isCooldown = true;
		yield return new WaitForSeconds(time);
		_isCooldown = false;
	}
}
