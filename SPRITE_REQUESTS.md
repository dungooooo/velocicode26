# SPRITE REQUESTS — Velocicode 2026
**Project:** Lula (Dinosaur Platformer) | **Game Jam Theme:** FOSSIL
**Engine:** Unity 2D | **Build Target:** WebGL (itch.io)
**Repo folder for all sprites:** `Assets/Sprites/`

---

## HOW TO DELIVER SPRITES

1. Export as **PNG with transparent background** (no white fill)
2. For animated sprites, export as a **horizontal sprite sheet** — all frames in a single row, same frame size
3. Drop your file into the correct subfolder below
4. Push to GitHub (or message me and I'll pull it in)
5. **Name files exactly as listed** — this keeps Unity wiring clean

---

## CANVAS & SCALE REFERENCE

| Setting | Value |
|---|---|
| Resolution | 1920 x 1080 (16:9) |
| Base tile grid | 32 x 32 px |
| Lula character | 32 x 64 px per frame (2 tiles tall) |
| bad_bird enemy | 32 x 32 px per frame (1 tile) |
| All art style | Retro pixel / sprite art preferred |

---

## FOLDER: `Assets/Sprites/Lula/`
*Replaces: `characters.gif` (old Mario sprite sheet)*
*Maps to: `Assets/Animations/Mario.controller` → will be renamed Lula.controller*

| File Name | Frames | Frame Size | Animation State It Feeds | Notes |
|---|---|---|---|---|
| `lula_idle.png` | 1–2 | 32 x 64 | `Idle` | Standing still. Can be a single frame or subtle 2-frame breathing loop |
| `lula_run.png` | 4–6 | 32 x 64 | `Run` | Horizontal movement. 4 frames minimum for smooth feel |
| `lula_jump.png` | 1–2 | 32 x 64 | `Jump` | Airborne pose. Usually 1 frame is fine |
| `lula_die.png` | 2–3 | 32 x 64 | `Die` | Death sequence. Plays for ~3 seconds then respawns |
| `lula_slide.png` | 1–2 | 32 x 64 | `SlideDownFlag` | End-of-level celebration. Can revisit if level-end mechanic changes |

**Facing direction:** Draw Lula facing RIGHT. Unity will flip her automatically for left movement.

---

## FOLDER: `Assets/Sprites/bad_bird/`
*Replaces: Goomba portion of `characters.gif`*
*Maps to: `Assets/Animations/Goomba.controller` → will be renamed bad_bird.controller*

| File Name | Frames | Frame Size | Animation State It Feeds | Notes |
|---|---|---|---|---|
| `bad_bird_walk.png` | 2–4 | 32 x 32 | `GoombaWalk` | Patrol loop. Walks back and forth, flips at walls |
| `bad_bird_die.png` | 2 | 32 x 32 | `GoombaDie` | Gets stomped from above. Squish/flatten frames |

**Behavior note:** bad_bird auto-patrols left/right and bounces off walls and other enemies. Gets destroyed 1 second after stomped. Player bounces off its head to kill it.

---

## FOLDER: `Assets/Sprites/FX/`
*Replaces: Coin + block pop animations*

| File Name | Frames | Frame Size | Animation State It Feeds | Notes |
|---|---|---|---|---|
| `coin_spin.png` | 4 | 16 x 16 | `Coin` (coin.controller) | Spinning collectible coin. Can be a gem, fossil shard, bone, etc. |
| `block_idle.png` | 4 | 32 x 32 | `coinblock_idle` | Animated "mystery block" idle. In this game, could be a fossil egg or rock |
| `block_hit.png` | 2 | 32 x 32 | `coinblock_hit` | Block gets punched from below — bump up then down |
| `block_empty.png` | 1 | 32 x 32 | `coinblock_empty` | After hit, block is depleted/dead |

---

## FOLDER: `Assets/Sprites/Environment/`
*Replaces: `blocks.gif`, `brickblock.png`, `background.gif`*
*Maps to: Unity Tilemap tiles in `Assets/Tiles/`*

| File Name | Size | Tile It Feeds | Notes |
|---|---|---|---|
| `tile_ground.png` | 32 x 32 | `ground.asset` | Base ground tile. Repeats across floor |
| `tile_brick.png` | 32 x 32 | BrickBlock prefab | Breakable block (player can't break in current code but it exists) |
| `tile_stair.png` | 32 x 32 | `stairblock.asset` | Stair/step block |
| `tile_pipe_top.png` | 32 x 32 | `smallpipe / medpipe / largepipe` | Pipe opening (decorative in current build) |
| `tile_pipe_body.png` | 32 x 32 | (same pipe assets) | Pipe body segment, stacks vertically |
| `background.png` | 1920 x 1080 | background sprite | Full scene background. Prehistoric sky, jungle, tar pit — your call |
| `bg_cloud.png` | ~64 x 32 | `cloud / medcloud / bigcloud` | Floating BG decoration |
| `bg_hill.png` | ~64 x 48 | `smallhill / bighill` | BG hill decoration |
| `bg_bush.png` | ~48 x 32 | `bush1 / bush2 / bush3` | BG bush decoration (3 width variants) |
| `flagpole.png` | 16 x 128 | flagpole prefab | Vertical pole, level end marker |
| `flag.png` | 32 x 32 | flag animations `FlagIdle / FlagDown` | 2-frame wave loop |

---

## FOLDER: `Assets/Sprites/UI/`
*No existing assets — these are new*

| File Name | Size | Used For | Notes |
|---|---|---|---|
| `ui_heart.png` | 32 x 32 | Lives display (Lives.cs) | Current code tracks lives as a number; this would be a visual icon |
| `ui_coin_icon.png` | 32 x 32 | Score/coin HUD | Small icon next to score counter |

---

## WHAT ALREADY EXISTS (DO NOT REPLACE YET)
These are in `Assets/Sprites/` at the root and are still wired to the live scene. Leave them alone until we confirm the new sprites are mapped in Unity:

- `characters.gif` — old Mario + Goomba sheet, still powering the scene
- `blocks.gif` — old block sheet
- `background.gif` — old background
- `brickblock.png` — old single brick

Once a new sprite is confirmed working in Unity, I'll archive these.

---

## ANIMATION STATES REFERENCE (for your awareness)
These are the animation clip names baked into Unity. My job is to swap what images they point to — you don't need to worry about these names, just the file names in the tables above.

```
Player:   Idle, Run, Jump, Die, SlideDownFlag
Enemy:    GoombaWalk, GoombaDie
Coin:     Coin
Block:    coinblock_idle, coinblock_hit, coinblock_empty, coinblock_still
Flag:     FlagIdle, FlagDown
```

---

*Last updated: 2026-07-22 | Maintained by dev — ping with questions before starting a new sprite*
