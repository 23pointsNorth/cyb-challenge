function LightTunnel(path)

IR_SCALE_FACTOR = 1;
DISTANCE_SCALE_FACTOR = 1.06;

%file = strcat('N:\\Data\\', filename);

light = load(strcat(path, 'LightTunnelData.txt'));
dist = load(strcat(path, 'LightDistData.txt'));

light = light * IR_SCALE_FACTOR;
dist = dist * DISTANCE_SCALE_FACTOR;



figure;
plot(dist, light, 'r');

xlabel('Distance in (mm)');
ylabel('Light Intensity');
title('Light Tunnel Data');
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