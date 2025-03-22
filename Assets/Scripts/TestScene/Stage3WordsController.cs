using UnityEngine;

public class Stage3WordsController : MonoBehaviour
{
    public GameObject words;
    public Camera mainCamera;
    private Rigidbody2D wordsRigid;
    private Transform wordsTransform;
    private Vector3 wordsRelativePosition;
    private Stage3StateController stage3StateController;
    private bool gravityScaleChanged = false;
    
    void Start()
    {
        wordsRigid = words.GetComponent<Rigidbody2D>();
        wordsTransform = words.GetComponent<Transform>();
        stage3StateController = gameObject.GetComponent<Stage3StateController>();

        wordsRigid.gravityScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (words != null)
        {
            if (stage3StateController.alphaDecreaseEnd && !gravityScaleChanged)
            {
                wordsRigid.gravityScale = 1;
                gravityScaleChanged = true;
            }

            wordsRelativePosition = mainCamera.WorldToViewportPoint(wordsTransform.position);

            if (wordsRelativePosition.x < 0 || 1 < wordsRelativePosition.x
                || wordsRelativePosition.y < 0 || 1 < wordsRelativePosition.y)
            {
                StartCoroutine(DestroyWords());
            }
        }
    }

    private System.Collections.IEnumerator DestroyWords()
    {
        Destroy(words, 2);
        yield return new WaitForSeconds(2);
        words = null;
        stage3StateController.wordsDestroyed = true;
    }
}
