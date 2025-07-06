using UnityEngine;
using UnityEngine.UI;
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
    Vector2 _spawnPosition;
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

    public void CreateBubble()
    {
        Bubble bubbleInstance = Instantiate(GameManager.instance.bubblePrefab, GameManager.instance.interactiveCanvas.transform);
        bubbleInstance.GetComponent<RectTransform>().anchoredPosition = GetPointOnTerrain(false);
    }
    public void CreateTrashBubble()
    {
        GameObject bubbleInstance = Instantiate(GameManager.instance.trashBubblePrefab, GameManager.instance.mapCanvas.transform);
        bubbleInstance.GetComponent<RectTransform>().anchoredPosition = GetPointOnTerrain(true);
        float random = UnityEngine.Random.Range(0.8f, 1.5f);
        bubbleInstance.GetComponent<RectTransform>().localScale = new Vector3(random, random, random);
        GameManager.instance.trashBubbles.Add(bubbleInstance);
    }
    public void RemoveTrashBubble()
    {
        if (GameManager.instance.trashBubbles.Count > 0)
        {
            GameObject obj = GameManager.instance.trashBubbles[GameManager.instance.trashBubbles.Count - 1];
            GameManager.instance.trashBubbles.Remove(obj);
            Destroy(obj);
        }
    }
    /*
    public Vector2 GetPointOnTerrain(bool isTrashBubble)
    {
        Vector2 targetPos;
        if (isTrashBubble)
            targetPos = new Vector2(UnityEngine.Random.Range(0, 1920), UnityEngine.Random.Range(0, 1080));
        else
            targetPos = new Vector2(UnityEngine.Random.Range(0, 1920 - 164), UnityEngine.Random.Range(0, 1080 - 253));

        Color color = GameManager.instance.mapSprite.GetPixel((int)targetPos.x * 4, (int)targetPos.y * 4);
        while (color.r >= 0.202 && color.r <= 0.206 && color.g >= 0.410 && color.g <= 0.414 && color.b >= 0.578 && color.b <= 0.582)    // Sea Color: R 204 G 412 B 480
        {
            if (isTrashBubble)
                targetPos = new Vector2(UnityEngine.Random.Range(0, 1920), UnityEngine.Random.Range(0, 1080));
            else
                targetPos = new Vector2(UnityEngine.Random.Range(0, 1920 - 164), UnityEngine.Random.Range(0, 1080 - 253));
            color = GameManager.instance.mapSprite.GetPixel((int)targetPos.x * 4, (int)targetPos.y * 4);
        }
        return targetPos;
    }*/
    public void GetRandomPointOnTerrain()
    { 
        // check if 
    }
    public Vector2 GetPointOnTerrain(bool isTrashBubble)
    {
        if (isTrashBubble)
        {
            _spawnPosition = new Vector2(UnityEngine.Random.Range(0, 1920), UnityEngine.Random.Range(0, 1080)); 
        }
        else
        {
            _spawnPosition = new Vector2(UnityEngine.Random.Range(0, 1920 - 164), UnityEngine.Random.Range(0, 1080 - 253)); 
        }
        Color color = GameManager.instance.mapSprite.GetPixel((int)_spawnPosition.x * 4, (int)_spawnPosition.y * 4);

        if (color.r >= 0.202 && color.r <= 0.206 && color.g >= 0.410 && color.g <= 0.414 && color.b >= 0.578 && color.b <= 0.582)
        {
            GetPointOnTerrain(isTrashBubble);
        }
        return _spawnPosition;
    }

    private Vector2 GetPointOnWater()
    {
        Vector2 targetPos = new Vector2(UnityEngine.Random.Range(0, GameManager.instance.mapCanvas.pixelRect.width), UnityEngine.Random.Range(0, GameManager.instance.mapCanvas.pixelRect.height));
        Color color = GameManager.instance.mapSprite.GetPixel((int)targetPos.x * 4, (int)targetPos.y * 4);
        while (!(color.r >= 0.202 && color.r <= 0.206 && color.g >= 0.410 && color.g <= 0.414 && color.b >= 0.578 && color.b <= 0.582))
        {
            targetPos = new Vector2(UnityEngine.Random.Range(0, GameManager.instance.mapCanvas.pixelRect.width), UnityEngine.Random.Range(0, GameManager.instance.mapCanvas.pixelRect.height));
            color = GameManager.instance.mapSprite.GetPixel((int)targetPos.x * 4, (int)targetPos.y * 4);
        }
        return targetPos;
    }
    private void GetRandomPointOnMap()
    {
        
    }
}
