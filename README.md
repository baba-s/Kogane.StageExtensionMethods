# Kogane Stage Extension Methods

Stage 型の拡張メソッド

## 使用例

```cs
using Kogane;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class Example
{
    public static void Hoge( Stage stage )
    {
        var transform  = stage.FindComponentOfType( typeof( Transform ) );
        var transforms = stage.FindComponentsOfType( typeof( Transform ) );
    }
}
```

```cs
using Kogane;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class Example
{
    public static void Hoge( Stage stage )
    {
        var stageHandle = stage.stageHandle;
        var isMainStage = stageHandle.IsMainStage();
        var customScene = stageHandle.CustomScene();
        var transform   = stageHandle.FindComponentOfType( typeof( Transform ) );
        var transforms  = stageHandle.FindComponentsOfType( typeof( Transform ) );
    }
}
```