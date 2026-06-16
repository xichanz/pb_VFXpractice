using System;
using UnityEngine;
using UnityEditor;


// Custom GUI for PandaPost shader
public class PostGUI : ShaderGUI
{
    public GUILayoutOption[] shortButtonStyle = new GUILayoutOption[] { GUILayout.Width(100) };

    public GUIStyle style = new GUIStyle();

    static bool Foldout(bool display, string title)
    {
        var style = new GUIStyle("ShurikenModuleTitle");
        style.font = new GUIStyle(EditorStyles.boldLabel).font;
        style.border = new RectOffset(15, 7, 4, 4);
        style.fixedHeight = 22;
        style.contentOffset = new Vector2(20f, -2f);
        style.fontSize = 11;
        style.normal.textColor = new Color(0.7f, 0.8f, 0.9f);

        var rect = GUILayoutUtility.GetRect(16f, 25f, style);
        GUI.Box(rect, title, style);

        var e = Event.current;

        var toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
        if (e.type == EventType.Repaint)
        {
            EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
        }

        if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
        {
            display = !display;
            e.Use();
        }

        return display;
    }

    static bool Foldouts(bool display, string title)
    {
        var style = new GUIStyle("ShurikenModuleTitle");
        style.font = new GUIStyle(EditorStyles.boldLabel).font;
        style.border = new RectOffset(15, 7, 4, 4);
        style.fixedHeight = 18;
        style.contentOffset = new Vector2(30f, -2f);
        style.fontSize = 10;
        style.normal.textColor = new Color(0.75f, 0.75f, 0.75f);

        var rect = GUILayoutUtility.GetRect(16f, 15f, style);
        GUI.Box(rect, title, style);

        var e = Event.current;

        var toggleRect = new Rect(rect.x + 15f, rect.y + 2f, 13f, 13f);
        if (e.type == EventType.Repaint)
        {
            EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
        }

        if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
        {
            display = !display;
            e.Use();
        }

        return display;
    }


    static bool _MainColor = true;
    static bool _Base = true;
    static bool _Texxx = false;
    static bool _tips = false;
    static bool _Thanks = false;
    static bool _honglan = false;
    static bool _UVDistort = false;
    static bool _Black = false;
    static bool _Texx = false;
    static bool _Logox = false;
    static bool _Logoxx = false;
    static bool _zhenping = false;

    MaterialEditor m_MaterialEditor;

    MaterialProperty ColorStyle = null;
    MaterialProperty centerU = null;
    MaterialProperty centerV = null;
    MaterialProperty Color1 = null;
    MaterialProperty Color2 = null;
    MaterialProperty LineTilingU = null;
    MaterialProperty LineTilingV = null;
    MaterialProperty LineUVScale = null;
    MaterialProperty LineUVScaleK = null;
    MaterialProperty LineColorScale = null;
    MaterialProperty LineOffset = null;
    MaterialProperty BlurFactor = null;
    MaterialProperty BlurFactorK = null;
    MaterialProperty Soft = null;
    MaterialProperty StepFactor = null;
    MaterialProperty StepFactorK = null;
    MaterialProperty RedBlueFactor = null;
    MaterialProperty RedBlueFactorK = null;
    MaterialProperty Tex = null;
    MaterialProperty TexRotator = null;
    MaterialProperty TexAlpha = null;
    MaterialProperty VignettePower = null;
    MaterialProperty VignetteScale = null;
    MaterialProperty MainAlpha = null;
    MaterialProperty MainAlphaK = null;
    MaterialProperty IfMainAlpha = null;
    MaterialProperty IfStepFactor = null;
    MaterialProperty IfLineUVScale = null;
    MaterialProperty IfBlurFactor = null;
    MaterialProperty IfRedBlueFactor = null;
    MaterialProperty Logo = null;
    MaterialProperty LogoAR = null;
    MaterialProperty LogoAlpha = null;
    MaterialProperty zhenfu = null;
    MaterialProperty zhenfuK = null;
    MaterialProperty Ifzhenfu = null;
    MaterialProperty zhenpin = null;
    MaterialProperty zhenpinK = null;
    MaterialProperty Ifzhenpin = null;
    MaterialProperty IfVignettePower = null;
    MaterialProperty VignettePowerK = null;
    MaterialProperty IfVignetteScale = null;
    MaterialProperty VignetteScaleK = null;
    MaterialProperty TexAR = null;

