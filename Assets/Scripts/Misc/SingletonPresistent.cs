using UnityEngine;

public class SingletonPresistent<T> : Singleton<SingletonPresistent<T>> where T : SingletonPresistent<T>
{
    public int numberrrrr = 12333;
    public void Awake()
    {
        base.Awake();
        if (!gameObject.transform.parent)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
}
