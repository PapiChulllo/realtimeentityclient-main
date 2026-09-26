# Realtime Entity Client (balloon pop)

**Unity Transport client for the shared balloon-pop lab.** It connects to the entity server, spawns local balloon proxies from server messages, and reports clicks so the server can replicate pops to all peers.

Nested Unity project path: `realtimeentityclient-main/`.

**Paired repository:** [realtimeentityserver-main](https://github.com/PapiChulllo/realtimeentityserver-main)

---

## How it works

1. `NetworkClient` connects to hardcoded IPv4 `10.0.0.82` port **9001** (change for localhost/LAN).
2. On `SpawnBalloon` messages, `GameLogic` instantiates a GameObject with `SpriteRenderer` (sprite from `Resources.Load("Circle")`), `CircleClick`, and `CircleCollider2D`, converting screen coordinates via `Camera.main.ScreenToWorldPoint`.
3. `CircleClick.OnMouseDown` sends `BalloonPopped,<id>` and destroys the local object immediately (server still authoritative for peers).

**Status / limitations:** educational sample. Hardcoded LAN IP. Client destroys locally on click before/without waiting for server ack (peers rely on server broadcast). Balloon sprite expects `Assets/Textures/Resources/Circle.png`. Commit history notes past issues with balloons appearing. No reconnect/interpolation. Unity not re-verified here.

## Tech stack

| Area | What it uses |
|---|---|
| Engine | **Unity** `2022.3.5f1` |
| Networking | **Unity Transport** `1.3.4` |
| Endpoint | Port **9001**; IP const `10.0.0.82` |
| Presentation | Runtime sprites + `Circle.png` in Resources |

## What's in the project

| System | Key files |
|---|---|
| Driver / connect / send | `realtimeentityclient-main/Assets/Scripts/NetworkClient.cs` |
| Signifier dispatch | `realtimeentityclient-main/Assets/Scripts/NetworkClientProcessing.cs` |
| Spawn / remove proxies | `realtimeentityclient-main/Assets/Scripts/GameLogic.cs` |
| Click → pop message | `realtimeentityclient-main/Assets/Scripts/CircleClick.cs` |
| Circle sprite | `realtimeentityclient-main/Assets/Textures/Resources/Circle.png` |

### Code / system highlights

- **Signifier protocol** mirrors the server (`SpawnBalloon` / `BalloonPopped`).
- **Optimistic local destroy** on click plus server broadcast for other clients.
- **Screen→world** placement assumes a configured main camera orthographic/setup matching the lab scene.

## Scenes

Use the nested project’s `Assets/Scenes/SampleScene.unity`. Start the [server](https://github.com/PapiChulllo/realtimeentityserver-main) first; edit `IPAddress` in `NetworkClient.cs` as needed.

## Third-party assets

Unity packages + a simple circle texture under Resources. No large third-party packs.

## About this repository

Public educational / portfolio client under **PapiChulllo**. Pair with [realtimeentityserver-main](https://github.com/PapiChulllo/realtimeentityserver-main).
