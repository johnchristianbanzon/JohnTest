using UnityEngine;

[CreateAssetMenu(menuName = "GameMode/Matching/Config", order = 31)]
public class MatchingConfig : ScriptableObject
{
    public string MatchModeName;
    public int MatchConditionAmount;
    public Vector2Int GameboardSize;
}