    public void FindProperties(MaterialProperty[] props)
    {
        ColorStyle = FindProperty("_ColorStyle", props);
        centerU = FindProperty("_centerU", props);
        centerV = FindProperty("_centerV", props);
        Color1 = FindProperty("_Color1", props);
        Color2 = FindProperty("_Color2", props);
        LineTilingU = FindProperty("_LineTilingU", props);
        LineTilingV = FindProperty("_LineTilingV", props);
        LineUVScale = FindProperty("_LineUVScale", props);
        LineUVScaleK = FindProperty("_LineUVScaleK", props);
        IfLineUVScale = FindProperty("_IfLineUVScale", props);
        LineColorScale = FindProperty("_LineColorScale", props);
        LineOffset = FindProperty("_LineOffset", props);
        BlurFactor = FindProperty("_BlurFactor", props);
        BlurFactorK = FindProperty("_BlurFactorK", props);
        IfBlurFactor = FindProperty("_IfBlurFactor", props);
        Soft = FindProperty("_Soft", props);
        StepFactor = FindProperty("_StepFactor", props);
        StepFactorK = FindProperty("_StepFactorK", props);
        IfStepFactor = FindProperty("_IfStepFactor", props);
        RedBlueFactor = FindProperty("_RedBlueFactor", props);
        RedBlueFactorK = FindProperty("_RedBlueFactorK", props);
        IfRedBlueFactor = FindProperty("_IfRedBlueFactor", props);
        Tex = FindProperty("_Tex", props);
        TexRotator = FindProperty("_TexRotator", props);
        TexAlpha = FindProperty("_TexAlpha", props);
        VignettePower = FindProperty("_VignettePower", props);
        VignetteScale = FindProperty("_VignetteScale", props);
        MainAlpha = FindProperty("_MainAlpha", props);
        MainAlphaK = FindProperty("_MainAlphaK", props);
        IfMainAlpha = FindProperty("_IfMainAlpha", props);
        LogoAR = FindProperty("_LogoAR", props);
        Logo = FindProperty("_Logo", props);
        LogoAlpha = FindProperty("_LogoAlpha", props);
        zhenfu = FindProperty("_zhenfu", props);
        zhenfuK = FindProperty("_zhenfuK", props);
        Ifzhenfu = FindProperty("_Ifzhenfu", props);
        zhenpin = FindProperty("_zhenpin", props);
        zhenpinK = FindProperty("_zhenpinK", props);
        Ifzhenpin = FindProperty("_Ifzhenpin", props);
        IfVignettePower = FindProperty("_IfVignettePower", props);
        VignettePowerK = FindProperty("_VignettePowerK", props);
        VignetteScaleK = FindProperty("_VignetteScaleK", props);
        IfVignetteScale = FindProperty("_IfVignetteScale", props);
        TexAR = FindProperty("_TexAR", props);
    }

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
    {
        FindProperties(props);

        m_MaterialEditor = materialEditor;

        Material material = materialEditor.target as Material;

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);

        _MainColor = Foldout(_MainColor, "Color Style");

        if (_MainColor)
        {
            EditorGUI.indentLevel++;

            m_MaterialEditor.ShaderProperty(ColorStyle, "Color Style");

            if (_tips == true)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                style.fontSize = 10;
                style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                style.wordWrap = true;
                GUILayout.Label("* Normal is the default color mode. BlackWhiteFlash is black-and-white flashing. ColorReverse inverts the color.", style);
                EditorGUILayout.EndVertical();
            }

            GUILayout.Space(5);

            if (material.GetFloat("_ColorStyle") == 1)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                GUILayout.Space(5);

                m_MaterialEditor.ShaderProperty(Color1, "Color 1");
                m_MaterialEditor.ShaderProperty(Color2, "Color 2");

