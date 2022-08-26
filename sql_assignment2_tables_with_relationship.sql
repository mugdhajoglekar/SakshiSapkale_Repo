/******create 'product_db' databse******/
create database product_db;

/******create table categories******/
create table categories(
    id int PRIMARY key,
    title varchar(50),
    description varchar(100),
);

/******Insert recors into categories******/
insert into categories(id,title,description)
values 
(2,'mobile','All new brand mobiles are here'),
(3,'watch','Latest watches are here'),
(4,'food','Yummy food items are here')

/******create table products******/
create table products(
    id int PRIMARY key,
    title varchar(50),
    price int,
    description varchar(100),
    category int,
    company VARCHAR(20),
    FOREIGN key (category) REFERENCES categories(id)   
);

/******insert records into products******/
insert into products(id ,title ,price ,description ,category ,company)
values 
(2,'Redmi Note 10 pro',1000,'Brand new mobile with latest features',2,'Xiaomi'),
(3,'T-shirt',500,'T-shirt for womens',1,'zara'),
(4,'Smart watch 10',2000,'New watch',3,'Apple');

--TRUNCATE table categories;
--drop table categories;
--select * from categories;
--select * from products;
--update categories set title= 'clothes' where id = 1;
--select * from orders;

/******create orders table******/
create table orders(
    id int PRIMARY key,
    date DATE
);

/******Insert records into orders******/
insert into orders(id, date)
values(5, '09-09-2022' );

/******Count total no of orders******/
select count(id) as Total from orders;

/******create orderDetail table******/
create table ordersDetail(
    id int PRIMARY key,
    orderId int,
    productId int,
    quantity int,
    price int,
    totalPrice int,
    discount int,
    FOREIGN key (orderId) REFERENCES orders(id),
    FOREIGN key (productId) REFERENCES products(id)
);

/******Insert records into ordersDetail table******/
insert into ordersDetail(id, orderId,productId,quantity,price,totalPrice,discount)
VALUES
(1, 1, 1,1, 50, 45, 10),
(2, 3, 2,1, 1000, 990, 10),
(3, 2, 3, 2, 1000, 990, 10),
(4, 4, 4, 1, 2000, 1800, 10);

/******show all the four tables******/
select * from ordersDetail;
select * from categories;
select * from products;
select * from orders;

/******Add column total in orders table*****/
ALTER TABLE orders
ADD total int;

/**** set all total orders to 1***/
update orders set total =1;
