
    drop table if exists Tag

    drop table if exists ProductTag

    drop table if exists Product

    create table Tag (
        Id  integer,
       Name TEXT,
       primary key (Id)
    )

    create table ProductTag (
        TagId INTEGER not null,
       ProductId INTEGER not null
    )

    create table Product (
        Id  integer,
       Title TEXT,
       primary key (Id)
    )
