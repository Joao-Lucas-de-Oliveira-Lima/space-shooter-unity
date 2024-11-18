# Space Shooter: Killiam3 Rebellion
This project was developed as a final assignment for the **Introduction to Game Development** course. The goal was to gain hands-on experience in game development using Unity, including working with its physics system, creating C# scripts, and integrating third-party assets to enhance the game's aesthetics and functionality.

## Prerequisites
- [Unity Editor 2022.2.10f1](https://unity.com/releases/editor/archive)

---

## Game Design Document (GDD)

### Authors
- Arlle Bruno Brasil Maciel  
- Adauto Lino Neto  
- João Lucas de Oliveira Lima  

### Introduction
*Killiam3 Rebellion* is a top-down space shooter where players take on the role of a space soldier aboard the spaceship **Killiam3**. Armed with a powerful arsenal, the player will face waves of alien invaders in various arenas. The ultimate goal is to protect their world and its inhabitants from annihilation.


### Story
In the year 2223, the player's world is under attack by strange alien creatures. Despite humanity's attempts to communicate, the invaders seek domination by exploiting natural resources and enslaving the population through genetic experiments.

As a member of the newly formed **Global Alliance** (name TBD), players join the resistance in a quest to stop the invasion. With the first generation of combat-ready spacecraft, their mission is to infiltrate the enemy fleet and destroy the mothership located in the [Sector TBD].

### Gameplay
#### First Level:

![Killiam3 fighting enemies and dodging meteors](/images/first_level.gif)
#### Last Level:

![Killiam3 battling the boss Sniper and avoiding cannon shots](/images/last_level.gif)

---

### Controls

| **Control**                | **Action**                  |
|----------------------------|-----------------------------|
| `A`, `Arrow Left`          | Move left              |
| `D`, `Arrow Right`         | Move right             |
| `W`, `Arrow Up`            | Move up |
| `S`, `Arrow Down`          | Move down|
| Mouse position             | Rotate the ship                        |
| Left mouse button          | Fire laser gun        |
| Right mouse button         | Launch missiles         |
---

### Gameplay Elements

#### Player Ship
<div style="display: flex; align-items: center;">
  <img src="/Assets//Sprites/Ships/playerShipModule2.png" style="padding:30px" alt="Killiam3, Yellow spaceship resembling a fighter jet">
  <p>A small, fast, and highly responsive ship with precise linear and angular movements. Equipped with two types of attacks: a standard laser gun and a powerful missile launcher capable of destroying most enemies in one shot.

</p>
</div>

#### Enemies
- Face a variety of enemy spaceships, each with unique movement patterns and attacks:

|Pursuer |Scout|Cannon|Meteor|Sniper|
|:---:|:---:|:---:|:---:|:---:|
|<img src="/Assets/Sprites/Ships/Cruiser_57x49.png" width=80px alt="Pursuer Spaceship">|<img src="/Assets/Sprites/Ships/IonCannon_A_Photon_119x119.png" width=80px alt="Scout Spaceship">|<img src="/Assets/Sprites/Cannons/CoreDefender_A_209x182.png" width=80px, alt="Space cannon">|<img src="/Assets/Sprites/SpaceObjects/Stones2Filled_09.png" width=80px, alt="Meteor">|<img src="/Assets/Sprites/Ships/Sniper.png" width=80px alt="Sniper spaceship">|


#### Life Bar
![Heart symbol](/Assets/Sprites/PlayerUI/hearth.png) ![Player life bar](/Assets/Sprites/PlayerUI/life_texture.png)
Starts full and decreases when hit by enemy fire or upon collision with obstacles.

#### Shield Bar
![Symbol of a shield](/Assets/Sprites/PlayerUI/energy.png) ![Player Shield Bar](/Assets/Sprites//PlayerUI/energy-bar.png)
Regenerates over time and absorbs most laser weapon damage. However, it offers limited protection against collisions with ships or meteors.

#### Special Attack Bar
![Sun symbol](/Assets/Sprites/PlayerUI/shild%20(1).png) ![Special attack bar](/Assets/Sprites/PlayerUI/shield-bar%20(1).png)
This bar charges over time and allows the player to fire powerful missiles, capable of eliminating most enemies with a single shot.

---

### Objective
Eliminate waves of enemies and defeat the boss across five different areas. To unlock each new area, all enemies in the current level must be defeated.

---

### Features to Implement

- [ ] **Health Kits:** Restore vitality during battles.
- [ ] **Upgrades:** Improve weapon performance and ship attributes.
- [ ] **Dropped Items:** Defeated enemies may drop random items such as health kits, missiles, upgrades, or nothing at all.
- [ ] **Boss Battles:** Intense battles at the end of each level.
- [ ] **New Levels:** Add more levels with different enemy types and unique challenges.
- [ ] **Cutscenes:** Incorporate cutscenes to narrate the game's story and increase immersion.
- [ ] **Score System:** Implement a score system to record player performance.
- [ ] **NPCs:** Introduce NPCs to deepen the narrative and create a more engaging experience.