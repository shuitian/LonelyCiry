using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 物品交易属性编辑器
/// </summary>
[CustomEditor(typeof(ItemTradeAttribute))]
public class ItemTradeAttributeEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ItemTradeAttribute itemTradeAttribute = (ItemTradeAttribute)target;
        EditorGUILayout.LabelField("Buying Price", itemTradeAttribute.buyingPrice.ToString());
    }
}
