use [Shop]

INSERT INTO "Role" Values('Менеджер');
INSERT INTO "Role" Values('Администратор');
INSERT INTO "Role" Values('Гость');
INSERT INTO "Role" Values('Клиент');

INSERT INTO "User" Values('Никита','Червов','Евгеньевич','adm','123',2);
INSERT INTO "User" Values('Полина','Иванова','Романовна','man','123',1);

INSERT INTO PickupPoint VALUES('г.Орехово-Зуево ул.Урицкого д.63');
INSERT INTO PickupPoint VALUES('г.Орехово-Зуево ул.Володарского д.15');

INSERT INTO Product VALUES('Война и мир','/Images/vim.jpg','Перкрасная книга Льва Николаевича Толстого','ООО"Литрес"',1000,0);
INSERT INTO Product VALUES('Приключения Тома Сойера','/Images/pts.jpg','Перкрасная книга Марка Твена','ООО"Литрес"',800,0);
INSERT INTO Product VALUES('Ромео и Джульетта','/Images/rij.jpg','Перкрасная книга Уильяма Шекспира','ООО"Литрес"',850,0);