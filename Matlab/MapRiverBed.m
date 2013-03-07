function MapRiverBed()

IR_SCALE_FACTOR = 1;
DISTANCE_SCALE_FACTOR = 0.95;
windowSize = 6;

%file = strcat('N:\\Data\\', filename);

left = load('N:\..University\Year2\Cybs Challenge\Data\\RiverDataLeft.txt');
right = load('N:\..University\Year2\Cybs Challenge\Data\\RiverDataRight.txt');
dist = load('N:\..University\Year2\Cybs Challenge\Data\\DistData.txt');


left = filter(ones(1,windowSize)/windowSize, 1, left);
right = filter(ones(1,windowSize)/windowSize, 1, right);

left = left * IR_SCALE_FACTOR;
right = right * IR_SCALE_FACTOR;
dist = dist * DISTANCE_SCALE_FACTOR;



figure;
plot(dist, left, 'r' ,dist, right,'m');

xlabel('Distance in (mm)');
ylabel('Deflection from Rover (mm)');
title('River Bed Map Profile');
grid on;

%Draw line tool 1
peakX = [450 550];
peakY = [180 150];
l1 = imdistline(gca, peakX, peakY);
api1 = iptgetapi(l1);
api1.setLabelTextFormatter('%02.0f mm');
api1.setColor('r');

%Draw line tool 2
peakX = [200 500];
peakY = [175 150];
l2 = imdistline(gca, peakX, peakY);
api2 = iptgetapi(l2);
api2.setLabelTextFormatter('%02.0f mm');
api2.setColor('g');

end