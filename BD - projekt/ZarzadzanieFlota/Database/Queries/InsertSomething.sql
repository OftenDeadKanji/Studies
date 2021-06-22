Insert Into Employees
Values('Jan', 'Kowalski', 889232512, 'Jan.Kowalski@gmail.com', 'uwaga', 'okoń');

Insert Into Employees
Values('Piotr', 'Nowak', 834642122, 'Jan.Kowalski@gmail.com', 'jan', 'okoń');

Insert Into Employees
Values('Test', 'Test', 123456789, 'Test.Test@test.test', 'test', 'test');

Insert Into Employees
Values('Wielce Szanowna', 'U.S.', 666666666, 'Komplikowanie.Zwyczajnego@Toku.Spraw', 'otwarta', 'furtka');

Insert Into Employees
Values('Najlepszy', 'Wykładowca', 000000000, 'TUC@polsl.pl', '<3', '<3');

Insert Into Employees
Values('Kanji', 'Klub', 997998999, 'Kanji.Jest@Martwy.D:', 'password', 'login');

Insert Into Drivers
Values(1, 0, 0);

Insert Into Drivers
Values(2, 1, 1);

Insert Into Stops
Values('Goethego', 'Zabrze', 8);

Insert Into Stops
Values('Stadion', 'Zabrze Centrum Południe', 2);

Insert Into Stops
Values('Kościół św. Józefa', 'Zabrze Centrum Południe', 2);

Insert Into Stops
Values('Kopalnia', 'Sośnica', 2);

Insert Into Stops
Values('Komag', 'Gliwice', 2);

Insert Into Stops
Values('Plac Piastów', 'Gliwice', 7);

Insert Into Stops
Values('Plac Mickiewicza', 'Katowice', 9);

Insert Into Stops
Values('Dom Marbiego', 'Chorzów', 1);

Insert Into Stops_on_route
Values(1, NULL, NULL, 1, 0);

Insert Into Stops_on_route
Values(2, NULL, 1, 2, 8);

Insert Into Stops_on_route
Values(3, NULL, 2, 3, 5);

Insert Into Stops_on_route
Values(4, NULL, 3, 4, 12);

Update Stops_on_route
SET id_next = 2 WHERE id = 1;

Update Stops_on_route
SET id_next = 3 WHERE id = 2;

Update Stops_on_route
SET id_next = 4 WHERE id = 3;

Insert Into Lines 
Values(32, 0, 0);

Insert Into Lines 
Values(870, 1, 2);

Insert Into Lines 
Values(6, 0, 1);

Insert Into Transits
Values(1, 1, 4, 0, 0, '01 AM', 60);

Insert Into Vehicles
Values('SZ83492', 'SN702', 0, 110);

Insert Into Vehicles
Values('SG1181L', 'SW223', 0, 150);

Insert Into Vehicles
Values('SK5402A', 'BG467', 1, 70);

Insert Into Vehicles
Values('SG5462H', 'WT345', 1, 70);

Insert Into Vehicles
Values('SZ7476S', 'FQ702', 2, 90);