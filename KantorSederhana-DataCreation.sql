--INSERT INTO Departement VALUES ('Human Resource');
--INSERT INTO Departement VALUES ('Research');
--INSERT INTO Departement VALUES ('Marketing');
--INSERT INTO Departement VALUES ('Finance');

--INSERT INTO Division VALUES ('IT');
--INSERT INTO Division VALUES ('Engineering');
--INSERT INTO Division VALUES ('Business');
--INSERT INTO Division VALUES ('Logistic');
--INSERT INTO Division VALUES ('Trainer');

--INSERT INTO Privilege VALUES ('Basic');
--INSERT INTO Privilege VALUES ('Manager');
--INSERT INTO Privilege VALUES ('Admin');

--INSERT INTO Employee(name,username,passwd,hireDate, departementId, divisionId, managerId, salary, privilegeLevel) 
--VALUES ('SuperAdmin','admin','admin','2000-01-01',NULL,NULL,NULL,0,3);

--INSERT INTO Employee VALUES ('Annisa Andiyanti','annisa','annisa','2018-03-07',3,1,NULL,7000000,2);
--INSERT INTO Employee VALUES ('Mujahid','mujahid','mujahid','2021-12-01',3,1,2,5500000,1);
--INSERT INTO Employee VALUES ('Khorona','khorona','khorona','2021-09-25',3,1,2,6500000,1);


--INSERT INTO Employee VALUES ('Giri Atma Santana','santana','mateyize49','2020-01-01',2,1,NULL,7000000,2);
--INSERT INTO Employee VALUES ('Upin','upin','upin','2019-05-04',2,1,5,6500000,1);
--INSERT INTO Employee VALUES ('Ipin','ipin','ipin','2019-05-04',2,1,5,4580000,1);
--INSERT INTO Employee VALUES ('LogisticPersonel','logistic','logistic','2020-12-04',2,4,5,4580000,1);

--INSERT INTO Employee VALUES ('Bunda Megawati','megawatt','megawatt','1947-04-23',1,5,NULL,10000000,3);

--INSERT INTO Project VALUES ('Perbaikan Server',5,'2022-09-20','2022-10-07');
--INSERT INTO Project VALUES ('Pelatihan Bootcamp Fresh Graduate ',9,'2022-09-10','2022-10-15');
--INSERT INTO Project VALUES ('Aplikasi Finansial Bank',2,'2022-07-20','2022-09-20');


---- Departement Research Event
--INSERT INTO Timesheet VALUES (1,2,1,'Troubleshooting','2022-09-20','2022-09-30','COMPLETED');
--INSERT INTO Timesheet VALUES (1,2,4,'Pembelian Hardware Untuk Maintenance','2022-09-30','2022-10-30','COMPLETED');
--INSERT INTO Timesheet VALUES (1,2,4,'Maintenance','2022-10-30','2022-11-01','ONGOING');
--INSERT INTO Timesheet VALUES (1,2,4,'Testrun','2022-11-01','2022-11-07','ONCOMING');

------ Departement Finance
--INSERT INTO Timesheet VALUES (1,3,1,'Analisa Spesfikasi Sistem','2022-07-20','2022-07-25','COMPLETED');
--INSERT INTO Timesheet VALUES (1,3,1,'Pengumpulan Dataset dan perncangan model machine learning','2022-07-25','2022-07-30','COMPLETED');
--INSERT INTO Timesheet VALUES (1,3,1,'Pengujian','2022-07-30','2022-08-10','COMPLETED');

---- Departement HR
--INSERT INTO Timesheet VALUES (1,1,5,'Pemilihan Trainer','2022-09-10','2022-09-11','COMPLETED');
--INSERT INTO Timesheet VALUES (1,1,5,'Penentuan Standar Materi Kurikulum','2022-09-11','2022-09-14','COMPLETED');
--INSERT INTO Timesheet VALUES (1,1,5,'Pengajaran','2022-09-15','2022-10-14','ONGOING');
--INSERT INTO Timesheet VALUES (1,1,5,'Evaluasi','2022-07-30','2022-10-15','ONCOMING');

-- Annoucement Board
--INSERT INTO Announcement VALUES ('2022-09-21',2,'MEETING DIVISI IT AKAN DILAKSANAKAN HARI RABU INI !! HARAP UNTUK SEMUA PERSONIL UNTUK HADIR TEPAT WAKTU !!!')