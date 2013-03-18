function SeismicActivity(path)

%% Load data
Fs = 400;                     % Sampling frequency 1037/10
T = 1/Fs;                     % Sample time
L = 16*60;                     % Length of signal

acc = load(strcat(path,'SeismicData.txt'));

time = (0:T:T*(size(acc) - 1));             % Time vector
time = time';

size(time)
size(acc)

%% Plot data Acc

figure;
plot(time, acc, 'r');
xlabel('Time (sec)');
ylabel('Acceleration in Z');
title('Acceleration data');
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

%% Fourier 

% Windowing
w = hanning(length(acc)); 
w = w';
figure;
plot(time, w);
title('Windowing function')

accw = w*acc;
for i=1:length(acc)
    accw(i) = acc(i)*w(i);
end

figure;
plot(time, accw);
title('Windowed result')
% for windowing use accw later on, otherwise accw = acc
%accw= acc;

NFFT = 2^nextpow2(L); % Next power of 2 from length of y
Y = fft(accw, NFFT)/L;
f = Fs/2*linspace(0,1,NFFT/2+1);

% Plot single-sided amplitude spectrum.
figure;
plot(f,2*abs(Y(1:NFFT/2+1))) 
title('Frequency Spectrum of received acceleromter data')
xlabel('Frequency (Hz)')
ylabel('Amplitude')

end