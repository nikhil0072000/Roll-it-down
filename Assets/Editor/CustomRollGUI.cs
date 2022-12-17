using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CustomRollGUI : ShaderGUI
{
    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        // base.OnGUI(materialEditor, properties);

        MaterialProperty fromColorProperty = FindProperty("_FromColor", properties);
        MaterialProperty toColorProperty = FindProperty("_ToColor", properties);
        MaterialProperty rollCenterPosXProperty = FindProperty("_RollCenterPosX", properties);
        MaterialProperty spinProperty = FindProperty("_Spin", properties);
        MaterialProperty bumpProperty = FindProperty("_Bump", properties);
        MaterialProperty amplitudeProperty = FindProperty("_Amplitude", properties);
        MaterialProperty frequencyProperty = FindProperty("_Frequency", properties);
        MaterialProperty xLengthProperty = FindProperty("_XLength", properties);
        MaterialProperty yLengthProperty = FindProperty("_YLength", properties);
        MaterialProperty smoothnessProperty = FindProperty("_Smoothness", properties);
        MaterialProperty metaliicProperty = FindProperty("_Metaliic", properties);
        MaterialProperty FromalbedoProperty = FindProperty("_Fromalbedo", properties);
        MaterialProperty ToalbedoProperty = FindProperty("_Toalbedo", properties);

        GUILayout.Label("Visual", EditorStyles.boldLabel);
        materialEditor.ColorProperty(fromColorProperty, fromColorProperty.displayName);
        materialEditor.ColorProperty(toColorProperty, toColorProperty.displayName);
        materialEditor.TextureProperty(FromalbedoProperty, FromalbedoProperty.displayName);
        materialEditor.TextureProperty(ToalbedoProperty, ToalbedoProperty.displayName);

        GUILayout.Label("Roll Setting", EditorStyles.boldLabel);
        DrawFloatProperty(materialEditor, rollCenterPosXProperty);
        DrawFloatProperty(materialEditor, spinProperty);
        materialEditor.ShaderProperty(bumpProperty, bumpProperty.displayName);

        GUILayout.Label("Curve Setting", EditorStyles.boldLabel);
        DrawFloatProperty(materialEditor, amplitudeProperty);
        DrawFloatProperty(materialEditor, frequencyProperty);

        GUILayout.Label("Scale Setting", EditorStyles.boldLabel);
        DrawFloatProperty(materialEditor, xLengthProperty);
        DrawFloatProperty(materialEditor, yLengthProperty);

        GUILayout.Label("Other Setting", EditorStyles.boldLabel);
        materialEditor.ShaderProperty(smoothnessProperty, smoothnessProperty.displayName);
        materialEditor.ShaderProperty(metaliicProperty, metaliicProperty.displayName);
    }

    static void DrawFloatProperty(MaterialEditor materialEditor, MaterialProperty materialProperty)
    {
        materialEditor.FloatProperty(materialProperty, materialProperty.displayName);
    }
}