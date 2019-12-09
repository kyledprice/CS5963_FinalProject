DuckHunt+ -> Final Project for CS5960 (VR)
Created by Kyle Price and Derek Dixon

The Unity project, along with corresponding source-code, can 
be found in the DuckHunt+ folder. An Windows executable can be 
found at the root directory of the repo. 

Promised items:

Static position throughout the game 
- Full support 
- There is no script allowing the player to navigate out of the persona bounding box. 

Game takes place in the middle of a meadow-marsh 
- Full support
- The map was built to look like a meadow-marsh centered in a valley. 

Ducks flying at different angles in and out of FOV 
- Full support
- DuckSpawn.cs contains a snippet of code dictating random flight vectors throughout 
  the game.

Ducks can be shot down and fly behind player 
- Full support 
- DuckSpawn.cs contains a snippet of code dictating random flight vectors throughout 
  the game. In Duck.cs, if the object encounters a collision with a projectile, regardless 
  of where it is located in the game, it will respond accordingly.

Aggressive creatures (originally bears) will approach player and deal damage 
- Full support
- The creatures we used do approach the player from random positions and deal  
  damage. However, we elected to use wolves primarily because we found better rigged 
  wolf models. In our eyes, the effect is the same, and the superior animations made it 
  worth it. 

Gopher tunneling at the player 
- No support
- While trying to implement the effect that an approaching gopher would have on the 
  terrain, all of the feasible solutions I could find were exhibiting heavy z-fighting. 
  We did not consider this as a potential issue when devising the feature. We decided 
  that it was more important to maintain immersion than include it as a feature.

Cottage, water tower assets in game 
- No support
- We deemed adding further assets unnecessary as we felt confident with overall gameworld.

Blocky/Pixelated art direction. 
- No support
- We changed art direction due to availability of art assets on the Unity store.

Watch on player wrist to convey information 
- Partial support
- We implemented a clipboard instead due to asset availability on the Unity store.

Aggressive animals make sounds when spawned, sound is relative to location 
- Full support
- WolfSpawn.cs plays a world fixed howling noise when it spawns each wolf. The sound
  is played relative to the wolf’s position to hopefully provide positional info to the 
  player.

Player fixed sound for atmospheric sounds (outdoor sounds) 
- Full support
- A player fixed audio track is looped through that provides natural ambient noises like:
  birds chirping, water moving, ducks quacking, and wind. This audio track is attached to 
  The “EmptySound” object and the “play on awake” option is selected.  

Two handed shotgun 
- Partial support 
- A one handed zapper was used instead since it stayed closer to the source material 	
  and since the left hand of the player is holding a clipboard, a two handed weapon was 
  impractical.

Mapping dominant hand based on which controller is first turned on. 
- No support
- Mapping control bindings between Unity and ValveVR 2.0 became challenging when attaching 
  hand type objects and actions to listeners. Due to this, having dynamic dominant hand 
  mapping became overly time consuming.

Weapon reloading 
- No support 
- After we decided to use the zapper model, we felt that having the ability to reload was 
  too much of a departure from the source material. 

Several types of weapons
- No support
- We proposed the option of having additional weapons if time permitted, as we spent longer 
  than expected developing the fundamentals of the game, ultimately we decided against this.

Laser sites for aiming 
- No support 
- Thanks to the modeling of the zapper, we found after testing, that iron sights were 
  acceptable in producing consistent shot placement.

Endless survival gameplay 
- Full support
- The player will continue to accrue points until their health is fully depleted, at which 
  point the game resets.

Points awarded for shooting ducks and aggressive animals. 
- Full support
- GameState.cs contains all of the state the dictates health and score.

Option to enter initials at the end on the scoreboard 
- No support
- After spending an unanticipated amount of time developing the core of the game, we considered 
  this feature as polish and deemed it better to further refine the core gameplay. 

Trees block shots 
- No support
- We found that placing the player in a wide open area was best for immersion and due to 
  this, there was no need for the wolves to path throughout the trees, hence this feature was 
  unnecessary.

Zapper shooting dynamics
- Full support
- The gun object, which is a child of the right hand under the player prefab has a script 
  attached called Launcher.cs.




