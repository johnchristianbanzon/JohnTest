using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MatchCard : MonoBehaviour, IPointerClickHandler
{
    public bool AllowClick = true;
    public SymbolData SymbolData;
    private Action<MatchCard> OnFlipCard;
    [SerializeField]
    private Sprite _backSprite;
    [SerializeField]
    private Image _symbolGraphic;
    private Sprite _symbolSprite;

    public void InitializeCard(SymbolData symbolData, Action<MatchCard> onFlipCard)
    {
        SymbolData = symbolData;
        _symbolSprite = symbolData.FaceSprite;
        OnFlipCard = onFlipCard;
       

        _symbolGraphic.sprite = _backSprite;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (AllowClick == false)
        {
            return;
        }
        Flip(true);
    }

    public void SpawnAnimation(float delay)
    {
        transform.localScale = Vector3.zero;
        transform.transform.DOScale(Vector3.one, 0.4f).SetDelay(delay).SetEase(Ease.OutBack);
    }

    public void PopOut()
    {
        transform.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack);
    }

    public void Shake()
    {
        transform.transform.DOShakeRotation(0.4f);
    }

    public void Flip(bool open)
    {
        AllowClick = false;
        transform.DORotate(new Vector3(0f, 90f, 0f), 0.4f).OnComplete(delegate
        {
            _symbolGraphic.sprite = open ? _symbolSprite : _backSprite;
            transform.DORotate(new Vector3(0f, -90, 0f), 0.004f);
            transform.DORotate(new Vector3(0f, 0, 0f), 0.4f).OnComplete(delegate
            {
                AllowClick = true;
                //transform.DORotate(new Vector3(0f, 0, 0f), 0.004f);
                if (open)
                {
                    OnFlipCard?.Invoke(this);
                }
            });
        });
    }

}
