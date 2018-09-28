using System;
using LavaLeak.Diplomata.Editor.Components;
using LavaLeak.Diplomata.Editor.Data;
using LavaLeak.Diplomata.Editor.Enums;
using LavaLeak.Diplomata.Editor.Helpers;
using UnityEditor;
using UnityEngine;

namespace LavaLeak.Diplomata.Editor.Windows
{
  public class DiplomataEditorWindow : EditorWindow
  {
    // The window data.
    public DiplomataEditorData Data;

    // The window state.
    public WindowStates State;

    // Window areas.
    public WindowArea Top;
    public WindowArea SideBar;
    public WindowArea MainContent;
    public WindowArea Bottom;

    [MenuItem("Tools/Diplomata/Editor")]
    static public void Init()
    {
      DiplomataEditorWindow window = (DiplomataEditorWindow) GetWindow(typeof(DiplomataEditorWindow), false, "Diplomata");
      window.minSize = new Vector2(1100.0f, 300.0f);
      window.Show();
    }

    private void OnEnable()
    {
      Data.Init();

      // TODO: Set the actions from the state.

      Top.Color = ColorHelper.ColorAdd(ColorHelper.ResetColor(), new Color(0.5f, 0.5f, 0.5f));
      Top.Size = new Vector2(100, 100);

      Top.DrawStack += delegate
      {
        EditorGUILayout.LabelField("Teste 1");
      };

      SideBar.Color = new Color(0.5f, 0.5f, 0.5f);
      SideBar.Size = new Vector2(200, 100);

      SideBar.DrawStack += delegate
      {
        EditorGUILayout.LabelField("Teste 2");
      };
    }

    private void OnGUI()
    {
      GUIHelper.Init();

      Top.Draw();
      EditorGUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
      SideBar.Draw();
      MainContent.Draw();
      EditorGUILayout.EndHorizontal();
      Bottom.Draw();
    }
  }
}
