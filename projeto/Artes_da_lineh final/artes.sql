-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 20-Nov-2020 às 18:57
-- Versão do servidor: 10.4.11-MariaDB
-- versão do PHP: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `artes`
--
CREATE DATABASE artes;
-- --------------------------------------------------------

--
-- Estrutura da tabela `desenhos`
--

CREATE TABLE `desenhos` (
  `idDesenho` int(11) NOT NULL,
  `imagemDesenho` varchar(255) NOT NULL,
  `fraseDesenho` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `desenhos`
--

INSERT INTO `desenhos` (`idDesenho`, `imagemDesenho`, `fraseDesenho`) VALUES
(1, 'alien.jpg', 'Ilustração Toy Story fanart'),
(2, 'chiclete.jpg', 'Ilustração menina chiclete'),
(3, 'cientista.jpg', 'Ilustração cientista'),
(4, 'desenhista.jpg', 'Ilustração dia mundial do desenhista'),
(5, 'dog.jpg', 'Ilustração cachorrinho'),
(6, 'emo.jpg', 'Ilustração menino anos 90'),
(7, 'espantalho.jpg', 'Ilustração espantalho'),
(8, 'fanart.jpg', 'Ilustração August fanart'),
(9, 'festa_junina.jpg', 'Ilustração menina comendo pipoca'),
(10, 'indio.jpg', 'Ilustração dia do índio'),
(11, 'mrs_potato_head.jpg', 'Ilustração Toy Story fanart'),
(12, 'natal.jpg', 'Ilustração de natal'),
(13, 'outono.jpg', 'Ilustração outono'),
(14, 'pais.jpg', 'Ilustração dia dos pais'),
(15, 'redes_sociais.jpg', 'Ilustração menina redes sociais'),
(16, 'ruiva.jpg', 'Projeto ilustra ruivas'),
(17, 'sereia.jpg', 'Ilustração menina sereia'),
(18, 'woody.jpg', 'Ilustração fã art Woody Toy Story'),
(19, 'circo.jpg', 'Ilustração dia do circo'),
(20, 'charge.jpg', 'Charge uso do celular na chuva'),
(21, 'terra.jpg', 'Ilustração dia do planeta terra');

-- --------------------------------------------------------

--
-- Estrutura da tabela `pedido`
--

CREATE TABLE `pedido` (
  `idPedido` int(11) NOT NULL,
  `nomePedido` varchar(255) NOT NULL,
  `estadoPedido` varchar(255) NOT NULL,
  `enderecoPedido` varchar(255) NOT NULL,
  `telefonePedido` varchar(255) NOT NULL,
  `dataPedidoPedido` datetime NOT NULL,
  `pedidoPedido` varchar(255) DEFAULT NULL,
  `usuarioPedido` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `produtos`
--

CREATE TABLE `produtos` (
  `idProdutos` int(11) NOT NULL,
  `imagemProdutos` varchar(255) NOT NULL,
  `imagem1Produtos` varchar(255) DEFAULT NULL,
  `imagem2Produtos` varchar(255) DEFAULT NULL,
  `imagem3Produtos` varchar(255) DEFAULT NULL,
  `imagem4Produtos` varchar(255) DEFAULT NULL,
  `imagem5Produtos` varchar(255) DEFAULT NULL,
  `nomeProdutos` varchar(255) NOT NULL,
  `precoProdutos` double(9,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `produtos`
--

INSERT INTO `produtos` (`idProdutos`, `imagemProdutos`, `imagem1Produtos`, `imagem2Produtos`, `imagem3Produtos`, `imagem4Produtos`, `imagem5Produtos`, `nomeProdutos`, `precoProdutos`) VALUES
(1, 'abelha.jpg', 'abelha1.jpg', 'abelha2.jpg', 'abelha3.jpg', 'abelha4.jpg', 'abelha5.jpg', 'chaveiro abelha', 99.99),
(2, 'bubbletea.jpg', 'bubbletea1.jpg', 'bubbletea2.jpg', 'bubbletea3.jpg', 'bubbletea4.jpg', NULL, 'chaveiro bubbletea', 99.99),
(3, 'coelho.jpg', 'coelho1.jpg', 'coelho2.jpg', 'coelho3.jpg', 'coelho5.jpg', 'coelho6.jpg', 'Amigurumi Coelho', 99.99),
(4, 'coruja.jpg', 'coruja1.jpg', 'coruja2.jpg', 'coruja3.jpg', NULL, NULL, 'chaveiro coruja', 99.99),
(5, 'dinossauro.jpg', 'dinossauro1.jpg', 'dinossauro2.jpg', 'dinossauro3.jpg', 'dinossauro4.jpg', 'dinossauro6.jpg', 'Amigurumi Dinossauro', 99.99),
(6, 'ironman.jpg', 'ironman1.jpg', 'ironman2.jpg', 'ironman3.jpg', 'ironman4.jpg', NULL, 'chaveiro iron man', 99.99),
(7, 'jake.jpg', 'jake1.jpg', 'jake2.jpg', 'jake3.jpg', 'jake4.jpg', NULL, 'chaveiro jake', 99.99),
(8, 'pessego.jpg', 'pessego1.jpg', 'pessego2.jpg', 'pessego3.jpg', 'pessego4.jpg', 'pessego5.jpg', 'chaveiro apeach', 99.99),
(9, 'pikachu.jpg', 'pikachu1.jpg', 'pikachu2.jpg', 'pikachu3.jpg', 'pikachu4.jpg', 'pikachu5.jpg', 'chaveiro pikachu', 99.99),
(10, 'pokebola.jpg', 'pokebola1.jpg', 'pokebola2.jpg', 'pokebola3.jpg', NULL, NULL, 'chaveiro pokebola', 99.99),
(11, 'pucca.jpg', 'pucca1.jpg', 'pucca2.jpg', 'pucca3.jpg', 'pucca4.jpg', NULL, 'chaveiro pucca', 99.99),
(12, 'totoro.jpg', 'totoro1.jpg', 'totoro2.jpg', 'totoro3.jpg', NULL, NULL, 'chaveiro totoro', 99.99),
(13, 'unicornio.jpg', 'unicornio1.jpg', 'unicornio2.jpg', 'unicornio3.jpg', 'unicornio4.jpg', NULL, 'Amigurumi unicornio', 99.99);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `idUsuario` int(11) NOT NULL,
  `nomeUsuario` varchar(255) NOT NULL,
  `emailUsuario` varchar(255) NOT NULL,
  `senhaUsuario` varchar(255) NOT NULL,
  `idadeUsuario` int(3) NOT NULL,
  `avatarUsuario` varchar(255) DEFAULT NULL,
  `tipoUsuario` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`idUsuario`, `nomeUsuario`, `emailUsuario`, `senhaUsuario`, `idadeUsuario`, `avatarUsuario`, `tipoUsuario`) VALUES
(1, 'adm', 'administrador@mail.com', 'B3538914AB593BD662C6DF0112823547971CCFD94AABA7EF06ED76C27E474E9E8CAFBF4C217B23FC35B6A783862694895BC111983854AE548BBD477EFCCB2F31', 17, 'https://avatars2.githubusercontent.com/u/64551315?s=460&u=fa32da66ed4dc69a6dd818f3b8120c81a22b2baf&v=4', 1);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `desenhos`
--
ALTER TABLE `desenhos`
  ADD PRIMARY KEY (`idDesenho`);

--
-- Índices para tabela `pedido`
--
ALTER TABLE `pedido`
  ADD PRIMARY KEY (`idPedido`);

--
-- Índices para tabela `produtos`
--
ALTER TABLE `produtos`
  ADD PRIMARY KEY (`idProdutos`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idUsuario`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `desenhos`
--
ALTER TABLE `desenhos`
  MODIFY `idDesenho` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de tabela `pedido`
--
ALTER TABLE `pedido`
  MODIFY `idPedido` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `produtos`
--
ALTER TABLE `produtos`
  MODIFY `idProdutos` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
