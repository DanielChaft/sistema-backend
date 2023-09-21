-- Criar o Banco de Dados
CREATE DATABASE programacao_do_zero;

-- Utilizar o Banco de Dados 
USE programacao_do_zero;

-- Criar tabelas
CREATE TABLE usuario (
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	genero VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	PRIMARY KEY (id)
);
CREATE TABLE endereco (
	id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(250) NOT NULL,
    numero VARCHAR(30) NOT NULL,
    bairro VARCHAR(150) NOT NULL,
    cidade VARCHAR(200) NOT NULL,
    complemento VARCHAR(100) NOT NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    PRIMARY KEY (id)
);
-- Relacionar as tabelas usuario e endereco
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

-- Adicionar chave estrangeira
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- Inserir dados de usuário
INSERT INTO usuario (nome, sobrenome, telefone, email, genero, senha) VALUES ('Daniel', 'Breitschaft', '11-98256-8477', 'daniel@gmail.com', 'Masculino', '1234')

-- Selecionar todos usuários
SELECT * FROM usuario;

-- Selecionar usuário específico pela coluna especificada
SELECT * FROM usuario WHERE nome = 'Daniel';

-- Alterar usuário no banco
UPDATE usuario SET telefone = '11-98256-4444' WHERE id = 1;

-- Deletar usuário
DELETE FROM usuario WHERE id = 2;


