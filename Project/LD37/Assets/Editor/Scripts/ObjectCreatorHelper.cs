﻿using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Scripts
{
    public class ObjectCreatorHelper
    {
        public static ScriptableObject CreateAsset(Type type)
        {
            var asset = ScriptableObject.CreateInstance(type);
            ProjectWindowUtil.CreateAsset(asset, string.Format("{0}.asset", type.Name));
            return asset;
        }
    }
}
