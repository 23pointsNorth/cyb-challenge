function MapRiverBed()

%file = strcat('N:\\..University\\Year2\\Cybs Challenge\\Data', filename);

left = load('N:\..University\Year2\Cybs Challenge\Data\RiverDataLeft.txt');
right = load('N:\..University\Year2\Cybs Challenge\Data\RiverDataRight.txt');
dist = load('N:\..University\Year2\Cybs Challenge\Data\DistData.txt');

figure;
plot(left, dist, '.' ,right, dist, '.');

end