using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class EditorModeTestScript
{
    [Test]
    public void TestQuitLevelButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;

    }

}
