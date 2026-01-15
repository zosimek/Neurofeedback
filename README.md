**Neurofeedback Application (EEG Biofeedback)**

**Overview**

This repository contains a neurofeedback (EEG biofeedback) application developed as part of an engineering thesis at Wrocław University of Science and Technology.
The system combines real-time EEG acquisition, signal processing in Python, and interactive feedback implemented in Unity to support relaxation and concentration training in healthy individuals.

The application follows a brain–computer interface (BCI) paradigm and uses neurofeedback protocols based on EEG band power modulation.


**System Architecture**

The project consists of two main components:
  — Python backend (signal processing)
  — Unity application (visual & auditory feedback)
Data flow
EEG device (Perun-32)
        ↓
LSL / streaming (via Svarog Streamer)
        ↓
Python signal processing
        ↓
Relative band power values
        ↓
Unity application (games & feedback)


**EEG Acquisition**

  — Device: Perun-32 EEG amplifier
  — Manufacturer: BrainTech (Warsaw, Poland)
  — Electrode system: International 10–20 system
  — Data streaming: Real-time streaming to Python
The EEG signal is acquired using BrainTech’s Perun-32 amplifier and streamed to the Python application, where all preprocessing and feature extraction are performed.


**Signal Processing (Python)**

The Python script performs real-time EEG preprocessing and feature extraction:
  — Band-pass filtering (1–35 Hz)
  — Power spectral density estimation using Welch’s periodogram
  — Computation of relative band power
  — Protocol-specific channel selection:
    — Relaxation: Alpha protocol (F3, F4)
    — Concentration: SMR protocol (C3, C4)
The calculated relative band power values are continuously transmitted to the Unity application and used to control feedback mechanisms.


**Neurofeedback Protocols**

The application implements two EEG neurofeedback protocols:
Relaxation (Alpha protocol)
  — Target band: Alpha (8–13 Hz)
  — Feedback type: Auditory
  — Goal: Increase alpha band power
  — Training condition: Eyes closed
Concentration (SMR protocol)
  — Target band: SMR / low beta (13–15 Hz)
  — Feedback type: Visual (games)
  — Goal: Maintain elevated SMR activity
  — Training condition: Eyes open
  

**Unity Application**

The Unity application is the core user interface and feedback system.
Features
  — 3 relaxation training variants (audio-based feedback)
  — 3 concentration training games (visual, game-based feedback)
  — Therapist control panel:
    — Patient selection
    — Training selection
    — Session control
  — Automatic threshold adaptation algorithm
  — Session data storage (Firebase Realtime Database)


**Feedback principle**

The game or audio feedback responds dynamically depending on whether the user’s EEG band power is above or below a threshold.
Thresholds can be adjusted manually or automatically to maintain a predefined success rate during training.


**Automatic Threshold Control**

An automatic threshold control algorithm (ATCA) is implemented to:
  — Adapt task difficulty to individual users
  — Maintain a target success factor during sessions
  — Prevent loss of engagement and frustration

Thresholds are adjusted dynamically based on the proportion of time EEG features exceed the threshold.


**Experimental Validation**

A proof-of-concept experiment was conducted with healthy participants:
  — 3 training sessions per participant
  — Separate relaxation and concentration groups
  — Observed improvements in:
    — Concentration task performance
    — Within-session relaxation indicators (blood pressure)

Due to sample size and experimental constraints, results are indicative rather than conclusive.


**Technologies Used**

  — Python – EEG preprocessing and feature extraction
  — Unity (C#) – Games and feedback interface
  — EEG hardware – Perun-32 (BrainTech)
  — Signal processing – FFT, Welch’s method
  — Database – Firebase Realtime Database


**Thesis Reference**

The full theoretical background, methodology, experimental design, and results are described in the accompanying engineering thesis:
  An application for EEG biofeedback
  Zofia Dobrowolska, Wrocław University of Science and Technology, 2023


**Disclaimer**
This project is intended for research and educational purposes only.
It is not a certified medical device and should not be used for diagnosis or treatment.
