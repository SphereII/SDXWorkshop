Revised version of ArchetypeTextureCache.cs

- Cleaned up UMA saving / loading logic for files, closing files as needed.
- Reduced the necessary RenderTexture, re-using a single variable to reduce the calls to new Texture2D()
- Optimized code a bit, using loops and helper methods.
- Changed HasTextureCache to always return false
	-> This was done since the default size of the atlas was 4096, which was generating textures of about 30 megs per UMA. For ravenhearst, this produced 1.5G of additional content.
	-> Most users have to turn down textures, so this was adjusted to return false, adjusting the generation of the textures to users' settings on first generation

Initial Loading of UMAs for Ravenhearst mod was showing a commit of 21 G.
After saving textures, loading was reduced to 7 G .
Further adjustments in this class reduced the inital loading down to 7 G.

Spawning in 75 UMA zombies dropped framerate from 60 fps to 30 fps, but memory usage was maintained.
Spawning in 75 baked zombies dropped framerate from 60 fps to 45 fps, but memory usage was maintained.