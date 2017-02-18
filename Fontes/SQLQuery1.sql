--##### CRIAÇÃO DE NÍVEIS DE ACESSO #####
SELECT * FROM GMQA.dbo.NiveisAcesso

INSERT INTO GMQA.dbo.NiveisAcesso (DescricaoNivelAcesso)
VALUES
('TOTAL'),
('SUPERVISOR'),
('GERENTE'),
('ADMINISTRADOR')

--#####   CRIAÇÃO DE USUÁRIOS    #####
SELECT * FROM GMQA.dbo.Usuarios

insert into GMQA.dbo.Usuarios (Nome, Email, Senha, IdNivelAcesso)
values
('Herbert Wagner', 'wagner.herbert@gmail.com', '4321', '1'),
('Ivan Ramos', 'ivan.rbd@gmail.com', '4321', '1'),
('Alfredo Silva', 'alfredo.silva@gmail.com', '1234', '2'),
('Rodolfo Pinto', 'pinto.rodolfo@gmail.com', '4321', '3'),
('Patrik Estrela', 'patrik.est@gmail.com', '4321', '3')

--#####   CRIAÇÃO DE PROJETOS    #####
SELECT * FROM GMQA.dbo.Projetos

INSERT INTO GMQA.dbo.Projetos (Nome, ClienteProjeto, DataInicio, DataFim, DataReal, IdUserResponsavelProjeto, IdUserAdmProjeto)
VALUES
('PROJETO TESTE', 'GOOGLE', GETDATE()-20, GETDATE()+10, GETDATE(), '1', '2'),
('PROJETO TESTE2', 'MICROSOFT', GETDATE()-10, GETDATE()+5, GETDATE(), '2', '3'),
('CRIAÇÃO DE APP', 'APPLE', GETDATE()-20, GETDATE()+20, GETDATE(), '4', '1'),
('CRIAÇÃO DE APP2', 'APPLE', GETDATE()-30, GETDATE()+50, GETDATE(), '3', '2')

--#####   CRIAÇÃO DE RISCOS    #####
INSERT INTO GMQA.dbo.Riscos (DescricaoRisco) 
VALUES
('Expirar licença'),
('Faltar funcionário')

DELETE FROM GMQA.dbo.Riscos
WHERE DescricaoRisco = 'Faltar funcionário';

select * from GMQA.dbo.Riscos