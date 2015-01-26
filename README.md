# Blind
GI Jam Winter 2015

An RPG in which the player character is not as omniscient as the average hero.

## [Team Froshbite, GI Jam Winter 2015 Edition](https://github.com/orgs/FroshBite/teams/gi-jam-winter-2015)

* [**Yaron Koller**](https://github.com/yaronkoller), Overworld Programmer
* [**Shan Phylim**](https://github.com/shanpls), Programmer, Lead Artist
* [**Kevin Xing**](http://github.com/ggkevinxing), Programmer, Lead Designer

## KNOWN ISSUES / TO-DO LIST

**Combat**

* **[IMPORTANT]** Skill system implementation, also actively filling skill description box with text on button hover
* **[IMPORTANT]** In tandem with skill system, overhaul how objects call audio files as the present solution will be really messy when more than two sounds are needed
* Bring back enemy red flash on hit (target child gameObject as the empty enemy gameObject does not have a renderer)
* Add camera shake on player getting hit (Perlin Noise????)
* Level up system implementation
* Balancing of currently-arbitrary stat numbers 

**Overworld**

* **[IMPORTANT]** Fix overworld room generation
* **[IMPORTANT]** Remember overworld state when changing between combat and overworld scenes, so that on combat end the overworld doesn't just completely reset 
