using UnityEngine;
using UnityEngine.Pool;
public enum SpawnedStatTextType {TRASH,FOLLOWER,MONEY,TIME,ILLEGALITY };
public class Spawner : Singleton<Spawner>
{//might be ui some day

    public SpawnedStatTextType spawnedText;
    public static new Spawner instance => Singleton<Spawner>.instance;

    [SerializeField] FloatingText _textPrefab;
    [SerializeField] Transform _floatingTextParentTransform;

    [SerializeField] Transform _trashTextSpawnPoint;//up//up
    [SerializeField] Transform _followerTextSpawnPoint;//up
    [SerializeField] Transform _moneyTextSpawnPoint;//up
    [SerializeField] Transform _timeTextSpawnPoint;//down
    [SerializeField] Transform _illegalityTextSpawnPoint;//up

    protected override void Awake()
    {
        base.Awake();
    }

    public void SpawnTextSpecific(SpawnedStatTextType spawnedTextType, float amount)
    { 
        FloatingText spawnedText = Instantiate(_textPrefab);

        Debug.Log("SpawningText");
        switch (spawnedTextType)
        {
            case SpawnedStatTextType.TRASH:
                {
                    spawnedText.transform.SetParent(_trashTextSpawnPoint);
                    spawnedText.transform.position = _trashTextSpawnPoint.position;
                    spawnedText.UpdateText("<sprite=0>" + ((int)amount).ToString("+#;-#;0"), amount < 0, true);
                }
                break;
                case SpawnedStatTextType.FOLLOWER:
                {
                    spawnedText.transform.SetParent(_followerTextSpawnPoint);
                    spawnedText.transform.position = _followerTextSpawnPoint.position;
                    spawnedText.UpdateText("<sprite=3>" + ((int)amount).ToString("+#;-#;0"), amount > 0, true);
                }
                break;
                case SpawnedStatTextType.MONEY: 
                {
                    spawnedText.transform.SetParent(_moneyTextSpawnPoint);
                    spawnedText.transform.position = _moneyTextSpawnPoint.position;
                    spawnedText.UpdateText("<sprite=1>" + ((int)amount).ToString("+#;-#;0"), amount > 0, true);
                }
                break;
                case SpawnedStatTextType.TIME:
                {
                    spawnedText.transform.SetParent(_timeTextSpawnPoint);
                    spawnedText.transform.position = _timeTextSpawnPoint.position;
                    spawnedText.UpdateText(((int)amount).ToString("+#;-#;0") + " days(???)", amount > 0, false);
                }
                break;
                case SpawnedStatTextType.ILLEGALITY: 
                {
                    spawnedText.transform.SetParent(_illegalityTextSpawnPoint);
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
