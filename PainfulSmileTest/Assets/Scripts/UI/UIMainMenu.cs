using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _buttonsContainer;

    public void ButtonsAnim()
    {
        _buttonsContainer.transform.DOShakeRotation(.5f).onComplete += () => _buttonsContainer.transform.DOLocalMoveY(-350,.5f).SetEase(Ease.InSine);
    }

}
