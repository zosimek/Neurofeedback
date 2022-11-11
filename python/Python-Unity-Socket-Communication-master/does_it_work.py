from numpy.fft import fft, ifft
import matplotlib.pyplot as plt
import numpy as np
from scipy import signal
from scipy.integrate import simps

import absolute_band_power

plt.style.use('seaborn-poster')

# filter ##################################################
filter = signal.firwin(1000, [0.01, 0.06], pass_zero=False)

# sampling rate
sr = 2000
# sampling interval
ts = 1.0/sr
t = np.arange(0,1,ts)

freq = 12
x = 3*np.sin(2*np.pi*freq*t)

freq = 13
x += 1*np.sin(2*np.pi*freq*t)

freq = 14
x += 2*np.sin(2*np.pi*freq*t)

sf = 2000/6

# Define window length (4 seconds)
win = 2 * 500
freqs, psd = signal.welch(x, sf, nperseg=win)

# Define lower and upper limits (example for delta)
# Alpha 8-12 Hz
# Lo-Betha 12-15 Hz
low, high = 12, 20

# Find intersecting values in frequency vector
idx_delta = np.logical_and(freqs >= low, freqs <= high)

# Frequency resolution
freq_res = freqs[1] - freqs[0]  # = 1 / 4 = 0.25

# Compute the absolute power by approximating the area under the curve
delta_power = simps(psd[idx_delta], dx=freq_res)

# Relative delta power (expressed as a percentage of total power)
total_power = simps(psd, dx=freq_res)
delta_rel_power = (delta_power / total_power) * 100
print(delta_rel_power)


noise = np. random. normal(0, 10, x. shape)
new_signal = x + noise
plt.figure(figsize = (8, 6))
plt.plot(t, new_signal, 'r')
plt.ylabel('Amplitude')
plt.show()

plt.figure(figsize = (8, 6))
plt.plot(t, x, 'r')
plt.ylabel('Amplitude clean')
plt.show()

filtered = signal.convolve(new_signal, filter, mode='same')

X = fft(filtered)
N = len(filtered)
n = np.arange(N)
T = N/sr
freq = n/T

plt.figure(figsize = (12, 6))
plt.subplot(121)

plt.stem(freq, np.abs(X), 'b', \
         markerfmt=" ", basefmt="-b")
plt.xlabel('Freq (Hz)')
plt.ylabel('FFT Amplitude |X(freq)|')
plt.xlim(0, 100)

plt.subplot(122)
plt.plot(t, ifft(X), 'r')
plt.xlabel('Time (s)')
plt.ylabel('Amplitude')
plt.tight_layout()
plt.show()