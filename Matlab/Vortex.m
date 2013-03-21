function Vortex(path)

mag_x = load(strcat(path, 'MagDataX.txt'));
mag_y = load(strcat(path, 'MagDataY.txt'));
mag_z = load(strcat(path, 'MagDataZ.txt'));
absVector = load(strcat(path, 'MagAbsValue.txt'));

angleXY = mag_z; % make it the correct size
angleXZ = mag_z; % make it the correct size
angleYZ = mag_z; % make it the correct size

time = (0:1:(size(mag_x) - 1));  

%% Plot data
figure;
plot(time, mag_x, 'r', time, mag_y, 'g', time, mag_z, 'b');

xlabel('Sample');
ylabel('Amplitude');
title('Vortex Data');

% Label the curve for function f in red
text(01, 100, 'x - red', 'Color', 'r');
text(01, 0, 'y - green', 'Color', 'g');
text(01, -100, 'z - blue', 'Color', 'b');

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

%% Plot normalized vector
%{
figure;
plot(time, absVector, 'r');

xlabel('Sample');
ylabel('Normalized Magnetic Vector');
title('Magnetic Vector Normalized Data');
grid on;
%}
%% Calculate angle plot

%% XY
for i=1:length(mag_z)
    angleXY(i) = atan2( mag_x(i), mag_y(i));
end

figure;
title('atan2(x, y)');
plot(time, angleXY, 'g');

%% XZ
for i=1:length(mag_z)
    angleXZ(i) = atan2( mag_x(i), mag_z(i));
end

figure;
title('atan2(x, z)');
plot(time, angleXZ, 'g');

%% YZ
for i=1:length(mag_z)
    angleYZ(i) = atan2( mag_y(i), mag_z(i));
end

figure;
title('atan2(y, z)');
plot(time, angleYZ, 'g');

end