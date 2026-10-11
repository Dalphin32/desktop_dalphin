using UnityEngine;

public class balloon : MonoBehaviour
{
    color_changer changer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>() as Rigidbody2D;
        rb.AddForceX(Random.Range(-60.0f, 60.0f));
        int ctrl_idx = Random.Range(0,3);
        switch(ctrl_idx){
            case 0:
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load("animator_ctrls/b_circ_ctrl") as RuntimeAnimatorController;
            break;
            case 1:
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load("animator_ctrls/b_hrt_ctrl") as RuntimeAnimatorController;
            break;
            case 2:
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load("animator_ctrls/b_dog_ctrl") as RuntimeAnimatorController;
            break;
        }

        changer = gameObject.AddComponent<color_changer>();
        changer.randomize_color(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 5) Destroy(gameObject);
    }
}
