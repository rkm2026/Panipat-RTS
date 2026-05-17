# PANIPAT 1761 - Battlefield Formation Prototype

A prototype built for Celestium Techlabs' Game Development Internship assignment focused on gameplay systems, formation logic, and technical problem solving.

---

## Problem Statement

Build a battlefield prototype where:

- Multiple units follow a leader
- Units maintain formations dynamically
- Basic collision avoidance exists
- Formations recover when disturbed
- Implementation remains performance-aware

---

## Features Implemented

### Leader Movement
- WASD based leader movement
- Leader rotation updates based on movement direction

---

### Follower Units
- 20+ follower soldiers
- Dynamically spawned at runtime

---

### Formation Types

#### Grid Formation
Units arranged in rows and columns

Example:
S S S  
S S S  
S S S  

---

#### Line Formation
Units arranged in horizontal line

Example:
S S S S S S

---

#### Wedge Formation
Triangular military formation

Example:
    S
   S S
  S S S

---

### Dynamic Formation Updates
Whenever leader moves:

- Formation recalculates
- Followers receive new target positions
- Soldiers reposition dynamically

---

### Collision Avoidance
Basic local collision avoidance implemented:

- Units detect nearby soldiers
- Separation force prevents overlapping

---

### Formation Recovery
If soldiers are displaced:

- They automatically return to assigned formation slots

---

### Environment
- Battlefield terrain
- Grass ground
- Rock obstacles

---

# Architecture

System follows modular architecture:

Player Input
↓
LeaderController
↓
FormationManager
↓
UnitController
↓
Collision/Recovery System

---

## LeaderController.cs

Responsible for:

- WASD input handling
- Leader movement
- Leader rotation

---

## FormationManager.cs

Responsible for:

- Spawning units
- Maintaining unit lists
- Generating formation slots
- Switching formations
- Updating target positions

---

## UnitController.cs

Responsible for:

- Moving units toward assigned slots
- Collision avoidance
- Returning to formation after disturbances

---

# Technical Decisions

---

## Why Manual Movement Instead of NavMesh?

For this prototype:

- Battlefield terrain is simple
- Faster implementation
- Easier debugging

NavMesh would be more useful for complex pathfinding environments.

---

## Why Separate Scripts?

Avoided putting all logic in one large script.

Benefits:

- Easier debugging
- Better scalability
- Cleaner architecture

---

## Why Basic Collision Instead of Advanced Pathfinding?

Assignment required basic collision avoidance.

Current implementation works well for 20–50 units.

Advanced alternatives:

- Spatial partitioning
- Flow fields
- NavMesh agents

---

# Performance Considerations

Current prototype is optimized for assignment scale:

20–50 units

---

## Current Bottleneck

Collision detection currently uses nearby unit checks:

O(n²)

This is acceptable for prototype scale.

---

## Future Optimizations

For larger battles:

- ECS/DOTS
- Spatial partitioning
- Job system
- Object pooling
- Better pathfinding

---

# Challenges Faced

- Maintaining formation stability during rapid turns
- Collision avoidance tuning
- Preventing unit overlap
- Ensuring formations recover correctly

---

# Future Improvements

- Combat system
- Better pathfinding
- Animation system
- RTS mouse selection
- Larger armies
- Smarter obstacle avoidance

---

# Controls

W → Move Forward  
A → Move Left  
S → Move Backward  
D → Move Right  

1 → Grid Formation  
2 → Line Formation  
3 → Wedge Formation  

---

# Demo Video

(Add your video link here)

---

# Repository

(Add GitHub repository link here)
