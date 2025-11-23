using UnityEngine;

[CreateAssetMenu(menuName = "GameMode/Matching/Config", order = 31)]
public class MatchingConfigSO : ScriptableObject
{
    public string MatchModeName;
    public int MatchConditionAmount;
    public Vector2Int GameboardSize;
}
