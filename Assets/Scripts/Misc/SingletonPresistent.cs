using UnityEngine;

public class SingletonPresistent<T> : Singleton<T> where T : Singleton<T>
{
    public int numberrrrr = 12333;
    protected override void Awake()
    {
        base.Awake();
        if (!gameObject.transform.parent)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
