using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Game", order = 0)]
public class ConfigFile : ScriptableObject
{
    [SerializeField] private ulong _baseCostClick;
    [SerializeField] private ulong _costUpdate ;
    [SerializeField] private ulong _costUpdateAutoClicker;
    [SerializeField] private ulong _maxCountUpdateClick;
    [SerializeField] private ulong _maxCountUpdateAutoClick;

    public ulong BaseCostClick => _baseCostClick;

    public ulong MAXCountUpdateClick => _maxCountUpdateClick;

    public ulong MAXCountUpdateAutoClick => _maxCountUpdateAutoClick;

    public ulong CostUpdate => _costUpdate;

    public ulong CostUpdateAutoClicker => _costUpdateAutoClicker;
}
