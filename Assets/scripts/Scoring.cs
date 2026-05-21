using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    private float score = 0f;
    public TMP_Text scoreText;
    private Vector3 reset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        reset = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
            switch (other.gameObject.tag)
            {
                case "100":
                    score += 100f;
                    Debug.Log($"score: {score}");
                    break;
                case "250":
                    score += 250f;
                    Debug.Log($"score: {score}");
                    break;
                case "500":
                    score += 500f;
                    Debug.Log($"score: {score}");
                    break;
                case "1000":
                    score += 1000f;
                    Debug.Log($"score: {score}");
                    break;
                case "box":
                    Debug.Log("ball reset");
                    ResetBall();
                break;
        }
    }
  

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {score}";
    }

    void ResetBall()
    {
        transform.position = reset;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
