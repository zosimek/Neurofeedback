from numpy.fft import fft, ifft
import matplotlib.pyplot as plt
import numpy as np
from scipy import signal
from scipy.integrate import simps

sr = 2000
# sampling interval

#######     filter    ######
filter = signal.firwin(1001, [0.5/sr*2, 50/sr*2], pass_zero=False)

ts = 1.0/sr
print(ts)
t = np.arange(0,1,ts)

freq = 12
x = 3*np.sin(2*np.pi*freq*t)

freq = 13
x += 1*np.sin(2*np.pi*freq*t)

freq = 14
x += 2*np.sin(2*np.pi*freq*t)

freq = 15
x += 4*np.sin(2*np.pi*freq*t)


#############    white noise    ######################
mean = 0
std = 5
num_samples = 2000
white_noise = np.random.normal(mean, std, size=num_samples)

y = x + white_noise

############     filtered    ###################
filtered = signal.convolve(y, filter, mode='same')

YF = fft(filtered)
N = len(filtered)
n = np.arange(N)
T = N/sr
freq = n/T

# plt.figure(figsize = (8, 6))
# plt.plot(t, x, 'r')
# plt.ylabel('Amplitude clean')
# plt.show()

X = fft(x)
Y = fft(y)
N = len(x)
n = np.arange(N)
T = N/2000
freq = n/T

plt.figure(figsize = (12, 6))

plt.subplot(133)
plt.stem(freq, np.abs(YF), 'b', \
         markerfmt=" ", basefmt="-b")
plt.xlabel('Freq (Hz) FILTERED')
plt.ylabel('FFT Amplitude |X(freq)|')
plt.xlim(0, 100)

plt.subplot(132)
plt.stem(freq, np.abs(X), 'b', \
         markerfmt=" ", basefmt="-b")
plt.xlabel('Freq (Hz) CLEAN')
plt.ylabel('FFT Amplitude |X(freq)|')
plt.xlim(0, 100)

# plt.subplot(222)
# plt.plot(t, ifft(X), 'r')
# plt.xlabel('Time (s) CLEAN')
# plt.ylabel('Amplitude')
# plt.tight_layout()

# plt.subplot(221)
# plt.plot(t, ifft(YF), 'r')
# plt.xlabel('Time (s) NOISE')
# plt.ylabel('Amplitude')
# plt.tight_layout()

plt.subplot(131)
plt.stem(freq, np.abs(Y), 'b', \
         markerfmt=" ", basefmt="-b")
plt.xlabel('Freq (Hz) NOISE')
plt.ylabel('FFT Amplitude |X(freq)|')
plt.xlim(0, 100)
plt.show()
