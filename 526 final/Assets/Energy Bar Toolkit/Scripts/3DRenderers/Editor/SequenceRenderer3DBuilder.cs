/*
* Energy Bar Toolkit by Mad Pixel Machine
* http://www.madpixelmachine.com
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace EnergyBarToolkit {

public class SequenceRenderer3DBuilder {

    // ===========================================================
    // Static Methods
    // ===========================================================

    public static SequenceRenderer3D Create() {
        var panel = MadPanel.UniqueOrNull();

        if (panel == null) {
            var panels = MadPanel.All();
            if (panels.Length == 0) {
                if (EditorUtility.DisplayDialog(
                "Init Scene?",
                "Scene not initialized for 3D bars. You cannot place new bar without proper initialization. Do it now?",
                "Yes", "No")) {
                    MadInitTool.ShowWindow();
                }
            } else {
                CreateMeshBarTool.ShowWindow(EnergyBar3DBase.BarType.Sequence);
            }

            return null;
        } else {
            return Create(panel);
        }
    }
    
    public static SequenceRenderer3D Create(MadPanel panel) {
        var bar = MadTransform.CreateChild<SequenceRenderer3D>(panel.transform, "sequence progress bar");
        TryApplyExampleTextures(bar);
        Selection.activeObject = bar.gameObject;
        
        return bar;
    }
    
    static void TryApplyExampleTextures(SequenceRenderer3D bar) {
        var gridTexture = AssetDatabase.LoadAssetAtPath(
            AssetDatabase.GUIDToAssetPath("92439f7267aa24d4ba8eb0bedaf261db"), typeof(Texture2D)) as Texture2D;
        
        if (gridTexture != null) {
            bar.gridTexture = gridTexture;
            bar.gridWidth = 7;
            bar.gridHeight = 9;
            bar.gridFrameCountManual = true;
            bar.gridFrameCount = 59;
        } else {
            Debug.LogWarning("Failed to locate example textures. This is not something bad, but have you changed "
                             + "your Energy Bar Toolkit directory location?");
        }
    }
    
    // ===========================================================
    // Inner and Anonymous Classes
    // ===========================================================

}

} // namespace