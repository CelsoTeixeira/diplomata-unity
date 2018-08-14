using System;
using UnityEngine;
using System.Collections.Generic;

namespace Diplomata.Models
{
  [Serializable]
  public class Effect
  {
    public Type type;
    public EndOfContext endOfContext;
    public GoTo goTo;
    public AnimatorAttributeSetter animatorAttributeSetter = new AnimatorAttributeSetter();
    public Flag customFlag;
    public int itemId;

    [NonSerialized]
    public Events onStart = new Events();

    [NonSerialized]
    public Events onComplete = new Events();

    public enum Type
    {
      None,
      EndOfContext,
      GoTo,
      SetAnimatorAttribute,
      GetItem,
      DiscardItem,
      SetCustomFlag,
      EquipItem
    }

    [Serializable]
    public struct GoTo
    {
      public string uniqueId;

      public GoTo(string uniqueId)
      {
        this.uniqueId = uniqueId;
      }

      public Message GetMessage(Context context)
      {
        foreach (Column col in context.columns)
        {
          if (Message.Find(col.messages, uniqueId) != null)
          {
            return Message.Find(col.messages, uniqueId);
          }
        }

        return null;
      }
    }

    [Serializable]
    public struct EndOfContext
    {
      public string talkableName;
      public int contextId;

      public EndOfContext(string talkableName, int contextId)
      {
        this.talkableName = talkableName;
        this.contextId = contextId;
      }

      public void Set(string talkableName, int contextId)
      {
        this.talkableName = talkableName;
        this.contextId = contextId;
      }

      public Context GetContext(List<Character> characters)
      {
        return Context.Find(Character.Find(characters, talkableName), contextId);
      }

      public Context GetContext(List<Interactable> interactables)
      {
        return Context.Find(Interactable.Find(interactables, talkableName), contextId);
      }
    }

    public Effect() {}

    public Effect(string talkableName)
    {
      endOfContext.talkableName = talkableName;
    }

    public string DisplayNone()
    {
      return "None";
    }

    public string DisplayEndOfContext(string contextName)
    {
      return "End of the context \"" + contextName + "\"";
    }

    public string DisplayGoTo(string messageTitle)
    {
      return "Go to \"" + messageTitle + "\"";
    }

    public string DisplaySetAnimatorAttribute()
    {
      if (animatorAttributeSetter != null)
      {
        switch (animatorAttributeSetter.type)
        {
          case AnimatorControllerParameterType.Bool:
            return "Set animator attribute " + animatorAttributeSetter.name + " to " + animatorAttributeSetter.setBool;

          case AnimatorControllerParameterType.Float:
            return "Set animator attribute " + animatorAttributeSetter.name + " to " + animatorAttributeSetter.setFloat;

          case AnimatorControllerParameterType.Int:
            return "Set animator attribute " + animatorAttributeSetter.name + " to " + animatorAttributeSetter.setInt;

          case AnimatorControllerParameterType.Trigger:
            return "Pull the trigger " + animatorAttributeSetter.name + " of animator";

          default:
            return "Animator attribute setter type not found.";
        }
      }

      else
      {
        return "Animator attribute setter not found.";
      }
    }

    public string DisplayGetItem(string itemName)
    {
      return "Get the item: \"" + itemName + "\"";
    }

    public string DisplayDiscardItem(string itemName)
    {
      return "Discard the item: \"" + itemName + "\"";
    }

    public string DisplayEquipItem(string itemName)
    {
      return "Equip the item: \"" + itemName + "\"";
    }

    public string DisplayCustomFlagEqualTo()
    {
      return "\"" + customFlag.name + "\" set to " + customFlag.value;
    }
  }
}
