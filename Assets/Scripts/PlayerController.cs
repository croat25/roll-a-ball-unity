using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Text CountText;
    public float speed;
    private int count;
    public Text WinText;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        CountText.text = "Count:" + count.ToString();
        SetCountText();
        WinText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up")){
            count += 1;
            other.gameObject.SetActive(false);
            SetCountText();
        }
    }
    void SetCountText()
    {
        CountText.text = "Count:" + count.ToString();
        if(count >= 11)
        {
            WinText.text = "Winner";
        }
    }
}


   