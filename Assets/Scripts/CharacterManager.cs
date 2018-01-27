using UnityEngine;
using System.Collections.Generic;

public class CharacterManager : Singleton<CharacterManager>
{
    public List<GameObject> camerasList;
    public List<GameObject> enemiesList;
    public GameObject player;

    public LayerMask enemiesLayer;
    public LayerMask wallsLayer;
    public LayerMask androidEnemyLayer;
    
}