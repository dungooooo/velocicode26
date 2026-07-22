# Velocicode 2026 — Lula the Dinosaur Platformer

**Game Jam Theme:** FOSSIL  
**Build Target:** WebGL (playable in browser via itch.io)  
**Status:** Active development — Mario clone codebase being excavated and revamped

---

## Project Overview

This repo began as a 2D Super Mario Bros remake built in Unity 2020 for an ODU college game dev course. It is being revamped into an original dinosaur-themed 2D platformer called **Lula** for a game jam. The Mario physics, movement, and enemy systems are being excavated and re-skinned — not rebuilt from scratch.

The original Mario snapshot is preserved in git history (commit `702e74a`) as a reference baseline.

---

## Tech Stack

| Item | Value |
|---|---|
| Engine | Unity 2D Core |
| Unity Version (original) | 2020.2.1f1 |
| Unity Version (working) | 6000.5.4f1 (Unity 6) |
| Platform | macOS Apple Silicon (development) |
| Build Target | WebGL |
| Language | C# |
| Version Control | Git / GitHub |
| Deployment | itch.io (browser play) |

---

## Canvas & Asset Specs

| Setting | Value |
|---|---|
| Game Resolution | 1920 x 1080 (16:9) |
| UI Canvas Reference | 1920 x 1080 |
| Base Tile Grid | 32 x 32 px |
| Lula (player) sprite | 32 x 64 px per frame |
| bad_bird (enemy) sprite | 32 x 32 px per frame |
| Sprite delivery format | Horizontal PNG sprite sheet, transparent background |

---

## How to Open This Project

1. **Install Unity 6000.5.4f1** via Unity Hub
2. Unity Hub → Projects → **Open** → select the `/velocicode26` folder (this root)
3. Unity detects version mismatch (project was 2020.2.1f1) — click **Open with 6000.5.4f1** and confirm the upgrade
4. `Library/` rebuilds automatically — 2–5 minutes on first open
5. Open the scene: `Assets/Scenes/Level 1-1.unity`

> `Library/` is excluded from git. Every developer's machine generates its own locally.

---

## How to Build for WebGL

### One-Time Setup
1. **File → Build Settings** → select **WebGL** → click **Switch Platform**
2. **Player Settings** → set:
   - Company Name: `velocicode`
   - Product Name: `Lula`
   - Default Screen Width: `1920` / Height: `1080`
   - WebGL Template: `Default`

### Build
1. **File → Build Settings** → confirm WebGL selected
2. **Add Open Scenes** (if scene not listed)
3. Click **Build** → output to `Builds/` folder
4. Unity generates `index.html` + supporting files

### Deploy to itch.io
1. Zip the entire `Builds/` output folder
2. itch.io → Upload → kind: **HTML**
3. Check **This file will be played in the browser**
4. Viewport: `1920 x 1080`

> `Builds/` is excluded from git. Build locally, deploy to itch.io directly.

---

## Project Architecture

### Folder Structure
```
Assets/
├── Animations/        # .anim clips + .controller state machines
├── Audio/             # .wav sound effects and music
├── Fonts/             # SuperMario256.ttf (to be replaced)
├── Physics Material/  # Player.physicsMaterial2D
├── Prefabs/           # Reusable GameObjects (enemy, coins, blocks, pipes, killZone)
├── Scenes/            # Level 1-1.unity
├── Scripts/           # All C# gameplay scripts
├── Sprites/
│   ├── Lula/          # Player sprite sheets (pending art)
│   ├── bad_bird/      # Enemy sprite sheets (pending art)
│   ├── Environment/   # Tiles, background, decorations (pending art)
│   ├── FX/            # Coins, block animations (pending art)
│   └── UI/            # HUD icons (pending art)
├── Tilemap/           # Level tilemap prefab
└── Tiles/             # Tile assets (.asset) used by Tilemap
```

### Scripts
| Script | Purpose | Status |
|---|---|---|
| `PlayerControl.cs` | Movement, jump, death, collision | **KEEP — core physics** |
| `CameraFollow.cs` | Smooth camera tracking | **KEEP** |
| `Goomba.cs` | Enemy patrol + stomp | **REVAMP → bad_bird** |
| `EnemySpawner.cs` | Spawns enemies | **KEEP** |
| `Score.cs` | Score counter | **KEEP** |
| `Lives.cs` | Lives tracking | **KEEP** |
| `Clock.cs` | Level timer | **KEEP / optional** |
| `CoinBlock.cs` | Mystery block hit logic | **REVAMP → fossil block** |
| `BrickBlock.cs` | Breakable block | **REVAMP or CUT** |
| `Coin.cs` | Collectible logic | **REVAMP → fossil shard** |
| `Remover.cs` | Destroys off-screen objects | **KEEP** |

### Key Physics Values
| Parameter | Value |
|---|---|
| `moveForce` | 365f |
| `maxSpeed` | 8f |
| `jumpForce` | 820f |
| Ground detection | `Physics2D.Linecast` on "Ground" layer |

---

## Roadmap

- [x] Phase 1: Repo initialized, .gitignore, sprite folders, art collaboration docs
- [ ] Phase 2: Code excavation — strip Mario-specific logic
- [ ] Phase 3: MVP — new scenes, greybox Lula movement test
- [ ] Phase 4: Art integration — swap sprites as delivered
- [ ] Phase 5: Polish + itch.io deploy

---

*Dev: dungo | Art/PM: [partner name] | Game Jam: FOSSIL*