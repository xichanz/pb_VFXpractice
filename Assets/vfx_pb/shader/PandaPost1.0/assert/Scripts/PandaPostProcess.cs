using UnityEngine;
using PandaTitle;

[ExecuteInEditMode]
public class PandaPostProcess : MonoBehaviour
{
    public Material PostProcessMat;

    [DisplayName("Step Factor")]
    [Range(0, 1)]
    public float StepFactor = 0.5F;

    [DisplayName("Main Alpha")]
    [Range(0, 1)]
    public float MainAlpha = 1F;

    [DisplayName("Radial Blur Strength")]
    [Range(0, 1)]
    public float BlurFactor;

    [DisplayName("UV Distortion Strength")]
    [Range(0, 4)]
    public float LineUVScale;

    [DisplayName("Chromatic Strength")]
    [Range(0, 1.5F)]
    public float Chromatic;

    [DisplayName("Shake Frequency")]
    [Range(0, 1)]
    public float Frequency;

    [DisplayName("Shake Amplitude")]
    [Range(0, 1)]
    public float Amplitude;

    [DisplayName("Vignette Power")]
    [Range(1, 3)]
    public float VignettePower = 1.5F;

    [DisplayName("Vignette Strength")]
    [Range(0, 3)]
    public float VignetteScale = 1.5F;

    private void Awake()
    {
        if (PostProcessMat == null)
        {
            enabled = false;
        }
        else
        {
            PostProcessMat.mainTexture = PostProcessMat.mainTexture;
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (PostProcessMat == null)
        {
            Graphics.Blit(src, dest);
            return;
        }

        PostProcessMat.SetFloat("_StepFactorK", StepFactor);
        PostProcessMat.SetFloat("_BlurFactorK", BlurFactor);
        PostProcessMat.SetFloat("_LineUVScaleK", LineUVScale);
        PostProcessMat.SetFloat("_MainAlphaK", MainAlpha);
        PostProcessMat.SetFloat("_zhenpinK", Frequency);
        PostProcessMat.SetFloat("_zhenfuK", Amplitude);
        PostProcessMat.SetFloat("_RedBlueFactorK", Chromatic);
        PostProcessMat.SetFloat("_VignettePowerK", VignettePower);
        PostProcessMat.SetFloat("_VignetteScaleK", VignetteScale);

        Graphics.Blit(src, dest, PostProcessMat);
    }
}