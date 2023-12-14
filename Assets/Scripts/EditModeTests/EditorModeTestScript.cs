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
    [Test]
    public void Test_lives()
    {
       int health(3);
       Assert.AreEqual(expected: 3, actual: health);

    }

    [Test]
    public void Test_lives_damage_1()
    {
       int health(3);
        lives--;
       Assert.AreEqual(expected: 2, actual: health);

    }

    [Test]
    public void Test_lives_lowerthan0()
    {
       int health(0)
       Assert.AreEqual(expected: 0, actual: health);

    }

    
}
