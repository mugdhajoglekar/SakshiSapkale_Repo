/******create 'student_db' database*****/
create DATABASE student_db;

/******switch to database*****/
USE student_db;

/******create table school*****/
create table school(
    id int PRIMARy KEY,
    name varchar(20),
    address varchar(50),
    principal varchar (20),
    phone int

);


/******create table student*****/

 create table student(
    id int PRIMARY KEY,
    name VARCHAR(20),
    address VARCHAR(20),
    phone int,
    email VARCHAR(20),
    age int,
    schoolId int,
    FOREIGN key(schoolId) REFERENCES student(id)
 );


/******Insert records into school table*****/

insert into school(
    id,
    name,
    address,
    principal,
    phone
)
values (
    4,
    'Dami',
    'Dont know',
    'dfg',
    45
),
 (
    5,
    'Kumar',
    'Dont know !!',
    'ijk',
    12
);


/******show student table*****/
SELECT * from student;


/******update school table*****/
update school set name='DTU' where id =2;
update school set name='VJTI' where id =4;
update school set name='COEP' where id =5;



/******insert values into students*****/
insert into student(
    id ,
    name ,
    address ,
    phone ,
    email ,
    age,
    schoolId
)
values(
    2,
    'Ajinkya',
    'dhule',
    99,
    'Ajinkya@gmail',
    22,
    2
),(
    3,
    'Adeelh',
    'sangli',
    90,
    'Adeelh@gmail',
    22,
    3
),
(
    4,
    'Dami',
    'BSL',
    91,
    'dami@gmail',
    22,
    4
),
(
    5,
    'kumar',
    'BSL',
    92,
    'kumar@gmail',
    21,
    5
);



SELECT * from student;