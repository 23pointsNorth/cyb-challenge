function MapRiverBed()

%file = strcat('N:\\Data\\', filename);

left = load('N:\\Data\\RiverDataLeft.txt');
right = load('N:\\Data\\RiverDataRight.txt');
dist = load('N:\\Data\\DistData.txt');

figure;
plot(left, dist, '.' ,right, dist, '.');

xlabel('Distance in (mm)');
ylabel('Deflection from Rover (mm)');
title('River Bed Map Profile');
grid on;

%Draw line tool 1
peakX = [600 500];
peakY = [300 200];
l1 = imdistline(gca, peakX, peakY);
api1 = iptgetapi(l1);
api1.setLabelTextFormatter('%02.0f mm');
api1.setColor('r');

%Draw line tool 2
peakX = [200 500];
peakY = [100 250];
l2 = imdistline(gca, peakX, peakY);
api2 = iptgetapi(l2);
api2.setLabelTextFormatter('%02.0f mm');
api2.setColor('g');

end