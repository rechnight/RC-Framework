# 🧱 Overview

RCFramework is a lightweight **MVC-inspired architecture** for Unity, designed for:
- **Scalable projects:** Supports multiple scenes, persistent and scene-specific systems.
- **Memory safety:** Scoped events and automatic unsubscriptions prevent leaks.
- **Modular design:** Clear separation of Models, Systems, Utilities, Commands, and Events.
- **Testability:** Uses dependency injection for all core components.

The framework allows developers to focus on **game logic** rather than boilerplate architecture.

---

## 🗂️ Core Principles
- **Single source of truth:** All Models, Systems, and Utilities are registered in a central Architecture hub.
- **Scoped events:** Event subscriptions are memory-safe and automatically cleaned up.
- **Dependency injection:** [Inject] is used for Models, Systems, Utilities.
- **Multi-scene aware:** Bootstrappers handle registration and cleanup per scene.
- **Utilities:** Shared services like save/load managers, audio managers, network helpers.

---

## 🧩 Core Components

### **Architecture**
- The **central hub** connecting all framework layers.  
- Handles **dependency injection**, **event dispatch**, and **instance resolution**.

### **Bootstrapper**
- Registers **Models**, **Systems**, and **Utilities** at scene load.  
- Tracks all elements for **automatic cleanup** on scene unload.  
- Supports **global bootstrappers** that persist across scenes.

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

1. **Bootstrapper** initializes the architecture, registers Models, Systems, Utilities, and cleans them up on shutdown.  
2. **Architecture** is the central hub — manages dependencies, injections, and the EventBus.  
3. **Models** hold state and send events when data changes.  
4. **Systems** contain business logic, react to events, and update Models.  
5. **Controllers** handle user input and send **Commands** to request state changes and listen to **Events** to change the view.  
6. **Commands** execute isolated operations, modifying **Models**, calling **Systems** or triggering **Events**.  
7. **Utilities** offer reusable helpers like saving, loading, or network logic — accessible from all layers.  
8. **Scoped Event Management** ensures all event subscriptions are automatically cleaned up on object disable or destroy.

---

## 📖 Learn More

Check out the tutorial series on building RCFramework step by step:

➡️ **[From Spaghetti to Symphony — Building a Clean Game Architecture in Unity](https://rabcat.hashnode.dev/from-spaghetti-to-symphony-building-a-clean-game-architecture-in-unity)**  
(Tutorials on making games with the framework coming soon)
