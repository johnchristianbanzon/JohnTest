public interface ISaveManager 
{
    public void SaveMatchingSaveData(MatchSaveStateDataList data);
    public MatchSaveStateDataList LoadMatchingSaveData();
    public void DeleteMatchingSaveData();
}
