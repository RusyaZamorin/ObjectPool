using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> objects = new List<GameObject>();
    private void Create(GameObject obj,Vector3 pos, Quaternion rot)
    {
        GameObject temp = Instantiate(obj,pos,rot);
        objects.Add(temp);
    }
    public GameObject TakeObject(GameObject obj, Vector3 pos, Quaternion rot)
    {
        if (objects.Count == 0)
        {
            Create(obj, pos, rot);
            return objects[0];
        }
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                objects[i].transform.position = pos;
                objects[i].transform.rotation = rot;
                objects[i].SetActive(true);
                return objects[i];
            }
        }
        Create(obj, pos, rot);
        return objects[objects.Count -1];
    }

}