                if (_tips == true)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    style.fontSize = 10;
                    style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                    GUILayout.Label("* These two colors control the black-and-white flash color range.", style);
                    EditorGUILayout.EndVertical();
                }

                GUILayout.Space(5);

                m_MaterialEditor.ShaderProperty(Soft, "Color Transition Softness");

                if (_tips == true)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    style.fontSize = 10;
                    style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                    GUILayout.Label("* Controls the softness of the color transition. Higher value means softer transition.", style);
                    EditorGUILayout.EndVertical();
                }

                GUILayout.Space(5);

                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.PrefixLabel("Step Factor K-Frame");
                if (material.GetFloat("_IfStepFactor") == 0)
                {
                    if (GUILayout.Button("Off", shortButtonStyle))
                    {
                        material.SetFloat("_IfStepFactor", 1);
                    }
                }
                else
                {
                    if (GUILayout.Button("On", shortButtonStyle))
                    {
                        material.SetFloat("_IfStepFactor", 0);
                    }
                }

                EditorGUILayout.EndHorizontal();

                if (material.GetFloat("_IfStepFactor") == 0)
                {
                    m_MaterialEditor.ShaderProperty(StepFactor, "Step Factor");

                    if (_tips == true)
                    {
                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        style.fontSize = 10;
                        style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                        GUILayout.Label("* Controls the cutoff threshold for the black-and-white color effect.", style);
                        EditorGUILayout.EndVertical();
                    }

                    GUILayout.Space(5);
                }

                EditorGUILayout.EndVertical();

                m_MaterialEditor.ShaderProperty(LineColorScale, "Line Color Strength");

                if (_tips == true)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    style.fontSize = 10;
                    style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                    GUILayout.Label("* Adds random line-like patterns to the screen for a distorted post-processing look.", style);
                    EditorGUILayout.EndVertical();
                }

                GUILayout.Space(5);
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel("Main Alpha K-Frame");
            if (material.GetFloat("_IfMainAlpha") == 0)
            {
                if (GUILayout.Button("Off", shortButtonStyle))
                {
                    material.SetFloat("_IfMainAlpha", 1);
                }
            }
            else
            {
                if (GUILayout.Button("On", shortButtonStyle))
                {
                    material.SetFloat("_IfMainAlpha", 0);
                }
            }

            EditorGUILayout.EndHorizontal();

            if (_tips == true)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                style.fontSize = 10;
                style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                GUILayout.Label("* Enable this if you want Main Alpha controlled by keyframes or script. When enabled, the slider below is ignored.", style);
                EditorGUILayout.EndVertical();
            }

            if (material.GetFloat("_IfMainAlpha") == 0)
            {
                m_MaterialEditor.ShaderProperty(MainAlpha, "Main Alpha");

                if (_tips == true)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    style.fontSize = 10;
                    style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                    GUILayout.Label("* Controls the overall visibility of this post-processing effect.", style);
                    EditorGUILayout.EndVertical();
                }
            }

            EditorGUILayout.EndVertical();
            GUILayout.Space(5);

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        _UVDistort = Foldout(_UVDistort, "Radial Blur");

        if (_UVDistort)
        {
            EditorGUI.indentLevel++;
            UVDistort(material);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        _honglan = Foldout(_honglan, "Chromatic Aberration");

        if (_honglan)
        {
            EditorGUI.indentLevel++;
            honglangui(material);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        _zhenping = Foldout(_zhenping, "Screen Shake");

        if (_zhenping)
        {
            EditorGUI.indentLevel++;
            zhenpinggui(material);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        _Black = Foldout(_Black, "Vignette");

        if (_Black)
        {
            EditorGUI.indentLevel++;
            Black(material);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        _Texx = Foldout(_Texx, "Texture");

        if (_Texx)
        {
            EditorGUI.indentLevel++;
            Textures(material);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        _Logox = Foldout(_Logox, "Logo");

        if (_Logox)
        {
            EditorGUI.indentLevel++;
            Logogui(material);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        _Base = Foldout(_Base, "Post Comprehensive Settings");

        if (_Base)
        {
            EditorGUI.indentLevel++;
            Base(material);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        _Thanks = Foldout(_Thanks, "Illustration / Notes");

        if (_Thanks)
        {
            EditorGUI.indentLevel++;
            Thanks(material);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();
    }


    void UVDistort(Material material)
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        m_MaterialEditor.ShaderProperty(centerU, "Center U");
        m_MaterialEditor.ShaderProperty(centerV, "Center V");
        EditorGUILayout.EndVertical();

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Controls the center point of the radial blur and UV distortion.", style);
            EditorGUILayout.EndVertical();
        }

        GUILayout.Space(5);

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PrefixLabel("Radial Blur Strength K-Frame");
        if (material.GetFloat("_IfBlurFactor") == 0)
        {
            if (GUILayout.Button("Off", shortButtonStyle))
            {
                material.SetFloat("_IfBlurFactor", 1);
            }
        }
        else
        {
            if (GUILayout.Button("On", shortButtonStyle))
            {
                material.SetFloat("_IfBlurFactor", 0);
            }
        }

        EditorGUILayout.EndHorizontal();

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Enable this if you want Blur Factor controlled by keyframes or script. When enabled, the slider below is ignored.", style);
            EditorGUILayout.EndVertical();
        }

        if (material.GetFloat("_IfBlurFactor") == 0)
        {
            m_MaterialEditor.ShaderProperty(BlurFactor, "Radial Blur Strength");
        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PrefixLabel("UV Distortion Strength K-Frame");
        if (material.GetFloat("_IfLineUVScale") == 0)
        {
            if (GUILayout.Button("Off", shortButtonStyle))
            {
                material.SetFloat("_IfLineUVScale", 1);
            }
        }
        else
        {
            if (GUILayout.Button("On", shortButtonStyle))
            {
                material.SetFloat("_IfLineUVScale", 0);
            }
        }

        EditorGUILayout.EndHorizontal();

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Enable this if you want Line UV Scale controlled by keyframes or script. When enabled, the slider below is ignored.", style);
            EditorGUILayout.EndVertical();
        }

        if (material.GetFloat("_IfLineUVScale") == 0)
        {
            m_MaterialEditor.ShaderProperty(LineUVScale, "UV Distortion Strength");

            if (_tips == true)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                style.fontSize = 10;
                style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                GUILayout.Label("* Controls the strength of the UV distortion lines.", style);
                EditorGUILayout.EndVertical();
            }
        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        m_MaterialEditor.ShaderProperty(LineTilingU, "Line Vertical Tiling");
        m_MaterialEditor.ShaderProperty(LineTilingV, "Line Horizontal Tiling");

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Controls the density of the distortion line pattern.", style);
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);

        m_MaterialEditor.ShaderProperty(LineOffset, "Line Offset");

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Offsets the line pattern. Useful for choosing a better-looking line state.", style);
            EditorGUILayout.EndVertical();
        }

        GUILayout.Space(5);
    }


    void honglangui(Material material)
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PrefixLabel("Chromatic Strength K-Frame");
        if (material.GetFloat("_IfRedBlueFactor") == 0)
        {
            if (GUILayout.Button("Off", shortButtonStyle))
            {
                material.SetFloat("_IfRedBlueFactor", 1);
            }
        }
        else
        {
            if (GUILayout.Button("On", shortButtonStyle))
            {
                material.SetFloat("_IfRedBlueFactor", 0);
            }
        }

        EditorGUILayout.EndHorizontal();

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Enable this if you want Chromatic Strength controlled by keyframes or script. When enabled, the slider below is ignored.", style);
            EditorGUILayout.EndVertical();
        }

        if (material.GetFloat("_IfRedBlueFactor") == 0)
        {
            m_MaterialEditor.ShaderProperty(RedBlueFactor, "Chromatic Strength");

            if (_tips == true)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                style.fontSize = 10;
                style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                GUILayout.Label("* Controls the amount of red/blue color channel offset.", style);
                EditorGUILayout.EndVertical();
            }
        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);
    }


    void zhenpinggui(Material material)
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PrefixLabel("Frequency K-Frame");
        if (material.GetFloat("_Ifzhenpin") == 0)
        {
            if (GUILayout.Button("Off", shortButtonStyle))
            {
                material.SetFloat("_Ifzhenpin", 1);
            }
        }
        else
        {
            if (GUILayout.Button("On", shortButtonStyle))
            {
                material.SetFloat("_Ifzhenpin", 0);
            }
        }

        EditorGUILayout.EndHorizontal();

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Enable this if you want shake frequency controlled by keyframes or script. When enabled, the slider below is ignored.", style);
            EditorGUILayout.EndVertical();
        }

        if (material.GetFloat("_Ifzhenpin") == 0)
        {
            m_MaterialEditor.ShaderProperty(zhenpin, "Frequency");

            if (_tips == true)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                style.fontSize = 10;
                style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                GUILayout.Label("* Controls screen shake frequency. Higher value means faster shake.", style);
                EditorGUILayout.EndVertical();
            }
        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PrefixLabel("Amplitude K-Frame");
        if (material.GetFloat("_Ifzhenfu") == 0)
        {
            if (GUILayout.Button("Off", shortButtonStyle))
            {
                material.SetFloat("_Ifzhenfu", 1);
            }
        }
        else
        {
            if (GUILayout.Button("On", shortButtonStyle))
            {
                material.SetFloat("_Ifzhenfu", 0);
            }
        }

        EditorGUILayout.EndHorizontal();

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Enable this if you want shake amplitude controlled by keyframes or script. When enabled, the slider below is ignored.", style);
            EditorGUILayout.EndVertical();
        }

        if (material.GetFloat("_Ifzhenfu") == 0)
        {
            m_MaterialEditor.ShaderProperty(zhenfu, "Amplitude");

            if (_tips == true)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                style.fontSize = 10;
                style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                GUILayout.Label("* Controls screen shake amplitude. Higher value means stronger shake.", style);
                EditorGUILayout.EndVertical();
            }
        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);
    }


    void Black(Material material)
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PrefixLabel("Vignette Power K-Frame");
        if (material.GetFloat("_IfVignettePower") == 0)
        {
            if (GUILayout.Button("Off", shortButtonStyle))
            {
                material.SetFloat("_IfVignettePower", 1);
            }
        }
        else
        {
            if (GUILayout.Button("On", shortButtonStyle))
            {
                material.SetFloat("_IfVignettePower", 0);
            }
        }

        EditorGUILayout.EndHorizontal();

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Enable this if you want Vignette Power controlled by keyframes or script. When enabled, the slider below is ignored.", style);
            EditorGUILayout.EndVertical();
        }

        if (material.GetFloat("_IfVignettePower") == 0)
        {
            m_MaterialEditor.ShaderProperty(VignettePower, "Vignette Power");
        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PrefixLabel("Vignette Strength K-Frame");
        if (material.GetFloat("_IfVignetteScale") == 0)
        {
            if (GUILayout.Button("Off", shortButtonStyle))
            {
                material.SetFloat("_IfVignetteScale", 1);
            }
        }
        else
        {
            if (GUILayout.Button("On", shortButtonStyle))
            {
                material.SetFloat("_IfVignetteScale", 0);
            }
        }

        EditorGUILayout.EndHorizontal();

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Enable this if you want Vignette Strength controlled by keyframes or script. When enabled, the slider below is ignored.", style);
            EditorGUILayout.EndVertical();
        }

        if (material.GetFloat("_IfVignetteScale") == 0)
        {
            m_MaterialEditor.ShaderProperty(VignetteScale, "Vignette Strength");
        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);
    }


    void Textures(Material material)
    {
        m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Texture"), Tex);

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Adds an extra texture overlay to the screen.", style);
            EditorGUILayout.EndVertical();
        }

        if (Tex.textureValue != null)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _Texxx = Foldouts(_Texxx, "Texture Settings");

            if (_Texxx)
            {
                EditorGUI.indentLevel++;

                m_MaterialEditor.ShaderProperty(TexAR, "Use R Channel");

                if (_tips == true)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    style.fontSize = 10;
                    style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                    GUILayout.Label("* When enabled, the R channel is used as the mask. When disabled, the A channel is used as the mask.", style);
                    EditorGUILayout.EndVertical();
                }

                m_MaterialEditor.ShaderProperty(TexRotator, "Texture Rotation");

                if (_tips == true)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    style.fontSize = 10;
                    style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                    GUILayout.Label("* Rotates the overlay texture.", style);
                    EditorGUILayout.EndVertical();
                }

                EditorGUI.indentLevel--;
            }

            EditorGUILayout.EndVertical();

            if (_tips == true)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                style.fontSize = 10;
                style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                GUILayout.Label("* Expand this section to customize texture settings such as channel selection and rotation.", style);
                EditorGUILayout.EndVertical();
            }

            m_MaterialEditor.TextureScaleOffsetProperty(Tex);

            GUILayout.Space(5);

            m_MaterialEditor.ShaderProperty(TexAlpha, "Texture Alpha");

            GUILayout.Space(5);
        }

        if (Tex.textureValue == null)
        {
            material.SetFloat("_TexAlpha", 0);
        }
    }


    void Logogui(Material material)
    {
        m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Logo Texture"), Logo);

        if (Logo.textureValue != null)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _Logoxx = Foldouts(_Logoxx, "Logo Settings");

            if (_Logoxx)
            {
                EditorGUI.indentLevel++;

                m_MaterialEditor.ShaderProperty(LogoAR, "Use R Channel");

                if (_tips == true)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    style.fontSize = 10;
                    style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                    GUILayout.Label("* When enabled, the R channel is used as the transparency channel. When disabled, the A channel is used.", style);
                    EditorGUILayout.EndVertical();
                }

                EditorGUI.indentLevel--;
            }

            EditorGUILayout.EndVertical();

            if (_tips == true)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                style.fontSize = 10;
                style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
                GUILayout.Label("* Expand this section to customize logo texture settings.", style);
                EditorGUILayout.EndVertical();
            }

            m_MaterialEditor.TextureScaleOffsetProperty(Logo);

            GUILayout.Space(5);

            m_MaterialEditor.ShaderProperty(LogoAlpha, "Logo Alpha");

            GUILayout.Space(5);
        }

        if (Logo.textureValue == null)
        {
            material.SetFloat("_LogoAlpha", 0);
        }
    }


    void Base(Material material)
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PrefixLabel("Beginner Explanation Mode");

        if (_tips == false)
        {
            if (GUILayout.Button("Off", shortButtonStyle))
            {
                _tips = true;
            }
        }
        else
        {
            if (GUILayout.Button("On", shortButtonStyle))
            {
                _tips = false;
            }
        }

        EditorGUILayout.EndHorizontal();

        if (_tips == true)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            style.fontSize = 10;
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
            GUILayout.Label("* Shows detailed explanations for each parameter. Useful when first learning this material.", style);
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);
    }


    void Thanks(Material material)
    {
        style.fontSize = 12;
        style.normal.textColor = new Color(0.5f, 0.5f, 0.5f);
        style.wordWrap = true;

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);

        GUILayout.Label("MainAlpha controls the overall effect opacity.", style);
        GUILayout.Space(5);

        GUILayout.Label("BlurFactor controls radial blur strength.", style);
        GUILayout.Space(5);

        GUILayout.Label("LineUVScale controls UV distortion strength.", style);
        GUILayout.Space(5);

        GUILayout.Label("Chromatic controls chromatic aberration strength.", style);
        GUILayout.Space(5);

        GUILayout.Label("Frequency controls screen shake frequency.", style);
        GUILayout.Space(5);

        GUILayout.Label("Amplitude controls screen shake amplitude.", style);
        GUILayout.Space(5);

        GUILayout.Label("VignettePower controls vignette falloff.", style);
        GUILayout.Space(5);

        GUILayout.Label("VignetteScale controls vignette strength.", style);
        GUILayout.Space(5);

        EditorGUILayout.EndVertical();

        GUILayout.Label("PandaPost custom inspector. Text labels have been cleaned up for readability.", style);

        GUILayout.Space(5);
    }
}