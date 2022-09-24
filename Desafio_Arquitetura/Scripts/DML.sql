USE master;
GO

USE DesafioArquitetura;
GO

INSERT INTO TipoUsuario (Tipo)
	VALUES
		('Paciente'),
		('Medico'),
		('Administrativo'),
		('Desenvolvimento')
GO
  
INSERT INTO Acesso (Nivel)
	VALUES
		('Paciente'),
		('Funcionario_Padrao'),
		('Administrador'),
		('Desenvolvedor')
GO
INSERT INTO Especialidade (Categoria)
	VALUES
		('Clínica(o) Geral'),
		('Cardiologista'),
		('Ortopedista'),
		('Neurologista'),
		('Otorrinolaringologista'),
		('Gastroenterologia'),
		('Endocrinologista')
GO



INSERT INTO Usuario(Nome, Email, IdTipoUsuario, Senha, IdAcesso) /* Usuários e seus dados de cadastro*/
	VALUES	
		-- Pacientes
		('Homer Simpson', 'homer@simpsons.com', 1, '$2b$10$33M.McKd5EUTM8aXp1PusOAhUJqO6qEbdEMJ5RzrUmq1ozpgms0.G', 1), -- homer123456
		('Bart Simpson', 'bart@simpsons.com', 1, '$2b$10$gDDxS76a7tyk8bHOHFBsg.J9IGyeF0RK.K6YuFr2b/7Unki1t8kVG', 1), -- bart123456
		('Maggie Simpson', 'maggie@simpsons.com', 1, '$2b$10$QN28rU4YpNeREDtSU5.CZORJhd5yHJKRFD971C2vR1TA5KehJhTCK', 1), -- maggie123456
		('Ned Flanders', 'ned@simpsons.com', 1, '$2b$10$eVrlmiQyxGcMqOGadwcgbOHmJVBkhmO8BFmobP85LgsfNxP5mYNWK', 1), -- ned123456
		('Otto Man', 'otto@simpsons.com',	1, '$2b$10$TTfthEyeccTRJ00dmDICKuXUbDhX0fAGDxKDzcKs/r0yPMlJ5o1cS', 1),  -- otto123456
		('Lenny Leonard', 'lenny@simpsons.com',	1, '$2b$10$UCiVBeSGv1avWcsw0.rXs.G.bPC9aQPdLP0qou60l6ouXBqOe8thO', 1), -- lenny123456
		('Barney Gumble', 'barney@simpsons.com',	1, '$2b$10$MtbxwqdCVjvZyAbubtX33e.E5zZmyZILFccdu63VwV4xo5YeoLAwm', 1), -- barney123456
		('Moe Szyslak', 'moe@simpsons.com',	1, '$2b$10$IWqO5417KrH90Yc1SmPvxOZxd/jNY2B7/oBiTTdImKe/cM5VqvMF.', 1), -- moe123456
		('Montgomery Burns', 'burns@simpsons.com', 1, '$2b$10$y6eO7W1bm5Vt6RP93mFqeeSHib3VonN9EWR.9yR/r4DaNjJ.9J2Oy', 1), -- burns123456
		

		-- 10
		-- Médicos
		('Abe Simpson', 'vovo@simpsons.com', 2, '$2b$10$t51K7pt7MDfFGilGIv0iYegovcztSP3T5cnh7xA2jcTnyq0gJ0kaa', 2), -- vovo123456
		('Apu Nahasapeemapetilon', 'apu@simpsons.com', 2, '$2b$10$iqD2KicGUk32RvGzIu3GKuHHygYwwIY9Wtr9IMTFQBwft02qSD/aG', 2), -- apu123456
		('Waylor Smithers', 'smithers@simpsons.com', 2, '$2b$10$YQZadXEdPd2dzE5zZh3omeHQtrTzB1iSmIriIVmsKscvK6QgwvOnW', 2), -- smithers123456
		('Chefe Wiggum', 'wiggum@simpsons.com', 2, '$2b$10$eMNwRrmY68U/19brOlx3Rub713z4kaMqxAq4bjZL/AV2Ktmp6u5cS', 2), -- wiggum123456
		('Krusty o plalhaço', 'krusty@simpsons.com', 2, '$2b$10$RMpBq4B34Oz49zDNNJqkNuR.e82ke0RsOAOO8JUST0LoGdNBHHV4m', 2), -- krusty12346
		('Sideshow Bob', 'bob@simpsons.com', 2, '$2b$10$e/OXXyeyY9qJ2zcJoQddOuCTbAb20KFRM8H8agohFcOr4q7x4gAPe', 2), -- bob123456
		('Diretor Seymour Skinner', 'skinner@simpsons.com',	2, '$2b$10$4ElHt0decGUecUE4OD/FweVTT3liZgxSLEgQESGtDsmMLIjaNqyNW', 2), -- skinner123456
		
		
		-- Administrativos
		('Marge Simpson', 'marge@simpsons.com', 3, '$2b$10$KHhK9HK2glC0buVs96yEquXfQtnQ7EB3uxsXJ8KKqrRV2CPhywfku', 3), -- marge123456
		
		-- Desenvolvimento
		('Lisa Simpson', 'lisa@simpsons.com', 4, '$2b$10$j1bTqAqKaZ/okhXcA4Nzs.9JkODv9ywOlv0T22xtKorsmgkrTmFCq', 4) -- lisa123456
		
GO

INSERT INTO Medico (CRM, IdEspecialidade, IdUsuario)
	VALUES
		('123456789', 1, 10),
		('987654321', 2, 11),
		('456123789', 3, 12),
		('159753648', 4, 13),
		('456789951', 5, 14),
		('159456753', 6, 15),
		('652145785', 7, 16)

GO

INSERT INTO Paciente (Carteirinha, DataNascimento, Ativo, IdUsuario)
	VALUES
		('741852963', '1964-07-12',1, 1),
		('369258147', '2011-08-10',1, 2),
		('258741369', '2021-09-17',1, 3),
		('982145639', '1965-04-15',1, 4),
		('789512356', '1995-05-14',1, 5),
		('456132052', '1965-07-25',1, 6),
		('789437934', '1960-06-07',1, 7),
		('125423658', '1965-04-09',1, 8),
		('951032698', '1900-03-12',1, 9)
GO

INSERT INTO Consulta (IdMedico, IdPaciente, DataHora)
	VALUES
		(1, 1, '2022-10-01'),
		(2, 2, '2022-10-02'),
		(3, 3, '2022-10-03'),
		(4, 2, '2022-10-04'),
		(5, 3, '2022-10-05'),
		(6, 4, '2022-10-06'),
		(7, 5, '2022-10-07'),

		(1, 6, '2022-10-10'),
		(2, 7, '2022-10-11'),
		(3, 7, '2022-10-12'),
		(4, 6, '2022-10-13'),
		(5, 8, '2022-10-14'),
		(6, 9, '2022-10-15'),
		(6, 9, '2022-10-16'),
		(6, 8, '2022-10-17')
GO