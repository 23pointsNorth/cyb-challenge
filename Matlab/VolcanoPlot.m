function VolcanoPlot()

period = 0.2;

temp = load('N:\..University\Year2\Cybs Challenge\Data\\TempData.txt');

time = (0:1:(size(temp) - 1)) * period;  

figure;
plot(time, temp, 'r');

xlabel('Time (s)');
ylabel('Temperature (''C)');
title('Temperature Volcano Data');
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