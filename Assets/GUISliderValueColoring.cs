using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]
public class GUISliderValueColoring : MonoBehaviour
{
    private MeshRenderer renderer;

    private void Awake() => renderer = GetComponent<MeshRenderer>();
    
    private void OnGUI()
    {
        Color currentColor = renderer.material.color;
        GUILayout.BeginArea(new Rect(Screen.width / 2, Screen.height / 2, 100, 100));
        GUILayout.BeginHorizontal();
        
        Slider(ref currentColor.r);
        Slider(ref currentColor.g);
        Slider(ref currentColor.b);
        Slider(ref currentColor.a);
        
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        renderer.material.color = currentColor;
    }

    private void Slider(ref float value)
    {
        GUILayout.BeginVertical();
        value = GUILayout.HorizontalSlider(value, 0, 1);
        GUILayout.EndVertical();
    }
}
