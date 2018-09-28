using System.Collections.Generic;
using LavaLeak.Diplomata.Editor.Controllers;
using LavaLeak.Diplomata.Models;
using LavaLeak.Diplomata.Models.Collections;

namespace LavaLeak.Diplomata.Editor.Data
{
  public struct DiplomataEditorData
  {
    public Options Options;
    public List<Character> Characters;
    public List<Interactable> Interactables;
    public GlobalFlags GlobalFlags;
    public Inventory Inventory;
    public Quest[] Quests;

    public void Init()
    {
      Options = OptionsController.GetOptions();
      Characters = CharactersController.GetCharacters(Options);
      Interactables = InteractablesController.GetInteractables(Options);
      GlobalFlags = GlobalFlagsController.GetGlobalFlags(Options.jsonPrettyPrint);
      Inventory = InventoryController.GetInventory(Options.jsonPrettyPrint);
      Quests = QuestsController.GetQuests(Options.jsonPrettyPrint);
    }
  }
}
