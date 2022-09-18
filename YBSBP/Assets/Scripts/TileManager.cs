using UnityEngine;
using System.Collections.Generic;
public class TileManager : MonoBehaviour
{
    #region VARIABLES

    public GameObject[] cubePrefabs;
    private Transform _player;
    private float _spawnPosZ;
    private float _cubeLength = 53.01118f;
    private int _maxCube = 5;
    private List<GameObject> _activeCubes;
    private float _safeZone = 82f;
    private int _lastPrefabIndex;

    #endregion

    private void Start()
    {
        GetReferences();

        for (int i = 0; i < _maxCube; i++)
        {
            if (i<3)
            {
                CubeSpawner(0);
                
            }
            else
            {
                CubeSpawner();    
            }
            
        }
    }

    private void Update()
    {
        if (_player.position.z - _safeZone > (_spawnPosZ - _maxCube * _cubeLength))
        {
            CubeSpawner();
            CubeDeleter();
        }
    }

    private void CubeSpawner(int prefabIndex = -1)
    {
        GameObject instantiate;
        if (prefabIndex == -1)
        {
            instantiate = Instantiate(cubePrefabs[RandomPrefabIndex()]);
        }
        else
        {
            instantiate = Instantiate(cubePrefabs[prefabIndex]);
        }
        instantiate.transform.SetParent(transform);
        instantiate.transform.position = Vector3.forward * _spawnPosZ;
        _spawnPosZ += _cubeLength;
        _activeCubes.Add(instantiate); 
    }

    private void CubeDeleter()
    {
        Destroy(_activeCubes[0]);
        _activeCubes.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (cubePrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = _lastPrefabIndex;
        while (randomIndex == _lastPrefabIndex)
        {
            randomIndex = Random.Range(0, cubePrefabs.Length);
        }
        _lastPrefabIndex = randomIndex;
        return randomIndex;
    }
    
    private void GetReferences()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _activeCubes = new List<GameObject>();
    }
}
