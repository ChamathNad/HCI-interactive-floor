# HCI Interactive Floor – Wedding Alley

An immersive, real-world wedding installation that combines **gesture-based interaction** with **digital projection**, powered by Unity and a custom Python server.

This project was created with support from **RIS Laboratories** at the University of Sri Jayewardenepura and gained recognition through national television coverage.

---

## 🌀 Project Overview

The HCI Interactive Floor brings a **digital wedding alley** to life using real-time **depth sensing** and **projected visuals**. A **Kinect or depth camera** tracks human movement and posture, dynamically affecting the Unity-rendered environment.

Multiple projectors are used to display the alley, transforming a physical space into a reactive, artistic digital corridor. Explorations are ongoing into expanding this with LED screens and holographic displays.

---

## 🛠 Tech Stack

| Layer                  | Tools / Frameworks                        |
|------------------------|-------------------------------------------|
| Game Engine            | Unity (C# Backend & Frontend)             |
| Real-Time Server       | Python (Custom server, WebSockets)        |
| Interaction Logic      | Kinect / Depth Camera (via Unity APIs)    |
| Web Interface (Optional)| HTML, JavaScript (p5.js, WebSocket)      |
| Assets & Modeling      | Custom 3D models + Unity primitives       |

---

## 📁 Project Structure

### Unity Project Root:
- `Assets/`, `Build/`, `Packages/` – Main Unity project folders  
- `HCI interactive floor.sln` – Visual Studio solution file  

### Embedded Server (inside `HCI.zip`):
- `multi.py` – Custom Python WebSocket server  
- `p5.min.js` – JavaScript library for frontend canvas interaction  
- `sketch.js` – Client-side interaction logic (optional web view)  
- `webSoc.html` – Basic HTML interface  
- `read me.txt` – Local notes

---

## 🚀 How It Works

1. **Camera Setup**: Depth camera/Kinect detects players walking along the alley.
2. **Unity Scene**: The virtual environment reacts to movement using animation triggers and particle effects.
3. **Python Server**: Handles real-time data from sensors or external clients and communicates with Unity.
4. **Web Interface (Optional)**: Can display real-time data or serve as a control panel using `webSoc.html`.

---

## 📸 Recognition

> *"This project was showcased on national television through the **'Knowledge 1st'** program by Rupavahini, Sri Lanka’s state TV network, in early 2020."*

*Archived footage currently unavailable.*

---

## 🧑‍💻 Development

Developed entirely as a collaborative project under RIS Labs.  
Unity development, server logic, and UI integrations were handled internally.

---

## ✍️ Author
RIS Laboratories, University of Sri Jayewardenepura

