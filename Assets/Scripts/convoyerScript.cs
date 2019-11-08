using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convoyerScript : MonoBehaviour
{
    float scroll = 2.7f;
    [SerializeField] Material mRight, mLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mRight.mainTextureOffset = new Vector2(0, scroll* Time.time);
        mLeft.mainTextureOffset = new Vector2(0, -scroll * Time.time);
        //mRight.SetTextureOffset("_mainTex", new Vector2(0, scrollSpeed));
        //mLeft.SetTextureOffset("_mainTex", new Vector2(0, -scrollSpeed));
    }
}
