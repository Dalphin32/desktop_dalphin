using UnityEngine;

public class confetti_spwn : MonoBehaviour
{
    private float confetti_spwn_timer;
    private float confetti_ded_timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        confetti_spwn_timer+= Time.deltaTime;
        confetti_ded_timer+= Time.deltaTime;

        if (confetti_spwn_timer >= 0.5f){
            Object.Instantiate(Resources.Load("confetti"),new Vector3(Random.Range(-2.0f,2.0f),1.25f,0),Quaternion.identity);
            confetti_spwn_timer = 0.0f;
        }
        if (confetti_ded_timer >= 10) Destroy(gameObject);
        
    }
}
