Unity ver 6000.1.0a7
Itch:	h		ttps://ecostrat.itch.io/ecostrat
Original codebase:	https://github.com/marsborox/EcostratOriginal/


Done:

MainMenu 	- Somewhat fixed main menu (buttons not displayed, background is disabled tho)
		- MainMenu_UI class, subscribing methods to events triggered by buttons //***** mabye own category??


Added Text explaining "Press Esc to skip intro"
Renamed Camera Canvas to UI Canvas (makes more sense)
Fixed timer on ui (was running even when game paused)
Trash increment amount - was being increased same rate disregard the game speed - fixed

GameManager 
	-Separate Timer/TimeControl - , moved all time relateed variables to TimeController
-Update-	 News relocated into news class, Update and ChangeStats must be separated into methods doing only one resource/playerStat
		enum PlayerStat - rework this, probably instances of PlayerStat inheriting classes playerGameObject?
		illegality and followerIncome is the same
		we can use one method for all slider display - can go to UI


	
top buttons - 	 made into toggle group, made own class for SpeedButtons,
		 assigned per interface w implemented InitiateButton method

Singleton 	- we have Singleton<T> class and SingletonPresistent<T> class (second inherits from first)
		-implemented on MySceneManager, rest waits for implementation	
		- SoundManager(Perma), RadioSoundManager,  TimeController, 
		- (UI) News, UpgradesDescriptionPanel, UpgradesWindow, EventWindow, 


To Do:

GameManager 	- Update must be divided - noto nly update
		- Update
		- Separate UI
		- Separate Sound
		- Separate Spawner

make Singleton Parent class implement to all singletons, make inheriting Singleton presistent and use that
create Singleton Classes - 2 presistent and only scene
Singletons:	- temporary add Scene Manager to game scene gameObject!, 
		- sound manager make presistent , move to mainGameMenu, make temporary gameObject in game
		- what needs to be converted to inherit from Singleton<T> class
		- 
		- GameManager, //temp
		
After Singleton MIgration for some reason after we clicked smthign in event window - it deactivated gameobjcet ,
which should be followed by unpausing the game, that didnt happen...

Tutorial - put those windows in que instead, all buttons will subscribe to open
buttons need fixing all of them


we have Interface for button initiation - does not have to be motherClass
its our standard InitiateButton, with playSound bonus

mabye UI class and rest will inherit from it

mabye
???
change PlayClip methods (playOneShot) to LINQ
