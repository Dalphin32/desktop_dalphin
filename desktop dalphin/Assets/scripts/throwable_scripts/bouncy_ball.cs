using UnityEngine;

public class bouncy_ball : MonoBehaviour
{
    private color_changer changer;
    private settings_data.DalSettings stgs;
    [SerializeField] private AudioClip bounce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>() as Rigidbody2D;
        rb.AddForce(new Vector2(Random.Range(-100.0f,100.0f),Random.Range(250.0f,300.0f)));

        changer = gameObject.AddComponent<color_changer>();
        changer.randomize_color(gameObject);

        stgs = GameObject.Find("manager").GetComponent<settings_data>().get_settings();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Destroy_ball",5);
    }

    void Destroy_ball(){
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject.Find("sound_player").GetComponent<AudioSource>().PlayOneShot(bounce, stgs.Volume);
    }
}