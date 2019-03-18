Shader is based on standard shader from built-in shaders in Unity.

Example scene contains "CyberSoldier" which is not my asset (I do not own it)
It can be found at Unity Asset Store (created by Will Morillas)

* You can put whatever texture you want for shader BUT remember to put sprite Wrap Mode to Repeat Mode!

If your project has StandardShaderGUI (from built-in shaders) already, please replace it with mine version of it.


All properties can be changed from material inspector. Shader can be found by name "Geometry Fragmentation".
There is whole section "Fragmentation Options" with all properties. Short description of every parameter:
Fragmentation scale - Used to animate fragmentation
Multiplier - controls how far fragments move, it should be set depending on size and scale of model
DirectionsMap - texture defining directions, you can use any texture (remember about * )
Overtension - mode that makes triangle to stretch out
Dezintegration - mode that makes triangle to disappear 
Disturbances - mode that changes direction vectors by time (need to be in PlayMode for normal use)