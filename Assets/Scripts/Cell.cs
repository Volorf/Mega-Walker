using UnityEngine;
using Random = UnityEngine.Random;

public class Cell : MonoBehaviour
{
    private Vector3 _rot;
    private const float CHANCE_OF_DIVIDING = 3f;
    private const float OFFSET = 0.05f;
    private const float RANDOM_RANGE = 0.05f;
    private bool _canReplicate = true;

    private float _timer = 0f;

    private void Replicate()
    {
        float xRan = Random.Range(-RANDOM_RANGE, RANDOM_RANGE);
        float zRan = Random.Range(-RANDOM_RANGE, RANDOM_RANGE);
        
        Vector3 offsetVec = new Vector3(xRan, OFFSET, zRan);
        Vector3 transPos = transform.position;
        Quaternion transRot = transform.rotation;

        GameObject replicant = Instantiate(this.gameObject, transPos, transRot);
        replicant.gameObject.name = "Cell";
        replicant.transform.Rotate(Random.Range(0f, 1f) > 0.5f ? Vector3.forward : Vector3.right, Random.Range(-10f, 10f));
        replicant.transform.Translate(offsetVec, Space.Self);
    }
    
    private void Update()
    {
        if (_timer >= 0.1f)
        {
            if (!_canReplicate) return;
            float chance = Random.Range(0f, 100f);
            if (chance <= CHANCE_OF_DIVIDING)
            {
                Replicate();
            }
            Replicate();
            _canReplicate = false;
            _timer = 0f;
        }
        
        _timer += Time.deltaTime;
    }
}
