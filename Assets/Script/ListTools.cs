using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListTools
{
    public static void RemoveNullItems(List<GameObject> gameObjects)
    {
        foreach (var item in gameObjects)
        {
            if (item == null)
            {
                gameObjects.Remove(item);
                break;
            }
        }
    }
   
    public static void DestoryListofGameObjects(List<GameObject> ListofGameObjects)
    {
        if (ListofGameObjects != null)
        {
            foreach (GameObject item in ListofGameObjects) UnityEngine.Object.Destroy(item);
            ListofGameObjects.Clear();
        }
    }
    public static void AddOneToList(List<GameObject> AddingTo, GameObject thingToAdd)
    {
        if (!AddingTo.Contains(thingToAdd)) AddingTo.Add(thingToAdd);
    }
    public static GameObject FindInListByName(string Name, List<GameObject> list)
    {
        GameObject temp = null;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].name == Name)
            {
                temp = list[i];
                break;
            }
        }
        return temp;
    }
    public static List<GameObject> ArrayToList(GameObject[] array)
    {
        List<GameObject> objects = new List<GameObject>();
        for (int i = 0; i < array.Length; i++)
        {
            objects.Add(array[i]);
        }
        return objects;
    }
    public static void DeActivateAllInList(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(false);
        }
    }
    public static void ActivateAllInList(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(true);
        }
    }
    public static bool AllIsActiveInList(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].activeInHierarchy == false)
            {
                return false;
            }
        }
        return true;
    }
}
