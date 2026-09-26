# Realtime Entity Client

**A Unity Transport lab client for the balloon-entity server**: connects, receives spawn messages, and reports pops back to the server.

---

## Status

Networking coursework / lab. Companion to `realtimeentityserver-main`.

## Tech stack

| Area | What it uses |
|---|---|
| Engine | Unity |
| Networking | **Unity Transport** |
| Language | **C#** |

## What's in the project

| System | Key files |
|---|---|
| Transport client | `realtimeentityclient-main/Assets/Scripts/NetworkClient.cs` |
| Message routing | `realtimeentityclient-main/Assets/Scripts/NetworkClientProcessing.cs` |
| Balloon presentation / click | `realtimeentityclient-main/Assets/Scripts/GameLogic.cs`, `CircleClick.cs` |

## About this repository

Educational networking sample. Pair with `realtimeentityserver-main`.
