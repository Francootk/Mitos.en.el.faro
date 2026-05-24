using System.Collections.Generic;
using UnityEngine;

public class Inventary_System : MonoBehaviour
{
    public Dictionary<string, int> inventory = new Dictionary<string, CollectableItems>();
    public Transform listado_items;

}
