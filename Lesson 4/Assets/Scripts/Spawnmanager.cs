using UnityEngine;
using UnityEngine.PlayerLoop;

public class spawnmanager : MonoBehaviour
{
    public GameObject enemyprefab;
    public GameObject powerupprefab;
    public int enemycount;
    public int wavenumber = 1;
    private float spawnrange = 9;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(powerupprefab, Genspawnpos(), powerupprefab.transform.rotation);
        SpawnEnemyWave(wavenumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemycount = FindObjectsOfType<Enemy>().Length;
        if(enemycount == 0){ 
            wavenumber++; 
            SpawnEnemyWave(wavenumber);
            Instantiate(powerupprefab, Genspawnpos(), powerupprefab.transform.rotation);
        }
        
    }

    void SpawnEnemyWave(int enemies_to_spawn){
        for(int i = 0; i < enemies_to_spawn; i++){
            Instantiate(enemyprefab, Genspawnpos(), enemyprefab.transform.rotation);
        }
    }

    private Vector3 Genspawnpos(){
        float spawnposx = Random.Range(-spawnrange, spawnrange);
        float spawnposz  = Random.Range(-spawnrange, spawnrange);
        Vector3 randompos = new Vector3(spawnposx, 0, spawnposz);
        return randompos;
    }
}
