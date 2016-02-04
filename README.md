Fader.cs
=========

This is a simple fader utility script for unity5 using uGUI.

How To Use
---------
Got Simplified!
1. Import UguiFader.unitypackage
That's it.
Now you can call fader like below.

```cs
Fader.instance.BlackIn();
// or...
Fader.instance.WhiteIn("MainGame");
Fader.instance.WhiteOut(2f, () => someGameObject.SetActive(true));
```

### Function List
```
    Fader.instance.BlackOut()
    Fader.instance.BlackIn()
    Fader.instance.WhiteOut()
    Fader.instance.WhiteIn()
    Fader.instance.BlackOutHalf()
    Fader.instance.Clear()
    Fader.instance.Fill()
```

###Overload List
As you can see in Fader.cs, there are 5 overloads to invoke fading function on each method.
* (float time = DefaultFadeTime)     : fade time(DefaultFadeTime is 1 sec.)
* (string sceneName)                 : load scene specified by string
* (System.Action action)             : callback
* (float time, string sceneName)     : specify fade time and load scene
* (float time, System.Action action) : specify fade time and callback

License
---------
The code is available under the MIT license.
