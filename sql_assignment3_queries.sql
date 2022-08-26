/****create task3 database****/
create database task3;

/*switch to task3 database*/
use task3;

/****create table salespeople****/
CREATE TABLE salespeople(snum int primary key, sname varchar(10), city varchar(10), comm decimal(3,2));

/****create table customers****/
CREATE TABLE customers(cnum int primary key, cname varchar(10), city varchar(10), rating int, snum int, 
FOREIGN key(snum) REFERENCES salespeople(snum));

/****create table orders****/
CREATE TABLE orders(onum int primary key, amt decimal(7,2), odate date, cnum int, snum int,
FOREIGN key(cnum) REFERENCES customers(cnum),
FOREIGN key(snum) REFERENCES salespeople(snum));

/**** Add records into salespeople table****/
INSERT INTO salespeople VALUES(1001, 'Peel', 'London', 0.12);
INSERT INTO salespeople VALUES(1002, 'Serres', 'San Jose', 0.13);
INSERT INTO salespeople VALUES(1004, 'Motika', 'London', 0.11);
INSERT INTO salespeople VALUES(1007, 'Rifkin', 'Barcelona', 0.15);
INSERT INTO salespeople VALUES(1003, 'Axelrod', 'New York', 0.10);

/**** Add records into customers table****/
INSERT INTO customers VALUES(2001, 'Hoffman', 'London', 100, 1001);
INSERT INTO customers VALUES(2002, 'Giovanni', 'Rome', 200, 1003);
INSERT INTO customers VALUES(2003, 'Liu', 'San Jose', 200, 1002);
INSERT INTO customers VALUES(2004, 'Grass', 'Berlin', 300, 1002);
INSERT INTO customers VALUES(2006, 'Clemens', 'London', 100, 1001);
INSERT INTO customers VALUES(2008, 'Cisneros', 'San Jose', 300, 1007);
INSERT INTO customers VALUES(2007, 'Pereira', 'Rome', 100, 1004);

/**** Add records into orders table****/
INSERT INTO orders VALUES(3001,18.69,'1990-10-03', 2008, 1007);
INSERT INTO orders VALUES(3003,767.19,'1990-10-03', 2001, 1001);
INSERT INTO orders VALUES(3002,1900.10,'1990-10-03', 2007, 1004);
INSERT INTO orders VALUES(3005,5160.45,'1990-10-03', 2003, 1002);
INSERT INTO orders VALUES(3006,1098.16,'1990-10-03', 2008, 1007);
INSERT INTO orders VALUES(3009,1713.23,'1990-10-04',2002, 1003);
INSERT INTO orders VALUES(3007,75.75,'1990-10-04',2004, 1002);
INSERT INTO orders VALUES(3008,4723.00,'1990-10-04',2006, 1001);
INSERT INTO orders VALUES(3010,309.95,'1990-10-04',2004, 1002);
INSERT INTO orders VALUES(3011,9891.88,'1990-10-04',2006, 1001);

/***show all tables**/
select * from salespeople;
select * from customers;
select * from orders;

/*Write a query that produces all rows from the Customers table for which the salesperson’s number
is 1001*/
select cnum, cname, city, rating, snum from customers where snum = 1001;

/*Write a select command that produces the rating followed by the name of each customer in San
Jose*/
select cname, rating, city from customers where city='San Jose';

/*Write a query that will produce the snum values of all salespeople from the Orders table (with the
duplicate values suppressed*/
select distinct(snum) from salespeople;

/*Write a query that will give you all orders for more than Rs. 1,000*/
select onum, amt from orders where amt > 1000;

/*Write a query that will give you the names and cities of all salespeople in London with a
commission above 0.10*/
select sname, city, comm from salespeople where city='London' and comm>0.10;

/*Write a query on the Customers table whose output will exclude all customers with a rating <=
100, unless they are located in Rome*/
select cnum, cname, city, rating from customers where rating > 100 or city='Rome';

/*
What will be the output from the following query? Select * from Orders
where (amt < 1000 OR
NOT (odate = ‘1990-10-03’
AND cnum > 2003));
*/
Select * from Orders
where (amt < 1000 OR
NOT (odate = '1990-10-03'
AND cnum > 2003));

/*What will be the output of the following query?
Select * from Orders
where NOT ((odate = ‘1990-10-03’ OR snum >1006) AND amt >= 1500)*/
Select * from Orders
where NOT ((odate = '1990-10-03' OR snum >1006) AND amt >= 1500)

/*Write a query that selects all orders except those with zeroes or NULLs in the amt field.*/
select * from orders where amt is not null and amt >0;
