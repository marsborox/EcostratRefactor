using UnityEngine;
public enum SpawnedStatTextType {TRASH,FOLLOWER,MONEY,TIME,ILLEGALITY };
public class Spawner : Singleton<Spawner>
{
    public SpawnedStatTextType spawnedText;
    public static new Spawner instance => Singleton<Spawner>.instance;

    [SerializeField] FloatingText _textPrefab;

    [SerializeField] RectTransform _trashTextSpawnPoint;//up//up
    [SerializeField] Transform _followerTextSpawnPoint;//up
    [SerializeField] RectTransform _moneyTextSpawnPoint;//up
    [SerializeField] RectTransform _timeTextSpawnPoint;//down
    [SerializeField] RectTransform _illegalityTextSpawnPoint;//up

    protected override void Awake()
    {
        base.Awake();
    }

    public void SpawnText(SpawnedStatTextType spawnedTextType, int amount)
    { 
        FloatingText spawnedText = Instantiate(_textPrefab);
        //spawnedText.UpdateText();
        switch (spawnedTextType)
        {
            case SpawnedStatTextType.TRASH:
                {
                    spawnedText.transform.position = _trashTextSpawnPoint.position;
                    spawnedText.UpdateText("<sprite=0>" + ((int)amount).ToString("+#;-#;0"), amount < 0, true);
                }
                break;
                case SpawnedStatTextType.FOLLOWER:
                {
                    spawnedText.transform.position = _followerTextSpawnPoint.position;
                    spawnedText.UpdateText("<sprite=3>" + ((int)amount).ToString("+#;-#;0"), amount > 0, true);
                }
                break;
                case SpawnedStatTextType.MONEY: 
                {
                    spawnedText.transform.position = _moneyTextSpawnPoint.position;
                    spawnedText.UpdateText("<sprite=1>" + ((int)amount).ToString("+#;-#;0"), amount > 0, true);
                }
                break;
                case SpawnedStatTextType.TIME:
                {
                    spawnedText.transform.position = _timeTextSpawnPoint.position;
                    spawnedText.UpdateText(((int)amount).ToString("+#;-#;0") + " seconds", amount > 0, false);
                }
                break;
                case SpawnedStatTextType.ILLEGALITY: 
                {
                    spawnedText.transform.position = _illegalityTextSpawnPoint.position;
                    spawnedText.UpdateText("<sprite=4>" + ((int)amount).ToString("+#;-#;0"), amount > 0, true);
                }
                break;
        }
    }
    public void SpawnTextSwitch(SpawnedStatTextType spawnedText1)
    {


    }
}
