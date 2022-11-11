import numpy as np
from scipy import signal
from numpy.fft import fft, ifft
import matplotlib.pyplot as plt
from math import pi
import numpy as np
from scipy import signal

sampling_freq = 1000
duration = 1.5


t = np.arange(0.0, duration, 1/sampling_freq)
y_clean = 3 * np.sin(2*pi*12*t) + 0.5 * np.sin(2*pi*13*t) + 2 * np.sin(2*pi*14*t) + np.sin(2*pi*15*t)

y = y_clean + 0.1 * np.sin(2*pi*60*t) + 0.2 * np.random.normal(size=len(t))
plt.figure(figsize=(18,4))
plt.plot(t, y)
#plt.plot(t, y_clean)
plt.xlabel('time (s)')
plt.ylabel('signal')
plt.show()

filter = signal.firwin(400, [0.02, 0.06], pass_zero=False)
plt.plot(filter)
plt.show()

y2 = signal.convolve(y, filter, mode='same')

plt.figure(figsize=(18,4))
plt.plot(t, y, alpha=0.4)
plt.plot(t, y_clean, '--', color='green')
plt.plot(t, y2)
plt.show()

plt.figure(figsize=(18,4))
plt.plot(t[:300], y[:300], alpha=0.4)
plt.plot(t[:300], y_clean[:300], '--', color='green')
plt.plot(t[:300], y2[:300])
plt.show()


X = fft(y_clean)
N = len(y_clean)
n = np.arange(N)
T = N/sampling_freq
freq = n/T

plt.figure(figsize = (12, 6))
plt.subplot(121)

plt.stem(freq, np.abs(X), 'b', \
         markerfmt=" ", basefmt="-b")
plt.xlabel('Freq (Hz) CLEAN')
plt.ylabel('FFT Amplitude |X(freq)|')
plt.xlim(10, 20)

plt.subplot(122)
plt.plot(t, ifft(X), 'r')
plt.xlabel('Time (s) CLEAN')
plt.ylabel('Amplitude')
plt.tight_layout()
plt.show()


X2 = fft(y2)
N2 = len(y2)
n2 = np.arange(N2)
T2 = N2/sampling_freq
freq = n2/T2

plt.figure(figsize = (12, 6))
plt.subplot(121)

plt.stem(freq, np.abs(X2), 'b', \
         markerfmt=" ", basefmt="-b")
plt.xlabel('Freq (Hz)')
plt.ylabel('FFT Amplitude |X(freq)|')
plt.xlim(10, 20)

plt.subplot(122)
plt.plot(t, ifft(X2), 'r')
plt.xlabel('Time (s)')
plt.ylabel('Amplitude')
plt.tight_layout()
plt.show()


X3 = fft(y)
N3 = len(y)
n3 = np.arange(N3)
T3 = N3/sampling_freq
freq = n3/T3

plt.figure(figsize = (12, 6))
plt.subplot(121)

plt.stem(freq, np.abs(X3), 'b', \
         markerfmt=" ", basefmt="-b")
plt.xlabel('Freq (Hz)')
plt.ylabel('FFT Amplitude |X(freq)|')
plt.xlim(10, 20, 1)

plt.subplot(122)
plt.plot(t, ifft(X3), 'r')
plt.xlabel('Time (s)')
plt.ylabel('Amplitude')
plt.tight_layout()
plt.show()