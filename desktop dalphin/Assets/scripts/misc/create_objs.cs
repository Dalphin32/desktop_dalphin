using UnityEngine;

public class create_objs : MonoBehaviour
{
    [SerializeField] private string obj_to_spawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < Random.Range(4,12); i++){
            GameObject obj = GameObject.Instantiate(Resources.Load(obj_to_spawn), transform.position, Quaternion.identity) as GameObject;
            obj.transform.parent = transform;
            obj.transform.localScale = new Vector3(1,1,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0) Destroy(gameObject);
    }
}
