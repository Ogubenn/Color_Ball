using UnityEngine;

public class ObstacleAnim : MonoBehaviour
{
    [Header("Anim Variables")]
    public float animationSpeed1 = 1.0f;
    public float animationSpeed2 = 1.0f;
    public float targetX = -1.5f;
    public float targetZ = 22.70f;

    private Vector3 initialPosition;
    private Vector3 targetXPos;
    private Vector3 targetZPos;
    private bool isAnimatingX = false;
    private bool isAnimatingZ = false;

    [Header("Kups")]
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;

    private void Start()
    {
        initialPosition = transform.position;
        targetXPos = new Vector3(targetX, initialPosition.y, initialPosition.z);
        targetZPos = new Vector3(targetX, initialPosition.y, targetZ);
        //isAnimatingX = true;
    }

    public void StartAnimation()
    {
        isAnimatingX = true;
        
    }

    private void Update()
    {
        
        ObstacleAnimFonk();
    }

    public void ObstacleAnimFonk()
    {
        
        if (isAnimatingX)
        {
            float step = animationSpeed1 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetXPos, step);

            if (Vector3.Distance(transform.position, targetXPos) < 0.01f)
            {
                isAnimatingX = false;
                isAnimatingZ = true;
                Cube1.SetActive(true);
                Cube2.SetActive(true);
            }
        }

        if (isAnimatingZ)
        {
            float step2 = animationSpeed2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetZPos, step2);

            if (Vector3.Distance(transform.position, targetZPos) < 0.01f)
            {
                isAnimatingZ = false;
            }
        }
        if(!isAnimatingX && !isAnimatingZ)
        {
            ReverseAnim();
        }

    }

    public void ReverseAnim()
    {
        float step2 = animationSpeed2 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, step2);
        isAnimatingX = true;
    }
}