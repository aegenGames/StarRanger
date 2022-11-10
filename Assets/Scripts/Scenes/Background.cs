using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    private float height;


    void Start()
    {
        height = this.GetComponent<RectTransform>().sizeDelta.y * 2;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (this.transform.localPosition.y <= -height)
        {
            this.transform.localPosition = new Vector3(this.transform.position.x, height, this.transform.position.z);
        }
        this.transform.position -= this.transform.up * speed * Time.deltaTime;
    }
}
