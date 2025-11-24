using System;

[Serializable]
public class MatchSaveStateData
{ 
    public int CardId;
    public int Position;
    public bool IsFaceUp;
    public bool IsMatched;

    private SymbolData SymbolData;

    public void SetSymbolData(SymbolData symbolData)
    {
        SymbolData = symbolData;
    }

    public SymbolData GetSymbolData() { return SymbolData; }
}