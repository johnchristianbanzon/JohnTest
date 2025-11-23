using UnityEngine;
using UnityEngine.UI;

public class MatchingView : BaseView
{
    [SerializeField]
    private MatchCard _matchCard;
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup;

    public void SetupBoard(int rowSize, int columnSize)
    {
        _gridLayoutGroup.constraintCount = columnSize;
        for (int i = 0; i < rowSize + columnSize; i++)
        {
            Instantiate(_matchCard, _gridLayoutGroup.transform);
        }
    }
}