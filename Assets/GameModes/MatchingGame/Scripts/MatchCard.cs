using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    public bool IsMatched;
    public bool IsFaceUp;
    private IAudioManager _audioManager;


    public void InitializeCard(SymbolData symbolData, Action<MatchCard> onFlipCard)
    {
        _audioManager = DependencyResolver.Container.Resolve<IAudioManager>();
        SymbolData = symbolData;
        _symbolSprite = symbolData.FaceSprite;
        OnFlipCard = onFlipCard;

        IsMatched = false;
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

    /// <summary>
    /// Call for matched
    /// </summary>
    public void PopOut()
    {
        IsMatched = true;
        transform.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack);
        _audioManager.PlaySfX(EnumMatchingAudio.Match1);
    }

    public void Shake()
    {
        _audioManager.PlaySfX(EnumMatchingAudio.Fail);
        transform.transform.DOShakeRotation(0.4f,30,randomnessMode: ShakeRandomnessMode.Harmonic).OnComplete(delegate
        {
            Flip(false);
        });
    }

    public void Flip(bool open, bool noEvent=false)
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
        IsFaceUp = open;

        if (open)
        {
            _audioManager.PlaySfX(EnumMatchingAudio.Flip1);

        }
       
    }

}
