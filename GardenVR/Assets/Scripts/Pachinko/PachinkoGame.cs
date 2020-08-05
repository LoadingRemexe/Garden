using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PachinkoGame : MonoBehaviour
{
    [SerializeField] Transform claw = null;
    [SerializeField] Transform rightLimit = null;
    [SerializeField] HingeJoint hinge = null;
    [SerializeField] GameObject dropPrefab = null;
    [SerializeField] GameObject[] levels = null;
    [SerializeField] PachinkoBasket[] baskets = null;

    private float clawspeed = .05f;
    public int pickupsCollected = 0;
    public int scorePoints = 0;
    private int numOfPlays = 3;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(levels[Random.Range(0, levels.Length)], transform);
        baskets = FindObjectsOfType<PachinkoBasket>();
        createNewBall();
    }

    public void MoveClaw(Vector2 input)
    {
        claw.Translate(input * clawspeed);
        claw.transform.position = new Vector3(Mathf.Clamp(claw.transform.position.x, -rightLimit.position.x, rightLimit.position.x), claw.transform.position.y, claw.transform.position.z);
    }

    public void DropBall()
    {
        hinge.connectedBody = null;
    }

    public void AddPickup()
    {
        pickupsCollected++;
    }
    public void AddScore(int score)
    {
        scorePoints += score;
        foreach(PachinkoBasket basket in baskets)
        {
            basket.ResetBasket();
        }
        createNewBall();
    }

    public void createNewBall()
    {
        if (numOfPlays > 0)
        {
            numOfPlays--;
            GameObject ball = Instantiate(dropPrefab, claw.position + Vector3.down, claw.rotation, null);
            hinge.connectedBody = ball.GetComponent<Rigidbody>();
            ball.GetComponent<Rigidbody>().AddForce(Vector3.left, ForceMode.Impulse);
        } else
        {
            PachinkoManager.Instance.EndGame();
        }
    }

}