Fader.cs
=========

This is a simple fader utility script for unity5 using uGUI.

How To Use
---------
1. Create Canvas, set Sort Order about 5000, and delete GraphicRaycaster component.
2. Create a new Image as a child of the canvas and set its RectTransform like this: Anchor minX 0, maxX 1, minY 0, maxY 1, left top right buttom 0.
3. Attach this fader script to the parent Canvas.
4. Now you can call fader from other script simply like this:

```cs
// no need SerializeField anymore
Fader.instance.BlackOut(Fader.DefaultFadeTime, "MainMenu");
// or...
Fader.instance.WhiteIn(2f, () => someGameObject.SetActive(true));
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

###what each argument means
1st arg specifies fade time by seconds. if you omit this argument, it will be `Fader.DefaultFadeTime`.

2nd arg is optional. 
###string
If you pass this argument as string, this script tries to switch to the scene specified by string.

###System.Action
If you pass this argument as function, it will be invoked on fading is finished.

License
---------
The code is available under the MIT license.
