using System;
using LavaLeak.Diplomata.Editor.Helpers;
using UnityEditor;
using UnityEngine;

namespace LavaLeak.Diplomata.Editor.Components
{
  public struct WindowArea
  {
    private GUIStyle style;
    public Texture2D BG;
    public Color Color;
    public Vector2 Size;
    public Action DrawStack;

    public void Draw(GUIStyle style = null)
    {
      if (this.style == null)
      {
        BG = GUIHelper.UniformColorTexture(1, 1, Color);
        this.style = new GUIStyle(style != null ? style : GUIHelper.windowStyle);
        this.style.normal.background = BG;
      }

      EditorGUILayout.BeginHorizontal(this.style, GUILayout.Height(Size.y), GUILayout.Width(Size.x));
      if (DrawStack != null)
        DrawStack();
      EditorGUILayout.EndHorizontal();
    }
  }
}
