create database artes;
drop table usuario;
create table usuario(
idUsuario int auto_increment primary key,
nomeUsuario varchar(255) not null,
emailUsuario varchar(255) not null,
senhaUsuario varchar(255) not null,
idadeUsuario int(3) not null,
avatarUsuario varchar(255),
tipoUsuario int(1) not null);
insert into usuario(nomeUsuario,emailUsuario,senhaUsuario,idadeUsuario,avatarUsuario,tipoUsuario) values("adm","a@mail.com","senha",17,"https://avatars2.githubusercontent.com/u/64551315?s=460&u=fa32da66ed4dc69a6dd818f3b8120c81a22b2baf&v=4",1);

create table produtos(
idProdutos int auto_increment primary key,
imagemProdutos varchar(255) not null,
nomeProdutos varchar(255) not null,
precoProdutos double(9,2) not null);

create table desenhos(
idDesenho int auto_increment primary key,
imagemDesenho varchar(255) not null,
fraseDesenho varchar(255) not null);

create table pedido(
idPedido int auto_increment primary key,
nomePedido varchar(255) not null,
estadoPedido varchar(255) not null,
enderecoPedido varchar(255) not null,
telefonePedido varchar(255) not null,
dataPedidoPedido datetime not null,
pedidoPedido varchar(255),
usuarioPedido varchar(255));

