using System;
using UnityEngine;
using UnityEngine.Rendering;

public class UICameraSplite : MonoBehaviour
{
    private Camera _camera;

    public RenderTexture rt;
    
    public RenderTexture rt2;
    public RenderTexture rt3;
    public RenderTexture rt4;
    public RenderTexture rt5;

    public Material mt;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        
        CommandBuffer buf = null;
        buf = new CommandBuffer();
        
        RenderTargetIdentifier id = new RenderTargetIdentifier(rt);
        
        buf.Blit(BuiltinRenderTextureType.CurrentActive, id);
        
        RenderTexture[]          rts   = new[] {rt2, rt3, rt4, rt5};
        RenderTargetIdentifier[] mrtID = new RenderTargetIdentifier[rts.Length];
       
        mrtID[0] = new RenderTargetIdentifier(rts[0]);
        buf.SetGlobalVector("offsetUV", new Vector4(0, 0.5f, 0, 0));
        buf.Blit(id, mrtID[0], mt);
        
        mrtID[1] = new RenderTargetIdentifier(rts[1]);
        buf.SetGlobalVector("offsetUV", new Vector4(0, 0, 0, 0));
        buf.Blit(id, mrtID[1], mt);
        
        mrtID[2] = new RenderTargetIdentifier(rts[2]);
        buf.SetGlobalVector("offsetUV", new Vector4(0.5f, 0f, 0, 0));
        buf.Blit(id, mrtID[2], mt);
        
        mrtID[3] = new RenderTargetIdentifier(rts[3]);
        buf.SetGlobalVector("offsetUV", new Vector4(0.5f, 0.5f, 0, 0));
        buf.Blit(id, mrtID[3], mt);
        

        _camera.AddCommandBuffer(CameraEvent.AfterHaloAndLensFlares, buf);
    }
}
