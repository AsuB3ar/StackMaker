using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;

    public static PlayerScript instance;

    public GameObject StackParent;
    public GameObject UpperStack;

    public bool isMoving = false;

    public float speed;

    public const string WALL = "Wall";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SwipeMovement();
    }

    public void SwipeMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || TouchInput.Instance.swipeLeft && isMoving == false)
        {
            isMoving = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || TouchInput.Instance.swipeRight && isMoving == false)
        {
            isMoving = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || TouchInput.Instance.swipeUp && isMoving == false)
        {
            isMoving = true;
            transform.rotation = Quaternion.Euler(0, -90, 0);
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || TouchInput.Instance.swipeDown && isMoving == false)
        {
            isMoving = true;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            rb.velocity = -Vector3.forward * speed * Time.deltaTime;
        }

        if (rb.velocity == Vector3.zero)
        {
            isMoving = false;
        }
    }
    public void PlusStack(GameObject stackPlus)
    {
        stackPlus.transform.SetParent(StackParent.transform);
        Vector3 upperPos = UpperStack.transform.localPosition;
        upperPos.y -= 0.5f;
        stackPlus.transform.localPosition = upperPos;


        Vector3 PlayerPos = transform.localPosition;
        PlayerPos.y += 0.5f;
        transform.localPosition = PlayerPos;
        UpperStack = stackPlus;
        UpperStack.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void SubtractStack()
    {
        Vector3 PlayerPos = transform.localPosition;
        PlayerPos.y -= 0.5f;
        transform.localPosition = PlayerPos;

        Destroy(StackParent.transform.GetChild(0).gameObject);
        for (int i = 0; i < StackParent.transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
