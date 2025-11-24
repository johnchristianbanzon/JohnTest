using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

/// <summary>
/// A group is created for every match sequence needed.
/// </summary>
public class MatchingGroupCheck 
{
    private List<MatchCard> _matchCards = new List<MatchCard>();
    private int _maxMatches;
    private Action<MatchingGroupCheck> _onComplete;

    public void Initialize(int maxMatches, Action<MatchingGroupCheck> OnComplete)
    {
        _maxMatches = maxMatches;
        _onComplete = OnComplete;
    }

    public void AddSymbol(MatchCard matchCard)
    {
        _matchCards.Add(matchCard);
        if (IsGroupFull())
        {
            _onComplete?.Invoke(this);
        }
           
    }

    public bool IsGroupCorrect()
    {
        bool allNamesAreSame = _matchCards.All(data => (data.SymbolData.Label == _matchCards[0].SymbolData.Label && 
                                                        data.SymbolData.Face == _matchCards[0].SymbolData.Face));
        return allNamesAreSame;
    }

    public bool IsGroupFull()
    {
       
        return _matchCards.Count == _maxMatches;
    }

    public void MatchSuccess()
    {
        for (int i = 0; i < _matchCards.Count; i++)
        {
            _matchCards[i].PopOut();
        }
    }

    public void ResetMatch()
    {
        for (int i = 0; i < _matchCards.Count; i++)
        {
            _matchCards[i].Shake();
        }
    }
}