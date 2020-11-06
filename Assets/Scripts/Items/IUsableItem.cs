using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsableItem
{
    UsableItemTemplate UsableTemplate { get; }
    void Use();
}
