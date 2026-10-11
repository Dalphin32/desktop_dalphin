using UnityEngine;

public class confetti : MonoBehaviour
{
    private float flip_countdown;
    private color_changer changer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changer = gameObject.AddComponent<color_changer>();
        changer.randomize_color(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        flip_countdown+=Time.deltaTime;
        if (flip_countdown>= 0.1f){
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            flip_countdown = 0;
        }
        transform.position = transform.position + new Vector3(0,-0.75f*Time.deltaTime,0);
        if (transform.position.y <= -1) Destroy(gameObject);
    }
}
