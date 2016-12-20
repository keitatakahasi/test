using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    public string nextSceneName;
    public Image FadeImage;

    bool isFade;
    bool isFadeIn;
    bool isFadeOut;
    float alpha;
	// Use this for initialization
	void Start () {
        isFade = true;
        isFadeIn = true;
        isFadeOut = false;
        alpha = 1.0f;
        this.transform.SetAsLastSibling();
	
	}
	
	// Update is called once per frame
	void Update () {
        alpha -= 0.04f;

        FadeImage.color = new Color(
            FadeImage.color.r,
            FadeImage.color.g,
            FadeImage.color.b,
            alpha
            );
	}
}
