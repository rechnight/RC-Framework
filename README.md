# 🧱 RCFramework Architecture Overview

A lightweight **MVC-inspired architecture** for Unity, designed for modularity, scalability, and clean separation of responsibilities.  
RCFramework combines **dependency injection**, **event-driven systems**, and **scene-scoped management** for robust game projects.

---

## 🧩 Core Components

### **Bootstrapper**
- Registers **Models**, **Systems**, and **Utilities** at scene load.  
- Tracks all elements for **automatic cleanup** on scene unload.  
- Supports **global bootstrappers** that persist across scenes.

### **Architecture**
- The **central hub** connecting all framework layers.  
- Handles **dependency injection**, **event dispatch**, and **instance resolution**.

### **Models**
- Store and manage the **game state**.  
- Expose events for changes and interactions.

### **Systems**
- Contain **core gameplay logic**.  
- React to events and manipulate Models.  
- Use **UnsubscribeHandler** for **automatic cleanup** of event subscriptions.

### **Controllers**
- The **view layer** — usually `MonoBehaviour` classes attached to GameObjects.  
- Handle input, UI updates and scene-specific visual logic.  
- Use **Commands** to request state changes (Controllers must not mutate Models/Systems directly).  
- Subscribe to Events or Bindable properties to update the view.  
- Receive dependencies via `[Inject]` (in `Awake`).

### **Utilities**
- Shared services or helpers (e.g., saving, localization, analytics).  
- Accessible by any System, Command, or other Utility.

### **Commands**
- Encapsulate **actions** that modify game state or trigger sequences.  
- Can use injected dependencies from Models, Systems, or Utilities.

### **EventBus**
- Decouples communication using:
  - `OnEvent<T>` (no parameters)
  - `OnArgsEvent<TArgs>` (with parameters)
- Uses **deferred operations** for safe event dispatch even during iteration.

### **Scoped Event Management**
- Via **`UnsubscribeHandler`** and extensions like `.UnsubscribeOnDestroy()`  
- Ensures **event handlers are cleaned up** when objects are destroyed or disabled.

---

## 🧭 Flow Summary

1. **Bootstrapper**  
   Initializes the architecture, registers all **Models**, **Systems**, **Utilities**, and **Controllers**,  
   then ensures proper **cleanup** on scene unload or shutdown.

2. **Architecture**  
   Acts as the **central hub** — managing dependency injection, shared instance access,  
   and lifecycle tracking for all registered components.

3. **Controllers**  
   Represent the **View layer**, reacting to player input or UI interactions.  
   They **listen to events** and **dispatch Commands** to request changes in game state.

4. **Commands**  
   Encapsulate **state-changing logic**, using injected dependencies from Models, Systems, or Utilities.  
   When executed, they **update data** and **emit new events** to notify the system.

5. **Systems**  
   Operate as the **logic layer**, listening to **EventBus** notifications.  
   They coordinate multiple Models and apply game logic in response to events.

6. **Utilities**  
   Provide **shared, reusable services** (e.g., saving, analytics, localization)  
   accessible to any layer without creating circular dependencies.

7. **UnsubscribeHandlers**  
   Handle **automatic event cleanup**, ensuring all listeners are safely released  
   when objects, Systems, or scenes are destroyed.

---

## 📖 Learn More

Check out the tutorial series on building RCFramework step by step:

➡️ **[From Spaghetti to Symphony — Building a Clean Game Architecture in Unity](https://rabcat.hashnode.dev/from-spaghetti-to-symphony-building-a-clean-game-architecture-in-unity)**  
(Tutorials on making games with the framework coming soon)
