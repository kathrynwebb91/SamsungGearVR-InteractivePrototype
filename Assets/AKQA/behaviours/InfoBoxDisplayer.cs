using UnityEngine;
using System.Collections;

public class InfoBoxDisplayer : MonoBehaviour
{

    public bool active;
    public bool selected;
    public bool infoOnShow;

    public Vector3     originalPos;
    public float       originalBGAlpha;
    private bool       fading;

    void Awake()
    {
        active = false;
        selected = false;
        infoOnShow = false;
        fading = false;
        originalPos = this.transform.position;
        originalBGAlpha = this.transform.GetChild(0).GetComponent<Renderer>().material.color.a;
    }


    //Show/Hide info box with fading
    public void ToggleInfo()
    {
        if (infoOnShow == false)
        {
            ShowInfo();
        }
        else
        {
            HideInfo();
        }
    }
    
    public void ShowInfo()
    {
        iTween.MoveBy(this.gameObject, new Vector3(0, 5, 0), 0.3F);
        this.GetComponent<Fader>().Fade(0.3F, 0, originalBGAlpha);
        infoOnShow = true;
    }

    public void HideInfo()
    {
        iTween.MoveTo(this.gameObject, originalPos, 0.3F);
        this.GetComponent<Fader>().Fade(0.3F, originalBGAlpha, 0);
        infoOnShow = false;
    }


	void Update(){

	}
}

