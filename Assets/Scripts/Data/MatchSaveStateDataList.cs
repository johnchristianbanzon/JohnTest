
using System;
using System.Collections.Generic;

[Serializable]
public class MatchSaveStateDataList
{
    public int GameModeId;
    public List<MatchSaveStateData> Cards = new List<MatchSaveStateData>();
}