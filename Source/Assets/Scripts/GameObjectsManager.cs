using UnityEngine;
using System.Collections.Generic;

public class GameObjectsManager : MonoBehaviour {

    private static Dictionary<string, Queue<GameObject>> objects = new Dictionary<string, Queue<GameObject>>();

    public static GameObjectsManager Manager {
        get;
        private set;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        objects.Clear();

        if (Manager == null)
        {
            Manager = this;
        }
        else if (Manager != this) {
            Destroy(gameObject);
        }

        objects.Add("bullet", new Queue<GameObject>());
    }

    public static GameObject GetObject(string name)
    {
        if (objects[name].Count > 0)
        {
            return objects [name].Dequeue();
        }

        return null;
    }

    public static void RetireObject(string name, GameObject gameObject)
    {
        objects [name].Enqueue(gameObject);
    }
}
