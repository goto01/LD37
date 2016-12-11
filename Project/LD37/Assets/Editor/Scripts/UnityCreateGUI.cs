using Assets.Scripts.OWCCursorRenderer;
using UnityEditor;

namespace Assets.Editor.Scripts
{
    public class UnityCreateGui {
        [MenuItem("Assets/Create/OWCCursor")]
        private static void CreateOWCCursor()
        {
            ObjectCreatorHelper.CreateAsset(typeof(OWCCursor));
        }
    }
}
