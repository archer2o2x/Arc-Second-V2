using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTagListener : MonoBehaviour
{
    public BaseSystem ListenerSystem;

    public TMP_Text TextObject;

    public TextTag[] TextTags;

    private void Start()
    {
        ListenerSystem.OnTagCreate.AddListener(OnChangedTag);
        ListenerSystem.OnTagDestruction.AddListener(OnChangedTag);
    }

    public void OnChangedTag()
    {
        foreach (TextTag tag in TextTags)
        {
            if (!ListenerSystem.SystemHasTag(tag.TriggerTag)) continue;

            TextObject.text = tag.DisplayText;

            return;
        }
    }

    [System.Serializable]
    public class TextTag
    {
        public string DisplayText;
        public string TriggerTag;
    }


}
