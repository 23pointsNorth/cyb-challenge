function Vortex()

mag_x = load('N:\..University\Year2\Cybs Challenge\Data\\MagDataX.txt');
mag_y = load('N:\..University\Year2\Cybs Challenge\Data\\MagDataY.txt');
mag_z = load('N:\..University\Year2\Cybs Challenge\Data\\MagDataZ.txt');

time = (0:1:(size(mag_x) - 1));  

figure;
plot(time, mag_x, 'r', time, mag_y, 'g', time, mag_z, 'b');

xlabel('Sample');
ylabel('Amplitude');
title('Vortex Data');
grid on;

%Draw line tool 1
%peakX = [450 550];
%peakY = [180 150];
%l1 = imdistline(gca, peakX, peakY);
%api1 = iptgetapi(l1);
%api1.setLabelTextFormatter('%02.0f');
%api1.setColor('r');

%Draw line tool 2
%peakX = [200 500];
%peakY = [175 150];
%l2 = imdistline(gca, peakX, peakY);
%api2 = iptgetapi(l2);
%api2.setLabelTextFormatter('%02.0f');
%api2.setColor('g');

end