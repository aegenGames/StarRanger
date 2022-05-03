using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    private float height;


    void Start()
    {
        height = this.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (this.transform.position.y <= -height)
        {
            this.transform.position = new Vector3(this.transform.position.x, height, this.transform.position.z);
        }
        this.transform.position -= this.transform.up * speed * Time.deltaTime;
    }
}
