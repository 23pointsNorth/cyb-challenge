function MapRiverBed()

Fs = 400;                     % Sampling frequency
T = 1/Fs;                     % Sample time
L = 8*60;                     % Length of signal

acc = load('N:\..University\Year2\Cybs Challenge\Data\SeismicData.txt');

time = (0:T:(T*(size(acc) - 1)));             % Time vector
time = time';

size(acc)
size(time)

figure;
plot(time, acc, 'r');

xlabel('Distance in (mm)');
ylabel('Light Intensity');
title('Light Tunnel Data');
grid on;

%Draw line tool 1
peakX = [1 0.95];
peakY = [1 0.9];
l1 = imdistline(gca, peakX, peakY);
api1 = iptgetapi(l1);
api1.setLabelTextFormatter('%02.0f mm');
api1.setColor('r');

%Draw line tool 2
peakX = [0.9 1];
peakY = [0.92 1];
l2 = imdistline(gca, peakX, peakY);
api2 = iptgetapi(l2);
api2.setLabelTextFormatter('%02.0f mm');
api2.setColor('g');

end