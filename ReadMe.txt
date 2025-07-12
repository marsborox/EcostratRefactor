Unity ver 6000.1.0a7
Itch:			ttps://ecostrat.itch.io/ecostrat
Original codebase:	https://github.com/marsborox/EcostratOriginal/

Done:

Added Text explaining "Press Esc to skip intro"
Renamed Camera Canvas to UI Canvas (makes more sense)
Fixed timer on ui (was running even when game paused)
Trash increment amount - was being increased same rate disregard the game speed - fixed
When closing event window - for some reason Hide was triggered twice, causing bug - fixed
Fixed text for add display time

Donation prefab redone so it spawns class not Button, moved whole donation / get  money from pop up


MainMenu 	- Somewhat fixed main menu (buttons not displayed, background is disabled tho)
		- MainMenu_UI class, subscribing methods to events triggered by buttons //***** mabye own category??



Events
we created EventHandler that will Invoke events and other stuff will subscribe to them,
	Events work fine w subscribed methods; Events for methods run from SOs created

SOs	- all / msot of pop ups (events, bubbles, upgrades) are done by using SOs AChangeStats,
these SOs have enum PlayerStats and value, was run over giant switch statement in GameManager
	
	we keep that logic but in AChangeStats is switch statement - based on enum Run method in MyEventManager, 
	and subscribe methods in PlayerStatsNew


GameManager

	-MainTimer - Separate Timer/TimeControl - , moved all time relateed variables to TimeController
			- we added counting time to spawn event for stat value manipulation
			

	-Update	- News relocated into news class, methods that add time to counter if treshold full do method - 
	we are using the generic one and it will invoke events, Timer stuff moved to MainTimer, 
	UI to UI - Update is removed, moved lesserStats to player-vars and methods
	- 
		
		
	- Spawner - UI display of spawned text Methods used to Spawner class 
		- Moved stuff to spawner class which should be there, shortened GetPointOnTerrain method
		- 
	- UI - some work on left panel - spawning of that pop up text reworked
		- Moved sliders it is working
		- all sliders except days is done working
		- UP panel texts working 
		- Time related texts are moved

	
top buttons - 	 made into toggle group, made own class for SpeedButtons,-must redo this 
		 assigned per interface w implemented InitiateButton method

Player		- there is a Player object w Player and PlayerStatsNew classes, all methods and stats are moved here, time even
		update loop ais working fine,
Singleton 	- we have Singleton<T> class and SingletonPresistent<T> class (second inherits from first)
		- implemented on MySceneManager(Perma), 
		- SoundManager(Perma), RadioSoundManager,  TimeController, 
		- (UI) News, UpgradesDescriptionPanel, UpgradesWindow, EventWindow, GameManager, 
		- Some Singletons are now prefabs

Interfaces	- we have Interface for button initiation - does not have to be motherClass
		- its our standard InitiateButton, with playSound bonus

Player (player Stats new) Subscribbed to events in MyEventManager, is handling all stats / resources / trash....

SOs 	- there are scriptable obejcts with sets values, 9enum + number0 - used to work over switch statement
		in GameManager, now based on enum it triggers Event in MyEventManager



Notes: need to fix upgrade the thing that extends time

Upgrades: UI Upgrades

A ChangeStats(inherits from PlayerActions) is used in pretty much everywhere
switch - 

we have now adjusted per order in switches
Followers			ChangeFollowerAmmount	event ok
PopUp Income			PopUpIncome		event ok
*
Timer				ChangeDaysLeft in Timer	event created	neeed to do in time !!!!!!!!!!
Trash				ChangeTrashInput	created ok
Trash Increment			ChangeTrashIncrementInput	created	ok
Hint				ChangeHint		event created  ok
*
*
Price modifier			missing completely	event created
*
Illegal Capacity		??? was really used?
Illegality reduction interval	?? was really used?

Trash Cap			unused
Donation Intensity		unused

To Do:

NEXT: everything what is not stat manipulation defined by time must be adjusted to initiate events - progress here, finish SOs stuff
trashIncrement_Increment change method refers to 

FollowUp: fix texts on sliders, move pop up value to UI class, doTexts, remove all stats (trash money illegality, followers) from GameManager
(need to move all stats to newPlayerStats first), News show wrong days remaining
colors of some pop up texts do not match color
should take care of "inflation" price modifier

Problems : spawning of trash bubbles in begining of game
		

Game Events (Events) will need some work most probably a lot of work

Upgrades - needs rework, must fix dependencies

GameManager 	- Update must be divided - noto nly update
		
		- Separate UI
		- Separate Sound
		- Update - to dissolve Update need Events, on their trigger all sorts of things will happen - subscribbed 
			make GetTimestamp Interface,

			Events 		- migrate changeStats methods accordingly, rename controller

			 - Update and ChangeStats must be separated into methods doing only one resource/playerStat
			 - All time related from Update should go to explicitly timeClass

			- enum PlayerStat - rework this, probably instances of PlayerStat inheriting classes playerGameObject?
		illegality and followerIncome is the same
		- we can use one method for all slider display - can go to UI

UI		- Left Panel	- move spawning floating text here, need to think about how will we display all
		- Opportunity for DirtyFlag??
		- Bug with ilegality bar - when raised should be red when reduced green color
		

lets move Time counting into time prob.+

notes for PlayerStats
Moving TImerSpawner - Donation Income, FOllowerIncome, Illegality,trashTimer,TrashIncrement,

mabye
???

can we do something with performance - instantiation mabye spawning (not pixel but coords/ object		

Tutorial - put those windows in que instead, all buttons will subscribe to open
buttons need fixing all of them


mute music option-mabye even ingame button

UI does not refresh immediately - because time is postponed??, 

mabye UI class and rest will inherit from it


change PlayClip methods (playOneShot) to LINQ

- mabye try to remove the static new .... instance from singleton statement

*************** troubleshooting
Singletons:	- temporary add Scene Manager to game scene gameObject!, 
		- sound manager move to mainGameMenu, make temporary gameObject in game
		