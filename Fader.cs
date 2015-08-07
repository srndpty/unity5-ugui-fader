using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Fader : MonoBehaviour
{
    public enum Style
    {
        BlackOut,
        BlackIn,
        WhiteOut,
        WhiteIn,
        BlackOutHalf,
        Clear,
        Fill
    };

    private Image fadeImg;
    private float fadeAlpha;
    private string nextSceneName;
    private Vector3 fadeColor;
    private bool isFading;
    private float fadeTime;
    private int fadeDir;
    private bool isPaused;
    private Style fadeStyle;

    // Use this for initialization
    void Start()
    {
        fadeImg = GetComponent<Image>();
        // set the image as tranparent
        Color c = fadeImg.color;
        fadeImg.color = new Color(c.r, c.g, c.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // run this function on fading only
        if (!isFading) return;

        // Update fading
        fadeAlpha += Time.deltaTime / fadeTime * fadeDir;
        fadeImg.color = new Color(fadeColor.x, fadeColor.y, fadeColor.z, fadeAlpha);

        if (fadeStyle == Style.BlackOutHalf && fadeAlpha > 0.5f)
        {
            isFading = false;
        }
    }

    public void Begin(Style style, float time, string sceneName = null)
    {
        // dont start new fade while fading
        if (isFading || isPaused) return;

        // prevent 0 divide
        if (time < 0.001f) time = 0.001f;

        // determine if goto next scene or not
        if (sceneName != null)
        {
            nextSceneName = sceneName;
        }

        if (style != Style.BlackOutHalf)
        {
            Invoke("OnFadeFinish", time);
        }

        fadeStyle = style;
        fadeTime = time;
        SetFaderParams(style);
        isFading = true;
    }

    void OnFadeFinish()
    {
        isFading = false;
        if (nextSceneName != null)
        {
            Application.LoadLevel(nextSceneName);
        }
    }

    void SetFaderParams(Style style)
    {
        // set fade color
        switch (style)
        {
            case Style.BlackOut:
                fadeColor = new Vector3(0, 0, 0);
                fadeAlpha = 0;
                fadeDir = +1;
                break;
            case Style.BlackIn:
                fadeColor = new Vector3(0, 0, 0);
                fadeAlpha = 1;
                fadeDir = -1;
                break;
            case Style.WhiteOut:
                fadeColor = new Vector3(1, 1, 1);
                fadeAlpha = 0;
                fadeDir = +1;
                break;
            case Style.WhiteIn:
                fadeColor = new Vector3(1, 1, 1);
                fadeAlpha = 1;
                fadeDir = -1;
                break;
            case Style.BlackOutHalf:
                fadeColor = new Vector3(0, 0, 0);
                fadeAlpha = 0;
                fadeDir = +1;
                break;
            case Style.Clear:
                fadeDir = -1;
                fadeTime /= fadeAlpha;
                break;
            case Style.Fill:
                fadeDir = +1;
                fadeTime /= 1 - fadeAlpha;
                break;
            default:
                // should not reach here
                break;
        }
    }

    public bool IsFading()
    {
        return isFading;
    }

    public void Pause()
    {
        if (isFading)
        {
            isFading = false;
            isPaused = true;
        }
    }

    public void Resume()
    {
        if (isPaused)
        {
            isFading = true;
        }
    }
}
