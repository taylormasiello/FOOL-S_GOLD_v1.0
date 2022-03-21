using UnityEngine;
using UnityEngine.Rendering;

public class ActiveRenderPipeline : MonoBehaviour
{
    [SerializeField] RenderPipelineAsset maskPipelineAsset;
    [SerializeField] RenderPipelineAsset noMaskPipelineAsset;
    [SerializeField] GameCursor gameCursorScript;

    void Start()
    {
        GraphicsSettings.defaultRenderPipeline = noMaskPipelineAsset;
    }


    void LateUpdate()
    {
        if (gameCursorScript.isPickaxe)
        {
            ToggleMaskPipeline();
        } else if (!gameCursorScript.isPickaxe)
        {
            ToggleNoMaskPipeline();
        }
    }

    void ToggleMaskPipeline()
    {
        if (GraphicsSettings.defaultRenderPipeline != maskPipelineAsset)
        {
            GraphicsSettings.defaultRenderPipeline = maskPipelineAsset;
        }
    }

    void ToggleNoMaskPipeline()
    {
        if (GraphicsSettings.defaultRenderPipeline != noMaskPipelineAsset)
        {
            GraphicsSettings.defaultRenderPipeline = noMaskPipelineAsset;
        }
    }
}
