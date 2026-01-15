import numpy as np
from scipy import signal
from scipy.integrate import simps
import matplotlib.pyplot as plt


def absolute_band_power(data):

    sf = 500

    # Define window length (4 seconds)
    win = 2 * 500
    freqs, psd = signal.welch(data, sf, nperseg=win)

    # plt.plot(psd)
    # plt.show()


    # Define lower and upper limits (example for delta)
    # Alpha 8-12 Hz
    # low, high = 8, 12
    # Lo-Betha 12-15 Hz
    low, high = 12, 15

    # Find intersecting values in frequency vector
    idx_delta = np.logical_and(freqs >= low, freqs <= high)


    # Frequency resolution
    freq_res = freqs[1] - freqs[0]  # = 1 / 4 = 0.25

    # Compute the absolute power by approximating the area under the curve
    band_power = simps(psd[idx_delta], dx=freq_res)


    # Relative delta power (expressed as a percentage of total power)
    total_power = simps(psd, dx=freq_res)
    band_rel_power = (band_power / total_power) * 100

    return band_rel_power