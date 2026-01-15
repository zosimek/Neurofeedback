import numpy as np
import time as tm
import UdpComms as U
from scipy.signal import filtfilt
from scipy import signal
from pylsl import StreamInlet, resolve_stream
from absolute_band_power import absolute_band_power as abp

########################################################################################################################
############################    Create a stream to Unity    ############################################################

# Create UDP socket to use for sending (and receiving)
sock = U.UdpComms(udpIP="127.0.0.1", portTX=8000, portRX=8001, enableRX=True, suppressWarnings=True)

########################################################################################################################
############################    Get stream from svarog LSL    ##########################################################

stream_name = "eegSignal"

streams = resolve_stream('type', 'EEG')

selected_stream = None
for stream in streams:
    if stream.name() in stream_name:
        selected_stream = stream
if selected_stream is None:
    print("Stream under the name ", stream_name, " has not been found in the list", [i.name() for i in streams])
    exit()

inlet = StreamInlet(selected_stream)

while True:
    start = tm.time()
    # samples in uV
    sample, timestamp = inlet.pull_chunk(timeout=1.0, max_samples=500)
    # sample, timestamp, time.monotonic()

    with open('filterVertical.txt') as f:
        filter = [float(line.rstrip()) for line in f]


    el1 = []
    el2 = []
    for elem in sample:
        el1.append(elem[0])
        el2.append(elem[1])
        el1_np = np.array(el1)
        el2_np = np.array(el2)
    # el1_fir = signal.convolve(el1_np, filter, mode='same')
    # el2_fir = signal.convolve(el2_np, filter, mode='same')
    el1_fir = filtfilt(filter, 1, el1_np)
    el2_fir = filtfilt(filter, 1, el2_np)
    el1_abp = abp(el1_fir)
    el2_abp = abp(el2_fir)
    final = (el1_abp + el2_abp) / 2
    print("power of band: " + str(final))
    end = tm.time()
    #print(end - start)


    sock.SendData(str(final)) # Send this string to other application
    data = sock.ReadReceivedData() # read data

    if data != None: # if NEW data has been received since last ReadReceivedData function call
        print(data) # print new received data

    tm.sleep(1)
