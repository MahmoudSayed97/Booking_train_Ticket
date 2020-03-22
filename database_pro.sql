
create database if not exists project;
use project;
set sql_safe_updates=0;
create table if not exists person(ssn varchar(40),pass varchar(40),credit varchar(40),primary key(ssn));
create table if not exists train(ssn int,ty varchar(40),num_chair int,primary key(ssn));
create table if not exists chair(source_s varchar(40),destination_s varchar(40),ssn_train int,date_time varchar(40),ssn int,foreign key(ssn_train) references train(ssn));
create table if not exists stations(station varchar(40), primary key(station));
create table if not exists train_type(ty varchar(40),primary key(ty));
create table if not exists bank(credit varchar(40),money double,pass varchar(40),primary key(credit));
create table if not exists schedual(source_s varchar(40),destination_s varchar(40),time_src varchar(40),time_dist varchar(40),price double,ssn_train int,foreign key(ssn_train) references train(ssn));
create table if not exists admin(ssn varchar(40),pass varchar(40), primary key(ssn));


insert into stations(station) values ('Aswan'),('Asuyt'),('Cairo'),('Alexandria');
insert into train_type(ty) values ('Special '),('Conditioned ');
insert into train(ssn,ty) values (125,'Conditioned '),(126,'Conditioned '),(82,'Special '),(83,'Special ');
insert into schedual(source_s,time_src,destination_s,time_dist,price,ssn_train) values ('Aswan','03:00','Alexandria','18:00',120.0,125),('Aswan','03:00','Cairo','14:00',100.0,125),('Aswan','03:00','Asuyt','10:00',70.0,125),('Asuyt','10:00','Cairo','14:00',70.0,125),('Asuyt','10:00','Alexandria','18:00',90.0,125)
,('Cairo','14:00','Alexandria','18:00',50.0,125);
insert into schedual(source_s,time_src,destination_s,time_dist,price,ssn_train) values ('Alexandria','20:00','Cairo','00:00',50.0,126),('Alexandria','20:00','Asuyt','04:00',90.0,126),('Alexandria','20:00','Aswan','11:00',120.0,126),('Cairo','00:00','Asuyt','04:00',70.0,126),('Cairo','00:00','Aswan','11:00',100.0,126)
,('Asuyt','04:00','Aswan','11:00',90.0,126);
insert into schedual(source_s,time_src,destination_s,time_dist,price,ssn_train) values ('Aswan','04:00','Alexandria','20:00',40.0,82),('Aswan','04:00','Cairo','16:00',30.0,82),('Aswan','04:00','Asuyt','11:00',20.0,82),('Asuyt','11:00','Cairo','16:00',35.0,82),('Asuyt','11:00','Alexandria','20:00',40.0,82)
,('Cairo','15:00','Alexandria','20:00',20.0,82);
insert into schedual(source_s,time_src,destination_s,time_dist,price,ssn_train) values ('Alexandria','21:00','Cairo','02:00',20.0,83),('Alexandria','21:00','Asuyt','06:00',90.0,83),('Alexandria','21:00','Aswan','14:00',40.0,83),('Cairo','02:00','Asuyt','06:00',35.0,83),('Cairo','02:00','Aswan','14:00',30.0,83)
,('Asuyt','06:00','Aswan','14:00',20.0,83);
insert into bank values ('1234567812345671',200.0,'11111112'),('1234567812345672',20050.0,'22222223'),('1234567812345673',100.0,'33333334'),('1234567812345674',40.0,'44444445'),('1234567812345675',150.0,'55555556');
insert into bank values ('8888877778888777',3000.0,'77777777');
insert into person values ('12345671234561','11111111','1234567812345671'),('12345671234562','22222222','1234567812345672'),('12345671234563','33333333','1234567812345673'),('12345671234564','44444444','1234567812345674'),('12345671234565','55555555','1234567812345675');
insert into admin values ('29806133200031','12345678'),('29711202602315','33343334');
select*from bank;
select *from person;
