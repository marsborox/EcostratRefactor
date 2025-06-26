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
When closing event window - for some reason Hide was triggered twice, causing bug - fixed
Fixed text for add display time

GameManager 

Events
we created EventHandler that will Invoke events and other stuff will subscribe to them,
	its kinda working but broken, must fix why illegality coutns weird, trash substract twice time, illegality adds every second - prob smthing with counting

	-Separate Timer/TimeControl - , moved all time relateed variables to TimeController
	

	-Update	- News relocated into news class, methods that add time to counter if treshold full do method - 
	we are using the generic one and it will invoke events, NEXT TIME SUBSCRIBE 
		
		
	- Spawner - UI display of spawned text Methods used to Spawner class 
		- Moved stuff to spawner class which should be there, shortened GetPointOnTerrain method
		- 
	
top buttons - 	 made into toggle group, made own class for SpeedButtons,-must redo this 
		 assigned per interface w implemented InitiateButton method

Singleton 	- we have Singleton<T> class and SingletonPresistent<T> class (second inherits from first)
		- implemented on MySceneManager(Perma), 
		- SoundManager(Perma), RadioSoundManager,  TimeController, 
		- (UI) News, UpgradesDescriptionPanel, UpgradesWindow, EventWindow, GameManager, 
		- Some Singletons are now prefabs

Interfaces	- we have Interface for button initiation - does not have to be motherClass
		- its our standard InitiateButton, with playSound bonus

To Do:

GameManager 	- Update must be divided - noto nly update
		
		- Separate UI
		- Separate Sound
		- Update - to dissolve Update need Events, on their trigger all sorts of things will happen - subscribbed 
			make GetTimestamp Interface, move timerDisplay to Timer class 
			 - Update and ChangeStats must be separated into methods doing only one resource/playerStat

			- enum PlayerStat - rework this, probably instances of PlayerStat inheriting classes playerGameObject?
		illegality and followerIncome is the same
		- we can use one method for all slider display - can go to UI

Playerstats broken 

lets move Time counting into time prob.+

notes for PlayerStats
Moving TImerSpawner - Donation Income, FOllowerIncome, Illegality,trashTimer,TrashIncrement,




can we do something with performance - instantiation mabye spawning (not pixel but coords/ object		

Tutorial - put those windows in que instead, all buttons will subscribe to open
buttons need fixing all of them


mute music option-mabye even ingame button

UI does not refresh immediately - because time is postponed, 

mabye UI class and rest will inherit from it

mabye
???
change PlayClip methods (playOneShot) to LINQ

- mabye try to remove the static new .... instance from singleton statement

*************** troubleshooting
Singletons:	- temporary add Scene Manager to game scene gameObject!, 
		- sound manager move to mainGameMenu, make temporary gameObject in game
		