using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject target;
    public Vector3 spawnValues;
    public int targetCnt;
    public float startWait;
    public float spawnWait;
    public float waveWait;
    public Transform CameraTransform;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < targetCnt; i++)
            {
                Vector3 spawnPosition = spawnValues;
                Quaternion spawnRotation = Quaternion.identity;
                GameObject duck = Instantiate(target, spawnPosition, spawnRotation) as GameObject;
                SoundManager.Instance.PlayDuckSound();
                duck.GetComponent<DuckController>().CameraTransform = CameraTransform;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

}
